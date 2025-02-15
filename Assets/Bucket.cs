using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public List<Fish> fishList = new List<Fish>();
    public int maxFishCount = 6;
    public Transform[] fishSlots;

    public void InitializeFish()
    {
        for (int i = 0; i < maxFishCount; i++)
        {
            int randomValue = Random.Range(1, 4);
            GameObject fishPrefab = Resources.Load<GameObject>($"Fish{randomValue}");

            if (fishPrefab != null)
            {
                GameObject fishObject = Instantiate(fishPrefab, transform);
                Fish fish = fishObject.GetComponent<Fish>();
                fish.value = randomValue;
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

    public void UpdateVisibleFish()
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            if (i < 3 && i < fishSlots.Length)
            {
                fishList[i].transform.position = fishSlots[i].position;
                fishList[i].gameObject.SetActive(true);
            }
            else
            {
                fishList[i].gameObject.SetActive(false);
            }
        }
    }

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
