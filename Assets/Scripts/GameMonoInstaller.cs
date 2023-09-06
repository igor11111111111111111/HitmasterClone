using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HitmasterClone
{
    public class GameMonoInstaller : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private Platform _startPlatform;
        [SerializeField]
        private Transform _bulletPoolParent;
        [SerializeField]
        private Button _playButton;

        public void Awake()
        {
            var context = gameObject.AddComponent<SceneContext>();
            context.Installers = new List<MonoInstaller>()
            {
                gameObject.AddComponent<CameraMonoInstaller>().Init(_camera),
                gameObject.AddComponent<BulletMonoInstaller>().Init(_bulletPoolParent),
                gameObject.AddComponent<PlatformMonoInstaller>().Init(_startPlatform),
                gameObject.AddComponent<MobileInputMonoInstaller>().Init(),
                gameObject.AddComponent<StartSystemMonoInstaller>().Init(_playButton),
                gameObject.AddComponent<FinishSystemMonoInstaller>().Init(),
                gameObject.AddComponent<PlayerSpawnMonoInstaller>().Init(_startPlatform)
            };
            context.Run();
        }
    }
}

