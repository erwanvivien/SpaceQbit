using System;
using UdpKit;
using UnityEngine;

public class LoadScene : Bolt.GlobalEventListener
{
    public bool IsServer;

    public void LoadS_C()
    {
        if (IsServer)
        {
            BoltLauncher.StartServer();
        }
        else
        {
            BoltLauncher.StartClient();
        }
    }
    
    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            string matchName = Guid.NewGuid().ToString();

            BoltNetwork.SetServerInfo(matchName, null);
            BoltNetwork.LoadScene("NtwHub");
        }
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        Debug.LogFormat("Session list updated: {0} total sessions", sessionList.Count);

        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltNetwork.Connect(photonSession);
            }
        }
    }
}
