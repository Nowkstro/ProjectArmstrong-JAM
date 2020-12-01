using System.Net.WebSockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomSpawner : MonoBehaviour {

    // private List<Transform> spawnPoints = new List<Transform>();
    // [HideInInspector] public List<Transform> nonSpawnedPoints = new List<Transform>();

    // [SerializeField] GameObject[] itemsPrefab = null;
    // [HideInInspector] public List<GameObject> nonSpawnedItems = new List<GameObject>();

    // public float spawnDelay = 2f;

    // void Start() {
    //     // Dynamically catching all spawn points
    //     for (int i = 0; i < transform.childCount; i++) {
    //         spawnPoints.Add(transform.GetChild(i));
    //     }
        
    //     // nonSpawnedItems and nonSpawnedPoint will be used to balance the game
    //     for (int i = 0; i < itemsPrefab.Length; i++) {
    //         nonSpawnedItems.Add(itemsPrefab[i]);
    //     }

    //     for (int i = 0; i < spawnPoints.Count; i++) {
    //         nonSpawnedPoints.Add(spawnPoints[i]);
    //     }

    //     InitialSpawnItems();
    // }

    // void InitialSpawnItems() {
    //     while (true) {
    //         int randItem = Random.Range(0, nonSpawnedItems.Count);
    //         int randSpawnPoint = Random.Range(0, nonSpawnedPoints.Count);

    //         Instantiate(
    //             nonSpawnedItems[randItem], 
    //             nonSpawnedPoints[randSpawnPoint].position, 
    //             Quaternion.identity
    //         );

    //         nonSpawnedItems.RemoveAt(randItem);
    //         nonSpawnedPoints.RemoveAt(randSpawnPoint);

    //         if (nonSpawnedItems.Count == 0)
    //             break;
    //     }
    // }

    // public void ItemCollectedInfo(ItemInfo ItemInfo) {
    //     StartCoroutine(SpawnItem(ItemInfo));
    // }

    // IEnumerator SpawnItem(ItemInfo ItemInfo) {
    //     foreach (GameObject prefab in itemsPrefab) {
    //         if (prefab.tag == ItemInfo.itemTag) {
    //             yield return new WaitForSeconds(spawnDelay);
    //             Instantiate(prefab, ItemInfo.spawnPosition, Quaternion.identity);
    //         }
    //     }
    // }

    public GameObject itemPrefab = default;
    private Transform[] spawnPositions = default;
    
    public int spawnAmount = default;
    public float spawnDelay = 2f;

    public void ItemCollectedInfo(ItemInfo ItemInfo) {
        StartCoroutine(SpawnItem(ItemInfo));
    }

    IEnumerator SpawnItem(ItemInfo ItemInfo) {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(itemPrefab, ItemInfo.spawnPosition, Quaternion.identity);
    }

    void Awake() {
        // Taking the number of positions dynamically
        spawnPositions = new Transform[gameObject.transform.childCount];

        // Adding to spawnPositions array
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            spawnPositions[i] = gameObject.transform.GetChild(i).transform;
        }
    }

    void Start() {
        List<int> positionsIndex = new List<int>();

        for (int i = 0; i < spawnPositions.Length; i++) {
            positionsIndex.Add(i);
        }

        for (int i = 0; i < spawnAmount; i++) {
            int randomPositionIndex = positionsIndex[Random.Range(0, positionsIndex.Count)];
            positionsIndex.Remove(randomPositionIndex);

            Instantiate(itemPrefab, spawnPositions[randomPositionIndex].position, Quaternion.identity);
        }
    }

}
