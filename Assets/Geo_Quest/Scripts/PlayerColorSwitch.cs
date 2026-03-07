using UnityEngine;

public class PlayerColorSwitch : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sr.color = new Color(1f, 0f, 0f); // Red
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = new Color(0f, 1f, 0f); // Green
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = new Color(0f, 0f, 1f); // Blue
        }
    }
}