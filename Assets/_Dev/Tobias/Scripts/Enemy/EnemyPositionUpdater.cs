using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Codergram._Dev.Tobias.Scripts.Enemy
{
    public class EnemyPositionUpdater : IPositionUpdater
    {
        private readonly EnemySpawner _spawner;

        public EnemyPositionUpdater(EnemySpawner spawner)
        {
            _spawner = spawner;
        }

        public void UpdatePosition()
        {
            foreach (var theEnemy in _spawner.Enemies.Where(IsHittingPlayer()))
            {
                DeactivateEnemy(theEnemy);
                MoveEnemyToNewPosition(theEnemy);
                _spawner.StartCoroutine(ActivateEnemy(theEnemy));
            }
        }

        private static Func<Enemy, bool> IsHittingPlayer() =>
            theEnemy => theEnemy.GetPlayerDistance() < theEnemy.GetPlayerScale();

        private static void DeactivateEnemy(Enemy theEnemy) => theEnemy.gameObject.SetActive(false);

        private void MoveEnemyToNewPosition(Enemy theEnemy)
        {
            var idx = Random.Range(0, _spawner.SpawnPositions.Count);
            theEnemy.transform.position = _spawner.SpawnPositions[idx].transform.position;
        }

        private IEnumerator ActivateEnemy(Enemy theEnemy)
        {
            yield return new WaitForSeconds(_spawner.RespawnTime);
            theEnemy.gameObject.SetActive(true);
        }
    }
}