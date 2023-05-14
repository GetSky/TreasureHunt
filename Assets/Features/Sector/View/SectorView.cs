using Features.Sector.Adapters;
using UnityEngine;
using Zenject;

namespace Features.Sector.View
{
    public class SectorView : MonoBehaviour
    {
        private SectorPresenter _presenter;

        [Inject]
        public void Construct(SectorPresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnChangedHighlight += Highlight;
        }

        private void Highlight(bool isHighlight)
        {
            Debug.Log(gameObject.name + ": " + isHighlight);
        }
    }
}