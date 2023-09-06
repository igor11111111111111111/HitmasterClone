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
                .Bind<BulletPool>()
                .FromInstance(new BulletPool(prefab, 10, _bulletPoolParent))
                .AsSingle();
        }
    }
}

