using UnityEngine;

namespace HitmasterClone
{
    public class HashAnimationNames
    {
        public int IsMove { get => Animator.StringToHash("IsMove"); }
        public int OnShoot { get => Animator.StringToHash("OnShoot"); }
        public int InBattle { get => Animator.StringToHash("InBattle"); }
        public int OnDeath { get => Animator.StringToHash("OnDeath"); }
    }
}

