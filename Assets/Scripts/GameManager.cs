using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemClientGame.Assets.Scripts.Network;
using System;

namespace MemClientGame.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private ColyseusClient _colyseusClient;
        private string cmdInfo = "";
        // Start is called before the first frame update
        public async void Start()
        {
            string[] arguments = Environment.GetCommandLineArgs();
                foreach(string arg in arguments)
                {
                    cmdInfo += arg.ToString() + "\n ";
                }
                Debug.Log(cmdInfo);
                Debug.Log(GetArg("-projectpath"));
                Debug.Log(GetArg("-serverip"));
                Debug.Log(GetArg("-serverport"));
                Debug.Log(GetArg("-roomname"));
            /*
            _colyseusClient = new ColyseusClient("localhost", "8080");
            await _colyseusClient.ConnectToServer();
            var room = _colyseusClient.JoinRoom("match");
            */
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