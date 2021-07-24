using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class spit1 : MonoBehaviour
{
    //private Player1 playerScript;
    private Vector2 targetPosition;
    public GameObject[] players;
    //PhotonView view;
    public float speed;
    public int damage;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            GameObject closestplayer = null;
            float disttoclosestplayer = Mathf.Infinity;

            foreach (GameObject currentplayer in players)
            {
                float distanceToEnemy = (currentplayer.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < disttoclosestplayer)
                {
                    disttoclosestplayer = distanceToEnemy;
                    closestplayer = currentplayer;
                }
            }
          //  playerScript = closestplayer.GetComponent<Player1>();
            targetPosition = closestplayer.transform.position;

            // view = GetComponent<PhotonView>();
        }
    }
        // Update is called once per frame
        void Update()
    {
        if (view.IsMine)
        {
            if (Vector2.Distance(transform.position, targetPosition) > .1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
        }


    [PunRPC]
    void DestroySpit()
    {
        if (view.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.GetComponent<Enemy1>().TakeDamage(damage);
            view.RPC("DestroySpit", RpcTarget.All);
        }

    }
}

