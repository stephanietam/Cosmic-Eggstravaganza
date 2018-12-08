using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class OutroNextButton : MonoBehaviour {

	public Text OutroText;
	private string[] lines;
	private int index = 0;
	public GameObject OutroImage1;
	public GameObject OutroImage2;
	public GameObject OutroImage3;

	public void Start()
	{
		TextAsset data = Resources.Load("outroLines") as TextAsset;
		lines = data.text.Split(new string[] {"\n"}, StringSplitOptions.None);
		OutroText.text = lines[index++];
	}

	public void OnClick()
	{
		if(index == lines.Length){
			SceneManager.LoadScene("MenuScene");

			Destroy(GameObject.FindGameObjectWithTag("GameState"));
			Destroy(GameObject.FindGameObjectWithTag("BG Audio"));
		}else{
			OutroText.text = lines[index++];
			if (index == 13){
				OutroImage1.SetActive(false);
				OutroImage2.SetActive(true);
			}
			if (index == 15){
				OutroImage2.SetActive(false);
				OutroImage3.SetActive(true);
			}
		}
	}

}
