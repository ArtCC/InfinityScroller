using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private float spawnTime, minSpawnTime, decreaseSpawnTime;

    private int obstaclesCounter;

    void Start() {
        StartCoroutine(Spawn());
    }

    public void StopSpawner() {
        StopAllCoroutines();
    }

    private void DecreaseSpawnTime() {
        if (obstaclesCounter == 5 && spawnTime > minSpawnTime) {
            spawnTime -= decreaseSpawnTime;

            obstaclesCounter = 0;
        }
    }

    private IEnumerator Spawn() {
        while (true) {
            int randomIndex = Random.Range(0, prefabs.Length);

            Instantiate(prefabs[randomIndex], GetRandomPosition(), Quaternion.identity);

            obstaclesCounter++;

            DecreaseSpawnTime();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private Vector2 GetRandomPosition() {        
        return new Vector2(transform.position.x, Random.Range(minHeight, maxHeight));
    }
}