using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab2;
    public GameObject fishPrefab3;
    public GameObject fishPrefab4;
    public Bucket bucket;

    void Start()
    {
        for (int i = 0; i < bucket.maxFishCount; i++)
        {
            int randomValue = Random.Range(2, 5);
            GameObject fishPrefab = null;

            switch (randomValue)
            {
                case 2:
                    fishPrefab = fishPrefab2;
                    break;
                case 3:
                    fishPrefab = fishPrefab3;
                    break;
                case 4:
                    fishPrefab = fishPrefab4;
                    break;
            }

            if (fishPrefab != null)
            {
                GameObject fishObject = Instantiate(fishPrefab);
                Fish fish = fishObject.GetComponent<Fish>();
                fish.value = randomValue;
                bucket.AddFish(fish);
            }
        }
    }
}