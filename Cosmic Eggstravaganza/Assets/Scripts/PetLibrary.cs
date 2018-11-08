using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetLibrary : MonoBehaviour {
    public GameState gameState;

    public GameObject noPet;

    public GameObject displayObject;

    public Creature displayCreature;

    public Text statsText;

    private List<GameObject> creatures;

    public GameObject displayPanel;

    private int creatureIndex;

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

            // set display creature
            this.displayObject = this.creatures[0];
            this.displayCreature = this.displayObject.GetComponent<Creature>();

            this.creatures[0].SetActive(true);
            this.creatureIndex = 0;
        
            // Show the stats for the displayed creature
            SetStats(this.statsText, this.displayCreature);
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
            SetStats(this.statsText, this.displayCreature);
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
        if (this.creatureIndex!=-1 && this.creatureIndex+1<this.creatures.Count)
        {
            
            this.creatures[this.creatureIndex].SetActive(false);
            this.creatureIndex++;
            this.displayObject = this.creatures[this.creatureIndex];
            this.displayCreature = this.displayObject.GetComponent<Creature>();
            this.creatures[this.creatureIndex].SetActive(true);
        }
    }

    public void LeftButtonOnClick()
    {
        if (this.creatureIndex != -1 && this.creatureIndex-1 >= 0)
        {
            this.creatures[this.creatureIndex].SetActive(false);
            this.creatureIndex--;
            this.displayObject = this.creatures[this.creatureIndex];
            this.displayCreature = this.displayObject.GetComponent<Creature>();
            this.creatures[this.creatureIndex].SetActive(true);
        }
    }
}
