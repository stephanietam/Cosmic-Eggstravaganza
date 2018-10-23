using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour {
    public GameState gameState;
    public Text statsText;

    // Use this for initialization
    public void Start()
    {
        SetStats(statsText);
    }

    // Update is called once per frame
    public void Update()
    {
        SetStats(statsText);
    }

    public void SetStats(Text text)
    {
        foreach (Creature creature in gameState.GetCreatures())
        {
            text.text = creature.name + "\n" +
                    "Happiness: " + creature.GetHappiness().GetPoints().ToString() + "\n" +
                    "Hunger: " + creature.GetHunger().GetPoints().ToString() + "\n" +
                    "Hygene: " + creature.GetHygene().GetPoints().ToString() + "\n";
        }
        
    }
}
