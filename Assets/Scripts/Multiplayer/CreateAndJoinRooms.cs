using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

  //  public GameObject waitlobby;
    

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

   public override void OnJoinedRoom()
   {
        PhotonNetwork.LoadLevel("Waiting Lobby");
       // waitlobby = GameObject.FindGameObjectWithTag("RoomDeets");
     //   waitlobby.GetComponent<WaitLobby>().players++;
    //    waitlobby.GetComponent<WaitLobby>().room = "createInput.text";



    }
}
