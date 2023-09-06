using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class CameraMonoInstaller : MonoInstaller
    {
        private Camera _camera;

        public CameraMonoInstaller Init(Camera camera)
        {
            _camera = camera;
            return this;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();
        }
    }
}

