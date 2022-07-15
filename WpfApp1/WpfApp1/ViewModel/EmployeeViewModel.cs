using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> employees;
        private Employee selectedEmployee;

        public EmployeeViewModel()
        {
            LoadEmployeesCommand = new RelayCommand(LoadEmployeesMethod,LoadEmployessCanExecute);
            SaveEmployeesCommand = new RelayCommand(SaveEmployeesMethod);
            
            LoadedCommand = new RelayCommand<RoutedEventArgs>(e =>
            {
                LoadEmplyeesMethodCanExecute(true);
            });
        }

        public void LoadData()
        {
            // Make a call to the repository class here
            // to set properties of your view model
        }


        private void LoadEmplyeesMethodCanExecute(bool value = false)
        {
            _canLoad = value;
            ((RelayCommand)LoadEmployeesCommand).RaiseCanExecuteChanged();
        }

        private bool LoadEmployessCanExecute()
        {
            return _canLoad;
        }

        private bool _canLoad;
        public ICommand LoadedCommand { get; private set; }
        public ICommand LoadEmployeesCommand { get; private set; }
        public ICommand SaveEmployeesCommand { get; private set; }

        public ObservableCollection<Employee> EmployeeList
        {
            get
            {
                return employees;
            }
        }

        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        public void SaveEmployeesMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved."));
        }

        private void LoadEmployeesMethod()
        {
            var vm1 = (new ViewModelLocator()).EmployeeViewModel;
            var vm = (App.Current.Resources["Locator"] as ViewModelLocator).EmployeeViewModel;
            employees = Employee.GetSampleEmployees();
            this.RaisePropertyChanged(() => this.EmployeeList);
            LoadEmplyeesMethodCanExecute();
            //Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Loaded."));
        }
    }
}
