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

	public void Start()
	{
		TextAsset data = Resources.Load("outroLines") as TextAsset;
		lines = data.text.Split(new string[] {"\n"}, StringSplitOptions.None);
		OutroText.text = lines[index++];
	}

	public void OnClick()
	{
		if(index == lines.Length){
			SceneManager.LoadScene("EndScene");
		}else{
			OutroText.text = lines[index++];
		}
	}

}
