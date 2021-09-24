using Codergram._Dev.Tobias.Scripts.Factories;
using TMPro;
using UnityEngine;

namespace Codergram._Dev.Tobias.Scripts.Movement
{
    public class WalkingMovement : IMovement
    {
        private readonly EnemyMovementManager _manager;
        private static readonly int Walk = Animator.StringToHash("Walk");

        public WalkingMovement(EnemyMovementManager manager)
        {
            _manager = manager;
        }

        public void Move()
        {
            _manager.Animator.SetTrigger(Walk);
        }
    }
}