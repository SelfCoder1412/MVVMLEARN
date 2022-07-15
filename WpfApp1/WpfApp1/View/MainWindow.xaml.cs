using System;
using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private readonly System.Windows.Threading.DispatcherTimer _timer
            = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Controller.MainViewModel();
            //_timer.Interval = TimeSpan.FromSeconds(0.2); //wait for the other click for 200ms
            //_timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Single Click!");
        }

        private void Label_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Double Click!");
        }

        private void Label_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //MessageBox.Show("Single Click!");
            Form2 bf = new Form2();
            bf.Show();
        }

        private void click_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
