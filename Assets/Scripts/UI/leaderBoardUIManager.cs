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
        List<PlayerScore> leaderboard = LeaderboardManager.instance.GetLeaderboard();
        leaderboardContent.text = "";

        foreach (PlayerScore playerScore in leaderboard)
        {
            leaderboardContent.text += $"{playerScore.playerName}: {playerScore.time:F2}s\n";
        }
    }
}