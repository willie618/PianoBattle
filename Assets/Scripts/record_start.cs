using UnityEngine;
using System.Collections;

public class record_start : MonoBehaviour {

	public Rigidbody2D projectile;
	float t0, t1, t2;
	public string recording = "";
	public float record_time = 32.0f;
	public char note = '-';
	public int scale = 0;
	string key = "--";
	bool recording_mode;
	float tempo;

	// Use this for initialization
	void Start () {
		t0 = Time.time;
		t1 = Time.time;

		if (GameObject.Find ("music_start").GetComponent<music_start> ().mode == 1) {
			recording_mode = true;
			audio.Play();
        }

		tempo = GameObject.Find ("music_start").GetComponent<music_start> ().tempo;
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.time;
		
		//note properties
		Rigidbody2D clone;
		//time it takes for recording lines to reach key
		float delay = 8.0f * 60f / tempo;

		if (recording_mode) {
			//time interval between each note marker
			if (t2 - t0 >= 0f && t2 - t0 < delay) {
				if (t2 - t1 > 60f/tempo) {
					t1 = Time.time;
					audio.Play();
                    clone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
				}
			}
			else if (t2 - t0 >= delay && t2 - t0 < record_time) {
				if (t2 - t1 > 60f/tempo) {
					t1 = Time.time;
					audio.Play();
                    clone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);

					if (note == '-')
						key = "--";
					else {
						key = note.ToString() + scale.ToString();
					}
					recording = recording + key;
					//debug key recording
                    GameObject.Find ("current_score_label").guiText.text = key;
					t1 = Time.time;
					note = '-';
					scale = 0;
				}
			}
			else if (t2 - t0 >= record_time && t2 - t0 < record_time+delay) {
				if (t2 - t1 > 60f/tempo) {
					t1 = Time.time;
					audio.Play();
                    if (note == '-')
						key = "--";
					else {
						key = note.ToString() + scale.ToString();
					}
					recording = recording + key;
					//debug key recording
					//GameObject.Find ("current_score_label").guiText.text = key;
					note = '-';
					scale = 0;
				}
			}
		}
	}
}
