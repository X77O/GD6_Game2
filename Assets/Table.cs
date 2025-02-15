using System.Collections.Generic;
using UnityEngine;

public class TableSceneManager : MonoBehaviour
{
    public GameObject fishPrefab1;
    public GameObject fishPrefab2;
    public GameObject fishPrefab3;
    public Transform[] fishPositions;

    void Start()
    {
        // As soon as the scene is loaded, we load the fishes from the bucket

        List<FishData> fishes = GameManager.GetSavedFishes();
        Debug.Log("Number of fishes loaded: " + fishes.Count);

        for (int i = 0; i < fishes.Count && i < fishPositions.Length; i++)
        {
            GameObject fishPrefab = GetFishPrefab(fishes[i].value);
            //Debug.Log("Fish value: " + fishes[i].value);

            if (fishPrefab != null)
            {
                GameObject fishObject = Instantiate(fishPrefab, fishPositions[i].position, Quaternion.identity);
                Fish fish = fishObject.GetComponent<Fish>();
                fish.value = fishes[i].value;
                //Debug.Log("Fish instantiated with value: " + fish.value);
            }
        }
    }

    GameObject GetFishPrefab(int value)
    {
        switch (value)
        {
            case 2: return fishPrefab1;
            case 3: return fishPrefab2;
            case 4: return fishPrefab3;
            default: return null;
        }
    }
}