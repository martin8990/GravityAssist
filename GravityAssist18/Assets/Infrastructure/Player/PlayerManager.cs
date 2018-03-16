using System.Collections.Generic;
namespace Infrastructure
{
    public static class PlayerManager
    {
        public static List<Player> players = new List<Player>();
        public static void OnGameOver()
        {
            players = new List<Player>();
        }
    }

}


