using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetLibrary : MonoBehaviour {
    public GameState gameState;

    public GameObject noPet;

    public Text statsText;

    private List<GameObject> creatures;

    public GameObject displayPanel;

    private int creatureIndex;

    public Button leftButton;

    public Button rightButton;

    public GameObject displayPet;

    void Start() {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();
        this.creatures = gameState.GetCreatureObjects();
        if (this.creatures.Count > 0)
        {
            // Hide all the creatures
            for (int i = this.creatures.Count-1; i >= 0; --i)
            {
                this.creatures[i].SetActive(false);
            }

            this.creatureIndex = 0;
            SetDisplayPet();
        }
        else
        {
            // Show no pet message
            this.noPet.SetActive(true);
            this.creatureIndex = -1;
        } 
    }

    public void Update()
    {
        if (this.creatures.Count > 0)
        {
            Creature creature = this.creatures[this.creatureIndex].GetComponent<Creature>();
            SetStats(this.statsText, creature);
        }

        if (this.creatureIndex == -1 || this.creatureIndex+1 >= this.creatures.Count)
        {
            rightButton.interactable = false;
        }
        if (this.creatureIndex == -1 || this.creatureIndex-1 < 0)
        {
            leftButton.interactable = false;
        }
    }

    public void SetStats(Text text, Creature creature)
    {
        text.text = String.Format("{0,15}   {1,15}\n", "Name", creature.name) +
                    String.Format("{0,15}   {1,15}\n", "Mood", creature.GetMood()) +
                    String.Format("{0,15}   {1,15}\n", "Happiness", creature.GetHappiness().GetPoints().ToString()) +
                    String.Format("{0,15}   {1,15}\n", "Hunger", creature.GetHunger().GetPoints().ToString()) +
                    String.Format("{0,15}   {1,15}\n", "Hygene", creature.GetHygene().GetPoints().ToString());
    }

    public void RightButtonOnClick()
    {
        if (this.creatureIndex != -1 && this.creatureIndex + 1 < this.creatures.Count && rightButton.interactable)
        {
            this.creatureIndex++;
            SetDisplayPet();
            leftButton.interactable = true;
        }
    }

    public void LeftButtonOnClick()
    {
        if (this.creatureIndex != -1 && this.creatureIndex-1 >= 0 && leftButton.interactable)
        {
            this.creatureIndex--;
            SetDisplayPet();
            rightButton.interactable = true;
        }
    }

    private void SetDisplayPet()
    {
        // Show the stats for the displayed creature
        Creature creature = this.creatures[this.creatureIndex].GetComponent<Creature>();
        SetStats(this.statsText, creature);
        Sprite creatureSprite = creature.GetComponent<SpriteRenderer>().sprite;

        // Set display pet image
        SpriteRenderer SR = this.displayPet.GetComponent<SpriteRenderer>();
        SR.sprite = creatureSprite;

        // Scale
        Transform transform = this.displayPet.GetComponent<Transform>();
        Vector3 scale = new Vector3(0.2f, 0.2f, 1f);
        transform.localScale = scale;
    }
}
