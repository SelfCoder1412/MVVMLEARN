using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    [DataObject]
    public class Sale
    {
        public Sale()
        {
            SaleDate = DateTime.Now;
        }

        public MySortableBindingList<SaleDetail> SaleDetails { get; set; }

        public string Salesman { get; set; }

        public string Client { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal TotalAmount
        {
            get
            {
                Debug.Assert(SaleDetails != null);
                return SaleDetails.Sum(a => a.TotalAmount);
            }
        }
    }

    [DataObject]
    public class SaleDetail
    {
        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
