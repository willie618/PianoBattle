using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	private bool note = false;
	private bool miss = false;
	//private current_score cs;

	// Use this for initialization
	void Start () {
		//cs = GameObject.Find ("current_score").GetComponent<current_score> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((this.name == "score_a" && other.name == "note_a") ||
		    (this.name == "score_as" && other.name == "note_as") ||
		    (this.name == "score_b" && other.name == "note_b") ||
		    (this.name == "score_c" && other.name == "note_c") ||
		    (this.name == "score_cs" && other.name == "note_cs") ||
		    (this.name == "score_d" && other.name == "note_d") ||
		    (this.name == "score_ds" && other.name == "note_ds") ||
		    (this.name == "score_e" && other.name == "note_e") ||
		    (this.name == "score_f" && other.name == "note_f") ||
		    (this.name == "score_fs" && other.name == "note_fs") ||
		    (this.name == "score_g" && other.name == "note_g") ||
		    (this.name == "score_gs" && other.name == "note_gs")) {
			note = true;
			miss = true;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (note) {
			if ((this.name == "score_a" && GameObject.Find ("key_a").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_as" && GameObject.Find ("key_as").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_b" && GameObject.Find ("key_b").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_c" && GameObject.Find ("key_c").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_cs" && GameObject.Find ("key_cs").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_d" && GameObject.Find ("key_d").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_ds" && GameObject.Find ("key_ds").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_e" && GameObject.Find ("key_e").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_f" && GameObject.Find ("key_f").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_fs" && GameObject.Find ("key_fs").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_g" && GameObject.Find ("key_g").GetComponent<key_pressed>().pressed) ||
			    (this.name == "score_gs" && GameObject.Find ("key_gs").GetComponent<key_pressed>().pressed)
			    ) { 
				if (miss) {
					GameObject.Find ("current_score").GetComponent<current_score>().value += 5;
					miss = false;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if ((this.name == "score_a" && other.name == "note_a") ||
		    (this.name == "score_as" && other.name == "note_as") ||
		    (this.name == "score_b" && other.name == "note_b") ||
		    (this.name == "score_c" && other.name == "note_c") ||
		    (this.name == "score_cs" && other.name == "note_cs") ||
		    (this.name == "score_d" && other.name == "note_d") ||
		    (this.name == "score_ds" && other.name == "note_ds") ||
		    (this.name == "score_e" && other.name == "note_e") ||
		    (this.name == "score_f" && other.name == "note_f") ||
		    (this.name == "score_fs" && other.name == "note_fs") ||
		    (this.name == "score_g" && other.name == "note_g") ||
			(this.name == "score_gs" && other.name == "note_gs")) {
			note = false;
			if (miss)
				GameObject.Find ("current_score").GetComponent<current_score>().value -= 2;
		}
	}
}
