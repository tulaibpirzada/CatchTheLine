using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class GameStartScreenEvents : MonoBehaviour 
{
	public void StartGameButtonTapped()
	{
		GameController.Instance.StartGame ();
	}

	public void SoundButtonTapped()
	{
		GameStartScreenController.Instance.ToggleMusicButton ();
	}

	public void ShareButtonTapped()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	public void LeaderboardButtonTapped()
	{
		if (!GameModel.Instance.IsGameCenterAuthenticated) {
			LeaderboardManager.AuthenticateToGameCenter();
			GameModel.Instance.IsLeaderboardTapped = true;
		}
		LeaderboardManager.ShowLeaderboard();
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			Debug.Log("Inside Init callback");

			FB.ShareLink(
				new Uri("https://developers.facebook.com/"),
				"Link Share",
				"Look I scored " + GameModel.Instance.Score + "in Line Stop",
				new Uri("http://i.imgur.com/j4M7vCO.jpg"),
				callback: ShareCallback);
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void FBAPICallback (IGraphResult result) 
	{
		Debug.Log("Inside FB API callback");
		if (result.ResultDictionary != null) {
			Debug.Log ("Result dictionary not null");

			foreach(KeyValuePair<string,object> resultObjectPair in result.ResultDictionary)
			{
				Debug.Log ("Key: " + resultObjectPair.Key);
				Dictionary<string, object> errorDictionary = resultObjectPair.Value as Dictionary<string, object>;
				object value = null;
				if (errorDictionary.TryGetValue ("message", out value)) {
					Debug.Log ("Value: " + value.ToString());
				}

			}
		} else {
			Debug.Log ("Result dictionary is null");
		}

	}



	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	private void ShareCallback (IShareResult result) 
	{
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
		}
	}
}
