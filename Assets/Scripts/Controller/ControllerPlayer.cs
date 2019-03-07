using UnityEngine;

namespace MemClientGame.Assets.Scripts.Controller
{
    class ControllerPlayer : MonoBehaviour
    {
        public Vector3 DesiredPosition;
        public float SpeedLerp;
        public float LocomationAnimationSmoothTime = .1f;
        public float LocomationAnimationSpeedPercent = 0;

        private Animator _animator;

        public void Start()
        {
            DesiredPosition = transform.position;
            _animator = GetComponentInChildren<Animator>();
        }

        public void Update()
        {
            if (DesiredPosition != null)
            {
                transform.position = Vector3.Lerp(transform.position, DesiredPosition, SpeedLerp);
                _animator.SetFloat("SpeedPercent", LocomationAnimationSpeedPercent, LocomationAnimationSmoothTime, Time.deltaTime);
            }
        }

        public void LateUpdate()
        {
            if(DesiredPosition != null)
            {
                var currentPosition = transform.position;
                var distance = Vector3.Distance(currentPosition, DesiredPosition);
                Debug.Log(distance);
                LocomationAnimationSpeedPercent = distance > 0.05 ? .6f : 0;
            } else
            {
                LocomationAnimationSpeedPercent = 0;
            }
        }
    }
}
