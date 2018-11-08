using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPhaseButton : MonoBehaviour {

    public GameState gameState;
    public Text dateTimeText;

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();
        dateTimeText.text = gameState.GetDateTime().ToString();
    }

    public void OnClick()
    {
        // Change scene aka change background?


        // Decrease stats for all pets
        if (gameState.creatureCount > 0)
        {
            List<Creature> creatures = gameState.GetCreatures();
            for (int i = 0; i < creatures.Count; ++i)
            {
                Creature creature = creatures[i];
                // change stats
                ChangeCreatureStats(creature);
            }
        }

        // Set time of day
        NextDateTime();
    }

    public void ChangeCreatureStats(Creature creature)
    {
        if (creature.HasHatched())
        {
            // decrease stats
            Attribute hygene = creature.GetHygene();
            Attribute hunger = creature.GetHunger();
            Attribute happiness = creature.GetHappiness();

            hygene.LosePoints(1);
            hunger.LosePoints(1);
            happiness.LosePoints(1);
        }
    }

    public void NextDateTime()
    {
        DateTime dateTime = gameState.GetDateTime();
        dateTime.NextPhase();

        dateTimeText.text = dateTime.ToString();
        Debug.Log(dateTimeText.text);
    }
}