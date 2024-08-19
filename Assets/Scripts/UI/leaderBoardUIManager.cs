using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leaderboardUIManager : MonoBehaviour
{
    public TextMeshProUGUI leaderboardContent;

    void Start()
    {
        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        List<LeaderboardEntry> leaderboard = LeaderboardManager.instance.GetLeaderboard();
        leaderboardContent.text = "";

        foreach (LeaderboardEntry entry in leaderboard)
        {
            leaderboardContent.text += $"{entry.playerName}: {entry.time:F2}s\n";
        }
    }
}
