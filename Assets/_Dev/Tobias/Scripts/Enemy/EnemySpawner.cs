using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Codergram._Dev.Tobias.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        
        [Header("Settings")]
        [SerializeField] private List<GameObject> spawnPositions;

        [Header("Settings")]
        [SerializeField] private float respawnTime = 2f;
        

        private readonly List<Enemy> _enemies = new List<Enemy>();

        private void Awake()
        {
            SpawnEnemies();
        }

        private void Update()
        {
            UpdateEnemyPositions();
        }

        private void SpawnEnemies()
        {
            foreach (var spawnPosition in spawnPositions)
            {
                _enemies.Add(Instantiate(enemy, spawnPosition.transform.position, Quaternion.identity));
            }
        }
        
        private void UpdateEnemyPositions()
        {
            foreach (var theEnemy in _enemies.Where(theEnemy => theEnemy.GetPlayerDistance() < theEnemy.GetPlayerScale()))
            {
                DeactivateEnemy(theEnemy);
                MoveEnemyToNewPosition(theEnemy);
                StartCoroutine(ActivateEnemy(theEnemy));
            }
        }

        private void MoveEnemyToNewPosition(Enemy theEnemy)
        {
            var idx = Random.Range(0, spawnPositions.Count);
            theEnemy.transform.position = spawnPositions[idx].transform.position;
        }

        private IEnumerator ActivateEnemy(Enemy theEnemy)
        {
            yield return new WaitForSeconds(respawnTime);
            theEnemy.gameObject.SetActive(true);
        }

        private static void DeactivateEnemy(Enemy theEnemy) => theEnemy.gameObject.SetActive(false);
    }
}