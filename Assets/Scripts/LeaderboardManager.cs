using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;

public class LeaderboardManager : MonoBehaviour {

	void Start ()
	{
		#if UNITY_ANDROID 
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;

		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
		#endif
	}

	#region GAME_CENTER
	public static void AuthenticateToGameCenter()
	{
		Social.localUser.Authenticate(success =>
			{
				if (success)
				{
					GameModel.Instance.IsGameCenterAuthenticated = true;
					if(GameModel.Instance.IsLeaderboardTapped) {
						ShowLeaderboard();
						GameModel.Instance.IsLeaderboardTapped = false;
					}
					Debug.Log("Authentication successful");
				}
				else
				{
					GameModel.Instance.IsGameCenterAuthenticated = false;
					Debug.Log("Authentication failed");
				}
			});
	}
	public static void ReportScore(long score)
	{
		Social.ReportScore(score, GameConstants.LEADERBOARD_ID, success =>
			{
				if (success)
				{
					Debug.Log("Reported score successfully");
				}
				else
				{
					Debug.Log("Failed to report score");
				}
				Debug.Log(success ? "Reported score successfully" : "Failed to report score"); Debug.Log("New Score:"+score);
			});
	}
	public static void ShowLeaderboard()
	{
		//#if UNITY_IPHONE
		Social.LoadScores(GameConstants.LEADERBOARD_ID, scores => {
			if (scores.Length > 0) {
				Debug.Log ("Got " + scores.Length + " scores");
				string myScores = "Leaderboard:\n";
				foreach (IScore score in scores)
					myScores += "\t" + score.userID + " " + score.formattedValue + " " + score.date + "\n";
				Debug.Log (myScores);
			}
			else
				Debug.Log ("No scores loaded");
		});
		Social.ShowLeaderboardUI();
		//#endif
	}
	#endregion
}
