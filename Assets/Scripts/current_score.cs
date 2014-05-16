using UnityEngine;
using System.Collections;

public class current_score : MonoBehaviour {

	public int value = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

/*		value += GameObject.Find ("score_a").GetComponent<score>().value;
		GameObject.Find ("score_a").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_as").GetComponent<score>().value;
		GameObject.Find ("score_as").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_b").GetComponent<score>().value;
		GameObject.Find ("score_b").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_c").GetComponent<score>().value;
		GameObject.Find ("score_c").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_cs").GetComponent<score>().value;
		GameObject.Find ("score_cs").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_d").GetComponent<score>().value;
		GameObject.Find ("score_d").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_ds").GetComponent<score>().value;
		GameObject.Find ("score_ds").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_e").GetComponent<score>().value;
		GameObject.Find ("score_e").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_f").GetComponent<score>().value;
		GameObject.Find ("score_f").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_fs").GetComponent<score>().value;
		GameObject.Find ("score_fs").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_g").GetComponent<score>().value;
		GameObject.Find ("score_g").GetComponent<score> ().value = 0;
		value += GameObject.Find ("score_gs").GetComponent<score>().value;
		GameObject.Find ("score_gs").GetComponent<score> ().value = 0;
*/
		this.guiText.text = value.ToString();
	}
}
