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

    public Button medicineButton;

    public GameObject petDescriptionText;

    public GameObject petStatusText;

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
            this.sellButton.interactable = true;
        }
        else
        {
            // Show no pet message
            this.noPet.SetActive(true);
            this.creatureIndex = -1;
            this.sellButton.interactable = false;
        }
        SetTextTitles(this.statsText);
    }

    public void Update()
    {
        if (this.creatures.Count > 0)
        {
            Creature creature = this.creatures[this.creatureIndex].GetComponent<Creature>();

            SetTextValues(this.descriptionText, creature);
            if (!creature.HasHatched() || gameState.GetMedicine()<=0 || creature.mood != Mood.Sick)
            {
                medicineButton.interactable = false;
            }
        }
        else
        {
            medicineButton.interactable = false;
        }
        
    }

    public void SetTextTitles(Text text)
    {
        text.text = String.Format("{0,-15}\n", "Name") +
                    String.Format("{0,-15}\n", "Mood") +
                    String.Format("{0,-15}\n\n", "Worth") +
                    String.Format("{0,-15}\n", "Hunger") +
                    String.Format("{0,-15}\n", "Hygene") +
                    String.Format("{0,-15}\n", "Amusement") +
                    String.Format("{0,-15}\n", "Energy") +
                    String.Format("{0,-15}\n", "Strength") +
                    String.Format("{0,-15}\n", "Dexterity") +
                    String.Format("{0,-15}\n", "Intelligence");
    }

    public void SetTextValues(Text text, Creature creature)
    {
        text.text = String.Format("{0,15}\n", creature.name) +
                    String.Format("{0,15}\n", creature.mood) +
                    String.Format("{0,15}\n\n", creature.GetWorth()) +
                    String.Format("{0,15}\n", creature.GetHunger().GetPoints().ToString()) +
                    String.Format("{0,15}\n", creature.GetHygene().GetPoints().ToString()) +
                    String.Format("{0,15}\n", creature.GetAmusement().GetPoints().ToString()) +
                    String.Format("{0,15}\n", creature.GetEnergy().GetPoints().ToString()) +
                    String.Format("{0,15}\n", creature.GetStrength().GetPoints().ToString()) +
                    String.Format("{0,15}\n", creature.GetDexterity().GetPoints().ToString()) +
                    String.Format("{0,15}\n", creature.GetIntelligence().GetPoints().ToString());
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
            SetTextValues(this.statsText, creature);
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
            this.petStatusText.SetActive(false);
            this.petDescriptionText.SetActive(false);
            this.sellButton.interactable = false;
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

    public void MedicineOnClick()
    {
        // boost pet stats
        GameObject creatureObject = this.creatures[this.creatureIndex];
        Creature creature = creatureObject.GetComponent<Creature>();
        creature.GetEnergy().AddPoints(5);
        creature.GetAmusement().AddPoints(5);
        creature.GetHygene().AddPoints(5);

        SetDisplayPet();
        gameState.medicine -= 1;
    }
}
