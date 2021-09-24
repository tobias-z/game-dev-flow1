using System;
using Codergram._Dev.Tobias.Scripts.Factories;
using TMPro;
using UnityEngine;

namespace Codergram._Dev.Tobias.Scripts.Movement
{
    public class RifleRunMovement : IMovement
    {
        private readonly EnemyMovementManager _manager;
        private static readonly int RifleRun = Animator.StringToHash("RifleRun");

        public RifleRunMovement(EnemyMovementManager manager)
        {
            _manager = manager;
        }

        public void Move()
        {
            _manager.Animator.SetTrigger(RifleRun);
        }
    }
}