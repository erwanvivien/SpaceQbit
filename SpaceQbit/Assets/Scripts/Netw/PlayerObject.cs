using UnityEngine;

public class PlayerObject
{
    public BoltEntity character;
    public BoltConnection connection;

    public bool IsServer
    {
        get { return connection == null; }
    }

    public bool IsClient
    {
        get { return connection != null; }
    }

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
        character.transform.position = RandomPosition();
    }
    Vector3 RandomPosition()
    {
        float x = Random.Range(-2f, +2f);
        float z = Random.Range(-2f, +2f);
        return new Vector3(x, 0, z);
    }
}
