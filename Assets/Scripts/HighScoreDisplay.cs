using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighScoreDisplay : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        List<HighScoreEntry> highScores = HighScoreManager.instance.GetHighScores();
        highScoreText.text = "HIGH SCORES:\n";
        foreach (HighScoreEntry entry in highScores)
        {
            highScoreText.text += entry.playerName + ": " + entry.time.ToString("f2") + " seconds\n";
        }
    }
}
