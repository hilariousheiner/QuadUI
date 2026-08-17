namespace QuadUI
{
    public class QuadGrid : IQuadGrid
    {
        private int width;
        public int Width => this.width;

        private int height;
        public int Height => this.height;

        private int[] cells;

        public QuadGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.cells = new int[width * height];
        }

        public QuadGrid(int width, int height, int[] cells)
        {
            this.width = width;
            this.height = height;

            this.cells = cells;
        }

        public bool this[int x, int y]
        {
            get => (this.cells[y * this.width + x] != 0);
            set => this.cells[y * this.width + x] = value ? 1 : 0;
        }
    }
}