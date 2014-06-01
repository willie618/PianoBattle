using UnityEngine;
using System.Collections;

public class note : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > -4)
			transform.Translate (Vector2.up * -0.04f);
		else
			Destroy (this.gameObject);
	}
}
