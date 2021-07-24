using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class WaitLobby : MonoBehaviourPunCallbacks
{
    public Text roomName;
    public Text playersNumber;

  // public int players = 0;
   //public string room = "hello";

    // Start is called before the first frame update

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void GameStart()
    {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.LoadLevel("Multiplayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        playersNumber.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString("0");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }
}
