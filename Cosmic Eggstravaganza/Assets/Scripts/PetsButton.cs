using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PetsButton : MonoBehaviour {

    public GameState gameState;

    public void OnClick()
    {
      SceneManager.LoadScene("PetsScene");
    }

}
