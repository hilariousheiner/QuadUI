using UnityEngine;

namespace QuadUI
{
    public class QuadGridExample : MonoBehaviour
    {
        [SerializeField]
        private QuadGridGraphic quadGrid;

        private void Start()
        {
            this.quadGrid.SetGrid(QuadGridIcons.TheLetterQ);
        }
    }
}