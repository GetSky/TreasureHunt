using UnityEngine;

namespace Features.Sector
{
    public class SectorView : MonoBehaviour
    {
        private bool _isTreasure;

        public void SetTreasure(bool isTreasure)
        {
            _isTreasure = isTreasure;  
        }

        public string UniqueCode()
        {
            return transform + gameObject.name;
        }

        private void Start()
        {
            GetComponent<MeshRenderer>().material.color = _isTreasure ? Color.yellow : Color.gray;
        }
    }
}