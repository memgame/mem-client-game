using Colyseus;
using MemClientGame.Assets.Scripts.Controller;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace MemClientGame.Assets.Scripts.Network.Listeners.Players
{
    public class ListenerPlayersPosition : IRoomListener
    {
        public const string LISTENER_PATH = "players/:id/position/:attribute";
        private GameManager _gameManager;
        public ListenerPlayersPosition(GameManager gameManager)
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

        private void OperationAdd(JToken jsonObj)
        {
            Debug.Log(jsonObj);
            Debug.Log("PlayerPosition add");
        }

        private void OperationReplace(JToken jsonObj)
        {
            string playerId = jsonObj["path"]["id"].ToString();
            string attribute = jsonObj["path"]["attribute"].ToString();
            float value = float.Parse(jsonObj["value"].ToString());

            ControllerPlayer player = _gameManager.Players[playerId].GetComponent<ControllerPlayer>();

            if (attribute == "x")
            {
                player.MoveTo.x = value;

            } else if (attribute == "z")
            {
                player.MoveTo.z = value;
            }
            Debug.Log(jsonObj);
            Debug.Log("PlayerPostion replace");
        }

        private void OperationRemove(JToken jsonObj)
        {
            Debug.Log(jsonObj);
            Debug.Log("PlayerPostion remove");
        }
    }
}
