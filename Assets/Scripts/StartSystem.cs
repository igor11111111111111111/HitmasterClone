using System;
using UnityEngine.UI;
namespace HitmasterClone
{
    public class StartSystem
    {
        public event Action OnStart;

        public StartSystem(Button button)
        {
            button.onClick.AddListener(() => OnStart?.Invoke());
        }
    }
}

