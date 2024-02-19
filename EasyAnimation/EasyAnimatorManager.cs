using System.Collections.Generic;
using UnityEngine;

namespace UnityTools.EasyAnimation
{
    public class EasyAnimatorManager : MonoBehaviour
    {
        public static EasyAnimatorManager Singleton { get; private set; }
        public Dictionary<string, UnityTools.EasyAnimation.EasyAnimation> Animations{ get; private set; } = new();
        private const string ResourcePath = "Animations";
        
        private void Awake(){
            if (Singleton == null || Singleton != this){
                Singleton = this;
            }
            else{
                Destroy(gameObject);
            }
            
            //Get all animations from resources
            
            UnityTools.EasyAnimation.EasyAnimation[] animations = Resources.LoadAll<UnityTools.EasyAnimation.EasyAnimation>(ResourcePath);
            foreach (UnityTools.EasyAnimation.EasyAnimation anim in animations){
                Animations.Add(anim.animationName, anim);
            }
        }

        public UnityTools.EasyAnimation.EasyAnimation GetAnimation(string animationName){
            return Animations[animationName];
        }
    }
}