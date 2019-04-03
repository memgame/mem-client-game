using Colyseus.Schema;
using UnityEngine;

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
        }

        private void OnAddPlayer(object sender, KeyValueEventArgs<Player, string> e)
        {
            string playerId = e.Value.id;
            string name = e.Value.name;
            float moveSpeed = e.Value.moveSpeed;
            float rotation = e.Value.rotation;
            float positionX = 0f;
            float positionY = 0f;
            float positionZ = 0f;


            GameObject player = Object.Instantiate(_gameManager.PrefabPlayer, new Vector3(positionX, positionY, positionZ), new Quaternion());
            player.transform.eulerAngles = new Vector3(0, rotation, 0);
            _gameManager.Players.Add(playerId, player);

            if (playerId == _gameManager.GameRoom.SessionId)
            {
                _gameManager.CameraTarget = player.transform;
            }
            Debug.Log("Player add");
        }

        private void OnRemovePlayer(object sender, KeyValueEventArgs<Player, string> e)
        {
            throw new System.NotImplementedException();
        }

        private void OnChangePlayer(object sender, KeyValueEventArgs<Player, string> e)
        {
            string playerId = e.Key;
            GameObject player = _gameManager.Players[playerId];
            Object.Destroy(player);
            _gameManager.Players.Remove(playerId);
            Debug.Log("Player remove");
        }
    }
}