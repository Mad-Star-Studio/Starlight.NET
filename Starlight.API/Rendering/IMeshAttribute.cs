namespace Starlight.API.Rendering;

public interface IMeshAttribute
{
    public string Name { get; }
    public int Size { get; }
    public int Offset { get; }
    public int Index { get; }
    public bool Normalized { get; }
    public int Divisor { get; }
    public int Stride { get; }
}