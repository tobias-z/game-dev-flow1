using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private void Start()
    {
        InvokeRepeating(nameof(CreateEnemy), 4f, 4f);
    }

    private void CreateEnemy()
    {
        Instantiate(enemy);
    }
}
