﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Creature : MonoBehaviour
    {
        public Attribute hunger;

        public Attribute hygene;

        public Attribute energy;

        public Attribute amusement;

        public Attribute strength;

        public Attribute dexterity;

        public Attribute intelligence;

        public int age;

        public bool hatched;

        public Area location;

        public Mood mood;

        public bool healthy;

        public bool alive;

        public int worth;

        public Creature()
        {
            this.hunger = new Attribute(10,10);
            this.hygene = new Attribute(10,10);
            this.energy = new Attribute(10,10);
            this.amusement = new Attribute(10,10);

            this.strength = new Attribute(0,100);
            this.dexterity = new Attribute(0,100);
            this.intelligence = new Attribute(0,100);

            this.age = 0;
            this.hatched = false;
            this.location = Area.Stable;
            this.mood = Mood.Happy;
            this.healthy = true;
            this.alive = true;

            this.worth = 10;
        }

        public bool HasHatched()
        {
            return this.hatched;
        }

        public void Hatch()
        {
            this.hatched = true;
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

        public Attribute GetStrength()
        {
          return this.strength;
        }

        public Attribute GetDexterity()
        {
          return this.dexterity;
        }

        public Attribute GetIntelligence()
        {
          return this.intelligence;
        }

        public string GetArea()
        {
          if (this.location == Area.Stable){
            return "Stable";
          }
          if (this.location == Area.Clean){
            return "Cleaning";
          }
          if (this.location == Area.Eat){
            return "Eating Hall";
          }
          if (this.location == Area.Playground){
            return "Playground";
          }
          if (this.location == Area.Gym){
            return "Gym";
          }
          return "None";
        }

        public int GetWorth()
        {
            this.worth = 10 + 10*this.strength.GetPoints() + 10*this.dexterity.GetPoints() + 10*this.intelligence.GetPoints();
            if (this.mood == Mood.Sick)
            {
                this.worth /= 2;
            }
            if (this.mood == Mood.Happy)
            {
              this.worth *= 2;
            }
            return this.worth;
        }

        public void SetMood()
        {
            if (this.hunger.GetPoints() > 5 && this.hygene.GetPoints() > 5 && this.energy.GetPoints() > 5 && this.amusement.GetPoints() > 5)
            {
                this.healthy = true;
                this.mood = Mood.Happy;
                return;
            }
            else if (this.hunger.GetPoints() < 3 && this.hygene.GetPoints() < 3 && this.energy.GetPoints() < 3)
            {
                this.healthy = false;
                this.mood = Mood.Sick;
                return;
            }
            else if (this.hunger.GetPoints() < 4)
            {
                this.mood = Mood.Hungry;
                return;
            }
            else if (this.energy.GetPoints() < 4)
            {
                this.mood = Mood.Sleepy;
                return;
            }
            else if (this.amusement.GetPoints() < 4)
            {
                this.mood = Mood.Bored;
                return;
            }
            else if (this.hygene.GetPoints() < 4)
            {
                this.mood = Mood.Disgusted;
                return;
            }
            else
            {
                this.mood = Mood.Neutral;
            }
        }

        public static Creature Instance;
        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        void OnMouseOver()
        {
            GameObject statsTitleObject = GameObject.Find("Stats Title Text");
            Text statsTitleText = statsTitleObject.GetComponent<Text>();
            statsTitleText.text = String.Format("{0,15}\n", "Name") +
                             String.Format("{0,15}\n", "Mood") +
                             String.Format("{0,15}\n", "Hunger") +
                             String.Format("{0,15}\n", "Hygene") +
                             String.Format("{0,15}\n", "Amusement") +
                             String.Format("{0,15}\n", "Energy") +
                             String.Format("{0,15}\n", "Area");
            GameObject statsTextObject = GameObject.Find("Stats Text");
            Text statsText = statsTextObject.GetComponent<Text>();
            statsText.text = String.Format("{0,15}\n", this.name) +
                             String.Format("{0,15}\n", this.GetMood()) +
                             String.Format("{0,15}\n", this.GetHunger().GetPoints().ToString()) +
                             String.Format("{0,15}\n", this.GetHygene().GetPoints().ToString()) +
                             String.Format("{0,15}\n", this. GetAmusement().GetPoints().ToString()) +
                             String.Format("{0,15}\n", this.GetEnergy().GetPoints().ToString()) +
                             String.Format("{0,15}\n", this.GetArea());

        }

        void OnMouseExit()
        {
            GameObject statsTextObject = GameObject.Find("Stats Text");
            Text statsText = statsTextObject.GetComponent<Text>();
            statsText.text = "";
            GameObject statsTitleObject = GameObject.Find("Stats Title Text");
            Text statsTitleText = statsTitleObject.GetComponent<Text>();
            statsTitleText.text = "";
        }
    }
}
