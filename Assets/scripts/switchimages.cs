using UnityEngine;
using UnityEngine.UI;

public class switchimages : MonoBehaviour
{
    [SerializeField] private Sprite imageA;
    [SerializeField] private Sprite imageB;
    [SerializeField] private float swapInterval = 0.5f;

    private Image targetImage;
    private float timer;
    private bool isImageA = true;

    private void Awake()
    {
        targetImage = GetComponent<Image>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= swapInterval)
        {
            timer = 0f;
            isImageA = !isImageA;
            targetImage.sprite = isImageA ? imageA : imageB;
        }
    }
}
