using UnityEngine;
using System.Collections;

public class current_score : MonoBehaviour {

	public int value = 0;
	float t1, t2;

	// Use this for initialization
	void Start () {
		t1 = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		//current score
		this.guiText.text = value.ToString();

		//current score color
		t2 = Time.realtimeSinceStartup;
		if (t2 - t1 >= 3.0f && t2 - t1 <= GameObject.Find ("music_start").GetComponent<music_start>().stop_time) {
			this.guiText.material.color = Color.white;
			GameObject.Find ("current_score_label").guiText.material.color = Color.white;
		}
		else {
			this.guiText.material.color = Color.red;
			GameObject.Find ("current_score_label").guiText.material.color = Color.red;
		}
	}
}
