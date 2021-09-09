using UnityEngine;
using UnityEngine.AI;

namespace Domain.Enemy
{
    public class MoveEnemyCommand : IEventCommand
    {
        private readonly Transform _player;
        private readonly NavMeshAgent _navMeshAgent;

        public MoveEnemyCommand(Transform player, NavMeshAgent navMeshAgent)
        {
            _player = player;
            _navMeshAgent = navMeshAgent;
        }

        public void Execute()
        {
            _navMeshAgent.SetDestination(_player.position);
        }

        public bool IsFinished()
        {
            return _navMeshAgent.remainingDistance < 0.1f || _navMeshAgent.isStopped;
        }
    }
}