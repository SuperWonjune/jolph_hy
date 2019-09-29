using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAgents
{
    [DisallowMultipleComponent]
    public class ObstacleContact : MonoBehaviour
    {
        [Header("Detect Obstacles")] public bool touchingObstacle;
        private const string Obstacle = "obstacle"; // Tag on obstacle

        /// <summary>
        /// Check for collision with a target.
        /// </summary>
        void OnCollisionEnter(Collision col)
        {
            if (col.transform.CompareTag(Obstacle))
            {
                touchingObstacle = true;
            }
        }

        /// <summary>
        /// Check for end of ground collision and reset flag appropriately.
        /// </summary>
        void OnCollisionExit(Collision other)
        {
            if (other.transform.CompareTag(Obstacle))
            {
                touchingObstacle = false;
            }
        }
    }
}
