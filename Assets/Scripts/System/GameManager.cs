using Player;
using UnityEngine;

namespace System
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerStatus _playerStatus;
        [SerializeField] private EnemyBaseStatus _enemyBaseStatus;
        [SerializeField] private GameObject _gameClearUI;
        [SerializeField] private GameObject _gameOverUI;

        private void Start()
        {
            _playerStatus.PlayerHPChangeAction += PlayerHP;
            _enemyBaseStatus.ChangeHP += EnemyBaseHP;
        }

        private void PlayerHP(float nowHP)
        {
            if (nowHP <= 0)
            {
                GameOver();
            }
        }

        private void EnemyBaseHP(float nowHP)
        {
            if (nowHP <= 0)
            {
                GameClear();
            }
        }

        private void GameClear()
        {
            _gameClearUI.SetActive(true);
        }

        private void GameOver()
        {
            _gameOverUI.SetActive(true);
        }
    }
}