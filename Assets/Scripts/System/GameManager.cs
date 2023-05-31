using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerStatus _playerStatus;
        [SerializeField] private EnemyBaseStatus _enemyBaseStatus;
        [SerializeField] private GameObject _gameClearUI;
        [SerializeField] private GameObject _gameOverUI;

        private Transform initialPlayerTransform;

        private void Start()
        {
            initialPlayerTransform = _playerStatus.transform;
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

        public void ReturnTitle()
        {
            SceneManager.LoadScene(0);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Respawn()
        {
            _playerStatus.transform.position = initialPlayerTransform.position;
            _playerStatus.transform.rotation = initialPlayerTransform.rotation;
        }
    }
}