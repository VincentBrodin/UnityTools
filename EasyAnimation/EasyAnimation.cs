using UnityEngine;

namespace UnityTools.EasyAnimation
{
    [CreateAssetMenu(fileName = "New Animation", menuName = "Easy Tools/Animation/New Animation", order = 0)]
    public class EasyAnimation : ScriptableObject
    {
        public string animationName;
        public float duration;
        public float delay;
        public AnimationCurve curve;
    }
}