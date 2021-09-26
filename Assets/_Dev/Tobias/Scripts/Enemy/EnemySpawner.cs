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

        [Header("Settings")] [SerializeField] private List<GameObject> spawnPositions;
        [Header("Settings")] [SerializeField] private float respawnTime = 2f;
        public List<Enemy> Enemies { get; } = new List<Enemy>();
        public List<GameObject> SpawnPositions => spawnPositions;
        public float RespawnTime => respawnTime;

        private IPositionUpdater _updater;

        private void Awake()
        {
            SpawnEnemies();
            _updater = new PositionUpdater(this);
        }
        
        private void SpawnEnemies()
        {
            foreach (var spawnPosition in spawnPositions)
            {
                Enemies.Add(Instantiate(enemy, spawnPosition.transform.position, Quaternion.identity));
            }
        }

        private void Update()
        {
            _updater.UpdatePosition();
        }

    }
}