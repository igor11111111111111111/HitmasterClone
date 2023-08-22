using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HitmasterClone
{
    public class GameMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private PlayerMonoInstaller _playerPrefab;
        [SerializeField]
        private Bullet _bulletPrefab;
        [SerializeField]
        private Platform _startPlatform;
        [SerializeField]
        private Transform _bulletPoolParent;
        [SerializeField]
        private Button _playButton;

        public override void InstallBindings()
        {
            Camera();
            BulletPool();
            PlatformSystem();
            MobileInputSystem();
            StartSystem();
            FinishSystem();
            Player();
        }

        private void PlatformSystem()
        {
            Container
                .Bind<PlatformSystem>()
                .FromInstance(new PlatformSystem(_startPlatform))
                .AsSingle();
        }

        private void Camera()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();
        }

        private void BulletPool()
        {
            Container
                .Bind<BulletPool>()
                .FromInstance(new BulletPool(_bulletPrefab, 10, _bulletPoolParent))
                .AsSingle();
        }

        private void MobileInputSystem()
        {
            var mobileInputSystem = GetComponent<MobileInputSystem>();
            Container
                .Bind<MobileInputSystem>()
                .FromInstance(mobileInputSystem)
                .AsSingle();
            Container.QueueForInject(mobileInputSystem);
        }

        private void StartSystem()
        {
            Container
                .Bind<StartSystem>()
                .FromInstance(new StartSystem(_playButton))
                .AsSingle();
        }

        private void FinishSystem()
        {
            Container.QueueForInject(new FinishSystem());
        }

        private void Player()
        {
            Container.InstantiatePrefabForComponent<PlayerMonoInstaller>(_playerPrefab, _startPlatform.transform.position, _startPlatform.transform.rotation, null);
        }
    }
}

