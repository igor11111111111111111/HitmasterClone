using Zenject;

namespace HitmasterClone
{
    public class MobileInputMonoInstaller : MonoInstaller
    {
        public MobileInputMonoInstaller Init() 
        {
            return this;
        }

        public override void InstallBindings()
        {
            var mobileInputSystem = gameObject.AddComponent<MobileInputSystem>();
            Container
                .Bind<MobileInputSystem>()
                .FromInstance(mobileInputSystem)
                .AsSingle();
            Container.QueueForInject(mobileInputSystem);
        }
    }
}

