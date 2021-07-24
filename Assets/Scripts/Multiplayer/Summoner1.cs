using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Summoner1 : Enemy1
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;
    private Animator anim;

    public float timeBetweenSummons;
    private float summonTime;

    public GameObject enemyToSummon;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (players.Length > 0)
        {
            if (Vector2.Distance(transform.position, targetPosition) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            } else
            {
                anim.SetBool("isRunning", false);

                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
            }
        }
    }

    public void Summon()
    {
        if (view.IsMine)
        {
            if (players.Length > 0)
            {
                PhotonNetwork.Instantiate(enemyToSummon.name, transform.position, transform.rotation);
            }
        }
    }

}
