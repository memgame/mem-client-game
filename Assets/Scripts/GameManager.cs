using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MemClientGame.Assets.Scripts.Network;
using System;
//using MemClientGame.Assets.Scripts.Network.Listeners.Players;
using Colyseus;

namespace MemClientGame.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Text ServerText; 
        public GameObject PrefabPlayer;
        public Transform CameraTarget;
        public Room<StateRoot> GameRoom;
        public Dictionary<string, GameObject> Players = new Dictionary<string, GameObject>();
        private ColyseusClient _colyseusClient;
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

            ServerText.text = serverip + ":" + serverport + " room: " + roomname;

            _colyseusClient = new ColyseusClient(serverip, serverport);
            await _colyseusClient.ConnectToServer();
            GameRoom = _colyseusClient.JoinRoom(roomname, token);
            //GameRoom.Listen(ListenerPlayers.LISTENER_PATH, new ListenerPlayers(this).OnChange);
            //GameRoom.Listen(ListenerPlayersPosition.LISTENER_PATH, new ListenerPlayersPosition(this).OnChange);
            //GameRoom.Listen(ListenerPlayersLocomationAnimationSpeedPercent.LISTENER_PATH, new ListenerPlayersLocomationAnimationSpeedPercent(this).OnChange);
            //GameRoom.Listen(ListenerPlayersRotation.LISTENER_PATH, new ListenerPlayersRotation(this).OnChange);
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