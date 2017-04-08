using UnityEngine;
using System.Collections;
using ChartboostSDK;
//using GoogleMobileAds.Api;

public class GameController : Singleton<GameController> 
{
	GameReferences gameRef;
	GameObject gameContextObject;
	private bool isUIOpen;
//	InterstitialAd interstitial;

	public bool IsUIOpen {
		get;
		set;
	}

	public void LoadGame(GameObject gameObject)
	{
		gameContextObject = gameObject;
		gameRef = gameContextObject.GetComponent<GameReferences> ();
		gameRef.movingLine.GetComponent<RectTransform>().anchoredPosition = new Vector3 (GameModel.Instance.LineMinPositionX, 0.0f, 0.0f);
		gameRef.scoreLabel.text = UpdateScoreLabel ();
		GameStartScreenController.Instance.ShowGameStartScreen (gameRef.gameStartScreenRef);
//		RequestInterstitial ();
	}

	public void StartGame()
	{
		LeaderboardManager.AuthenticateToGameCenter();
		GameStartScreenController.Instance.HideGameStartScreen ();
		ScoreController.Instance.Init (gameRef);
	}

	public void UpdateScore(int addedScore)
	{
		GameModel.Instance.Score = GameModel.Instance.Score + addedScore;
		gameRef.scoreLabel.text = UpdateScoreLabel ();
	}

	public string UpdateScoreLabel()
	{
		return GameModel.Instance.Score.ToString();
	}

	public void EndGame()
	{
		ScoreController.Instance.StopScoring ();
		if (GameModel.Instance.Score > GameModel.Instance.BestScore) {
			if(GameModel.Instance.IsGameCenterAuthenticated) {
				LeaderboardManager.ReportScore(GameModel.Instance.Score);
			}
			GameModel.Instance.BestScore = GameModel.Instance.Score;
			PlayerPrefs.SetInt ("BestScore", GameModel.Instance.BestScore);
		}
		GameModel.Instance.AdShowCounter += 1;
		PlayerPrefs.SetInt ("AdCounter", GameModel.Instance.AdShowCounter);
		if (GameModel.Instance.AdShowCounter % 3 == 0) {
			Chartboost.showInterstitial(CBLocation.HomeScreen);
		}
		GameOverScreenController.Instance.ShowGameOverScreen (gameRef.gameOverScreenRef);
	}

//	private void RequestInterstitial()
//	{
//		#if UNITY_ANDROID
//		string adUnitId = "ca-app-pub-7025712615436961/5883085539";
//		#elif UNITY_IPHONE
//		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
//		#else
//		string adUnitId = "unexpected_platform";
//		#endif
//
//		// Initialize an InterstitialAd.
//		interstitial = new InterstitialAd(adUnitId);
//		// Create an empty ad request.
//		AdRequest request = new AdRequest.Builder()
//		.AddTestDevice("857577306204323")    //add test device id
//		.Build();
//		// Load the interstitial with the request.
//		interstitial.LoadAd(request);
//		//		Debug.Log ("interstitial.LoadAd");
//		}
//
//		private void ShowInterstitial()
//		{
//			if (interstitial.IsLoaded ()) {
//			interstitial.Show ();
//			}
//		}

}
