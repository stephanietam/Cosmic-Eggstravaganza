using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scripts {
    public class GameState : MonoBehaviour
    {
        public readonly DateTime dateTime;

        public int food;

        public int stars;

        public int medicine;

        public int creatureCount;

        public List<GameObject> creatureObjects;

        public int dept;

        public GameState()
        {
            this.dateTime = new DateTime();
			this.food = 0;
            this.stars = 10;
            this.medicine = 0;
            this.creatureCount = 0;
            this.creatureObjects = new List<GameObject>();
            this.dept = 1000;
        }

        public void Start()
        {
            // Create the first creature
            this.CreateCreature();
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

        public int GetMedicine()
        {
            return medicine;
        }

        public void AddStars(int amount)
        {
            this.stars += amount;
        }

        public void AddFood(int amount)
        {
            this.food += amount;
        }

        public void AddMedicine(int amount)
        {
            this.medicine += amount;
        }

        public void AddCreature(GameObject creatureObject)
        {
            this.creatureCount += 1;
            this.creatureObjects.Add(creatureObject);
        }

        public void RemoveCreature(GameObject creatureObject)
        {
            this.creatureObjects.Remove(creatureObject);
            this.creatureCount -= 1;
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

        public List<GameObject> GetCreatureObjects()
        {
            return this.creatureObjects;
        }

        public static GameState Instance;
        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(transform.gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(transform.gameObject);
            }
        }

        public void CreateCreature()
        {
            // Create gameobject
            GameObject newCreature = new GameObject("Creature " + this.creatureCount++);
            newCreature.AddComponent<SpriteRenderer>();
            newCreature.AddComponent<CapsuleCollider2D>();

            // Set egg
            Texture2D tex = Resources.Load<Texture2D>("egg") as Texture2D;
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            SpriteRenderer SR = newCreature.GetComponent<SpriteRenderer>();
            SR.sprite = sprite;

            // Set size
            Transform transform = newCreature.GetComponent<Transform>();
            Vector3 mi = transform.localScale;
            mi.y = 0.2f;
            mi.x = 0.2f;
            transform.localScale = mi;

            // Set collider size
            CapsuleCollider2D collider = newCreature.GetComponent<CapsuleCollider2D>();
            Vector2 v = collider.size;
            v.x = 5f;
            v.y = 5f;
            collider.size = v;

            // Add creature component
            newCreature.AddComponent<Creature>();
            newCreature.SetActive(false);

            // Add to list of creatures
            creatureObjects.Add(newCreature);
        }
    }
}
