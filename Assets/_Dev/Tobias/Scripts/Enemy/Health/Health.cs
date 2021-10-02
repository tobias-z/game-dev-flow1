using UnityEngine;
using UnityEngine.UI;

namespace Codergram._Dev.Tobias.Scripts.Enemy.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        [Range(0, 200)][SerializeField] private float maxHealth;
        [SerializeField] private Image health;

        public void TakeDamage(float amount)
        {
            var healthToReduce = amount / maxHealth;
            health.fillAmount -= healthToReduce;
        }
    }
}