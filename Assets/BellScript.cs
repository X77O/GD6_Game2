using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BellScript : MonoBehaviour
{
    public GameObject bell;
    public GameObject bucketSpawner; // Reference to the BucketSpawner

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
            DayCycle.day = false; // Day set to false to only spawn 1 bucket per day, need to update this when next day comes
            StartCoroutine(LoadTableScene());
            GameObject merchant = GameObject.FindWithTag("Merchant");
            if (merchant != null)
            {
                merchant.GetComponent<MerchantScript>().OnBellPressed();
            }
        }
    }

    IEnumerator LoadTableScene()
    {
        yield return new WaitForSeconds(5f);

        // Saving fish, this should work for multiple days, since we save before loading the table
        BucketSpawner spawner = bucketSpawner.GetComponent<BucketSpawner>();
        if (spawner.spawnedBucket != null)
        {
            GameManager.SaveFishes(spawner.spawnedBucket.fishList);
        }

        SceneManager.LoadScene("Table");
    }
}