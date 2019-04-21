using UnityEngine;

[BoltGlobalBehaviour("scene")]
public class TutorialPlayerCallbacks : Bolt.GlobalEventListener
{

    public override void SceneLoadLocalDone(string map)
    {
        // this just instantiates our player camera,
        // the Instantiate() method is supplied by the BoltSingletonPrefab<T> class
        LocalCamera.Instantiate();
    }

    public override void ControlOfEntityGained(BoltEntity entity)
    {
        // this tells the player camera to look at the entity we are controlling
        LocalCamera.instance.SetTarget(entity);
    }
}