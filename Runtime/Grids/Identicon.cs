namespace QuadUI
{
    public class Identicon : IQuadGrid
    {
        private const int gridSize = 7;
        public int Width => Identicon.gridSize;
        public int Height => Identicon.gridSize;
        
        private QuadGrid quadGrid;

        public Identicon(string text)
           : this(HashUtility.Hash(text))
        { }

        public Identicon(ulong hash)
        {
            this.generate(hash);
        }

        public bool this[int x, int y]
        {
            get => this.quadGrid[x, y];
            set => this.quadGrid[x, y] = value;
        }

        private void generate(ulong hash)
        {
            this.quadGrid = new QuadGrid(Identicon.gridSize, Identicon.gridSize);

            BitReader bits = new(hash);

            int columns = (Identicon.gridSize + 1) / 2;

            for (int y = 0; y < Identicon.gridSize; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    bool filled = bits.Next();

                    this.quadGrid[x, y] = filled;
                    this.quadGrid[Identicon.gridSize - 1 - x, y] = filled;
                }
            }
        }
    }
}