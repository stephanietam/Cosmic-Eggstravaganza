using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour {

    public GameState gameState;

    public void OnClick()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();
        List<GameObject> creatures = this.gameState.GetCreatureObjects();
        for (int i = this.gameState.creatureCount - 1; i >= 0; --i)
        {
            GameObject creature = creatures[i];
            if (!creature.activeSelf)
            {
                creature.SetActive(false);
            }

        }

        SceneManager.LoadScene("OptionsScene");
    }

}
