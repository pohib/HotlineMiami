using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLAYER
{
    public class PlayerView : MonoBehaviour, IView
    {
        [SerializeField] private Components components;

        public Components Components { get => components; }
        public InventoryAndEquipment InventoryAndEquipment { get; private set; }

        Components IView.components { get { return components; } }

        public void Init(InventoryAndEquipment inventory)
        {
            InventoryAndEquipment = inventory;
        }

        public void Move(Vector3 direction)
        {
            components.controller.Move(direction);
            components.my_transform.position = new Vector3(components.my_transform.position.x, 0, components.my_transform.position.z);
        }
    }


    [System.Serializable]
    public struct Components
    {
        public CharacterConfig config;
        public Transform my_transform;
        public Transform my_Root;
        public CharacterController controller;
        public Transform camera;
        public PlayerAnimationController animationController;
        public CharacterStats characterStats;
    }
}
