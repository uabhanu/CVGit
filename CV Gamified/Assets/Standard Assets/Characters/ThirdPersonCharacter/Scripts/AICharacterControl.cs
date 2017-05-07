using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]

    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        GameObject m_bulletObj;
        [SerializeField] GameObject PF_Bullet;
        int m_bulletCount = 0;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);

            else
            {
                character.Move(Vector3.zero, false, false);

                if (m_bulletCount < 1)
                {
                    m_bulletObj = Instantiate(PF_Bullet , new Vector3(0f , 0f , 0f) , transform.rotation);
                    m_bulletCount++;
                }
            }
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
