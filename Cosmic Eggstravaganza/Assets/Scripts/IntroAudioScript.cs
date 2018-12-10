using UnityEngine;
using System.Collections;

public class IntroAudioScript : MonoBehaviour
{
	public AudioSource backgroundMusic;
	public AudioSource explosionSound;

	// Use this for initialization
	void Start ()
	{

	}

	public void Explosion()
	{
		backgroundMusic.Stop();
		explosionSound.Play();
	}
}

