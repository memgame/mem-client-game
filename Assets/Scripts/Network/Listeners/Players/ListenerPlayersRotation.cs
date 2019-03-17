using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colyseus;
using MemClientGame.Assets.Scripts.Controller;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace MemClientGame.Assets.Scripts.Network.Listeners.Players
{
    public class ListenerPlayersRotation : IRoomListener
    {
        public const string LISTENER_PATH = "players/:id/rotation";
        private GameManager _gameManager;
        public ListenerPlayersRotation(GameManager gameManager)
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
            Debug.Log("PlayerRotation add");
        }

        private void OperationReplace(JToken jsonObj)
        {
            string playerId = jsonObj["path"]["id"].ToString();
            float value = float.Parse(jsonObj["value"].ToString());
            ControllerPlayer player = _gameManager.Players[playerId].GetComponent<ControllerPlayer>();
            player.DesiredRotation.y = value;
            Debug.Log(jsonObj);
            Debug.Log("PlayerRotation replace");
        }

        private void OperationRemove(JToken jsonObj)
        {
            Debug.Log(jsonObj);
            Debug.Log("PlayerRotation remove");
        }
    }
}
