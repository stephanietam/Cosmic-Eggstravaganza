using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPage : MonoBehaviour {
	void Start () {
        // pause the farm audio
        GameObject audioSourceObject = GameObject.FindGameObjectWithTag("BG Audio");
        AudioSource backgroundMusic = audioSourceObject.GetComponent<AudioSource>();
        backgroundMusic.Pause();
    }
}
