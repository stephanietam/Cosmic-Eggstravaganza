using UnityEngine;

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

        public int worth;

        public Creature()
        {
            this.hunger = new Attribute(10);
            this.hygene = new Attribute(10);
            this.energy = new Attribute(10);
            this.amusement = new Attribute(10);
            this.strength = new Attribute(0);
            this.dexterity = new Attribute(0);
            this.intelligence = new Attribute(0);

            this.age = 0;
            this.hatched = false;
            this.location = Area.Stable;
            this.mood = Mood.Happy;
            this.healthy = true;
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

        public int GetWorth()
        {
            this.SetWorth();
            return this.worth;
        }

        public void SetWorth()
        {
          this.worth = 10+10*this.strength.GetPoints()+10*this.dexterity.GetPoints()+10*this.intelligence.GetPoints();
          if (this.mood == Mood.Sick)
          {
            this.worth /= 2;
          }
        }

        public void SetMood()
        {
            if (this.hunger.GetPoints() > 5 && this.hygene.GetPoints() > 5 && this.energy.GetPoints() > 5 && this.amusement.GetPoints() > 5)
            {
                this.healthy = true;
                this.mood = Mood.Happy;
            }
            else if (this.hunger.GetPoints() < 4 && this.hygene.GetPoints() < 4 && this.energy.GetPoints() < 4 && this.amusement.GetPoints() < 4)
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
