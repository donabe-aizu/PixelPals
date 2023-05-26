using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnemyBaseHPView : MonoBehaviour
    {
        [SerializeField] private EnemyBaseStatus enemyBaseStatus;
        [SerializeField] private Slider hpSlider;

        private float maxHP;

        private void Start()
        {
            maxHP = enemyBaseStatus.MaxHP;
            hpSlider.value = 1f;
            enemyBaseStatus.ChangeHP += EnemyBaseHP;
        }

        private void EnemyBaseHP(float nowHP)
        {
            hpSlider.value = nowHP / maxHP;
        }
    }
}