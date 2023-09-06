using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HitmasterClone
{
    public class StartSystemMonoInstaller : MonoInstaller
    {
        private Button _playButton;

        public StartSystemMonoInstaller Init(Button playButton)
        {
            _playButton = playButton;
            return this;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<StartSystem>()
                .FromInstance(new StartSystem(_playButton))
                .AsSingle();
        }
    }
}

