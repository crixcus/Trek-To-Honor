using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
    }
}
