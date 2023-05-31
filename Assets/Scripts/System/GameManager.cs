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

        private Pose _initialPlayerPose;

        private void Start()
        {
            _initialPlayerPose = new Pose(_playerStatus.transform.position,_playerStatus.transform.rotation);
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
            _playerStatus.transform.position = _initialPlayerPose.position;
            _playerStatus.transform.rotation = _initialPlayerPose.rotation;
        }
    }
}