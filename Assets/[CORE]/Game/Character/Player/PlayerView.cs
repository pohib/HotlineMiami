using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLAYER
{
    public class PlayerView : Singleton<PlayerView>, IView
    {
        [SerializeField] private Components components;

        public Components Components { get => components; }

        Components IView.components { get { return components; } }

        public void Move(Vector3 direction)
        {
            components.controller.Move(direction * components.speed);
            components.my_transform.position = new Vector3(components.my_transform.position.x, 0, components.my_transform.position.z);
        }
    }


    [System.Serializable]
    public struct Components
    {
        public Transform my_transform;
        public Transform my_Root;
        public CharacterController controller;
        public float speed;
        public float rotation_speed;
        public Transform camera;
        public PlayerAnimationController animationController;
        public PlayerWeaponManager weaponManager;
    }
}
