using UnityEngine;
using System.Collections;

public class countdown : MonoBehaviour {

	float t1, t2;

	// Use this for initialization
	void Start () {
		t1 = Time.realtimeSinceStartup; 
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.realtimeSinceStartup; 
		if (t2 - t1 >= 1.0f && t2 - t1 < 2.0f)
			this.guiText.text = "2";
		else if (t2 - t1 >= 2.0f && t2 - t1 < 3.0f)
			this.guiText.text = "1";
		else if (t2 - t1 >= 3.0f && t2 - t1 < 4.0f)
			this.guiText.text = "GO!";
		else if (t2 - t1 >= 4.0f)
			Destroy(this.gameObject);
	}
}
