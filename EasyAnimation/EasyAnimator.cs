using UnityEngine;

namespace UnityTools.EasyAnimation
{
    public class EasyAnimator : MonoBehaviour
    {
        public global::UnityTools.EasyAnimation.EasyAnimation easyAnimation;
        public bool playOnStart;
        public bool loop;
        public bool destroyOnEnd;
        private float _startTime;
        private bool _isPlaying;
        public bool IsPlaying { get; private set; }
        public float Time { get; private set; }
        public float EvaluatedTime { get; private set; }
        
        private void Start(){
            if (playOnStart){
                Play();
            }
        }

        public void Play(){
            _startTime = easyAnimation.delay;
            _isPlaying = true;
            Time = 0;
        }
        
        public void Stop(){
            _isPlaying = false;
        }
        
        private void Update(){
            if (!_isPlaying) return;
            if (_startTime > 0){
                _startTime -= UnityEngine.Time.deltaTime;
                return;
            }
            IsPlaying = true;
            Time += UnityEngine.Time.deltaTime;
            EvaluatedTime = easyAnimation.curve.Evaluate(Time / easyAnimation.duration);
            if (!(Time >= easyAnimation.duration)) return;
            if (loop){
                Time = 0;
            }
            else{
                IsPlaying = false;
                _isPlaying = false;
                if (destroyOnEnd){
                    Destroy(gameObject);
                }
            }
        }
        
    
    }
}