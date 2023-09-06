using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class BulletMonoInstaller : MonoInstaller
    { 
        private Transform _bulletPoolParent;

        public BulletMonoInstaller Init(Transform bulletPoolParent)
        {
            _bulletPoolParent = bulletPoolParent;
            return this;
        }

        public override void InstallBindings()
        {
            Bullet prefab = Resources.Load<Bullet>(nameof(Bullet));
            Container
                .Bind<ObjectPool<Bullet>>()
                .FromInstance(new ObjectPool<Bullet>(prefab, _bulletPoolParent))
                .AsSingle();
        }
    }
}

