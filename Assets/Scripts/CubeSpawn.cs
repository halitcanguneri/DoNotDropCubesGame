using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    public GameObject blueCubePrefab;
    public GameObject brownCubePrefab;
    public GameObject pinkCubePrefab;

    public Transform spawnArea;

    void Start()
    {
        InvokeRepeating("SpawnBlueCubePrefab", 0f, 6f); 
        InvokeRepeating("SpawnBrownCubePrefab", 2f, 6f); 
        InvokeRepeating("SpawnPinkCubePrefab", 4f, 6f);
    }

    void SpawnBlueCubePrefab()
    {
        Vector3 spawnPosition = spawnArea.position;

        Instantiate(blueCubePrefab, GetRandomSpawnPosition(spawnPosition), Quaternion.identity);
        
    }
    void SpawnBrownCubePrefab()
    {
        Vector3 spawnPosition = spawnArea.position;

        
        Instantiate(brownCubePrefab, GetRandomSpawnPosition(spawnPosition), Quaternion.identity);
       
    }
    void SpawnPinkCubePrefab()
    {
        Vector3 spawnPosition = spawnArea.position;

        
        Instantiate(pinkCubePrefab, GetRandomSpawnPosition(spawnPosition), Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition(Vector3 basePosition)
    {
        float spawnOffset = Random.Range(-10f, 10f); // X ve Z ekseni için rastgele offset deðeri
        return new Vector3(basePosition.x + spawnOffset, basePosition.y, basePosition.z + spawnOffset);
    }
}
