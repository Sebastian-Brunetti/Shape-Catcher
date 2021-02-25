using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private bool playing;

    public AudioSource musicPlayer;
    public AudioClip[] tracks;

    void Start ()
    {
        PlayRandomTrack();
	}
	
	void Update ()
    {
		if (!musicPlayer.isPlaying)
        {
            PlayRandomTrack();
        }
	}

    void PlayRandomTrack()
    {
        musicPlayer.clip = tracks[Random.Range(0, tracks.Length)];
        musicPlayer.Play();
    }
}
