using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject lightPrefab;

    [SerializeField]
    private float spawnInterval = 3.5f;
    // Start is called before the first frame updatez
    void Start()
    {
        StartCoroutine(Spawn(spawnInterval, lightPrefab));
    }

    private IEnumerator Spawn(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(Spawn(interval, enemy));
    }
}
