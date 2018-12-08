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
    public GameObject IntroImage1;
    public GameObject IntroImage2;
    public GameObject IntroImage3;

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
        if (index == 8){
          IntroImage1.SetActive(false);
          IntroImage2.SetActive(true);
        }
        if (index == 9){
          IntroImage2.SetActive(false);
          IntroImage3.SetActive(true);
        }
      }
    }

}
