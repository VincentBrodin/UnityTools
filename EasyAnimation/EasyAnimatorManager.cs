using System.Collections.Generic;
using UnityEngine;

namespace EasyAnimation
{
    public class EasyAnimatorManager : MonoBehaviour
    {
        public static EasyAnimatorManager Singleton { get; private set; }
        public Dictionary<string, EasyAnimation> Animations{ get; private set; } = new();
        private const string ResourcePath = "Animations";
        
        private void Awake(){
            if (Singleton == null || Singleton != this){
                Singleton = this;
            }
            else{
                Destroy(gameObject);
            }
            
            //Get all animations from resources
            
            EasyAnimation[] animations = Resources.LoadAll<EasyAnimation>(ResourcePath);
            foreach (EasyAnimation anim in animations){
                Animations.Add(anim.animationName, anim);
            }
        }

        public EasyAnimation GetAnimation(string animationName){
            return Animations[animationName];
        }
    }
}