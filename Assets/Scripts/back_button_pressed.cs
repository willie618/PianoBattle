using UnityEngine;
using System.Collections;

public class back_button_pressed : MonoBehaviour {

	float t1, t2;

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		t1 = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.realtimeSinceStartup;

		//phone back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) { 
					int s=GameObject.Find ("current_score").GetComponent<current_score>().value;
					obj_Activity.CallStatic("setScore", s);
				}
			}
			Application.Quit ();
		}	

		//touch screen back button
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider2D == Physics2D.OverlapPoint(touchPos))	{
				gameObject.renderer.enabled = true;
				using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
					using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) { 
						int s=GameObject.Find ("current_score").GetComponent<current_score>().value;
						obj_Activity.CallStatic("setScore", s);
					}
				}
				Application.Quit ();
			}
			else {
				gameObject.renderer.enabled = false;
			}
		}	
		else {
			gameObject.renderer.enabled = false;
		}

		//forced time out
//		if (t2 - t1 >= GameObject.Find ("music_start").GetComponent<music_start>().stop_time + 3.0f) {
//			Application.Quit ();
//		}
	}
}