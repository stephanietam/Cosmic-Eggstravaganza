namespace Assets.Scripts
{
    enum Phases
    {
        Morning = 0,
        Afternoon = 1,
        Night = 2
    }

    /// <summary>
    /// DateTime object takes care of the day and time
    /// </summary>
    public class DateTime
    {
        private int day;
        private Phases phase;

        public DateTime()
        {
            this.day = 1;
            this.phase = Phases.Morning;
        }

        /// <summary>
        /// GetDay returns the current day
        /// </summary>
        /// <returns></returns>
        public int GetDay()
        {
            return day;
        }

        /// <summary>
        /// GetPhase returns the current phase
        /// </summary>
        /// <returns></returns>
        public int GetPhase()
        {
            return (int)this.phase;
        }

        /// <summary>
        /// NextPhase switches the phase and changes the day if necessary
        /// </summary>
        public void NextPhase()
        {
            this.phase = (Phases)(((int)this.phase + 1) % 3);

            if (this.phase == Phases.Morning)
            {
                NextDay();
            }
        }

        /// <summary>
        /// NextDay increments the day variable
        /// </summary>
        public void NextDay()
        {
            this.day++;
        }

        public override string ToString()
        {
            return "Day " + this.day + ", " + this.phase;
        }
    }
}
