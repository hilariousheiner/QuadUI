using UnityEngine;

namespace QuadUI
{
    public class QuadFrameExample : MonoBehaviour
    {
        [SerializeField]
        private UIMeshGraphic targetGraphic;

        private AUIMeshBuilder meshBuilder;

        [SerializeField]
        private Color color = Color.white;

        [SerializeField]
        private float thickness = 10;


        private void Start()
        {
            this.meshBuilder = new QuadFrameMeshBuilder(this.color, this.thickness);
            if (this.targetGraphic != null)
            {
                this.targetGraphic.SetMeshBuilder(this.meshBuilder);
            }
        }
    }
}

