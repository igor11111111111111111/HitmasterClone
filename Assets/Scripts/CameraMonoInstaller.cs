using UnityEngine;
using Zenject;
using Cinemachine;

namespace HitmasterClone
{
    public class CameraMonoInstaller : MonoInstaller
    {
        private Camera _camera;
        private CinemachineVirtualCamera _CVC;

        public CameraMonoInstaller Init(Camera camera, CinemachineVirtualCamera CVC)
        {
            _camera = camera;
            _CVC = CVC;
            return this;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();

            Container
                .Bind<CinemachineVirtualCamera>()
                .FromInstance(_CVC)
                .AsSingle();
        }
    }
}

