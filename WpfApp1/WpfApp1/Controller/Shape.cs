namespace WpfApp1.Controller
{
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString() => $"Width: {Width}, Height: {Height}";
    }
}
