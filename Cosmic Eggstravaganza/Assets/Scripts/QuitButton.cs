using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour {

    public GameState gameState;

    public void OnClick()
    {
      Application.Quit();
    }

}
