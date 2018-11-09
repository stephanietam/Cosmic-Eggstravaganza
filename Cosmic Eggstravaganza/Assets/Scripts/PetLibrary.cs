using Assets.Scripts;
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

            //this.creatures[0].SetActive(true);
            this.creatureIndex = 0;

            // Show the stats for the displayed creature
            Creature creature = this.creatures[this.creatureIndex].GetComponent<Creature>();
            SetStats(this.statsText, creature);
            Sprite creatureSprite = creature.GetComponent<SpriteRenderer>().sprite;

            // Set display pet image
            SpriteRenderer SR = this.displayPet.GetComponent<SpriteRenderer>();
            SR.sprite = creatureSprite;
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
        text.text = creature.name + "\n" +
                "Age: " + creature.age/3 + " days\n" +
                "Happiness: " + creature.GetHappiness().GetPoints().ToString() + "\n" +
                "Hunger: " + creature.GetHunger().GetPoints().ToString() + "\n" +
                "Hygene: " + creature.GetHygene().GetPoints().ToString() + "\n";
    }

    public void RightButtonOnClick()
    {
        if (this.creatureIndex != -1 && this.creatureIndex + 1 < this.creatures.Count && rightButton.interactable)
        {
            this.creatures[this.creatureIndex].SetActive(false);
            this.creatureIndex++;
            this.creatures[this.creatureIndex].SetActive(true);
            leftButton.interactable = true;
        }
    }

    public void LeftButtonOnClick()
    {
        if (this.creatureIndex != -1 && this.creatureIndex-1 >= 0 && leftButton.interactable)
        {
            this.creatures[this.creatureIndex].SetActive(false);
            this.creatureIndex--;
            this.creatures[this.creatureIndex].SetActive(true);
            rightButton.interactable = true;
        }
    }
}
