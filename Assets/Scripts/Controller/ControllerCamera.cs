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

            if(Input.GetMouseButtonDown(1) && GameManager.GameRoom != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log(hit.point);
                    GameManager.GameRoom.Send(new
                    {
                        ACTION_TYPE = "MOVE_PLAYER_TO",
                        payload = new
                        {
                            hit.point.x,
                            hit.point.z
                        }
                    });
                }
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
