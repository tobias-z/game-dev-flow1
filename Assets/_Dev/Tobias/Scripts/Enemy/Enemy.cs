using UnityEngine;

namespace Codergram._Dev.Tobias.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float attackDistance = 30f;
        public Transform Player => player;
        public float AttackDistance => attackDistance;

        public float GetPlayerDistance() => Vector3.Distance(player.position, transform.position);

        public float GetPlayerScale() => player.transform.localScale.x + 1;
    }
}