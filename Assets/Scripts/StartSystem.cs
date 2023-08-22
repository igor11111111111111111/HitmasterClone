using System;
using UnityEngine.UI;
using Zenject;

namespace HitmasterClone
{
    public class StartSystem
    {
        public Action OnStart;
        public StartSystem(Button button)
        {
            button.onClick.AddListener(() => OnStart?.Invoke());
        }
    }
}

