using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerScore
{
    public string playerName;
    public float time;
    public int score;

    public PlayerScore(string playerName, float time, int score)
    {
        this.playerName = PlayerPrefs.GetString("name");
        this.time = time;
        this.score = score;
    }
}

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;
    private List<PlayerScore> leaderboard = new List<PlayerScore>();
    private string filePath;

    private void Awake()
    {
        instance = this;
        filePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadLeaderboard();
    }

    public void AddScore(string playerName, float time, int score)
    {
        leaderboard.Add(new PlayerScore(playerName, time, score));
        leaderboard.Sort((x, y) => y.time.CompareTo(x.score));
        SaveLeaderboard();
        Debug.Log("Leaderboard saved to: " + Application.persistentDataPath);
    }

    public List<PlayerScore> GetLeaderboard()
    {
        return leaderboard;
    }

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(new LeaderboardWrapper { leaderboard = this.leaderboard }, true);
        File.WriteAllText(filePath, json);
    }

    private void LoadLeaderboard()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            LeaderboardWrapper loadedData = JsonUtility.FromJson<LeaderboardWrapper>(json);
            leaderboard = loadedData.leaderboard;
        }
    }
}


[Serializable]
public class LeaderboardWrapper
{
    public List<PlayerScore> leaderboard;
}