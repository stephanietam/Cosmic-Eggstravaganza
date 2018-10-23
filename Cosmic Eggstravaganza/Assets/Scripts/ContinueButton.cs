using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {

    public GameState gameState;

    public void OnClick()
    {
      SceneManager.LoadScene("FarmScene");
    }

}
