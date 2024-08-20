using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardUIManager : MonoBehaviour
{
    public TextMeshProUGUI leaderboardContent;

    void Start()
    {
        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        if (leaderboardContent == null)
        {
            Debug.LogError("Leaderboard Content is not assigned in the Inspector.");
            return;
        }

        List<PlayerScore> leaderboard = LeaderboardManager.instance.GetLeaderboard();
        leaderboardContent.text = "";

        foreach (PlayerScore playerScore in leaderboard)
        {
            leaderboardContent.text += $"{playerScore.playerName}: {playerScore.time:F2}s\n";
        }
    }

}