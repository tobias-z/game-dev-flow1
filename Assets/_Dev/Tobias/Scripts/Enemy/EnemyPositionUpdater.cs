using System.Collections;
using System.Linq;
using UnityEngine;

namespace Codergram._Dev.Tobias.Scripts.Enemy
{
    public class PositionUpdater : IPositionUpdater
    {
        private readonly EnemySpawner _enemySpawner;

        public PositionUpdater(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        public void UpdatePosition()
        {
            foreach (var theEnemy in _enemySpawner.Enemies.Where(
                theEnemy => theEnemy.GetPlayerDistance() < theEnemy.GetPlayerScale()))
            {
                DeactivateEnemy(theEnemy);
                MoveEnemyToNewPosition(theEnemy);
                _enemySpawner.StartCoroutine(ActivateEnemy(theEnemy));
            }
        }

        private static void DeactivateEnemy(Enemy theEnemy) => theEnemy.gameObject.SetActive(false);

        private void MoveEnemyToNewPosition(Enemy theEnemy)
        {
            var idx = Random.Range(0, _enemySpawner.SpawnPositions.Count);
            theEnemy.transform.position = _enemySpawner.SpawnPositions[idx].transform.position;
        }

        private IEnumerator ActivateEnemy(Enemy theEnemy)
        {
            yield return new WaitForSeconds(_enemySpawner.RespawnTime);
            theEnemy.gameObject.SetActive(true);
        }
    }
}