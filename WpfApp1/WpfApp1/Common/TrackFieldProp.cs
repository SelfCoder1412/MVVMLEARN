using System;

namespace WpfApp1.Common
{
    internal class TrackFieldProp
    {
        //Fields to be monitored
        private int myValue;

        //Property settings, the event trigger function is called here
        public int MyValue
        {
            get { return myValue; }
            set
            {
                //If the variable changes, call the event trigger function
                if (value != myValue)
                {
                    myValue = value;
                    OnMyValueChanged?.Invoke(this, null);
                }
            }
        }
        //Events associated with the delegate
        public event MyValueChanged OnMyValueChanged;
    }
    //Defined delegate
    public delegate void MyValueChanged(object sender, EventArgs e);
   
}
