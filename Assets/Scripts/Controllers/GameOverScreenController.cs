using UnityEngine;
using System.Collections;


public class GameOverScreenController : Singleton<GameOverScreenController> 
{
	GameOverScreenReferences gameOverScreenRef;

	public void ShowGameOverScreen(GameOverScreenReferences gameOverScreenReferences)
	{
		GameController.Instance.IsUIOpen = true;
		gameOverScreenRef = gameOverScreenReferences;
		gameOverScreenRef.gameObject.SetActive (true);
		ToggleMusicButton ();

		gameOverScreenRef.currentScore.text = GameController.Instance.UpdateScoreLabel (); 
		gameOverScreenRef.bestScore.text = "BEST " + GameModel.Instance.BestScore.ToString (); 
	}

	public void ToggleMusicButton ()
	{
		if (GameModel.Instance.IsMusicOn) {
			GameModel.Instance.IsMusicOn = false;
			gameOverScreenRef.musicButton.image.sprite = Resources.Load<Sprite> ("soundOffIcon");
		}
		else {
			GameModel.Instance.IsMusicOn = true;
			gameOverScreenRef.musicButton.image.sprite = Resources.Load<Sprite> ("soundOnIcon");
		}
	}
}
