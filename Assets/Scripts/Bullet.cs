using UnityEngine;

namespace HitmasterClone
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float _liveTime;
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private int _damage;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(Transform parent, Vector3 target)
        {
            transform.SetPositionAndRotation(parent.position, parent.rotation);
            _rigidbody.AddForce((target - parent.transform.position).normalized * _moveSpeed, ForceMode.Impulse);
            gameObject.SetActive(true);
            Invoke(nameof(Destroy), _liveTime);
        }

        private void Destroy()
        {
            CancelInvoke(nameof(Destroy));
            _rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
            Destroy();
        }
    }
}