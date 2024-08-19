using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;

    public List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

    private void Awake()
    {
        instance = this;
        LoadLeaderboard();
    }

    public void AddScore(string playerName, float time)
    {
        LeaderboardEntry entry = new LeaderboardEntry(playerName, time);
        leaderboard.Add(entry);
        leaderboard.Sort((x, y) => x.time.CompareTo(y.time)); // Sort by time (ascending)
        SaveLeaderboard();
    }

    public List<LeaderboardEntry> GetLeaderboard()
    {
        return leaderboard;
    }

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(new LeaderboardWrapper { entries = leaderboard });
        File.WriteAllText(Application.persistentDataPath + "/leaderboard.json", json);
    }

    private void LoadLeaderboard()
    {
        string path = Application.persistentDataPath + "/leaderboard.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            leaderboard = JsonUtility.FromJson<LeaderboardWrapper>(json).entries;
        }
    }
}

[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public float time;

    public LeaderboardEntry(string playerName, float time)
    {
        this.playerName = playerName;
        this.time = time;
    }
}

[System.Serializable]
public class LeaderboardWrapper
{
    public List<LeaderboardEntry> entries;
}
