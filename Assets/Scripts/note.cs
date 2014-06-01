using UnityEngine;
using System.Collections;

public class note : MonoBehaviour {

	const float tempo = 0.04f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//falling notes
		if (transform.position.y > -4)
			transform.Translate (Vector2.up * -tempo);
		else
			Destroy (this.gameObject);
	}
}
