using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHPView : MonoBehaviour
    {
        [SerializeField] private PlayerStatus _playerStatus;
        [SerializeField] private Slider hpSlider;

        private float maxHP;

        private void Start()
        {
            maxHP = _playerStatus.MaxHP;
            hpSlider.value = 1f;
            _playerStatus.PlayerHPChangeAction += PlayerHP;
        }

        private void PlayerHP(float nowHP)
        {
            hpSlider.value = nowHP / maxHP;
        }
    }
}