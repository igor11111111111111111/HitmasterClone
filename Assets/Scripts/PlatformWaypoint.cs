using System;
using UnityEngine;

namespace HitmasterClone
{
    public class PlatformWaypoint : MonoBehaviour
    {
        public Action OnPlayerEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerTrigger player))
            {
                OnPlayerEnter?.Invoke();
            }
        }
    }
}

