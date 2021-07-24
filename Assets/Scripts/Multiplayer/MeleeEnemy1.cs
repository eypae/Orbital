using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeleeEnemy1 : Enemy1
{
    public float stopDistance;

    private float attackTime;

    public float attackSpeed;
    
    GameObject closestplayer = null;

    PhotonView playerView;
    public GameObject heart;
    PhotonView heartPhoton;

    public override void Start()
    {
        //view = GetComponent<PhotonView>();
        base.Start();
        heart = GameObject.FindGameObjectWithTag("Health");
        heartPhoton = heart.GetComponent<PhotonView>();

    }

    public override void Update()
    {
        base.Update();
       
        if (players.Length > 0)
        {

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
            playerView = closestplayer.GetComponent<PhotonView>();
            if (Vector2.Distance(transform.position, closestplayer.transform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, closestplayer.transform.position, speed * Time.deltaTime);
            } else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }

        }
    }

    IEnumerator Attack()
    {
        heartPhoton.RPC("TakeDamage", RpcTarget.All, damage);
        //playerView.RPC("TakeDamage",RpcTarget.All, damage);
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = closestplayer.transform.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }



}
