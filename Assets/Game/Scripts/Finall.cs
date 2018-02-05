using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finall : MonoBehaviour {

	public Text score_value;

	public void MainMenuGo () {
		PlayerPrefs.SetInt ("player_mistakes", 3);
		PlayerPrefs.SetInt("player_score", 0);
		SceneManager.LoadScene ("MainMenu");
	}

	void Start () {
		score_value.text = "" + General.score;

		if (General.score > PlayerPrefs.GetInt("maxplayer_score")) {
			PlayerPrefs.SetInt("maxplayer_score", General.score);
		}
	}
}
