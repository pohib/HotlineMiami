using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLAYER
{
    public class PlayerModel : IModel
    {
        private Vector3 direction;
        private Vector3 storeDir;
        private Vector3 directionForward;
        private Vector3 dirSides;

        private Vector2 InputDirection
        {
            get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
        }

        public Vector3 moveDirection(float speed)
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        }

        public void RotatePlayer(Transform my_transform)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            my_transform.LookAt(new Vector3(mousePosition.x, 0, mousePosition.z));
        }

        bool Velocity()
        {
            if (InputDirection.x != 0 || InputDirection.y != 0)
            {
                return true;
            }

            return false;
        }
    }
}