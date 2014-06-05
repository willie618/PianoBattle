using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	private bool note = false;
	private bool miss = false;
	char score_letter;
	char score_scale;
	string key;
	private const int HIT = 5;
	private const int PENALTY = 2;
	float t1, t2;

	// Use this for initialization
	void Start () {
		//determine which hitbox is tied to script
		t1 = Time.time; 
		score_letter = this.name [6];
		score_scale = this.name [7];
		key = "key_" + score_letter + score_scale;
	}
	
	// Update is called once per frame
	void Update () {
		//reset score marker feedback
		t2 = Time.time; 
		if (t2 - t1 > 0.25f) {
			GameObject.Find ("score_hit").renderer.enabled = false;
			GameObject.Find ("score_miss").renderer.enabled = false;
			t1 = Time.time; 
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		//initialize variables as waiting for key press on note enter
		if (other.name == "note(Clone)") {
			if (!GameObject.Find (key).GetComponent<key_pressed>().pressed)
				note = true;
			miss = true;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		//change variables for correct key press
		if (note) {
			if (GameObject.Find (key).GetComponent<key_pressed>().pressed) {
				if (miss) {
					t1 = Time.time; 
                    GameObject.Find ("score_hit").renderer.enabled = true;
					GameObject.Find ("current_score").GetComponent<current_score>().value += HIT;
					miss = false;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		//determine if key was missed on note exit
		if (other.name == "note(Clone)") {
			note = false;
			if (miss) {
				t1 = Time.time; 
                GameObject.Find ("score_miss").renderer.enabled = true;
				GameObject.Find ("current_score").GetComponent<current_score>().value -= PENALTY;
			}
		}
	}
}
