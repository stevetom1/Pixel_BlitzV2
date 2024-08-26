using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            string cutName = playerScore.playerName;
            if(playerScore.playerName.Length > 10) 
            {
                cutName = playerScore.playerName.Substring(0, 10);
            }
            cutName = cutName.PadRight(12);
            leaderboardContent.text += $"{cutName} {playerScore.time:F2}s {playerScore.score.ToString().PadLeft(6)}\n";
        }
    }
}
