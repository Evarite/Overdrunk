using UnityEngine;
namespace Overdrunk.Items
{
    public interface IPickable
    {
        void PickUp(Transform transformTo) { }
    }
}
