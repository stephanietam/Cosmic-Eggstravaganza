﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Creature : MonoBehaviour
    {
        public Attribute hunger;

        public Attribute happiness;

        public Attribute hygene;

        public Attribute energy;

        public Attribute amusement;

        public int age;

        public bool hatched;

        public Area location;

        public Mood mood;

        public bool healthy;

        public Creature()
        {
            this.hunger = new Attribute(10);
            this.happiness = new Attribute(10);
            this.hygene = new Attribute(10);
            this.energy = new Attribute(10);
            this.amusement = new Attribute(10);

            this.age = 0;
            this.hatched = false;
            this.location = Area.Stable;
            this.mood = Mood.Happy;
            this.healthy = true;
        }

        public bool HasHatched()
        {
            return this.hatched;
        }

        public void Hatch()
        {
            this.hatched = true;
        }

        public Attribute GetHappiness()
        {
            return this.happiness;
        }

        public Attribute GetHunger()
        {
            return this.hunger;
        }

        public Attribute GetHygene()
        {
            return this.hygene;
        }

        public Attribute GetAmusement()
        {
            return this.amusement;
        }

        public Attribute GetEnergy()
        {
            return this.energy;
        }

        public Mood GetMood()
        {
            return this.mood;
        }

        public void SetMood()
        {
            if (this.hunger.GetPoints() > 5 && this.happiness.GetPoints() > 5 && this.hygene.GetPoints() > 5 && this.energy.GetPoints() > 5 && this.amusement.GetPoints() > 5)
            {
                this.healthy = true;
                this.mood = Mood.Happy;
            }
            else if (this.hunger.GetPoints() < 4 && this.happiness.GetPoints() < 4 && this.hygene.GetPoints() < 4 && this.energy.GetPoints() < 4 && this.amusement.GetPoints() < 4)
            {
                this.healthy = false;
                this.mood = Mood.Sick;
            }
            else if (this.hunger.GetPoints() < 4)
            {
                this.mood = Mood.Hungry;
            }
            else if (this.energy.GetPoints() < 4)
            {
                this.mood = Mood.Sleepy;
            }
            else if (this.amusement.GetPoints() < 4)
            {
                this.mood = Mood.Bored;
            }
            else if (this.hygene.GetPoints() < 4)
            {
                this.mood = Mood.Disgusted;
            }
            else
            {
                this.mood = Mood.Neutral;
            }
        }

        public void DecreaseAttribute(Attribute attribute)
        {
            attribute.LosePoints(1);
        }

        public void IncreaseAttribute(Attribute attribute)
        {
            attribute.AddPoints(1);
        }

        public static Creature Instance;
        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
