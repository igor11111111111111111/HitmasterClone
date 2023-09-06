using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace HitmasterClone
{
    public class PlayerMoveSystem
    {
        [Inject]
        private void Init(NavMeshAgent agent, PlayerController controller, PlatformSystem  platformSystem, Transform transform, PlayerData data)
        {
            controller.OnMove += async (isMove) =>
            {
                if (isMove)
                {
                    await Task.Delay(100);
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

