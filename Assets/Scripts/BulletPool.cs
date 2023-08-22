using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HitmasterClone
{
    public class BulletPool
    {
        private List<Bullet> _bullets;
        private Bullet _prefab;
        private Transform _parent;

        public BulletPool(Bullet prefab, int size, Transform parent)
        {
            _bullets = new List<Bullet>();
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < size; i++)
            {
                Create();
            }
        }
         
        public Bullet Get()
        {
            Bullet bullet = null;
            try
            {
                bullet = _bullets
                .Where(b => b != null && b.gameObject.activeInHierarchy == false)
                .First();
                bullet.gameObject.SetActive(true);
            }
            catch (System.Exception)
            {

            }

            if (bullet == null)
            {
                bullet = Create();
                bullet.gameObject.SetActive(true);
            }
            return bullet;
        }

        private Bullet Create()
        {
            var bullet = Object.Instantiate(_prefab, _parent);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
            return bullet;
        }
    }
}

