using Colyseus;
using System;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mem.Models;

namespace MemClientGame.Assets.Scripts.Network
{
    public class ColyseusClient
    {
        public bool IsConnectedToServer {get; private set; } = false;
        private Client _client;
        private List<Room<StateRoot>> _rooms;
        private string _serverName;
        private string _port;
        private string _serverUri;

        public ColyseusClient(string serverName, string port)
        {
            Debug.Log("ColyseusClient created");
            _serverName = serverName;
            _port = port;
            _serverUri = "ws://" + this._serverName + ":" + this._port;
            _client = new Client(_serverUri);
            //_client.OnClose += (object sender, EventArgs e) => Debug.Log("ColyseusClient connection closed");
            _rooms = new List<Room<StateRoot>>();
        }

        public async Task<bool> ConnectToServer()
        {
            Debug.Log($"ColyseusClient connecting to {_serverUri}");
            try
            {
                await _client.Connect();
                Application.quitting += OnApplicationQuit;
                IsConnectedToServer = true;
                ClientRecv();
                Debug.Log("ColyseusClient connected to server successfully");
                return true;
            }
            catch
            {
                Debug.LogWarning("ColyseusCLient connection to server FAILED");
                return false;
            }
        }

        public Room<StateRoot> JoinRoom(string roomName, string token)
        {
            var options = new Dictionary<string, object>();
            options.Add("token", token);
            Room<StateRoot> room = _client.Join<StateRoot>(roomName, options);
            Debug.Log("sessionid" + room.Id);
            _rooms.Add(room);
            room.OnReadyToConnect += async (sender, e) =>
            {
                await room.Connect();
                Debug.Log($"ColyseusClient connected to {room.Name} room successfully");
            };
            return room;
        }

        public void CloseConnectionToServer()
        {
            foreach(Room<StateRoot> room in _rooms)
            {
                room.Leave();
                Debug.Log($"ColyseusClient room: {room.Id} left");
            }
            _client.Close();
            Debug.Log($"ColyseusClient: {_client.Id} closed");
            IsConnectedToServer = false;
        }

        private async void ClientRecv()
        {
            while (IsConnectedToServer)
            {
                _client.Recv();
                await Task.Delay(TimeSpan.FromMilliseconds(5));
            }
        }

        private void OnApplicationQuit()
        {
            CloseConnectionToServer();
        }
    }
}