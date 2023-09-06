using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Cinemachine;

namespace HitmasterClone
{
    public class CameraFollowSystem : MonoBehaviour
    {
        [Inject]
        private void Init(CinemachineVirtualCamera CVC, PlayerData data, Transform transform, PlayerController controller)
        {
            CVC.Follow = transform;
            CVC.LookAt = transform;

            controller.OnMove += (active) =>
            {
                CVC.enabled = active;
            };
        }
    }
}

