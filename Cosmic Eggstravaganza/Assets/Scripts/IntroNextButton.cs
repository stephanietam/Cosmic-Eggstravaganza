using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class IntroNextButton : MonoBehaviour {

    public GameState gameState;
    public Text IntroText;
    private string[] lines;
    private int index = 0;

    public void Start()
    {
      TextAsset data = Resources.Load("introLines") as TextAsset;
      lines = data.text.Split(new string[] {"\n"}, StringSplitOptions.None);
      IntroText.text = lines[index++];
    }

    public void OnClick()
    {
      if(index == lines.Length){
        SceneManager.LoadScene("FarmScene");
      }else{
        IntroText.text = lines[index++];
      }
    }

}
