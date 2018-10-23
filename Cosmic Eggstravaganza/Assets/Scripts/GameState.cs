using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class GameState : MonoBehaviour
    {
        private readonly DateTime dateTime;

		private int food;
        private int stars;

        public GameState()
        {
            this.dateTime = new DateTime();
			this.food = 100;
            this.stars = 100;
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
    }
}
