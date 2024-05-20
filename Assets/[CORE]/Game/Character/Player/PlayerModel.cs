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
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (inputDirection != Vector3.zero)
            {
                Vector3 moveVector = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * inputDirection;
                moveVector = moveVector.normalized * speed * Time.deltaTime;
                return moveVector;
            }
            else
            {
                return Vector3.zero;
            }
        }

        public void RotatePlayer(Transform my_transform)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            my_transform.LookAt(new Vector3(mousePosition.x, 0, mousePosition.z));
        }
    }
}