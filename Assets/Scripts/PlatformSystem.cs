using System;
using UnityEngine;

namespace HitmasterClone
{
    public class PlatformSystem
    {
        public event Action OnAllEnemyDeath;
        public event Action OnFinish;
        private Platform _current;

        public PlatformSystem(Platform start)
        {
            _current = start;
            _current.NextPlatform.OnPlayerEnter += Change;
        }

        private void Change()
        {
            _current.NextPlatform.OnPlayerEnter -= Change;
            _current.OnAllEnemyDeath -= AllEnemyDeath;

            _current = _current.NextPlatform;
            if (_current.NextPlatform == null)
            {
                OnFinish?.Invoke();
                return;
            }

            _current.NextPlatform.OnPlayerEnter += Change;
            _current.OnAllEnemyDeath += AllEnemyDeath;
        }

        private void AllEnemyDeath()
        {
            OnAllEnemyDeath?.Invoke();
        }

        public Vector3 GetNextWaypointPosition()
        {
            return _current.NextPlatform.Waypoint.transform.position;
        }
    }
}

