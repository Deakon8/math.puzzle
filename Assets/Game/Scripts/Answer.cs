using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {

	public int answer;

	void Start () {
		answer = Random.Range(1,4);
		this.gameObject.GetComponentInChildren<Text>().text = "" + answer;
	}

	public void answer_click () {
		General.selected_answer = answer;
		General.check_answer = true;
	}
}
