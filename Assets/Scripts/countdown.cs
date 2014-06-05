using UnityEngine;
using System.Collections;

public class countdown : MonoBehaviour {

	float t1, t2;
	float tempo;

	// Use this for initialization
	void Start () {
		tempo = GameObject.Find ("music_start").GetComponent<music_start> ().tempo;
		t1 = Time.realtimeSinceStartup; 
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.realtimeSinceStartup;

		//second countdown
		if (t2 - t1 >= 60f/tempo && t2 - t1 < 120f/tempo)
			this.guiText.text = "2";
		else if (t2 - t1 >= 120f/tempo && t2 - t1 < 180f/tempo)
			this.guiText.text = "1";
		else if (t2 - t1 >= 180f/tempo && t2 - t1 < 240f/tempo)
			this.guiText.text = "GO!";
		else if (t2 - t1 >= 240f/tempo)
			Destroy(this.gameObject);
	}
}
