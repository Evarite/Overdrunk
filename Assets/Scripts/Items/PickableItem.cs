using UnityEngine;
namespace Overdrunk.Items
{
    [AddComponentMenu("Overdrunk/Items/Pickable Item")]
    public class PickableItem : MonoBehaviour, IPickable
    {
        private Rigidbody _rb;
        private bool _isPickedUp;
        private Transform _handTransform;

        void Awake()
        {
            _rb=GetComponent<Rigidbody>();
        }

        void Start()
        {
            _isPickedUp=false;
        }

        void IPickable.PickUp(Transform transformTo) {

            if (TryGetComponent<Rigidbody>(out _rb))
            {
                _rb.isKinematic = true;
            }

            _isPickedUp = true;
            _handTransform = transformTo;
            transform.position = _handTransform.position;
            transform.rotation = _handTransform.rotation;
        }

        void LateUpdate()
        {
            if (!_isPickedUp) return; 

            transform.position = _handTransform.position;
            transform.rotation = _handTransform.rotation;
        }

        


    }
}