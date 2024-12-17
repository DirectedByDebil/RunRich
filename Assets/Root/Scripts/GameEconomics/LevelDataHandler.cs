using UnityEngine;
using System.Collections.Generic;

namespace GameEconomics
{
    public sealed class LevelDataHandler : MonoBehaviour
    {

        public IReadOnlyCollection<IPickable> Good { get => _good; }
        
        public IReadOnlyCollection<IPickable> Bad { get => _bad; }


        [SerializeField] private Transform _goodParent;

        [SerializeField] private Transform _badParent;


        [SerializeField] private List<PickableObject> _good;

        [SerializeField] private List<PickableObject> _bad;


        private void OnValidate()
        {

            FillList(_goodParent, out _good);

            FillList(_badParent, out _bad);
        }


        private void FillList(Transform parent,
            
            out List<PickableObject> list)
        {

            list = new List<PickableObject>(parent.childCount);


            foreach(Transform child in parent)
            {

                if(!TryAddChild(child, list))
                {

                    TryAddBunch(child, list);
                }
            }
        }


        private bool TryAddChild(Transform child, IList<PickableObject> list)
        {

            PickableObject pickable = child.gameObject.GetComponent<PickableObject>();


            if (pickable)
            {

                list.Add(pickable);

                return true;
            }

            return false;
        }


        private bool TryAddBunch(Transform child, List<PickableObject> list)
        {

            PickableBunch bunch = child.gameObject.GetComponent<PickableBunch>();


            if (bunch)
            {

                list.AddRange(bunch.Pickables);
                
                return true;
            }

            return false;
        }

    }
}
