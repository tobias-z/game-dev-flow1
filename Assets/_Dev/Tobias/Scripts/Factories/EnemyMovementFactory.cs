using System;
using Codergram._Dev.Tobias.Scripts.Enemy;
using Codergram._Dev.Tobias.Scripts.Enemy.Movement;

namespace Codergram._Dev.Tobias.Scripts.Factories
{
    public class EnemyMovementFactory : IFactory<IMovement>
    {
        private readonly EnemyMovementManager _manager;
        
        public EnemyMovementFactory(EnemyMovementManager manager)
        {
            _manager = manager;
        }
        
        public IMovement Create()
        {
            var playerDistance = _manager.Enemy.GetPlayerDistance();
            if (ShouldRun(playerDistance))
                return new RifleRunMovement(_manager);
            if (playerDistance < 15)
                return new WalkingMovement(_manager);

            return null;
        }

        private bool ShouldRun(float playerDistance)
        {
            var isMoving = playerDistance < _manager.Enemy.AttackDistance;
            return playerDistance > 15 && isMoving;
        }
    }
}