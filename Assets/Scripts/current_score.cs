using UnityEngine;
using System.Collections;

public class current_score : MonoBehaviour {

	public int value = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = value.ToString();
	}
}
