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
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f, 1), Random.Range(-1f, 1f), 0), Quaternion.identity);
        newEnemy.gameObject.tag = "Enemy";
        StartCoroutine(Spawn(interval, enemy));
    }
}
