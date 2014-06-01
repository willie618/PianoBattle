using UnityEngine;
using System.Collections;

public class record_start : MonoBehaviour {

	public Rigidbody2D projectile;
	float t0, t1, t2;
	public string recording = "";
	public float record_time = 10.0f;
	public char note = '-';
	public int scale = 0;
	string key = "--";
	public bool recording_mode = false;

	// Use this for initialization
	void Start () {
		t0 = Time.realtimeSinceStartup;
		t1 = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.realtimeSinceStartup;
		
		//note properties
		Rigidbody2D clone;

		if (recording_mode) {
			//time interval between each note marker
			if (t2 - t0 >= 0f && t2 - t0 < 3.0f) {
				if (t2 - t1 > 0.5f) {
					t1 = Time.realtimeSinceStartup;
					clone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
				}
			}
			else if (t2 - t0 >= 3.0f && t2 - t0 < record_time) {
				if (t2 - t1 > 0.5f) {
					t1 = Time.realtimeSinceStartup;
					clone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);

					if (note == '-')
						key = "--";
					else {
						key = note.ToString() + scale.ToString();
					}
					recording = recording + key;
					GameObject.Find ("current_score_label").guiText.text = key;
					t1 = Time.realtimeSinceStartup;
					note = '-';
					scale = 0;
				}
			}
			else if (t2 - t0 >= record_time && t2 - t0 < record_time+3.0f) {
				if (t2 - t1 > 0.5f) {
					t1 = Time.realtimeSinceStartup;
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
