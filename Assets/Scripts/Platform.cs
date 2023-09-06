using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HitmasterClone
{
    [RequireComponent(typeof(BoxCollider))]
    public class Platform : MonoBehaviour
    {
        public event Action OnAllEnemyDeath;
        public event Action OnPlayerEnter;
        public Platform NextPlatform => _nextPlatform;
        [SerializeField]
        private Platform _nextPlatform;
        public PlatformWaypoint Waypoint => _waypoint;
        [SerializeField]
        private PlatformWaypoint _waypoint;
        private List<Enemy> _enemy;
        private Coroutine _update;

        private void Awake()
        {
            _enemy = new List<Enemy>();
            _waypoint.OnPlayerEnter += () =>
            {
                if(_update == null)
                {
                    GetComponent<BoxCollider>().enabled = false;
                    OnPlayerEnter?.Invoke();
                    _update = StartCoroutine(CustomUpdate());
                }
            };
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                if(!_enemy.Contains(enemy))
                {
                    _enemy.Add(enemy);
                }
            }
        }

        private IEnumerator CustomUpdate()
        {
            while (true)
            {
                var count = _enemy.Where(e => e.Data.IsAlive).Count();
                if(count == 0)
                {
                    OnAllEnemyDeath?.Invoke();
                    if(_update != null)
                        StopCoroutine(_update);
                }  

                yield return new WaitForSeconds(1);
            }
        }
    }
}

