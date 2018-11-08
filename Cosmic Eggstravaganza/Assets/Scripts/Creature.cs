using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class Creature : MonoBehaviour
    {
        public Attribute hunger;
        public Attribute happiness;
        public Attribute hygene;
        public bool hatched;

        public Creature()
        {
            hunger = new Attribute(10);
            happiness = new Attribute(10);
            hygene = new Attribute(10);
            hatched = false;
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
    }
}
