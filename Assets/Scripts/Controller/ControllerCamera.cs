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
        public Terrain CameraLimit;
        public float ScrollSpeed = 20f;
        public float MinCameraDistance = 3f;
        public float MaxCameraDistance = 120f;
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

                float scroll = Input.GetAxis("Mouse ScrollWheel");
                pos.y += -scroll * ScrollSpeed * 100f * Time.deltaTime;

                pos.x = Mathf.Clamp(pos.x, CameraLimit.transform.position.x, CameraLimit.terrainData.size.x);
                pos.y = Mathf.Clamp(pos.y, MinCameraDistance, MaxCameraDistance);
                pos.z = Mathf.Clamp(pos.z, CameraLimit.transform.position.z, CameraLimit.terrainData.size.z);

                transform.position = pos;
            }
        }
    }
}
