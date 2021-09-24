using System;
using Codergram._Dev.Tobias.Scripts.Factories;
using UnityEngine;
using UnityEngine.AI;

namespace Codergram._Dev.Tobias.Scripts
{
    public class EnemyMovementManager : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float attackDistance = 30f;
        
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Animator Animator { get; private set; }
        public float AttackDistance => attackDistance;
        
        private EnemyMovementFactory _enemyMovementFactory;
        
        public float PlayerDistance() => Vector3.Distance(player.position, transform.position);
        
        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            _enemyMovementFactory = new EnemyMovementFactory(this);
        }

        private void Update()
        {
            AttackPlayer();
            _enemyMovementFactory.Create().Move();
        }
        
        private void AttackPlayer()
        {
            var shouldAttackPlayer = PlayerDistance() < AttackDistance;
            if (shouldAttackPlayer)
            {
                NavMeshAgent.SetDestination(player.position);
            }
        }
    }
}