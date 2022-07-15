using GalaSoft.MvvmLight.Command;
using System.IO;
using System.IO.Compression;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;

namespace SchematicJsonConvertor.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Prop
        private bool isBusy;
        public bool IsBusy { get => isBusy; set => Set(ref isBusy, value); }
        private string _browsePath;
        public string BrowsePath
        {
            get => _browsePath;
            set
            {
                Set(ref _browsePath, value);
                convertCommand.RaiseCanExecuteChanged();
            }
        }
        private RelayCommand browsePathCommand;
        public ICommand BrowsePathCommand
        {
            get
            {
                return browsePathCommand;
            }
        }
        private RelayCommand convertCommand;
        public ICommand ConvertCommand
        {
            get
            {
                return convertCommand;
            }
        }

        private IEnumerable<FileInfo> files = null;
        protected delegate void OnUiThreadDelegate();
        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            convertCommand = new RelayCommand(ConvertExecute, CanConvertExecute);
            browsePathCommand = new RelayCommand(BrowsePathExecute);
        }
        protected void OnUiThread(OnUiThreadDelegate onUiThreadDelegate)
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                onUiThreadDelegate();
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(onUiThreadDelegate);
            }
        }
        private bool Unzip(string fileFullName, string convFolder)
        {
            string fileName = Path.Combine(convFolder, Path.GetFileName(fileFullName));
            var decompressedData = Decompress(File.ReadAllBytes(fileFullName));
            if (decompressedData != null)
            {
                string jsonString = System.Text.Encoding.UTF8.GetString(decompressedData, 0, decompressedData.Length);
                if (File.Exists(fileName))
                    fileName = Path.Combine(convFolder, Path.GetFileName(fileFullName),
                        Guid.NewGuid().ToString().Substring(0, 7));
                //
                dynamic parsedJson = JsonConvert.DeserializeObject(jsonString);
                File.WriteAllText(fileName, JsonConvert.SerializeObject(parsedJson, Formatting.Indented)); ;
                return true;
            }

            return false;
        }
        static byte[] Decompress(byte[] gzip)
        {
            try
            {
                using (var stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
                {
                    const int size = 4096;
                    byte[] buffer = new byte[size];
                    using (MemoryStream memory = new MemoryStream())
                    {
                        int count = 0;
                        do
                        {
                            count = stream.Read(buffer, 0, size);
                            if (count > 0)
                            {
                                memory.Write(buffer, 0, count);
                            }
                        }
                        while (count > 0);
                        return memory.ToArray();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private void BrowsePathExecute()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                    BrowsePath = dialog.SelectedPath;
            }
        }

        private void ConvertExecute()
        {
            IsBusy = true;
            string convertFolder = Path.Combine(BrowsePath, "Conv" + DateTime.Now.ToString("ddMMyyhhmmss"));
            Directory.CreateDirectory(convertFolder);
            Task.Factory.StartNew(() =>
            {
                int index = 0;
                foreach (FileInfo VARIABLE in files)
                {
                    if (Unzip(VARIABLE.FullName, convertFolder))
                        index++;
                }

                if (index > 0)
                {
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage($"Converted {index} json file/files to folder {convertFolder}"));
                }
                else
                {
                    Directory.Delete(convertFolder);
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage($"No Json Converted"));
                }
                this.OnUiThread(() =>
                {
                    this.IsBusy = false; 
                });
            });
            //.ContinueWith(t => IsBusy = false,
            //    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private bool CanConvertExecute()
        {
            if (BrowsePath == null)
                return false;
            DirectoryInfo dir = new DirectoryInfo(BrowsePath);
            if (!dir.Exists)
                return false;

            files = dir.EnumerateFiles("*.json", SearchOption.AllDirectories);
            if (files == null || files.Count() < 1)
            {
                return false;
            }

            return true;
        }
    }
}