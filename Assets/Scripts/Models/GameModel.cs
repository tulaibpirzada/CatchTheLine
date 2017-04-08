using UnityEngine;
using System.Collections;

public class GameModel : Singleton<GameModel> 
{
	private bool isGameCenterAuthenticated;
	private bool isLeaderboardTapped;
	private bool isMusicOn;
	private int score;
	private int bestScore;
	private int adShowCounter;
	private int lineMovementSpeed;
	private float lineMinPositionX;
	private float lineMaxPositionX;

	public bool IsGameCenterAuthenticated
	{
		get{ return isGameCenterAuthenticated;}
		set{isGameCenterAuthenticated = value;}
	}

	public bool IsLeaderboardTapped
	{
		get{ return isLeaderboardTapped;}
		set{isLeaderboardTapped = value;}
	}

	public bool IsMusicOn
	{
		get{ return isMusicOn;}
		set{isMusicOn = value;}
	}

	public int Score
	{
		get{ return score;}
		set{score = value;}
	}

	public int BestScore
	{
		get{ return bestScore;}
		set{bestScore = value;}
	}

	public int AdShowCounter
	{
		get{ return adShowCounter;}
		set{adShowCounter = value;}
	}

	public int LineMovementSpeed
	{
		get{ return lineMovementSpeed;}
	}

	public float LineMinPositionX
	{
		get{ return lineMinPositionX;}
	}

	public float LineMaxPositionX
	{
		get{ return lineMaxPositionX;}
	}

	public void SetUpGameVariables()
	{
		score = 0;
		if (PlayerPrefs.HasKey ("BestScore")) {
			bestScore = PlayerPrefs.GetInt ("BestScore");
		} else {
			bestScore = 0;
		}
		if (PlayerPrefs.HasKey ("AdCounter")) {
			adShowCounter = PlayerPrefs.GetInt ("AdCounter");
		} else {
			adShowCounter = 0;
		}
		isMusicOn = false;
		isGameCenterAuthenticated = false;
		isLeaderboardTapped = false;
		lineMovementSpeed = 5;
		lineMinPositionX = -301.8f;
		lineMaxPositionX = 301.8f;
	}
}
