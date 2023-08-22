using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace HitmasterClone
{
    public class PlayerMoveSystem
    {
        [Inject]
        private void Init(NavMeshAgent agent, PlayerController controller, PlatformSystem  platformSystem, Transform transform)
        {
            controller.OnMove += (isMove) =>
            {
                if (isMove)
                {
                    agent.isStopped = false;
                    var position = platformSystem.GetNextWaypointPosition();
                    transform.LookAt(position);
                    agent.SetDestination(position);
                }
                else
                {
                    agent.isStopped = true;
                }
            };
        }
    }
}

