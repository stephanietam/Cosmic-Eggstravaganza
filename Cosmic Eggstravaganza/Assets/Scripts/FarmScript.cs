using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScript : MonoBehaviour {

    public GameState gameState;

	// Use this for initialization
	void Start () {
        Debug.Log("Started");
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();
    }

    private void Update()
    {
        // Show all the creatures if not shown
        List<GameObject> creatures = this.gameState.GetCreatureObjects();
        for (int i = this.gameState.creatureCount - 1; i >= 0; --i)
        {
            GameObject creature = creatures[i];
            if (!creature.activeSelf)
            {
                creature.SetActive(true);
            }
            
        }
    }

}
