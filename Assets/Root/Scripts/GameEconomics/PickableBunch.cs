using UnityEngine;
using System.Collections.Generic;

namespace GameEconomics
{
    public sealed class PickableBunch : MonoBehaviour
    {

        public IReadOnlyCollection<PickableObject> Pickables
        {
            
            get => _pickables; 
        }

        [SerializeField] private List<PickableObject> _pickables;



        private void OnValidate()
        {

            Transform parent = transform;

            _pickables = new List<PickableObject>(parent.childCount);


            foreach(Transform child in parent)
            {

                PickableObject pickable = child.gameObject.GetComponent<PickableObject>();

                if(pickable)
                {

                    _pickables.Add(pickable);
                }
            }
        }

    }
}
