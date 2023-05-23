using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadaudio : MonoBehaviour 
{
	public AudioSource gunAudioR;
	public AudioClip sound1;
	public AudioClip sound2;
	public AudioClip sound3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SoundF () {
		gunAudioR.clip = sound1;
		gunAudioR.Play ();
    }
	void SoundS () {
		gunAudioR.clip = sound2;
		gunAudioR.Play ();
    }
	void soundT () {
		gunAudioR.clip = sound3;
		gunAudioR.Play ();
    }
}
