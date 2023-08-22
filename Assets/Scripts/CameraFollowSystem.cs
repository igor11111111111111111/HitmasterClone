using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace HitmasterClone
{
    public class CameraFollowSystem : MonoBehaviour
    {
        private Camera _camera;
        private PlayerData _data;

        [Inject]
        private void Init(Camera camera, PlayerData data)
        {
            camera.transform.SetParent(transform);
            _camera = camera;
            _data = data;


                //if (active)
                //{
                //    camera.transform.parent = null;
                //    camera.transform.localPosition = transform.localPosition;
                //    /*new Vector3(camera.transform.localPosition.x, 2.4f, camera.transform.localPosition.z);*/
                //}
                //else
                //{
                //    camera.transform.SetParent(transform);
                //}
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
                _camera.transform.localPosition = new Vector3(0, 2.7f, -3.3f);
                _camera.transform.localRotation = Quaternion.Euler(new Vector3(13, 0, 0));
            }
        }
    }
}

