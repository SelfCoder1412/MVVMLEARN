using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApp1.Model;

namespace WpfApp1.View
{
    public partial class Form1 : Form
    {
        MyBindingList<myInt> bindingList;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingList = new MyBindingList<myInt>();
            bindingList.Add(new myInt(8));
            bindingList.Add(new myInt(9));
            bindingList.Add(new myInt(11));
            bindingList.Add(new myInt(12));
            

            dataGridView1.DataSource = bindingList;
            bindingList.BeforeRemove += bindingList_BeforeRemove;
            bindingList.myIntOldNew += bindingList_myIntOldNew;

            //dataGridView1.DataSource = names;
            //new Thread(() => names.Add(new Name() { FirstName = "Larry", LastName = "Lan" })).Start();
            //new Thread(() => names.Add(new Name() { FirstName = "Jessie", LastName = "Feng" })).Start();
        }
        void bindingList_BeforeRemove(myInt deletedItem)
        {
            MessageBox.Show("You've just deleted item with value " + deletedItem.myIntProp.ToString());
        }

        void bindingList_myIntOldNew(myInt oldItem, myInt newItem)
        {
            MessageBox.Show("You've just CHANGED item with value " + oldItem.myIntProp.ToString() + " to " + newItem.myIntProp.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingList.Add(new myInt(13));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingList.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingList[dataGridView1.SelectedCells[0].RowIndex] = new myInt(new Random().Next());
        }
    }
}
