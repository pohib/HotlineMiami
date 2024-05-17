using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLAYER
{
    public class PlayerModel : IModel
    {
        public Vector3 moveDirection(float speed)
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        }

        public void RotatePlayer(Transform my_transform)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            my_transform.LookAt(new Vector3(mousePosition.x, 0, mousePosition.z));
        }
    }
}