using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MemClientGame.Assets.Scripts.Network;
using System;
using MemClientGame.Assets.Scripts.Network.Listeners.Players;

namespace MemClientGame.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Text serverText; 
        public GameObject _prefabPlayer;
        private ColyseusClient _colyseusClient;
        private Dictionary<string, GameObject> _players = new Dictionary<string, GameObject>();
        // Start is called before the first frame update
        public async void Start()
        {
            var serverip = GetArg("-serverip");
            serverip = serverip != null ? serverip : "localhost";
            Debug.Log(serverip);

            var serverport = GetArg("-serverport");
            serverport = serverport != null ? serverport : "8080";
            Debug.Log(serverport);

            var roomname = GetArg("-roomname");
            roomname = roomname != null ? roomname : "match";
            Debug.Log(roomname);

            var token = GetArg("-token");
            Debug.Log(token);

            serverText.text = serverip + ":" + serverport + " room: " + roomname;

            _colyseusClient = new ColyseusClient(serverip, serverport);
            await _colyseusClient.ConnectToServer();
            var room = _colyseusClient.JoinRoom(roomname, token);
            room.Listen(ListenerPlayers.LISTENER_PATH, new ListenerPlayers(_players, _prefabPlayer).OnChange);
        }
        private static string GetArg(string name)
        {
            var args = System.Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == name && args.Length > i + 1)
                {
                    return args[i + 1];
                }
            }
            return null;
        }
    }
}