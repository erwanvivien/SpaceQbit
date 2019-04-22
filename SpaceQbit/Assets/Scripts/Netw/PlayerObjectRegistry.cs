using System.Collections.Generic;
using System.Linq;

public static class PlayerObjectRegistry
{
    static List<PlayerObject> players = new List<PlayerObject>();

    static PlayerObject CreatePlayer(BoltConnection connection)
    {
        PlayerObject player;

        player = new PlayerObject();

        player.connection = connection;

        if (player.IsClient)
        {
            player.connection.UserData = player;
        }

        players.Add(player);

        return player;
    }

    public static IEnumerable<PlayerObject> AllPlayers
    {
        get { return players; }
    }

    public static PlayerObject ServerPlayer
    {
        get { return players.First(player => player.IsServer); }
    }

    public static PlayerObject CreateServerPlayer()
    {
        return CreatePlayer(null);
    }

    public static PlayerObject CreateClientPlayer(BoltConnection connection)
    {
        return CreatePlayer(connection);
    }

    public static PlayerObject GetTutorialPlayer(BoltConnection connection)
    {
        if (connection == null)
        {
            return ServerPlayer;
        }

        return (PlayerObject) connection.UserData;
    }
}