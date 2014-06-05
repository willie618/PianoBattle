using UnityEngine;
using System.Collections;

public class music_start : MonoBehaviour {

	public Rigidbody2D projectile;
	public Rigidbody2D arrow;
	public float stop_time;
    public float tempo = 60f;
	float t0, t1, t2;
	string jingle_bells = "e3e3e3--e3e3e3--e3g3c3d3e3------f3f3f3f3f3e3e3e3e3d3d3e3d3--g3--e3e3e3--e3e3e3--e3g3c3d3e3------f3f3f3f3f3e3e3e3g3g3f3d3c3------";
	string london_bridge = "d4e4d4c4b3c4d4--a3b3c4--b3c4d4--d4e4d4c4b3c4d4--a3--d4--b3g3--";
	string happy_birthday = "g3g3a3--g3--c4--b3------g3g3a3--g3--d4--c4------g3g3g4--e4--c4--b3--a3--f4f4e4--c4--d4--c4--";
	string mary_had_a_little_lamb = "A3G3F3G3A3A3A3--G3G3G3--A3C4C4--A3G3F3G3A3A3A3--G3G3A3G3F3------A3G3F3G3A3A3A3--G3G3G3--A3C4C4--A3G3F3G3A3A3A3--G3G3A3G3F3------";
	string the_entertainer = "d5e5c5a4--b4g4--d4e4c4a3--b3g3--d3e3c3a2--b2a2G2g2------g3--d3D3e3c4--e3c4--e3c4--------c4d4D4e4c4d4e4--b3d4--c4----------d3D3e3c4--e3c4--e3c4--------a3g3F3a3c4e4--d4c4a3d4----------d3D3e3c4--e3c4--e3c4--------c4d4D4e4c4d4e4--b3d4--c4----------c4d4e4c4d4e4--c4d4c4e4c4d4e4--c4d4c4e4c4d4e4--b3d4--c4----------";
	string song_title;
	string song;
	float start_pos;
	public int mode = 0;	//0: battle, 1: recording, 2: playback

	// Use this for initialization
	void Start () {
		t0 = Time.time;
		t1 = Time.time;

		song_title = "Jingle Bells";
		song = "";

		//determine song
		if (mode == 0) {
			if (song_title == "Jingle Bells") {
				song = jingle_bells;
				start_pos = 0.72f*0.0f;
			}
			else if (song_title == "London Bridge") {
				song = london_bridge;
				start_pos = 0.72f*3.0f;
			}
			else if (song_title == "Happy Birthday") {
				song = happy_birthday;
				start_pos = 0.72f*5.0f;
			}
			else if (song_title == "Mary Had a Little Lamb") {
				song = mary_had_a_little_lamb;
				start_pos = 0.72f*3.0f;
			}
			else if (song_title == "The Entertainer") {
				song = the_entertainer;
				start_pos = 0.72f*10.0f;
			}
			else {
				song = "";
				start_pos = 0.72f*0.0f;
			}
		}

		//determine starting position
		GameObject.Find ("camera").transform.Translate (start_pos, 0f, 0f);
		GameObject.Find ("bar_4").transform.Translate (start_pos, 0f, 0f);
		GameObject.Find ("score_marker").transform.Translate (start_pos, 0f, 0f);
		GameObject.Find ("back_button").transform.Translate (start_pos, 0f, 0f);

		if (mode == 0)
			stop_time = (8.0f + song.Length/2f) * 60f/tempo;
		else
			stop_time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		t2 = Time.time;

		//note properties
		Rigidbody2D clone, clone2;
		char note = '-';
		float scale = 0f;
		bool black_note = false;
		Vector3 note_pos = new Vector3(0f, 0f, 0f);

		//battle or playback mode
		if (mode != 1) {
			
			//time interval between each note
			if (t2 - t1 > 60f/tempo) {
				if (song != "") {
					//determine next note
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
					//generate note
					if (note != '-') {
						note_pos.x = note_pos.x + (scale-3.0f) * 5.04f;
						clone = (Rigidbody2D)Instantiate(projectile, transform.position + note_pos, transform.rotation);
						clone2 = (Rigidbody2D)Instantiate(arrow, transform.position + note_pos, transform.rotation);
                        if (black_note)
							clone.transform.localScale -= (new Vector3(4f/3f, 0f, 0f));
					}
					t1 = Time.time;
				}
			}
		}
		//recording mode
		else if (mode == 1 &&
				 t2 - t0 > GameObject.Find ("record_start").GetComponent<record_start>().record_time + 3.0f &&
		    	 t2 - t0 < GameObject.Find ("record_start").GetComponent<record_start>().record_time + 6.0f) {
			song = GameObject.Find ("record_start").GetComponent<record_start>().recording;
		}
	}
}
