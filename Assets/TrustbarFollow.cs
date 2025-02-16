using UnityEngine;
using UnityEngine.UI;

public class TrustbarFollow : MonoBehaviour
{
    public Slider trustbar;
    public Vector3 offset; // Offset for positioning
    public Camera mainCamera;
    public RectTransform canvasRect;
    public MerchantScript merchant;

    void Update()
    {
        if (merchant != null)
        {
            // Trust value
            trustbar.value = merchant.GetTrust();
        }


        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position + offset);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, mainCamera, out Vector2 localPos);

        trustbar.GetComponent<RectTransform>().anchoredPosition = localPos;
    }
}
