using UnityEngine;
using System.Collections;

public class key_pressed : MonoBehaviour {

	public bool pressed = false;
	float t1, t2;

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		t1 = Time.realtimeSinceStartup; 
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.realtimeSinceStartup;
		if (Input.touchCount == 1)	{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider2D == Physics2D.OverlapPoint(touchPos))	{
				gameObject.renderer.enabled = true;
				if (!pressed) {
					audio.Play();
					if (t2 - t1 >= 3.0f && t2 - t1 <= GameObject.Find ("music_start").GetComponent<music_start>().stop_time)
						//wrong note penalty
						GameObject.Find ("current_score").GetComponent<current_score>().value -= 1;
						
						//record note
						GameObject.Find ("record_start").GetComponent<record_start>().note = this.name[4];
						GameObject.Find ("record_start").GetComponent<record_start>().scale = int.Parse(this.name.Substring (5,1));
				}
				pressed = true;
			}
			else {
				gameObject.renderer.enabled = false;
				pressed = false;
            }
		}	
		else {
			gameObject.renderer.enabled = false;
			pressed = false;
		}
	}
}