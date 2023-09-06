using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace HitmasterClone
{
    public class CameraFollowSystem : MonoBehaviour
    {
        private Camera _camera;
        private PlayerData _data;
        private Vector3 _outBattlePosition;
        private Vector3 _outBattleRotation;

        [Inject]
        private void Init(Camera camera, PlayerData data)
        {
            camera.transform.SetParent(transform);
            _camera = camera;
            _data = data;
            _outBattlePosition = new Vector3(0, 2.7f, -3.3f);
            _outBattleRotation = new Vector3(13, 0, 0);
        }

        private void Update()
        {
            if (_data.InBattle)
            {
                _camera.transform.parent = null;
            }
            else
            {
                _camera.transform.parent = transform;
                _camera.transform.localPosition = _outBattlePosition;
                _camera.transform.localRotation = Quaternion.Euler(_outBattleRotation);
            }
        }
    }
}

