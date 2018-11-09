using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadButton : MonoBehaviour {

    public GameState gameState;

    public void OnClick()
    {
        string path = Path.Combine(Application.persistentDataPath, "save.sv");
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        using (StreamReader streamReader = File.OpenText (path))
        {
            string jsonString = streamReader.ReadToEnd ();
            this.gameState = JsonUtility.FromJson<GameState> (jsonString);
        }
        SceneManager.LoadScene("FarmScene");
    }

}
