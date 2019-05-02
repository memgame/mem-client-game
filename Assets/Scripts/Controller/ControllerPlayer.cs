using UnityEngine;

namespace MemClientGame.Assets.Scripts.Controller
{
    class ControllerPlayer : MonoBehaviour
    {
        public Vector3 DesiredPosition;
        public Vector3 DesiredRotation;
        public float SpeedLerp;
        public float LocomationAnimationSmoothTime = .1f;
        public float LocomationAnimationSpeedPercent = 0;
        public string PlayerId = null;

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

            if (DesiredRotation != null)
            {
                var t = Time.deltaTime / SpeedLerp;
                
                float angle = Mathf.LerpAngle(transform.eulerAngles.y, DesiredRotation.y, t);
                transform.eulerAngles = new Vector3(0, angle, 0);
            }
        }
    }
}
