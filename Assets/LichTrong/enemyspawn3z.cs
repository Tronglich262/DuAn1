using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyspawn2: MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] float spwanRate = 2.5f, spawnRadius = 4f;
    private float spawnTimer = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spwanRate)
        {
            spawnEnemy();
            spawnTimer = 0;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
    void spawnEnemy()
    {
        Vector2 randomPositon = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab2, randomPositon, Quaternion.identity);
    }
}
