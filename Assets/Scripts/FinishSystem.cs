using UnityEngine.SceneManagement;
using Zenject;

namespace HitmasterClone
{
    public class FinishSystem
    {
        [Inject]
        private void Init(PlatformSystem platformSystem)
        {
            platformSystem.OnFinish += () => SceneManager.LoadScene("Game");
        }
    }
}

