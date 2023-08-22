using System;
using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class PlayerTrigger : MonoBehaviour
    {
        public Action<PlatformWaypoint> OnEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlatformWaypoint waypoint))
            {
                waypoint.gameObject.SetActive(false);
                OnEnter?.Invoke(waypoint);
            }
        }
    }
}

