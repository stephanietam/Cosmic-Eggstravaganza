using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LostNextButton : MonoBehaviour {
    public Text LostText;
    private string[] lines;
    private int index = 0;

    public void Start()
    {
        TextAsset data = Resources.Load("lostLines") as TextAsset;
        lines = data.text.Split(new string[] {"\n"}, StringSplitOptions.None);
        LostText.text = lines[index++];
    }

    public void OnClick()
    {
        Debug.Log(index);
        if(index == lines.Length){
            SceneManager.LoadScene("MenuScene");
            Destroy(GameObject.FindGameObjectWithTag("GameState"));
            Destroy(GameObject.FindGameObjectWithTag("BG Audio"));
        }
        else {
            LostText.text = lines[index++];
        }
    }

}
