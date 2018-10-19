using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts {
    public class GameState : MonoBehaviour
    {
        private readonly DateTime dateTime;

        private int stars;

        public GameState()
        {
            this.dateTime = new DateTime();
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
    }
}
