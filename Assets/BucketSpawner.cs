using UnityEngine;

public class BucketSpawner : MonoBehaviour
{
    public GameObject bucketPrefab;
    public Transform spawnPoint;
    public KeyCode spawnKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnBucket();
        }
    }

    void SpawnBucket()
    {
        GameObject bucketObject = Instantiate(bucketPrefab, spawnPoint.position, spawnPoint.rotation);
        Bucket bucket = bucketObject.GetComponent<Bucket>();

        if (bucket != null)
        {
            bucket.InitializeFish();
            int totalValue = bucket.CalculateTotalValue();
            Debug.Log("Total value of the bucket: " + totalValue);
        }
        else
        {
            Debug.LogError("Bucket component not found!");
        }
    }
}
