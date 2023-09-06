using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class PlatformMonoInstaller : MonoInstaller
    {
        private Platform _startPlatform;

        public PlatformMonoInstaller Init(Platform startPlatform)
        {
            _startPlatform = startPlatform;
            return this;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<PlatformSystem>()
                .FromInstance(new PlatformSystem(_startPlatform))
                .AsSingle();
        }
    }
}

