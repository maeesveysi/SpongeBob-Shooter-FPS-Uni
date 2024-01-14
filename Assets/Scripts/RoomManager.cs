using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Numerics;

public class RoomManager : MonoBehaviourPunCallbacks
{
     public GameObject player;

    [Space]
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("Connecting.......");
        PhotonNetwork.ConnectUsingSettings();
    }
      public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected !");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("We're in the Lobby");
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We're in a Room !");
        
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, UnityEngine.Quaternion.identity);
        _player.GetComponent<PlayerSetup>().islocalplayer();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
