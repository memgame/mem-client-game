using UnityEngine;

namespace MemClientGame.Assets.Scripts.Controller
{
    public class ControllerCamera : MonoBehaviour
    {
        public GameManager GameManager;
        public Vector3 OffsetCamera;
        public float SpeedCamera;
        public float BorderThickness = 10f;
        public bool IsFocusingPlayer = false;
        public void Start()
        {

        }

        public void Update()
        {
            // Exit Game  
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }

            // Change Camera Type
            if (Input.GetKeyDown(KeyCode.Z))
            {
                IsFocusingPlayer = !IsFocusingPlayer;
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
            if (IsFocusingPlayer)
            {
                if (GameManager.CameraTarget != null)
                {
                    var desiredPosition = GameManager.CameraTarget.position + OffsetCamera;
                    var t = Time.deltaTime / SpeedCamera;
                    transform.position = Vector3.Lerp(transform.position, desiredPosition, t);

                    //transform.LookAt(GameManager.CameraTarget);
                }
            } else {
                Vector3 pos = transform.position;
                if (Input.mousePosition.y >= Screen.height - BorderThickness)
                {
                    var t = Time.deltaTime / SpeedCamera;
                    pos.z += t;
                }
                if (Input.mousePosition.y <= BorderThickness)
                {
                    var t = Time.deltaTime / SpeedCamera;
                    pos.z -= t;
                }
                if (Input.mousePosition.x >= Screen.width - BorderThickness)
                {
                    var t = Time.deltaTime / SpeedCamera;
                    pos.x += t;
                }
                if (Input.mousePosition.x <= BorderThickness)
                {
                    var t = Time.deltaTime / SpeedCamera;
                    pos.x -= t;
                }
                transform.position = pos;
            }
        }
    }
}
