using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MemClientGame.Assets.Scripts.Controller
{
    public class ControllerTag : MonoBehaviour
    {
        public float SpeedLerp = .9f;
        public float HealthPercent = 1;

        public float EnergyPercent = 1;
        [SerializeField]
        private Image _healthbarFill;
        [SerializeField]
        private Image _energybarFill;

        void Update ()
        {
            _healthbarFill.fillAmount = Mathf.Lerp(HealthPercent, _healthbarFill.fillAmount, SpeedLerp);
            _energybarFill.fillAmount = Mathf.Lerp(EnergyPercent, _energybarFill.fillAmount, SpeedLerp);
        }
        void LateUpdate ()
        {
            transform.LookAt(
                transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up
            );
        }
    }
}
