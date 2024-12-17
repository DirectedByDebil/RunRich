using UnityEngine;

namespace Characters
{

    [RequireComponent(typeof(Rigidbody))]
    public sealed class Player : MonoBehaviour
    {

        public Rigidbody Rigidbody { get => _rigidbody; }


        [SerializeField] private Transform _leftArm;

        [SerializeField] private Transform _rightArm;


        private Rigidbody _rigidbody;


        private void OnValidate()
        {

            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
