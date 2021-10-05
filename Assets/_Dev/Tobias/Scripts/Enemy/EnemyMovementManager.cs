using Codergram._Dev.Tobias.Scripts.Enemy.Movement;
using Codergram._Dev.Tobias.Scripts.Factories;
using UnityEngine;
using UnityEngine.AI;

namespace Codergram._Dev.Tobias.Scripts.Enemy
{
    public class EnemyMovementManager : MonoBehaviour
    {
        public Animator Animator { get; private set; }
        public Enemy Enemy { get; private set; }

        private NavMeshAgent _navMeshAgent;
        private IFactory<IMovement> _movementFactory;

        private void Awake()
        {
            Enemy = GetComponent<Enemy>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            _movementFactory = new EnemyMovementFactory(this);
        }

        private void Update()
        {
            AttackPlayer();
            _movementFactory.Create()?.Move();
        }

        private void AttackPlayer()
        {
            var shouldAttackPlayer = Enemy.GetPlayerDistance() < Enemy.AttackDistance;
            if (shouldAttackPlayer)
            {
                _navMeshAgent.SetDestination(Enemy.Player.position);
            }
        }
    }
}