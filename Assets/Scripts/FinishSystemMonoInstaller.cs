using Zenject;

namespace HitmasterClone
{
    public class FinishSystemMonoInstaller : MonoInstaller
    {
        public FinishSystemMonoInstaller Init() 
        {
            return this;
        }

        public override void InstallBindings()
        {
            Container.QueueForInject(new FinishSystem());
        }
    }
}

