using UnityEngine;

public class HealthBarDisplay : MonoBehaviour
{
    public Transform fill;

    private float initialX;
    private float initialY;

    void Start()
    {
        if (fill != null)
        {
            initialX = fill.localScale.x;
            initialY = fill.localScale.y;
        }
    }

    public void SetHealth(float normalizedValue)
    {
        if (fill != null)
        {
            fill.localScale = new Vector3(normalizedValue * initialX, initialY, 1f);
        }
    }
}
