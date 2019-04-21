using UnityEngine;

[BoltGlobalBehaviour(BoltNetworkModes.Host, "scene")]
public class ServerCallbacks : Bolt.GlobalEventListener
{

    void Awake()
    {
        PlayerObjectRegistry.CreateServerPlayer();
    }

    public override void Connected(BoltConnection connection)
    {
        PlayerObjectRegistry.CreateClientPlayer(connection);
    }

    public override void SceneLoadLocalDone(string map) {
    }

    public override void SceneLoadRemoteDone(BoltConnection connection) {
    }
}