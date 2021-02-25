using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController: MonoBehaviour {

    private bool playing;

    public AudioSource musicPlayer;
    public AudioClip[] tracks;

    void Start ()
    {
        PlayRandomTrack();
	}
	
	void Update ()
    {
		if (!musicPlayer.isPlaying && PlayerPrefs.GetFloat("MusicToggle") == 1)
        {
            PlayRandomTrack();
        }
	}

    void PlayRandomTrack()
    {
        if (PlayerPrefs.GetFloat("MusicToggle") == 1)
        {
            musicPlayer.clip = tracks[Random.Range(0, tracks.Length)];
            musicPlayer.Play();
        }
        
    }
}
