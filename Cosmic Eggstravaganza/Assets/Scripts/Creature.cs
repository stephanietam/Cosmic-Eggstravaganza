using UnityEngine;

namespace Assets.Scripts
{
    public class Creature : MonoBehaviour
    {
        public Attribute hunger;

        public Attribute happiness;

        public Attribute hygene;

        public int age;

        public bool hatched;

        public Area location;

        public Mood mood;

        public Creature()
        {
            this.hunger = new Attribute(10);
            this.happiness = new Attribute(10);
            this.hygene = new Attribute(10);
            this.age = 0;
            this.hatched = false;
            this.location = Area.Stable;
            this.mood = Mood.Happy;
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
            return hunger;
        }

        public Attribute GetHappiness()
        {
            return happiness;
        }

        public Attribute GetHygene()
        {
            return hygene;
        }

        public Mood GetMood()
        {
            return this.mood;
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
