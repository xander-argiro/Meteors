using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource audioSource;
    public AudioClip killPlayer;

    public int score = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: 0";
        gameOverText.enabled = false;
    }

    public void AddScore()
    {
        score++;

        scoreText.text = "Score: " + score;
    }

    public static void GameOver()
    {
        Instance.audioSource.PlayOneShot(Instance.killPlayer);

        Instance.gameOverText.enabled = true;

        Instance.StartCoroutine(Instance.Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
