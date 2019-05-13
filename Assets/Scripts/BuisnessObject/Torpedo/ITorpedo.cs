public interface ITorpedo
{
    ISubmarine Source { get; }
    IPositioned Target { get; }
}