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

        [Inject]
        private void Init(Camera camera)
        {
            _camera = camera;
        }

        private void Update()
        {
            // для теста через пк
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    OnClick?.Invoke(raycastHit.point);
                }
            }

            // для билда mobile
            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);
            //    Ray ray = _camera.ScreenPointToRay(touch.position);
            //    if (Physics.Raycast(ray, out RaycastHit raycastHit))
            //    {
            //        OnClick?.Invoke(raycastHit.point);
            //    }
            //}
        }
    }
}

