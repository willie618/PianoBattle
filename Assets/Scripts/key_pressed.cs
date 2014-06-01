using UnityEngine;
using System.Collections;

public class key_pressed : MonoBehaviour {

	public bool pressed = false;
	float t1, t2;
	const float total_time = 34.0f;

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
					if (t2 - t1 <= total_time && t2 - t1 >= 3.0f)
						GameObject.Find ("current_score").GetComponent<current_score>().value -= 1;
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