using UnityEngine.UI;

namespace QuadUI
{
    public class UIMeshGraphic : MaskableGraphic
    {
        private AUIMeshBuilder meshBuilder;
        
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            if (this.meshBuilder != null)
            {
                this.meshBuilder.GetMesh(this, vh);
            }
        }

        public void SetMeshBuilder(AUIMeshBuilder meshBuilder)
        {
            this.meshBuilder = meshBuilder;
            this.SetVerticesDirty();
        }
    }
}
