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
        private GameObject _prefabPlayer;
        private Dictionary<string, GameObject> _players;
        public ListenerPlayers(Dictionary<string, GameObject> players, GameObject prefabPlayer)
        {
            _players = players;
            _prefabPlayer = prefabPlayer;
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
            GameObject player = GameManager.Instantiate(_prefabPlayer);
            _players.Add(playerId, player);
            Debug.Log(jsonObj);
            Debug.Log("Player add");
        }

        private void OperationReplace(JToken jsonObj) {
            Debug.Log(jsonObj);
            Debug.Log("Player replace");
        }

        private void OperationRemove(JToken jsonObj) {
            string playerId = jsonObj["path"]["id"].ToString();
            GameObject player = _players[playerId];
            GameManager.Destroy(player);
            _players.Remove(playerId);
            Debug.Log(jsonObj);
            Debug.Log("Player remove");
        }
    }
    
}