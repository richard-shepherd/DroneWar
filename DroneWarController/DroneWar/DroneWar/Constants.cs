namespace DroneWar
{
    /// <summary>
    /// Constants used by the DroneWar game.
    /// </summary>
    public class Constants
    {
        // Health assigned to drones at the start of the game...
        public const int INITIAL_HEALTH = 100;

        // The size of the x-axis of the playing space...
        public const double SPACE_SIZE_X = 1000000.0;

        // The size of the y-axis of the playing space...
        public const double SPACE_SIZE_Y = 1000000.0;

        // Attacks have no effect if they are made from further away
        // than this fraction of the space-width...
        public const double MINIMUM_DISTANCE_FOR_ATTACKS = 0.2 * SPACE_SIZE_X;
    }
}
