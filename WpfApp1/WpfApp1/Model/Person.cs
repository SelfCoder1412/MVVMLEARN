using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class myInt : INotifyPropertyChanged
    {
        public myInt(int myIntVal)
        {
            myIntProp = myIntVal;
        }
        private int iMyInt;
        public int myIntProp
        {
            get
            {
                return iMyInt;
            }
            set
            {
                iMyInt = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(myIntProp)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
