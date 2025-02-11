using UnityEngine;
using UnityEngine.UI;

public class CoinSlider : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject coinStackPrefab;
    public Slider coinSlider;
    public Transform coinContainer;
    public float gap = 0.1f; // Gap between coins and stacks

    void Update()
    {
        // Clear previous coins
        foreach (Transform child in coinContainer)
        {
            Destroy(child.gameObject);
        }

        int coinCount = (int)coinSlider.value;
        int stackCount = coinCount / 4;
        int individualCoins = coinCount % 4;

        // Instantiate coin stacks
        for (int i = 0; i < stackCount; i++)
        {
            GameObject stack = Instantiate(coinStackPrefab, coinContainer);
            stack.transform.localPosition = new Vector3(i * gap, 0, 0);
        }

        // Instantiate individual coins
        for (int i = 0; i < individualCoins; i++)
        {
            GameObject coin = Instantiate(coinPrefab, coinContainer);
            coin.transform.localPosition = new Vector3((stackCount + i) * gap, 0, 0);
        }
    }
}