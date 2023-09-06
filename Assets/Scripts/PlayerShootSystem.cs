using UnityEngine;
using Zenject;

namespace HitmasterClone
{

    public class PlayerShootSystem
    {
        [Inject]
        private void Init(Transform transform, PlayerController controller, ObjectPool<Bullet> bulletPool, BulletSpawnPoint bulletSpawnPoint)
        {
            controller.OnShoot += (target) => Shoot(transform, target, bulletSpawnPoint, bulletPool);
        }

        private void Shoot(Transform transform, Vector3 target, BulletSpawnPoint bulletSpawnPoint, ObjectPool<Bullet> bulletPool)
        {
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
            bulletPool
                .Get()
                .Init(bulletSpawnPoint.transform, target);
        }
    }
}

