using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveButton : MonoBehaviour {

    public GameState gameState;
    public Text saveText;
    string dataPath;

    public void Start()
    {
      GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
      this.gameState = gameObject.GetComponent<GameState>();
      saveText.text = "";
    }

    public void OnClick()
    {
      saveText.text = "Saving...";
      dataPath = Path.Combine(Application.persistentDataPath, "save.sv");
      string saveInfo = gameState.WriteSave();
      using (StreamWriter streamWriter = File.CreateText(dataPath))
       {
           streamWriter.Write (saveInfo);
       }
       saveText.text = "Game saved.";
    }

}
