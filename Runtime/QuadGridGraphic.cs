using UnityEngine;
using UnityEngine.UI;

namespace QuadUI
{
    public class QuadGridGraphic : MaskableGraphic
    {
        [SerializeField]
        private Color backgroundColor = Color.clear;

        [SerializeField]
        [Range(0, 1)]
        private float borderSize = 0.5f;

        private IQuadGrid grid;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            Rect outer = GetPixelAdjustedRect();
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
                            this.addQuad(vh, cell, this.color);
                        }
                    }
                }
            }
        }

        public void SetGrid(IQuadGrid grid)
        {
            if (this.grid == grid)
            {
                return;
            }

            this.grid = grid;
            this.SetVerticesDirty();
        }

        public void SetColor(Color color)
        {
            this.color = color;
            this.SetVerticesDirty();
        }

        public void SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
            this.SetVerticesDirty();
        }

        private Rect getCellRect(Rect inner, int x, int y, float cellWidth, float cellHeight)
        {
            return new Rect(inner.xMin + x * cellWidth, inner.yMax - (y + 1) * cellHeight, cellWidth, cellHeight);
        }
        private void addQuad(VertexHelper vh, Rect rect, Color color)
        {
            int i = vh.currentVertCount;

            vh.AddVert(new Vector3(rect.xMin, rect.yMin), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax, rect.yMin), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax, rect.yMax), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMin, rect.yMax), color, Vector2.zero);

            vh.AddTriangle(i, i + 1, i + 2);
            vh.AddTriangle(i + 2, i + 3, i);
        }
    }
}
