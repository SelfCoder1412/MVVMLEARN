using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApp1.Model;

namespace WpfApp1.View
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var sales = new[] {
                new Sale(){
                    Client = "Jahmani Mwaura",
                    SaleDate = new DateTime(2008,1,1),
                    Salesman = "Gachie",
                    SaleDetails = new MySortableBindingList<SaleDetail>(){
                        new SaleDetail(){
                            Product = "Sportsman",
                            Quantity = 1,
                            UnitPrice = 80
                        },
                         new SaleDetail(){
                            Product = "Tusker Malt",
                            Quantity = 2,
                            UnitPrice = 100
                        },
                        new SaleDetail(){
                            Product = "Alvaro",
                            Quantity = 1,
                            UnitPrice = 50
                        }
                    }
                },
                new Sale(){
                    Client = "Ben Kones",
                    SaleDate = new DateTime(2008,1,1),
                    Salesman = "Danny",
                    SaleDetails = new MySortableBindingList<SaleDetail>(){
                        new SaleDetail(){
                            Product = "Embassy Kings",
                            Quantity = 1,
                            UnitPrice = 80
                        },
                         new SaleDetail(){
                            Product = "Tusker",
                            Quantity = 5,
                            UnitPrice = 100
                        },
                        new SaleDetail(){
                            Product = "Novida",
                            Quantity = 3,
                            UnitPrice = 50
                        }
                    }
                },
                new Sale(){
                    Client = "Tim Kim",
                    SaleDate = new DateTime(2008,1,1),
                    Salesman = "Kiplagat",
                    SaleDetails = new MySortableBindingList<SaleDetail>(){
                        new SaleDetail(){
                            Product = "Citizen Special",
                            Quantity = 10,
                            UnitPrice = 30
                        },
                        new SaleDetail(){
                            Product = "Burn",
                            Quantity = 2,
                            UnitPrice = 100
                        }
                    }
                }
            };

            saleBindingSource.DataSource = new MySortableBindingList<Sale>(sales);
        }
    }
}
