using UnityEngine;

namespace QuadUI
{
    public class QuadGridExample : MonoBehaviour
    {
        [SerializeField]
        private UIMeshGraphic targetGraphic;

        private AUIMeshBuilder meshBuilder;

        private void Start()
        {
            this.meshBuilder = new QuadGridMeshBuilder(QuadGridIcons.TheLetterQ, Color.black, Color.white, 0.5f);
            if (this.targetGraphic != null)
            {
                this.targetGraphic.SetMeshBuilder(this.meshBuilder);
            }
        }
    }
}