using UnityEngine;

public class SkyChange : MonoBehaviour
{
    public Sprite[] sprites;

    // Update is called once per frame
    void Update()
    {
        if (DayCycle.day)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }

        if (!DayCycle.day)
        {
            Debug.Log(DayCycle.day);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }
}
