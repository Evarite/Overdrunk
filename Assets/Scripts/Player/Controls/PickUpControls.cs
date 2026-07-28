using Overdrunk.Items.Interfaces;
using UnityEngine;
namespace Overdrunk.Player.Controls
{
    [AddComponentMenu("Overdrunk/Player/Controls/Pick Up Controller")]
    public class PickUpControls : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IPickable pickable))
            {
                Debug.Log("Colliders yeah");
                pickable.PickUp(transform.Find("HandTransform").transform);
            }
        }

    }
}