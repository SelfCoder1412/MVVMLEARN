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
    public partial class BindingListChangedForm : Form
    {
        BindingList<Person> people = new BindingList<Person>();
        Action<Person> personAdder;
        public BindingListChangedForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = true;
            this.bindingSource1.DataSource = this.people;
            this.personAdder = this.PersonAdder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(this.GotANewPersononBackgroundThread);
            t.Start();
        }

        // runs on the background thread.
        private void GotANewPersononBackgroundThread()
        {
            Person person = new Person { Id = 1, Name = "Foo" };

            //Invokes the delegate on the UI thread.
            this.Invoke(this.personAdder, person);
        }

        //Called on the UI thread.
        void PersonAdder(Person person)
        {
            this.people.Add(person);
        }
    }
}
