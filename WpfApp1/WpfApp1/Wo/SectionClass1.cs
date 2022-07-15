using System.ComponentModel;

namespace WpfApp1.Wo
{
    class SectionClass1
    {
        public class SwitchBoard
        {
            public int ElementID { get; set; }
        }
        public BindingList<long> Incomers { get; set; }

        public SectionClass1()
        {
            Incomers = new BindingList<long>();
            Incomers.Add(1);
            Incomers.Add(2);
        }

        internal void Checker(SwitchBoard switchBoard)
        {
            //var checker = Incomers.Contains(switchBoard.ElementID);
        }
    }
}
