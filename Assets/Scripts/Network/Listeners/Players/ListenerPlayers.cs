using System.Collections.Generic;
using Colyseus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace MemClientGame.Assets.Scripts.Network.Listeners.Players
{
    public class ListenerPlayers : IRoomListener
    {
        public const string LISTENER_PATH = "players/:id";
        private GameManager _gameManager;
        public ListenerPlayers(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void OnChange(DataChange obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonObj = JToken.Parse(jsonString);
            var operation = jsonObj["operation"].ToString();
            if (operation == "add")
            {
                OperationAdd(jsonObj);
            }
            else if (operation == "remove")
            {
                OperationRemove(jsonObj);
            }
            else if (operation == "replace")
            {
                OperationReplace(jsonObj);
            }
        }

        private void OperationAdd(JToken jsonObj) {
            string playerId = jsonObj["path"]["id"].ToString();
            string name = jsonObj["value"]["name"].ToString();
            float moveSpeed = float.Parse(jsonObj["value"]["moveSpeed"].ToString());
            //int health = int.Parse(jsonObj["value"]["health"].ToString());
            float positionX = float.Parse(jsonObj["value"]["position"]["x"].ToString());
            float positionY = float.Parse(jsonObj["value"]["position"]["y"].ToString());
            float positionZ = float.Parse(jsonObj["value"]["position"]["z"].ToString());


            GameObject player = Object.Instantiate(_gameManager.PrefabPlayer, new Vector3(positionX, positionY, positionZ), new Quaternion());
            _gameManager.Players.Add(playerId, player);

            if (playerId == _gameManager.GameRoom.sessionId)
            {
                _gameManager.CameraTarget = player.transform;
            }
            Debug.Log(jsonObj);
            Debug.Log("Player add");
        }

        private void OperationReplace(JToken jsonObj) {
            Debug.Log(jsonObj);
            Debug.Log("Player replace");
        }

        private void OperationRemove(JToken jsonObj) {
            string playerId = jsonObj["path"]["id"].ToString();
            GameObject player = _gameManager.Players[playerId];
            Object.Destroy(player);
            _gameManager.Players.Remove(playerId);
            Debug.Log(jsonObj);
            Debug.Log("Player remove");
        }
    }
    
}