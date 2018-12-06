using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmScript : MonoBehaviour {

    public GameState gameState;

    public Text starsText;

    public Text foodText;

    private int phase;

    public GameObject morningImage;

    public GameObject nightImage;

    public GameObject afternoonImage;

    public GameObject audioSourceObject;

    void Start () {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();
        SetBackground();


        GameObject audioSourceObject = GameObject.FindGameObjectWithTag("BG Audio");
        AudioSource backgroundMusic = audioSourceObject.GetComponent<AudioSource>();
        backgroundMusic.UnPause();
    }

    private void SetBackground()
    {
        this.phase = this.gameState.GetDateTime().GetPhase();
        if (this.phase==0)
        {
            morningImage.SetActive(true);
            nightImage.SetActive(false);
            afternoonImage.SetActive(false);
        }
        else if (this.phase == 1)
        {
            morningImage.SetActive(false);
            nightImage.SetActive(false);
            afternoonImage.SetActive(true);
        }
        else if (this.phase == 2)
        {
            morningImage.SetActive(false);
            nightImage.SetActive(true);
            afternoonImage.SetActive(false);
        }
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

        // Set background, stars, and food
        SetBackground();
        starsText.text = "Stars: " + this.gameState.GetStars().ToString();
        foodText.text = "Food: " + this.gameState.GetFood().ToString();
    }

}
