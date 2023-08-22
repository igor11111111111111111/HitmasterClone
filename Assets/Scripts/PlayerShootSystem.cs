using UnityEngine;
using Zenject;

namespace HitmasterClone
{

    public class PlayerShootSystem
    {
        [Inject]
        private void Init(Transform transform, PlayerController controller, BulletPool bulletPool, BulletSpawnPoint bulletSpawnPoint)
        {
            controller.OnShoot += (target) => Shoot(transform, target, bulletSpawnPoint, bulletPool);
        }

        private void Shoot(Transform transform, Vector3 target, BulletSpawnPoint bulletSpawnPoint, BulletPool bulletPool)
        {
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
            bulletPool
                .Get()
                .Init(bulletSpawnPoint.transform, target);
        }
    }
}

