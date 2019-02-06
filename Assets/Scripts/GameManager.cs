using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MemClientGame.Assets.Scripts.Network;
using System;

namespace MemClientGame.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Text serverText; 
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

            serverText.text = serverip + ":" + serverport + " room: " + roomname;

            _colyseusClient = new ColyseusClient(serverip, serverport);
            await _colyseusClient.ConnectToServer();
            var room = _colyseusClient.JoinRoom(roomname, token);
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