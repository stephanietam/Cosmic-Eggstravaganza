using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class GameState : MonoBehaviour
    {
        private readonly DateTime dateTime;

		private int food;
        private int stars;

        private readonly List<Creature> creatures;

        private int creatureCount;

        private List<GameObject> creatureObjects;

        public GameState()
        {
            this.dateTime = new DateTime();
			this.food = 100;
            this.stars = 100;
            this.creatureCount = 0;
            this.creatureObjects = new List<GameObject>();
        }

        public void Start()
        {
            // Create the first creature
            GameObject newCreature = new GameObject("Creature" + this.creatureCount++);
            newCreature.AddComponent<Creature>();
            newCreature.GetComponent<Creature>().Hatch();
            creatureObjects.Add(newCreature);
            Debug.Log("Creature created!");
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }

        public int GetStars()
        {
            return stars;
        }

		public int GetFood()
		{
			return food;
		}

        public void AddStars(int amount)
        {
            this.stars += amount;
        }

        public List<Creature> GetCreatures()
        {
            List<Creature> creatures = new List<Creature>();
            for (int i = 0; i < creatureObjects.Count; ++i)
            {
                creatures.Add(creatureObjects[i].GetComponent<Creature>());
            }
            return creatures;
        }
    }
}
