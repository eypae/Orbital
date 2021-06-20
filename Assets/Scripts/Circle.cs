using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Circle : MonoBehaviourPun, IPunObservable
{
    public PhotonView pv;
    public float speed;

    private Vector3 smoothMove;

    //private GameObject sceneCamera;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            playerCamera = GameObject.Find("Main Camera");
            //sceneCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            ProcessInputs();
        }
        else
        {
            smoothMovement();
        }
    }

    private void smoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
    }

    private void ProcessInputs()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        transform.position += move * speed * Time.deltaTime;

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            smoothMove = (Vector3)stream.ReceiveNext();
        }
    }
}
