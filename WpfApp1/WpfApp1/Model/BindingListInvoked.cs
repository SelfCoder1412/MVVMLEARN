using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class MyBindingList<myInt> : BindingList<myInt>
    {
        protected override void RemoveItem(int itemIndex)
        {
            //itemIndex = index of item which is going to be removed
            //get item from binding list at itemIndex position
            myInt deletedItem = this.Items[itemIndex];

            if (BeforeRemove != null)
            {
                //raise event containing item which is going to be removed
                BeforeRemove(deletedItem);
            }

            //remove item from list
            base.RemoveItem(itemIndex);
        }

        protected override void SetItem(int index, myInt item)
        {
            //here we still have old value at index
            myInt oldMyInt = this.Items[index];
            //new value
            myInt newMyInt = item;

            if (myIntOldNew != null)
            {
                //raise event
                myIntOldNew(oldMyInt, newMyInt);
            }

            //update item at index position
            base.SetItem(index, item);
        }

        public delegate void myIntDelegate(myInt deletedItem);
        public event myIntDelegate BeforeRemove;
        public delegate void myIntDelegateChanged(myInt oldItem, myInt newItem);
        public event myIntDelegateChanged myIntOldNew;
    }
    public class BindingListInvoked<T> : BindingList<T>
    {
        public BindingListInvoked() { }

        private ISynchronizeInvoke _invoke;
        public BindingListInvoked(ISynchronizeInvoke invoke) { _invoke = invoke; }
        public BindingListInvoked(IList<T> items) { this.DataSource = items; }
        delegate void ListChangedDelegate(ListChangedEventArgs e);

        protected override void OnListChanged(ListChangedEventArgs e)
        {

            if ((_invoke != null) && (_invoke.InvokeRequired))
            {
                var ar = _invoke.Invoke(new ListChangedDelegate(base.OnListChanged), new object[] { e });
            }
            else
            {
                base.OnListChanged(e);
            }
        }
        public IList<T> DataSource
        {
            get
            {
                return this;
            }
            set
            {
                if (value != null)
                {
                    this.ClearItems();
                    RaiseListChangedEvents = false;

                    foreach (T item in value)
                    {
                        this.Add(item);
                    }
                    RaiseListChangedEvents = true;
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
            }
        }
    }
}
