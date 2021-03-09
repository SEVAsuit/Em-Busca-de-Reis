using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamekit2D
{
    [RequireComponent(typeof(CharacterController2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Feirante1 : EnemyBehaviour
    {
        public new void Shooting()
        {
            Vector2 shootPosition = shootingOrigin.transform.localPosition;

            //if we are flipped compared to normal, we need to localy flip the shootposition too
            if ((spriteFaceLeft && m_SpriteForward.x > 0) || (!spriteFaceLeft && m_SpriteForward.x > 0))
                shootPosition.x *= -1;

            BulletObject obj = m_BulletPool.Pop(shootingOrigin.TransformPoint(shootPosition));
			
			BulletObject obj2 = m_BulletPool.Pop(shootingOrigin.TransformPoint(shootPosition));
			
			BulletObject obj3 = m_BulletPool.Pop(shootingOrigin.TransformPoint(shootPosition));

            shootingAudio.PlayRandomSound();
			
			float x=(m_TargetShootPosition-shootingOrigin.transform.position).x;
			
			Vector3 vectorHigh = new Vector3(x,10,0);
			Vector3 vectorMedium = new Vector3(x,5,0);
			Vector3 vectorLow = new Vector3(x,2,0);
			
			obj.rigidbody2D.velocity = vectorHigh;
			obj2.rigidbody2D.velocity = vectorMedium;
			obj3.rigidbody2D.velocity = vectorLow;
        }

        //This will give the velocity vector needed to give to the bullet rigidbody so it reach the given target from the origin.
        private Vector3 GetProjectilVelocity(Vector3 target, Vector3 origin)
        {
            const float projectileSpeed = 7.5f;

            Vector3 velocity = Vector3.zero;
            Vector3 toTarget = target - origin;

            float gSquared = Physics.gravity.sqrMagnitude;
            float b = projectileSpeed * projectileSpeed + Vector3.Dot(toTarget, Physics.gravity);
            float discriminant = b * b - gSquared * toTarget.sqrMagnitude;

           /* // Check whether the target is reachable at max speed or less.
            if (discriminant < 0)
            {
                velocity = toTarget;
                velocity.y = 0;
                velocity.Normalize();
                velocity.y = 0.7f;

                velocity *= projectileSpeed;
                return velocity;
            }*/

            float discRoot = Mathf.Sqrt(discriminant);

            // Highest
            float T_max = Mathf.Sqrt((b + discRoot) * 2f / gSquared);

            // Lowest speed arc
            float T_lowEnergy = Mathf.Sqrt(Mathf.Sqrt(toTarget.sqrMagnitude * 4f / gSquared));

            // Most direct with max speed
            float T_min = Mathf.Sqrt((b - discRoot) * 2f / gSquared);

            float T = 0;

            // 0 = highest, 1 = lowest, 2 = most direct
            int shotType = 1;

            switch (shotType)
            {
                case 0:
                    T = T_max;
                    break;
                case 1:
                    T = T_lowEnergy;
                    break;
                case 2:
                    T = T_min;
                    break;
                default:
                    break;
            }

            velocity = toTarget / T - Physics.gravity * T / 2f;

            return velocity;
        }
		
		private Vector3 GetProjectil2Velocity(Vector3 target, Vector3 origin)
        {
            const float projectileSpeed = 7.5f;

            Vector3 velocity = Vector3.zero;
            Vector3 toTarget = target - origin;

            float gSquared = Physics.gravity.sqrMagnitude;
            float b = projectileSpeed * projectileSpeed + Vector3.Dot(toTarget, Physics.gravity);
            float discriminant = b * b - gSquared * toTarget.sqrMagnitude;

           /* // Check whether the target is reachable at max speed or less.
            if (discriminant < 0)
            {
                velocity = toTarget;
                velocity.y = 0;
                velocity.Normalize();
                velocity.y = 0.7f;

                velocity *= projectileSpeed;
                return velocity;
            }*/

            float discRoot = Mathf.Sqrt(discriminant);

            // Highest
            float T_max = Mathf.Sqrt((b + discRoot) * 2f / gSquared);

            // Lowest speed arc
            float T_lowEnergy = Mathf.Sqrt(Mathf.Sqrt(toTarget.sqrMagnitude * 4f / gSquared));

            // Most direct with max speed
            float T_min = Mathf.Sqrt((b - discRoot) * 2f / gSquared);

            float T = 0;

            // 0 = highest, 1 = lowest, 2 = most direct
            int shotType = 0;

            switch (shotType)
            {
                case 0:
                    T = T_max;
                    break;
                case 1:
                    T = T_lowEnergy;
                    break;
                case 2:
                    T = T_min;
                    break;
                default:
                    break;
            }

            velocity = toTarget / T - Physics.gravity * T / 2f;

            return velocity;
        }
		
		private Vector3 GetProjectil3Velocity(Vector3 target, Vector3 origin)
        {
            const float projectileSpeed = 7.5f;

            Vector3 velocity = Vector3.zero;
            Vector3 toTarget = target - origin;

            float gSquared = Physics.gravity.sqrMagnitude;
            float b = projectileSpeed * projectileSpeed + Vector3.Dot(toTarget, Physics.gravity);
            float discriminant = b * b - gSquared * toTarget.sqrMagnitude;

            /*// Check whether the target is reachable at max speed or less.
            if (discriminant < 0)
            {
                velocity = toTarget;
                velocity.y = 0;
                velocity.Normalize();
                velocity.y = 0.7f;

                velocity *= projectileSpeed;
                return velocity;
            }*/

            float discRoot = Mathf.Sqrt(discriminant);

            // Highest
            float T_max = Mathf.Sqrt((b + discRoot) * 2f / gSquared);

            // Lowest speed arc
            float T_lowEnergy = Mathf.Sqrt(Mathf.Sqrt(toTarget.sqrMagnitude * 4f / gSquared));

            // Most direct with max speed
            float T_min = Mathf.Sqrt((b - discRoot) * 2f / gSquared);

            float T = 0;

            // 0 = highest, 1 = lowest, 2 = most direct
            int shotType = 2;

            switch (shotType)
            {
                case 0:
                    T = T_max;
                    break;
                case 1:
                    T = T_lowEnergy;
                    break;
                case 2:
                    T = T_min;
                    break;
                default:
                    break;
            }

            velocity = toTarget / T - Physics.gravity * T / 2f;

            return velocity;
        }
    }
}