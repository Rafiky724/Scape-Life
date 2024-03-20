using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; // Asigna el prefab del enemigo en el Inspector
    public float spawnInterval = 5f; // Intervalo de tiempo entre spawns
    public bool estaActivo = false;

    // Start is called before the first frame update
    void Start()
    {

        //InvokeRepeating("SpawnEnemy", 0f, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarSpawn()
    {

        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

}
