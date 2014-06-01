using UnityEngine;
using System.Collections;

public class move_button_pressed : MonoBehaviour {
	
	bool pressed = false;
	float move = 0f;

	// Use this for initialization
	void Start () {
		//determine which button is tied to script
		if (this.name == "right_button_pressed") {
			move = 0.72f;
		}
		else if (this.name == "right_scale_button_pressed") {
			move = 5.04f;
		}
		else if (this.name == "left_button_pressed") {
			move = -0.72f;
		}
		else if (this.name == "left_scale_button_pressed") {
			move = -5.04f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider2D == Physics2D.OverlapPoint(touchPos))	{
				gameObject.renderer.enabled = true;
				//move camera and HUD
				if (!pressed) {
					GameObject.Find ("camera").transform.Translate (move, 0f, 0f);
					GameObject.Find ("bar_4").transform.Translate (move, 0f, 0f);
					GameObject.Find ("score_marker").transform.Translate (move, 0f, 0f);
					GameObject.Find ("back_button").transform.Translate (move, 0f, 0f);
					pressed = true;
					while (transform.position.x < -12.24) {
						GameObject.Find ("camera").transform.Translate (0.72f, 0f, 0f);
						GameObject.Find ("bar_4").transform.Translate (0.72f, 0f, 0f);
						GameObject.Find ("score_marker").transform.Translate (0.72f, 0f, 0f);
						GameObject.Find ("back_button").transform.Translate (0.72f, 0f, 0f);
					}
					while (transform.position.x > 12.24) {
						GameObject.Find ("camera").transform.Translate (-0.72f, 0f, 0f);
						GameObject.Find ("bar_4").transform.Translate (-0.72f, 0f, 0f);
						GameObject.Find ("score_marker").transform.Translate (-0.72f, 0f, 0f);
						GameObject.Find ("back_button").transform.Translate (-0.72f, 0f, 0f);
					}
				}
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
