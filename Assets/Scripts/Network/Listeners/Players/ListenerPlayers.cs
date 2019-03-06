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
        GameManager _gameManger;
        public ListenerPlayers(GameManager gameManager)
        {
            _gameManger = gameManager;
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
            GameObject player = Object.Instantiate(_gameManger.PrefabPlayer);
            _gameManger.Players.Add(playerId, player);
            Debug.Log(jsonObj);
            Debug.Log("Player add");
        }

        private void OperationReplace(JToken jsonObj) {
            Debug.Log(jsonObj);
            Debug.Log("Player replace");
        }

        private void OperationRemove(JToken jsonObj) {
            string playerId = jsonObj["path"]["id"].ToString();
            GameObject player = _gameManger.Players[playerId];
            Object.Destroy(player);
            _gameManger.Players.Remove(playerId);
            Debug.Log(jsonObj);
            Debug.Log("Player remove");
        }
    }
    
}