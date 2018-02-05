using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour {

	public Text math_display;
	public Text score_display;
	public Outline bonus_display;
	public static int score;
	private int difficulty;
	public static int selected_answer;
	public static bool check_answer = false;
	public static int correct_answer;
	private bool math_bonus = false;
	private int mistakes = 3;

	private GameObject mistake_1;
	private GameObject mistake_2;
	private GameObject mistake_3;

	void Start () {

		mistake_1 = GameObject.Find("1");
		mistake_2 = GameObject.Find("2");
		mistake_3 = GameObject.Find("3");

		if (Random.Range(0,3) == 1) {
			math_bonus = true;
		}

		difficulty = PlayerPrefs.GetInt("player_diff");
		score = PlayerPrefs.GetInt("player_score");
		mistakes = PlayerPrefs.GetInt("player_mistakes");
		if (difficulty == 0) {
			math_display.text = "2+1 = ?";
			correct_answer = 3;
		}
		if (difficulty == 1) {
			math_display.text = "1+6-5 = ?";
			correct_answer = 2;
		}
		if (difficulty == 2) {
			math_display.text = "7-2*3 = ?";
			correct_answer = 1;
		}
	}

	void Update () {

		if (mistakes == 3) {
			mistake_1.SetActive(true);
			mistake_2.SetActive(true);
			mistake_3.SetActive(true);
		}
		if (mistakes == 2) {
			mistake_1.SetActive(true);
			mistake_2.SetActive(true);
			mistake_3.SetActive(false);
		}
		if (mistakes == 1) {
			mistake_1.SetActive(true);
			mistake_2.SetActive(false);
			mistake_3.SetActive(false);
		}
		if (mistakes == 0) {
			mistake_1.SetActive(false);
			mistake_2.SetActive(false);
			mistake_3.SetActive(false);
			SceneManager.LoadScene ("Finall");
		}

		if (check_answer) {
			if (selected_answer != correct_answer) {
				mistakes--;
				check_answer = false;
				SceneManager.LoadScene ("GameLevel");
			}
			if (selected_answer == correct_answer) {
				if (math_bonus) {
					if (mistakes != 3) {
						mistakes++;
					} else {
						score = score + 2;
					}
					check_answer = false;
					SceneManager.LoadScene ("GameLevel");
				}
				if (!math_bonus) {
					score++;
					check_answer = false;
					SceneManager.LoadScene ("GameLevel");
				}
			}
		}

		if (math_bonus) {
			bonus_display.enabled = true;
		}

		PlayerPrefs.SetInt("player_score", score);
		PlayerPrefs.SetInt("player_mistakes", mistakes);
		score_display.text = "SCORE: " + PlayerPrefs.GetInt("player_score");

	}
}
