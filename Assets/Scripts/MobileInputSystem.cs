using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace HitmasterClone
{
    public class MobileInputSystem : MonoBehaviour
    {
        public event Action<Vector3> OnClick;
        private Camera _camera;
        private int _shootDistance;

        [Inject]
        private void Init(Camera camera)
        {
            _camera = camera;
            _shootDistance = 10;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, _shootDistance))
                {
                    OnClick?.Invoke(raycastHit.point);
                }
                else
                {
                    var screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _shootDistance);
                    var worldPosition = _camera.ScreenToWorldPoint(screenPosition);
                    OnClick?.Invoke(worldPosition);
                }
            }
        }
    }
}

