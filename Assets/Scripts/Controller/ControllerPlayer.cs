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
        public float Health;
        public float HealthMax;
        public float Energy;
        public float EnergyMax;
        public string PlayerId = null;
        private ControllerTag _controllerTag;

        private Animator _animator;

        public void Start()
        {
            DesiredPosition = transform.position;
            _animator = GetComponentInChildren<Animator>();
            _controllerTag = GetComponentInChildren<ControllerTag>();
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
            
            if (_controllerTag != null)
            {
                _controllerTag.HealthPercent = Mathf.Clamp01(Health / HealthMax);
                _controllerTag.EnergyPercent = Mathf.Clamp01(Energy / EnergyMax);
            }
        }
    }
}
