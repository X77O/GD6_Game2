using UnityEngine;

public class BucketSpawner : MonoBehaviour
{
    public GameObject bucketPrefab;
    public Transform spawnPoint;
    public Bucket spawnedBucket;
    public int totalValue = 0;

    public void SpawnBucket()
    {
        GameObject bucketObject = Instantiate(bucketPrefab, spawnPoint.position, spawnPoint.rotation);
        spawnedBucket = bucketObject.GetComponent<Bucket>();

        if (spawnedBucket != null)
        {
            spawnedBucket.InitializeFish();
            totalValue = spawnedBucket.CalculateTotalValue();
            Debug.Log("Total value of the bucket: " + totalValue);

        }
    }
}