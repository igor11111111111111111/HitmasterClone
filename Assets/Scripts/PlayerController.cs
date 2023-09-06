using System;
using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class PlayerController
    {
        public event Action<bool> OnInBattle;
        public event Action<bool> OnMove;
        public event Action<Vector3> OnShoot;

        [Inject]
        private void Init(StartSystem startSystem, MobileInputSystem input, PlayerTrigger trigger, PlayerData data, PlatformSystem platformSystem)
        {
            startSystem.OnStart += () => OnMove?.Invoke(true);

            input.OnClick += (target) =>
            {
                if (data.InBattle)
                    OnShoot?.Invoke(target);
            };

            trigger.OnEnter += (_) =>
            {
                data.InBattle = true;
                OnInBattle?.Invoke(true);
                OnMove?.Invoke(false);
            };

            platformSystem.OnAllEnemyDeath += () =>
            {
                data.InBattle = false;
                OnInBattle?.Invoke(false);
                OnMove?.Invoke(true);
            };
        }
    }
}

