using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class PlayerSpawnMonoInstaller : MonoInstaller
    {
        private Platform _startPlatform;

        public PlayerSpawnMonoInstaller Init(Platform startPlatform)
        {
            _startPlatform = startPlatform;
            return this;
        }

        public override void InstallBindings()
        {
            PlayerMonoInstaller prefab = Resources.Load<PlayerMonoInstaller>("Player");
            Container.InstantiatePrefabForComponent<PlayerMonoInstaller>(prefab, _startPlatform.transform.position, _startPlatform.transform.rotation, null);
        }
    }
}

