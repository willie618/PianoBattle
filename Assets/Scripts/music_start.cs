using UnityEngine;
using System.Collections;

public class music_start : MonoBehaviour {

	public Rigidbody2D projectile;
	float t1, t2;
	string jingle_bells = "e3e3e3--e3e3e3--e3g3c3d3e3------f3f3f3f3f3e3e3e3e3d3d3e3d3--g3--e3e3e3--e3e3e3--e3g3c3d3e3------f3f3f3f3f3e3e3e3g3g3f3d3c3------";
	string happy_birthday = "g3g3a3--g3--c4--b3------g3g3a3--g3--d4--c4----g3g3g4--e4--c4--b3--a3--f4f4e4--c4--d4--c4--";
	string song;
	float start;

	// Use this for initialization
	void Start () {
		t1 = Time.realtimeSinceStartup;
		song = happy_birthday;
		if (song == jingle_bells)
			start = 0.72f*0.0f;
		else if (song == happy_birthday)
			start = 0.72f*5.0f;
		GameObject.Find ("camera").transform.Translate (start, 0f, 0f);
		GameObject.Find ("bar_4").transform.Translate (start, 0f, 0f);
		GameObject.Find ("score_marker").transform.Translate (start, 0f, 0f);
		GameObject.Find ("back_button").transform.Translate (start, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.realtimeSinceStartup;
		Rigidbody2D clone;
		char note = '-';
		float scale = 0f;
		bool black_note = false;
		Vector3 note_pos = new Vector3(0f, 0f, 0f);
		if (t2 - t1 > 0.5f) {
			if (song != "") {
				note = song[0];
				if (note != '-')
					scale = float.Parse(song.Substring (1,1));
				song = song.Substring (2, song.Length-2);
				switch(note) {
					case 'c':
						note_pos.x = -2.16f;
						black_note = false;
						break;
					case 'C':
						note_pos.x =  -1.8f;
						black_note = true;
						break;
					case 'd':
						note_pos.x =  -1.44f;
						black_note = false;
						break;
					case 'D':
						note_pos.x =  -1.08f;
						black_note = true;
						break;
					case 'e':
						note_pos.x =  -0.72f;
						black_note = false;
						break;
					case 'f':
						note_pos.x =  0f;
						black_note = false;
						break;
					case 'F':
						note_pos.x =  0.36f;
						black_note = true;
						break;
					case 'g':
						note_pos.x =  0.72f;
						black_note = false;
						break;
					case 'G':
						note_pos.x =  1.08f;
						black_note = true;
						break;
					case 'a':
						note_pos.x =  1.44f;
						black_note = false;
						break;
					case 'A':
						note_pos.x =  1.8f;
						black_note = true;
						break;
					case 'b':
						note_pos.x =  2.16f;
						black_note = false;
						break;
				}
				if (note != '-') {
					note_pos.x = note_pos.x + (scale-3.0f) * 5.04f;
					clone = (Rigidbody2D)Instantiate(projectile, transform.position + note_pos, transform.rotation);
					if (black_note)
						clone.transform.localScale -= (new Vector3(4f/3f, 0f, 0f));
				}
				t1 = Time.realtimeSinceStartup;
			}
		}
	}
}
