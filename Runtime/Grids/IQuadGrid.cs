namespace QuadUI
{
    public interface IQuadGrid
    {
        int Width { get; }
        int Height { get; }

        bool this[int x, int y] { get; set; }
    }
}