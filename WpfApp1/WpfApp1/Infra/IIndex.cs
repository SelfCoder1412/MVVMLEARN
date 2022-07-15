namespace WpfApp1.Infra
{
    public interface IIndex<out T>
    {
         T this[int index] { get; }
        int Count { get; }
    }
}
