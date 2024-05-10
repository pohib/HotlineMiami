using UnityEngine;

namespace PLAYER
{
    public interface IModel
    {
        public Vector3 moveDirection(float speed);
        public void RotatePlayer(Transform my_transform);
    }
}