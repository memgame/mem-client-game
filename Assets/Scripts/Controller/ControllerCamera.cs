using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MemClientGame.Assets.Scripts.Controller
{
    public class ControllerCamera : MonoBehaviour
    {
        public GameManager GameManager;
        public Vector3 OffsetCamera;
        public float SpeedCamera;
        public void Start()
        {

        }

        public void Update()
        {
            // Exit Game  
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }

        public void LateUpdate()
        {
            if (GameManager.CameraTarget != null)
            {
                var desiredPosition = GameManager.CameraTarget.position + OffsetCamera;
                var t = Time.deltaTime / SpeedCamera;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, t);

                //transform.LookAt(GameManager.CameraTarget);
            }
        }
    }
}
