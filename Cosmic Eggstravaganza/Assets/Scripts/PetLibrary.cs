using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetLibrary : MonoBehaviour {
    public GameState gameState;

    public GameObject noPet;

    public Text statsText;

    public Text descriptionText;

    private List<GameObject> creatures;

    public GameObject displayPanel;

    private int creatureIndex;

    public Button leftButton;

    public Button rightButton;

    public GameObject displayPet;

    public Button sellButton;

    public GameObject petText;

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
            SetDescription(this.descriptionText, creature);
        }
    }

    public void SetStats(Text text, Creature creature)
    {
        text.text = String.Format("{0,15}   {1,15}\n", "Hunger", creature.GetHunger().GetPoints().ToString()) +
                    String.Format("{0,15}   {1,15}\n", "Hygene", creature.GetHygene().GetPoints().ToString()) +
                    String.Format("{0,15}   {1,15}\n", "Amusement", creature.GetAmusement().GetPoints().ToString()) +
                    String.Format("{0,15}   {1,15}\n", "Energy", creature.GetEnergy().GetPoints().ToString());
    }

    public void SetDescription(Text text, Creature creature)
    {
        text.text = String.Format("{0,15}   {1,15}\n", "Name", creature.name) +
                    String.Format("{0,15}   {1,15}\n", "Mood", creature.GetMood()) +
                    String.Format("{0,15}   {1,15}\n", "Worth", creature.GetWorth());
    }

    public void RightButtonOnClick()
    {
        if (this.creatures.Count > 0)
        {
            this.creatureIndex++;

            if (this.creatureIndex >= this.creatures.Count)
            {
                this.creatureIndex %= this.creatures.Count;
            }

            SetDisplayPet();
        }
    }

    public void LeftButtonOnClick()
    {
        if (this.creatures.Count > 0)
        {
            this.creatureIndex--;

            if (this.creatureIndex < 0)
            {
                this.creatureIndex = this.creatures.Count - 1;
            }

            SetDisplayPet();
        }
    }

    private void SetDisplayPet()
    {
        if (this.creatures.Count <= 0)
        {
            this.noPet.SetActive(true);
        }
        else
        {
            this.noPet.SetActive(false);
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

    public void SellPet()
    {
        GameObject creatureObject = this.creatures[this.creatureIndex];
        this.gameState.stars += creatureObject.GetComponent<Creature>().GetWorth();

        this.gameState.RemoveCreature(creatureObject);

        if (this.creatures.Count <= 0)
        {
            this.sellButton.interactable = false;
            this.displayPet.SetActive(false);
            this.petText.SetActive(false);

        }
        else
        {
            this.creatureIndex += 1;
            if (this.creatureIndex >= this.creatures.Count)
            {
                this.creatureIndex = 0;
            }

        }

        SetDisplayPet();
    }
}
