using System;
using UnityEngine;


namespace AI
{
    public class AIModel : IModel
    {
        int path_ID = 0;

        private RayScan rayScan;
        public RayScan GetScan => rayScan;

        private ItemConfig currentWeapon;

        public AIModel(Transform transform, Transform target)
        {
            rayScan = new RayScan(transform, target);
        }

        public bool followTarget { get; set; }
        public Action<float> checkDistance { get; set; }

        public bool CheckDistanceToTarget(Components components)
        {
            if(rayScan.CheckViewSpace())
            {
                if(Vector3.Distance(components.my_transform.position, rayScan.target.position) <= components.agent.stoppingDistance)
                {
                    return true;
                }
            }

            return false;
        }

        public Vector3 moveDirection(Components components)
        {
            if(currentWeapon == null)
            {
                currentWeapon = GameInstanceContainer.instance.itemsListConfig.GetItem(components.config.currentWeapon);
                components.characterAnimation.WeaponAnimation(currentWeapon.Type);
            }

            if (!followTarget)
            {
                if (!rayScan.CheckViewSpace())
                {
                    if (components.config.isPatrol)
                    {
                        components.agent.speed = components.config.walkSpeed;
                        components.agent.stoppingDistance = components.config.defaultStopDistance;
                        
                        if (Vector3.Distance(components.my_transform.position, components.path_points[path_ID].position) <= components.agent.stoppingDistance)
                        {
                            SetNewPoint(components.path_points.Length);
                        }
                        else
                        {
                            return components.path_points[path_ID].position;
                        }
                    }
                    else
                    {
                        return components.my_transform.position;
                    }
                }
            }

            if(!rayScan.CheckViewSpace())
            {
                rayScan.ResetDistance();
            }

            components.agent.stoppingDistance = currentWeapon.DistanceToAttack;
            components.agent.speed = components.config.runSpeed;
            checkDistance?.Invoke(rayScan.GetDistanceToTarget);

            return rayScan.target.position;
        }

        void SetNewPoint(int length)
        {
            path_ID++;

            if(path_ID >= length)
            {
                path_ID = 0;
            }
        }
    }
}