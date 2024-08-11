using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text timerText;

    private float startTime;
    private bool isGameActive = false;
    private int checkpointsPassed = 0;
    private int totalCheckpoints = 6;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (isGameActive)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void StartGame()
    {
        startTime = Time.time;
        isGameActive = true;
    }

    public void CheckpointReached()
    {
        checkpointsPassed++;
        if (checkpointsPassed >= totalCheckpoints)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        isGameActive = false;
        float finishTime = Time.time - startTime;
        HighScoreManager.instance.AddHighScore(MainMenu.playerName, finishTime);
        SceneManager.LoadScene("Main Menu");
    }
}
