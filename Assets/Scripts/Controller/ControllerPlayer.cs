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
                var t = Time.deltaTime / SpeedLerp;
                transform.position = Vector3.Lerp(transform.position, DesiredPosition, t);
                _animator.SetFloat("SpeedPercent", LocomationAnimationSpeedPercent, LocomationAnimationSmoothTime, Time.deltaTime);
            }
        }
    }
}
