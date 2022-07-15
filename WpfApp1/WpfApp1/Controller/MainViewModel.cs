using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WpfApp1.Common;
using WpfApp1.Infra;

namespace WpfApp1.Controller
{
    internal class MainViewModel
    {
        //public ObservableCollection<Details> CatalogSearchResults { get; private set; }
        internal MainViewModel()
        {
            
            //AsyncDemo asn = new AsyncDemo();
            //asn.asyncStart();
            //SectionClass1 sc = new SectionClass1();
            //SectionClass1.SwitchBoard switchBoard = new SectionClass1.SwitchBoard();
            //sc.Checker(null);
        }


        private void FuncDelegates()
        {
            Func<int, int, int> val = mymethod;
            int j = val(10, 100);
        }

        public static int mymethod(int s, int d)
        {
            return s * d ;
        }

        private void MyRectangle()
        {
            Task tp = new Task(MyRectangle);
            //tp.Start();
            TCPChecker.Start();
            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            IIndex<Shape> shapes = rectangles;

            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine(shapes[i]);
                
            }
        }
    }
}
