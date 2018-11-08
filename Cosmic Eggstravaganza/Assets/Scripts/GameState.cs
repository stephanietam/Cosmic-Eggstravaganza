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

        public readonly List<Creature> creatures;

        public int creatureCount;

        public List<GameObject> creatureObjects;

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

        private void CreateCreature()
        {
            // Create gameobject
            GameObject newCreature = new GameObject("Creature " + this.creatureCount++);
            newCreature.AddComponent<SpriteRenderer>();
            newCreature.AddComponent<CapsuleCollider2D>();

            // Choose random pet
            List<string> imageFiles = new List<string>{"1","2","3","4","5","6a", "6b", "6c", "7" };
            System.Random random = new System.Random();
            int randomImageInt = random.Next(0,9);
            Debug.Log("Randomimageint: " + randomImageInt);

            // Set image
            Texture2D tex = Resources.Load<Texture2D>(imageFiles[randomImageInt]) as Texture2D;
            Debug.Log("image name: " + tex.name);
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            SpriteRenderer SR = newCreature.GetComponent<SpriteRenderer>();
            SR.sprite = sprite;

            // Set size
            Transform transform = newCreature.GetComponent<Transform>();
            Vector3 mi = transform.localScale;
            mi.y = 0.1f;
            mi.x = 0.1f;
            transform.localScale = mi;

            // Set collider size
            CapsuleCollider2D collider = newCreature.GetComponent<CapsuleCollider2D>();
            Vector2 v = collider.size;
            v.x = 10f;
            v.y = 10f;
            collider.size = v;

            // Add creature component
            newCreature.AddComponent<Creature>();
            newCreature.GetComponent<Creature>().Hatch();

            // Add to list of creatures
            creatureObjects.Add(newCreature);
            Debug.Log("Creature created!");
        }
    }
}
