using UnityEngine;
using UnityEngine.UI;

namespace QuadUI
{
    public class QuadGridMeshBuilder : AUIMeshBuilder
    {
        private Color backgroundColor = Color.clear;
        private Color foregroundColor = Color.clear;

        private float borderSize = 0.5f;

        private IQuadGrid grid;

        public QuadGridMeshBuilder(IQuadGrid grid, Color backgroundColor, Color foregroundColor, float borderSize)
        {
            this.grid = grid;
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
            this.borderSize = borderSize;
        }

        public override void GetMesh(UIMeshGraphic graphic, VertexHelper vh)
        {
            vh.Clear();

            Rect outer = graphic.GetPixelAdjustedRect();
            this.addQuad(vh, outer, this.backgroundColor);

            if (this.grid != null)
            {
                float cellWidth = outer.width / ((float)grid.Width + 2f * this.borderSize);
                float cellHeight = outer.height / ((float)grid.Height + 2f * this.borderSize);

                Rect inner = new Rect(outer.xMin + this.borderSize * cellWidth, outer.yMin + this.borderSize * cellHeight, cellWidth * grid.Width, cellHeight * grid.Height);

                for (int y = 0; y < grid.Height; y++)
                {
                    for (int x = 0; x < grid.Width; x++)
                    {
                        Rect cell = this.getCellRect(inner, x, y, cellWidth, cellHeight);
                        if (this.grid[x, y])
                        {
                            this.addQuad(vh, cell, this.foregroundColor);
                        }
                    }
                }
            }
        }

        private Rect getCellRect(Rect inner, int x, int y, float cellWidth, float cellHeight)
        {
            return new Rect(inner.xMin + x * cellWidth, inner.yMax - (y + 1) * cellHeight, cellWidth, cellHeight);
        }
    }
}