using UnityEngine;
using System;


namespace GameEconomics
{

    public sealed class PickableObject : MonoBehaviour, IPickable
    {

        public event Action<int> PickedUp;


        [SerializeField, Range(-20, 20)]

        private int _cost;



        private void OnTriggerEnter(Collider other)
        {
            
            if(other.CompareTag("Player"))
            {

                PickedUp?.Invoke(_cost);

                //#TODO animate
            }
        }

    }

}