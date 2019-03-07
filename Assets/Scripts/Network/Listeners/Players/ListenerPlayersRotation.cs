using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colyseus;
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
            Debug.Log("hey" + Time.fixedTime);
            Debug.Log(value);

            GameObject player = _gameManager.Players[playerId];
            player.transform.eulerAngles = new Vector3(0, value, 0);

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
