using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text score_display;

	void Start () {
		score_display.text = "MAX SCORE: " + PlayerPrefs.GetInt("maxplayer_score");
	}

	public void low_diff () {
		PlayerPrefs.SetInt("player_diff", 0);
	}
	public void medium_diff () {
		PlayerPrefs.SetInt("player_diff", 1);
	}
	public void high_diff () {
		PlayerPrefs.SetInt("player_diff", 2);
	}
	public void start_game () {
		SceneManager.LoadScene ("GameLevel");
	}
}
