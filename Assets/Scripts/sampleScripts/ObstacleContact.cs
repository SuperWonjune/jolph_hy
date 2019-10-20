using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLAgents
{
    [DisallowMultipleComponent]
    public class ObstacleContact : MonoBehaviour
    {
        [HideInInspector] public Agent agent;

        [Header("Detect Obstacles")]
        public bool agentDoneOnObstacleContact;
        public bool penalizeObstacleContact; // Whether to penalize on contact.
        public float obstacleContactPenalty; // Penalty amount (ex: -1).
        public bool touchingObstacle;
        private const string Obstacle = "obstacle"; // Tag on obstacle
        /// <summary>
        /// Check for collision with a target.
        /// </summary>
        void OnCollisionEnter(Collision col)
        {
            if (col.transform.CompareTag(Obstacle))
            {
                touchingObstacle = true;
                if (penalizeObstacleContact)
                {
                    agent.SetReward(obstacleContactPenalty);
                }

                if (agentDoneOnObstacleContact)
                {
                    agent.Done();
                }
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
