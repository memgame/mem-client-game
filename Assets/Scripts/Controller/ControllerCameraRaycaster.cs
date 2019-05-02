using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MemClientGame.Assets.Scripts.Controller
{
    public class ControllerCameraRaycaster : MonoBehaviour
    {
        public Texture2D DefaultCursor = null;
        public Texture2D AttackCursor = null;
        public Vector2 CursorHotspot = new Vector2(0, 0);
        public GameObject MoveToIndicator = null;

        private GameManager _gameManager = null;
        private GameObject _lastMoveToIndicator = null;
        Rect _screenRectAtStartGame = new Rect(0, 0, Screen.width, Screen.height);
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            Debug.Log("Hey");
            Debug.Log(_gameManager);
        }

        // Update is called once per frame
        void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // TODO Implement UI interaction
            } else
            {
                PerformRaycasts();
            };
        }
        void PerformRaycasts()
        {
            if(_screenRectAtStartGame.Contains(Input.mousePosition))
            {
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
                {
                    if (IsRaycastHitOnPlayer(hitInfo)) return;
                    MoveToRaycastHit(hitInfo);
                }
                Cursor.SetCursor(DefaultCursor, CursorHotspot, CursorMode.Auto);
            }
        }

        private bool IsRaycastHitOnPlayer (RaycastHit hitInfo)
        {
            var gameObjectHit = hitInfo.collider.gameObject;
            var controllerPlayer = gameObjectHit.GetComponent<ControllerPlayer>();

            if (controllerPlayer)
            {
                Cursor.SetCursor(AttackCursor, CursorHotspot, CursorMode.Auto);

                if (Input.GetMouseButtonDown(1) && _gameManager.GameRoom != null)
                {
                    _gameManager.GameRoom.Send(new
                    {
                        ACTION_TYPE = "TARGET_PLAYER",
                        payload = new
                        {
                            playerId = controllerPlayer.PlayerId
                        }
                    });
                }

                return true;
            }

            return false;
        }

        private void MoveToRaycastHit (RaycastHit hitInfo)
        {
            if(Input.GetMouseButtonDown(1) && _gameManager.GameRoom != null)
            {
                Debug.Log(hitInfo.point);
                _gameManager.GameRoom.Send(new
                {
                    ACTION_TYPE = "MOVE_PLAYER_TO",
                    payload = new
                    {
                        hitInfo.point.x,
                        hitInfo.point.z
                    }
                });

                
                if (_lastMoveToIndicator)
                {
                    Destroy(_lastMoveToIndicator);
                }
                if (MoveToIndicator != null)
                {
                    _lastMoveToIndicator = Instantiate(MoveToIndicator, new Vector3(hitInfo.point.x, 0, hitInfo.point.z), Quaternion.identity);
                    Destroy(_lastMoveToIndicator, 1);
                }
            }
        }
    }
}
