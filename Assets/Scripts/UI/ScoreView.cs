using System;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private PlayerStatus _playerStatus;
        [SerializeField] private TextMeshProUGUI _textMesh;

        private void Start()
        {
            _textMesh.text = 0.ToString("D3");
            _playerStatus.KillCountAction += ChangeScore;
        }

        private void ChangeScore(int score)
        {
            _textMesh.text = score.ToString("D3");
        }
    }
}