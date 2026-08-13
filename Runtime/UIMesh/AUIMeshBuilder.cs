using UnityEngine;
using UnityEngine.UI;

namespace QuadUI
{
    public abstract class AUIMeshBuilder
    {
        public abstract void GetMesh(UIMeshGraphic graphic, VertexHelper vh);

        protected void addQuad(VertexHelper vh, Rect rect, Color color)
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
