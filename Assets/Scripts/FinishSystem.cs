using Zenject;

namespace HitmasterClone
{
    public class FinishSystem
    {
        [Inject]
        private void Init(PlatformSystem platformSystem)
        {
            platformSystem.OnFinish += () => new SceneChanger(SceneNames.Game);
        }
    }
}

