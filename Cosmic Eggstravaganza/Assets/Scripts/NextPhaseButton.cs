using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPhaseButton : MonoBehaviour {

    public GameState gameState;

    public Text dateTimeText;

    public GameObject deadPetPopUp;
    public Text deadPetPopUpDesc;
    public GameObject deadPetPopImg;

    public GameObject bgHider;

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();
        dateTimeText.text = gameState.GetDateTime().ToString();
    }

    public void OnClick()
    {
        // Decrease stats for all pets
        if (gameState.creatureCount > 0)
        {
            List<GameObject> creatureObjects = gameState.GetCreatureObjects();
            for (int i = 0; i < creatureObjects.Count; ++i)
            {
                Creature creature = creatureObjects[i].GetComponent<Creature>();
                // change stats
                ChangeCreatureStats(creature);

                // Check if creature is dead
                CheckDeath(creatureObjects[i], gameState.deadCreatures);
            }
        }

        // popup for dead creatures
        List<GameObject> deadCreatures = gameState.deadCreatures;
        if (deadCreatures.Count > 0)
        {
            if (!deadPetPopUp.activeSelf)
            {
                DeadCreaturesPopUp(deadCreatures[0]);
            }
        }

        // Set time of day
        NextDateTime();

        // check for eggs to hatch
        for (int i = 0; i < this.gameState.creatureCount; ++i)
        {
            GameObject creatureObject = this.gameState.creatureObjects[i];
            Creature creature = creatureObject.GetComponent<Creature>();
            if (!creature.HasHatched() && creature.age >= 3)
            {
                creature.Hatch();

                // Set new image of pet
                List<string> imageFiles = new List<string> { "1", "2", "3", "4", "5", "6a", "6b", "6c", "7" };
                System.Random random = new System.Random();
                int randomImageInt = random.Next(0, 9);

                Texture2D tex = Resources.Load<Texture2D>(imageFiles[randomImageInt]) as Texture2D;
                Sprite sprite = new Sprite();
                sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                SpriteRenderer SR = creatureObject.GetComponent<SpriteRenderer>();
                SR.sprite = sprite;

                // Set size
                Transform transform = creatureObject.GetComponent<Transform>();
                Vector3 mi = transform.localScale;
                mi.y = 0.1f;
                mi.x = 0.1f;
                transform.localScale = mi;

                // Set collider size
                CapsuleCollider2D collider = creatureObject.GetComponent<CapsuleCollider2D>();
                Vector2 v = collider.size;
                v.x = 10f;
                v.y = 10f;
                collider.size = v;
            }
        }
    }

    public void CheckDeath(GameObject creature, List<GameObject> deadCreatures)
    {
        Creature c = creature.GetComponent<Creature>();
        if (c.GetHunger().GetPoints() <= 0)
        {
            // Pet is dead
            deadCreatures.Add(creature);
            Debug.Log("creature added to deadcreatures");
        }
    }

    private void DeadCreaturesPopUp(GameObject creatureObject)
    {
        Creature creature = creatureObject.GetComponent<Creature>();
        Sprite creatureSprite = creature.GetComponent<SpriteRenderer>().sprite;

        // Set display pet image
        Image img = this.deadPetPopImg.GetComponent<Image>();
        img.sprite = creatureSprite;
        img.preserveAspect = true;

        deadPetPopUpDesc.text = "Name: " + creature.name + "\n" +
                                "Age: " + creature.age + " days\n" +
                                "ToD: " + gameState.GetDateTime().ToString() + "\n";

        deadPetPopUp.SetActive(true);
        bgHider.SetActive(true);
    }

    public void ClosePopUp()
    {
        List<GameObject> deadCreatures = gameState.deadCreatures;
        gameState.RemoveCreature(deadCreatures[0]);
        GameObject dead = GameObject.Find(deadCreatures[0].name);
        Destroy(dead);
        deadCreatures.Remove(deadCreatures[0]);

        deadPetPopUp.SetActive(false);
        bgHider.SetActive(false);
        
        if (deadCreatures.Count > 0)
        {
            if (!deadPetPopUp.activeSelf)
            {
                DeadCreaturesPopUp(deadCreatures[0]);
            }
        }      
    }

    public void ChangeCreatureStats(Creature creature)
    {
        if (creature.HasHatched())
        {
            // decrease stats
            Attribute hygene = creature.GetHygene();
            Attribute hunger = creature.GetHunger();
            Attribute energy = creature.GetEnergy();
            Attribute amusement = creature.GetAmusement();
            Attribute strength = creature.GetStrength();
            Attribute dexterity = creature.GetDexterity();
            Attribute intelligence = creature.GetIntelligence();
            List<Attribute> attributes = new List<Attribute>{strength,dexterity,intelligence};

            hygene.LosePoints(1);
            hunger.LosePoints(1);
            energy.LosePoints(1);
            amusement.LosePoints(1);
            creature.SetMood();

            if (creature.location == Area.Eat){
                if (this.gameState.GetFood() > 0){
                  this.gameState.AddFood(-1);
                  hunger.AddPoints(3);
                }
                energy.AddPoints(3);
            }
            if (creature.location == Area.Clean){
              hygene.AddPoints(3);
            }
            if (creature.location == Area.Playground){
              amusement.AddPoints(3);
            }
            if (creature.location == Area.Gym){
              System.Random random = new System.Random();
              int randomStat = random.Next(0, 3);
              attributes[randomStat].AddPoints(2);
            }
        }
        creature.age += 1;
    }

    public void NextDateTime()
    {
        DateTime dateTime = gameState.GetDateTime();
        dateTime.NextPhase();

        dateTimeText.text = dateTime.ToString();
        Debug.Log(dateTimeText.text);
    }
}
