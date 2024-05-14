using UnityEngine;

namespace PLAYER
{
    public interface IView
    {
        public Components components { get; }

        public void Init(InventoryAndEquipment inventory);
        public void Move(Vector3 direction);
    }
}
