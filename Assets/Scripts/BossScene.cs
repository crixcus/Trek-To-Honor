using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene("Boss Fight");
    }
}
