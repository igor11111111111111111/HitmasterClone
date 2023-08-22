using UnityEngine;
using UnityEngine.UI;

namespace HitmasterClone
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        public void Refresh(float value)
        {
            _slider.value = value;
        }

        public void Enable(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}