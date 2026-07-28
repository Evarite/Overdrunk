using UnityEngine;
namespace Overdrunk.Items.Interfaces
{
    [AddComponentMenu("Overdrunk/Items/Pickable Item")]
    public class PickableItem : MonoBehaviour, IPickable
    {
        private Rigidbody _rb;
        private bool _isPickedUp = false;
        private Transform _handTransform;

        void Awake() => _rb = GetComponent<Rigidbody>();
        
        public void PickUp(Transform transformTo) {

            if (_rb != null) _rb.isKinematic = true;

            _isPickedUp = true;

            transform.SetParent(transformTo);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}