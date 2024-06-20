using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    private string filePath;
    private List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    private int maxHighScores = 5;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Path.Combine(Application.persistentDataPath, "highscores.json");
        LoadHighScores();
    }

    public void AddHighScore(string playerName, float time)
    {
        HighScoreEntry newEntry = new HighScoreEntry { playerName = playerName, time = time };
        highScores.Add(newEntry);
        highScores.Sort((x, y) => x.time.CompareTo(y.time));

        if (highScores.Count > maxHighScores)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        SaveHighScores();
    }

    private void LoadHighScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            highScores = JsonConvert.DeserializeObject<List<HighScoreEntry>>(json);
        }
    }

    private void SaveHighScores()
    {
        string json = JsonConvert.SerializeObject(highScores, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public List<HighScoreEntry> GetHighScores()
    {
        return highScores;
    }
}

[System.Serializable]
public class HighScoreEntry
{
    public string playerName;
    public float time;
}
