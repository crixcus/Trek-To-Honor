using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [Header("References")]
    public GameObject GameOverScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreFinal;
    public GameObject HUD;

    public int soulScore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverScreen.SetActive(false); 
        HUD.SetActive(true);
    }

    void Update()
    {
        scoreText.text = "Souls Eradicated : " + soulScore.ToString();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void GameOver()
    {
        if (!GameOverScreen.activeInHierarchy)
        {
            SoundManager.Instance.PlayGameOverSound();
            GameOverScreen.SetActive(true);
            HUD.SetActive(false);
            scoreFinal.text = "Souls Eradicated : " + soulScore.ToString();
            Time.timeScale = 0f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
