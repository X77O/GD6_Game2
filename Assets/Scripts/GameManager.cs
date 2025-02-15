using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<FishData> savedFishes = new List<FishData>();

    public static void SaveFishes(List<Fish> fishList)
    {
        savedFishes.Clear();
        foreach (Fish fish in fishList)
        {
            savedFishes.Add(new FishData(fish.value));
        }
    }

    public static List<FishData> GetSavedFishes()
    {
        return savedFishes;
    }
}

[System.Serializable]
public class FishData
{
    public int value;

    public FishData(int value)
    {
        this.value = value;
    }
}
