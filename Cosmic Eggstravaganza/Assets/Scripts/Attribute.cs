using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Attribute
    {
        private int currentPoints;
        private readonly int totalPoints;

        public Attribute(int startPoints, int totalPoints)
        {
            this.currentPoints = startPoints;
            this.totalPoints = totalPoints;
        }

        public int GetPoints()
        {
            return currentPoints;
        }

        public int GetTotalPoints()
        {
            return totalPoints;
        }

        public void LosePoints(int points)
        {
            if (currentPoints > 0)
            {
                currentPoints -= points;
            }
        }

        public void AddPoints(int points)
        {
            if (currentPoints < this.totalPoints)
            {
                currentPoints += points;
            }
            if (currentPoints > this.totalPoints)
            {
              currentPoints = this.totalPoints;
            }
        }
    }
}
