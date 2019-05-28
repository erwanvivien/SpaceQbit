using UnityEngine;

public class PlayerObject
{
    public BoltEntity character;
    public BoltConnection connection;

    public bool IsServer => connection == null;

    public bool IsClient => connection != null;

    public void Spawn()
    {
        if (!character)
        {
            character = BoltNetwork.Instantiate(BoltPrefabs.Perso2);

            if (IsServer)
            {
                character.TakeControl();
            }
            else
            {
                character.AssignControl(connection);
            }
        }

        //character.transform.position = RandomPosition();
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(-0.45f, +0.45f);
        float z = Random.Range(-0.45f, +0.45f);
        return new Vector3(x, 0, z);
    }
}