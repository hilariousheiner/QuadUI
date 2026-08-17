using UnityEngine;

namespace QuadUI
{
    public class IdenticonExample : MonoBehaviour
    {
        [SerializeField]
        private string identiconName;

        [SerializeField]
        private UIMeshGraphic targetGraphic;

        private AUIMeshBuilder meshBuilder;

        private void Start()
        {
            Identicon identicon = new Identicon(this.identiconName);
            this.meshBuilder = new QuadGridMeshBuilder(identicon, Color.black, Color.white, 0.5f);

            if (this.targetGraphic != null)
            {
                this.targetGraphic.SetMeshBuilder(this.meshBuilder);
            }
        }
    }
}