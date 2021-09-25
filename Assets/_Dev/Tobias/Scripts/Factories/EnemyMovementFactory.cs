using System;
using Codergram._Dev.Tobias.Scripts.Enemy;
using Codergram._Dev.Tobias.Scripts.Enemy.Movement;

namespace Codergram._Dev.Tobias.Scripts.Factories
{
    public class EnemyMovementFactory
    {
        private readonly EnemyMovementManager _manager;
        
        public EnemyMovementFactory(EnemyMovementManager manager)
        {
            _manager = manager;
        }
        
        public IMovement Create()
        {
            var playerDistance = _manager.Enemy.GetPlayerDistance();
            if (ShouldRun())
                return new RifleRunMovement(_manager);
            if (playerDistance < 15)
                return new WalkingMovement(_manager);

            return null;
        }

        private bool ShouldRun()
        {
            var playerDistance = _manager.Enemy.GetPlayerDistance();
            var isMoving = playerDistance < _manager.Enemy.AttackDistance;
            return playerDistance > 15 && isMoving;
        }
    }
}