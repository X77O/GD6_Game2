using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public List<Fish> fishList = new List<Fish>();
    public int maxFishCount = 6;
    public Transform[] fishSlots;


    //  Seting the fish to the bucket, and setting the value of the fish
    public void InitializeFish()
    {
        for (int i = 0; i < maxFishCount; i++)
        {
            int prefabNumber = Random.Range(1, 4); // Generates 1, 2, or 3
            GameObject fishPrefab = Resources.Load<GameObject>($"Fish{prefabNumber}");

            if (fishPrefab != null)
            {
                GameObject fishObject = Instantiate(fishPrefab, transform);
                Fish fish = fishObject.GetComponent<Fish>();
                // Fish1 = 2, Fish2 = 3, Fish3 = 4 - VALUES
                fish.value = prefabNumber + 1;
                AddFish(fish);
            }
        }
    }

    public void AddFish(Fish fish)
    {
        if (fishList.Count < maxFishCount)
        {
            fishList.Add(fish);
            UpdateVisibleFish();
        }
    }

    // Showing only 3 fish at a time with positive z value

    public void UpdateVisibleFish()
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            if (i < 3 && i < fishSlots.Length)
            {
                fishList[i].transform.position = new Vector3(fishSlots[i].position.x, fishSlots[i].position.y, 3);
                fishList[i].gameObject.SetActive(true);
            }
            else
            {
                fishList[i].transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                fishList[i].gameObject.SetActive(false);
            }
        }
        // Bucket position is set to 1, so the white square is the bucket
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }

    // Value of bucket
    public int CalculateTotalValue()
    {
        int totalValue = 0;
        foreach (Fish fish in fishList)
        {
            totalValue += fish.value;
        }
        return totalValue;
    }
}