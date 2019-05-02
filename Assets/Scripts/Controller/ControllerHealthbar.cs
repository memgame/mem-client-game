using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MemClientGame.Assets.Scripts.Controller
{
    public class ControllerHealthbar : MonoBehaviour
    {
        public float HealthPercent = 1;
        public float SpeedLerp = .9f;
        
        [SerializeField]
        private Image healthbarFill;

        void Update ()
        {
            healthbarFill.fillAmount = Mathf.Lerp(HealthPercent, healthbarFill.fillAmount, SpeedLerp);
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