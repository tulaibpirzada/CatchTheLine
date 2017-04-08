using UnityEngine;
using UnityEngine.Audio;
using System.Collections;


public class LineMover : MonoBehaviour 
{
	public AudioSource lineSoundSource;
	private bool isOnLeft;
	private float speed;
	void Start()
	{
		isOnLeft = true;
		speed = GameConstants.LEVEL_SPEEDS[0];
	}
	void Update()
	{
		if (ScoreController.Instance.ShouldStartOscillatingLine) 
		{
			if (isOnLeft) {
				gameObject.GetComponent<RectTransform>().Translate (Vector3.right * Time.deltaTime * speed);
				if (gameObject.GetComponent<RectTransform>().anchoredPosition.x >= GameModel.Instance.LineMaxPositionX) {
					isOnLeft = false;
					lineSoundSource.Play ();
				}
			} else {
				gameObject.GetComponent<RectTransform>().Translate (Vector3.left * Time.deltaTime * speed);
				if (gameObject.GetComponent<RectTransform>().anchoredPosition.x <= GameModel.Instance.LineMinPositionX) {
					isOnLeft = true;
					lineSoundSource.Play ();
				}
			}
		}
	}

	public void IncreaseSpeed()
	{
		speed = GameConstants.LEVEL_SPEEDS [GameModel.Instance.Score / 10];
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		ScoreController.Instance.IsTapValidForOneRound = true;
	}

	void OnTriggerStay2D(Collider2D other)
	{
//		Debug.Log ("On trigger stay");
		if (other.tag == "Ball" && ScoreController.Instance.IsScreenTapped) {
			Debug.Log ("Is Valid Input");
			ScoreController.Instance.IsValidTap = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		ScoreController.Instance.IsTapValidForOneRound = false;
//		Debug.Log ("On trigger exit");
		if (other.tag == "Ball") {
			ScoreController.Instance.IsValidTap = false;
		}
	}
}
