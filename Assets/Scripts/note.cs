using UnityEngine;
using System.Collections;

public class note : MonoBehaviour {

    float speed;
	float tempo;

	// Use this for initialization
	void Start () {
		tempo = GameObject.Find ("music_start").GetComponent<music_start> ().tempo;
		speed = 0.04f * tempo / 60f;
    }
    
    // Update is called once per frame
	void Update () {
		//falling notes
		if (transform.position.y > -4)
			transform.Translate (Vector2.up * -speed);
		else
			Destroy (this.gameObject);
	}
}
