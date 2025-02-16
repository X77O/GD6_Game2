using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketSpawner : MonoBehaviour
{
    public GameObject bucketPrefab;
    public Transform spawnPoint;
    public GameObject bell;
    private Bucket spawnedBucket;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckBellClick();
        }
    }

    void CheckBellClick()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider != null && hitCollider.gameObject == bell && DayCycle.day)
        {
            SpawnBucket();
            StartCoroutine(LoadTableScene());
        }

        // Now this should work when day is set to true, but perhaps need to clear or destroy the previous bucket
    }

    public void SpawnBucket()
    {
        GameObject bucketObject = Instantiate(bucketPrefab, spawnPoint.position, spawnPoint.rotation);
        spawnedBucket = bucketObject.GetComponent<Bucket>();

        if (spawnedBucket != null)
        {
            spawnedBucket.InitializeFish();
            int totalValue = spawnedBucket.CalculateTotalValue();
            Debug.Log("Total value of the bucket: " + totalValue);
            DayCycle.day = false; // Day set to false to only spawn 1 bucket per day, need to update this when next day comes
        }
    }

    IEnumerator LoadTableScene()
    {
        yield return new WaitForSeconds(5f);

        // Saving fish, this should work for multiple days, since we save before loading the table
        if (spawnedBucket != null)
        {
            GameManager.SaveFishes(spawnedBucket.fishList);
        }

        SceneManager.LoadScene("Table");
    }
}
