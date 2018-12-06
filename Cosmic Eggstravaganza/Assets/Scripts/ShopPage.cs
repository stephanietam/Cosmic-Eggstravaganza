using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPage : MonoBehaviour {
	void Start () {
        GameObject audioSourceObject = GameObject.FindGameObjectWithTag("BG Audio");
        AudioSource backgroundMusic = audioSourceObject.GetComponent<AudioSource>();
        backgroundMusic.Pause();
    }
}
