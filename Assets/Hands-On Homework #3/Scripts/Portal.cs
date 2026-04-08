using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == HW3Structs.Tags.playerTag)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}