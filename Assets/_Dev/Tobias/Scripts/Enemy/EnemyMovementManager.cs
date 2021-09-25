using Codergram._Dev.Tobias.Scripts.Factories;
using UnityEngine;
using UnityEngine.AI;

namespace Codergram._Dev.Tobias.Scripts.Enemy
{
    public class EnemyMovementManager : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Animator Animator { get; private set; }
        public Enemy Enemy { get; private set; }

        private EnemyMovementFactory _enemyMovementFactory;

        private void Awake()
        {
            Enemy = GetComponent<Enemy>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            _enemyMovementFactory = new EnemyMovementFactory(this);
        }

        private void Update()
        {
            AttackPlayer();
            _enemyMovementFactory.Create()?.Move();
        }
        
        private void AttackPlayer()
        {
            var shouldAttackPlayer = Enemy.GetPlayerDistance() < Enemy.AttackDistance;
            if (shouldAttackPlayer)
            {
                NavMeshAgent.SetDestination(Enemy.Player.position);
            }
        }
    }
}