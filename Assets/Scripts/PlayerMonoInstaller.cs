using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace HitmasterClone
{
    public class PlayerMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private BulletSpawnPoint _bulletSpawnPoint;

        public override void InstallBindings()
        {
            Transform();
            Data();
            Animator();
            Trigger();
            Controller();
            NavMeshAgent();
            BulletSpawnPoint();
            MoveSystem();
            ShootSystem();
            CameraMoveSystem();
        }

        private void Transform()
        {
            Container
                .Bind<Transform>()
                .FromInstance(transform)
                .AsSingle();
        }

        private void Controller()
        {
            var controller = new PlayerController();
            Container
                .Bind<PlayerController>()
                .FromInstance(controller)
                .AsSingle();
            Container.QueueForInject(controller);
        }

        private void BulletSpawnPoint()
        {
            Container
                .Bind<BulletSpawnPoint>()
                .FromInstance(_bulletSpawnPoint)
                .AsSingle();
        }

        private void Animator()
        {
            var unityAnimator = GetComponentInChildren<Animator>();
            Container.QueueForInject(new PlayerAnimator(unityAnimator));
        }

        private void MoveSystem()
        {
            Container.QueueForInject(new PlayerMoveSystem());
        }

        private void Data()
        {
            Container
                .Bind<PlayerData>()
                .FromInstance(new PlayerData())
                .AsSingle();
        }

        private void NavMeshAgent()
        {
            Container
                .Bind<NavMeshAgent>()
                .FromInstance(GetComponent<NavMeshAgent>())
                .AsSingle();
        }

        private void Trigger()
        {
            Container
                .Bind<PlayerTrigger>()
                .FromInstance(GetComponentInChildren<PlayerTrigger>())
                .AsSingle();
        }

        private void ShootSystem()
        {
            Container.QueueForInject(new PlayerShootSystem());
        }

        private void CameraMoveSystem()
        {
            Container.QueueForInject(gameObject.AddComponent<CameraFollowSystem>());
        }
    }
}

