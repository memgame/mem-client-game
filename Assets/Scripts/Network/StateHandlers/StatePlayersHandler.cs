using Colyseus.Schema;
using MemClientGame.Assets.Scripts.Controller;
using UnityEngine;
using Mem.Models;

namespace MemClientGame.Assets.Scripts.Network.StateHandlers
{
    public class StatePlayersHandler
    {
        private StatePlayers _statePlayers;
        private GameManager _gameManager;
        public StatePlayersHandler(StatePlayers statePlayers, GameManager gameManager)
        {
            _statePlayers = statePlayers;
            _gameManager = gameManager;
            _statePlayers.players.OnAdd += OnAddPlayer;
            _statePlayers.players.OnRemove += OnRemovePlayer;
            _statePlayers.players.OnChange += OnChangePlayer;
        }

        private void OnAddPlayer(object sender, KeyValueEventArgs<Player, string> e)
        {
            GameObject player = Object.Instantiate(
                _gameManager.PrefabPlayer,
                new Vector3(e.Value.position.x, e.Value.position.y, e.Value.position.z),
                new Quaternion());

            ControllerPlayer playerController = player.GetComponent<ControllerPlayer>();

            playerController.PlayerId = e.Value.id;
            playerController.Health = e.Value.health;
            playerController.HealthMax = e.Value.healthMax;
            playerController.Energy = e.Value.energy;
            playerController.EnergyMax = e.Value.energyMax;
            //player.transform.eulerAngles = new Vector3(0, e.Value.rotation, 0);
            playerController.DesiredRotation.y = e.Value.rotation;
            playerController.LocomationAnimationSpeedPercent = e.Value.locomationAnimationSpeedPercent;
            _gameManager.Players.Add(e.Value.id, player);

            if (e.Value.id == _gameManager.GameRoom.SessionId)
            {
                _gameManager.CameraTarget = player.transform;
            }
            Debug.Log("Player add");

            e.Value.OnChange += (object sender2, OnChangeEventArgs e2) =>
            {
                e2.Changes.ForEach((Colyseus.Schema.DataChange obj) =>
                {
                    Debug.Log(obj.Field);
                    switch(obj.Field)
                    {
                        case "position":
                        {
                            Position position = obj.Value as Position;
                            playerController.DesiredPosition.x = position.x;
                            playerController.DesiredPosition.z = position.z;
                            
                            Debug.Log("position changed");
                            Debug.Log(position.x + " " + position.z);
                            break;
                        }
                        case "rotation":
                        {
                            playerController.DesiredRotation.y = float.Parse(obj.Value.ToString());
                            break;
                        }
                        case "locomationAnimationSpeedPercent":
                        {
                            playerController.LocomationAnimationSpeedPercent = float.Parse(obj.Value.ToString());
                            break;
                        }
                        case "health":
                        {
                            playerController.Health = float.Parse(obj.Value.ToString());
                            break;
                        }
                        case "healthMax":
                        {
                            playerController.HealthMax = float.Parse(obj.Value.ToString());
                            break;
                        }
                        case "energy":
                        {
                            playerController.Energy = float.Parse(obj.Value.ToString());
                            break;
                        }
                        case "energyMax":
                        {
                            playerController.EnergyMax = float.Parse(obj.Value.ToString());
                            break;
                        }
                        case "isAlive":
                        {
                            playerController.IsAlive = bool.Parse(obj.Value.ToString());
                            break;
                        }   
                    }
                });
            };
        }

        private void OnRemovePlayer(object sender, KeyValueEventArgs<Player, string> e)
        {
            string playerId = e.Key;
            GameObject player = _gameManager.Players[playerId];
            Object.Destroy(player);
            _gameManager.Players.Remove(playerId);
            Debug.Log("Player remove");
        }

        private void OnChangePlayer(object sender, KeyValueEventArgs<Player, string> e)
        {

        }
    }
}