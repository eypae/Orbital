using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BoomerEnemy1 : Enemy1
{
    public float stopDistance;

    private float attackTime;

    private Animator anim;

    public Transform spitPoint;

    public GameObject spit1;

    //PhotonView view;

    public override void Start()
    {
        //view = GetComponent<PhotonView>();
        base.Start();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       // if (view.IsMine)
       // {
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
                if (Vector2.Distance(transform.position, closestplayer.transform.position) > stopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, closestplayer.transform.position, speed * Time.deltaTime);
                }
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    anim.SetTrigger("attack");
                }
            }
        //}
    }

    public void RangedAttack()
    {
        //if (view.IsMine)
        //{
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
                Vector2 direction = closestplayer.transform.position - spitPoint.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                spitPoint.rotation = rotation;
                PhotonNetwork.Instantiate(spit1.name, spitPoint.position, spitPoint.rotation);
            }
     //   }
    }
}
