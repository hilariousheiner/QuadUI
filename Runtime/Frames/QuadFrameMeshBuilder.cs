using UnityEngine;
using UnityEngine.UI;

namespace QuadUI
{
    public class QuadFrameMeshBuilder : AUIMeshBuilder
    {
        private Color color;
        private float thickness;
        public QuadFrameMeshBuilder(Color color, float thickness)
        {
            this.color = color;
            this.thickness = thickness;
        }

        public override void GetMesh(UIMeshGraphic graphic, VertexHelper vh)
        {
            Rect outer = graphic.GetPixelAdjustedRect();

            this.addQuadFrame(vh, outer, this.color, this.thickness);
        }

        private void addQuadFrame(VertexHelper vh, Rect rect, Color color, float thickness)
        {
            vh.Clear();
            int i = vh.currentVertCount;

            vh.AddVert(new Vector3(rect.xMin, rect.yMin), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax, rect.yMin), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax - thickness, rect.yMin + thickness), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMin + thickness, rect.yMin + thickness), color, Vector2.zero);

            vh.AddTriangle(i, i + 1, i + 2);
            vh.AddTriangle(i + 2, i + 3, i);

            i = vh.currentVertCount;

            vh.AddVert(new Vector3(rect.xMin, rect.yMax), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax, rect.yMax), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax - thickness, rect.yMax - thickness), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMin + thickness, rect.yMax - thickness), color, Vector2.zero);

            vh.AddTriangle(i, i + 1, i + 2);
            vh.AddTriangle(i + 2, i + 3, i);

            i = vh.currentVertCount;

            vh.AddVert(new Vector3(rect.xMin, rect.yMin), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMin + thickness, rect.yMin + thickness), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMin + thickness, rect.yMax - thickness), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMin, rect.yMax), color, Vector2.zero);

            vh.AddTriangle(i, i + 1, i + 2);
            vh.AddTriangle(i + 2, i + 3, i);

            i = vh.currentVertCount;

            vh.AddVert(new Vector3(rect.xMax, rect.yMin), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax - thickness, rect.yMin + thickness), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax - thickness, rect.yMax - thickness), color, Vector2.zero);
            vh.AddVert(new Vector3(rect.xMax, rect.yMax), color, Vector2.zero);

            vh.AddTriangle(i, i + 1, i + 2);
            vh.AddTriangle(i + 2, i + 3, i);
        }
    }
}