using System.Threading;

[BoltGlobalBehaviour(BoltNetworkModes.Client, "NtwHub")]
public class PlayerCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string map)
    {
        // this just instantiates our player camera,
        // the Instantiate() method is supplied by the BoltSingletonPrefab<T> class
        PlayerObjectRegistry.CreateServerPlayer();
        PlayerObjectRegistry.ServerPlayer.Spawn();
        PlayerObjectRegistry.ServerPlayer.character.TakeControl();
        PCamera.Instantiate();
    }

    public override void ControlOfEntityGained(BoltEntity boltEntity)
    {
        // this tells the player camera to look at the entity we are controlling
        PCamera.instance.SetTarget(boltEntity);
    }
}