using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player1 : MonoBehaviour
{

    public float speed; //How fast the player can move in the game world

    private Rigidbody2D rb; //Rigidbody2D variable contains all the physics inside Unity
    private Animator anim;

    private Vector2 moveAmount;
    private Transitions sceneTransitions;

    public GameObject heart;
    PhotonView heartPhoton;
     PhotonView viewy;

    public GameObject[] players;

    public GameObject sound;

    void Awake()
    {
        anim = GetComponent<Animator>(); //Enables access to everything in the Animator, able to tweak Player Animator settings via code
        rb = GetComponent<Rigidbody2D>(); //setting rb variable equal to the rigidbody2d component that is attached to player character
        sceneTransitions = FindObjectOfType<Transitions>();
        viewy = GetComponent<PhotonView>();
        heart = GameObject.FindGameObjectWithTag("Health");
        heartPhoton = heart.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (viewy.IsMine)
        {
            //Vector2 variable = x,y coordinate. Use this variable to detect what keys the user is pressing. 
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveAmount = moveInput.normalized * speed; //.normalized = ensures player does not move faster when moving diagonally

            if (moveInput == Vector2.zero) //if character is running, set isRunning = true. (0 = idle, !0 = not idle)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }
    }

    //FixedUpdate gets called every single physics frame
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime); //Time.fixedDeltaTime makes it framerate independent
    }

    public void SpeedUp()
    {
        foreach (GameObject i in players)
        {
            Instantiate(sound, transform.position, transform.rotation);
            i.GetComponent<Player1>().UpSpeed();
        }
    }

    void UpSpeed()
    {
        speed = 10;
        Invoke("Wait", 5);
    }

    void Wait()
    {
        speed = 5;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spit")
        {
            heartPhoton.RPC("TakeDamage", RpcTarget.All, 1);
            //collision.GetComponent<Enemy1>().TakeDamage(damage);
         //   view.RPC("TakeDamage", RpcTarget.All, 1);
            //TakeDamage(1);
        }
        if (collision.tag == "Boss")
        {
            heartPhoton.RPC("TakeDamage", RpcTarget.All, 1);
           // view.RPC("TakeDamage", RpcTarget.All, 1);
            //TakeDamage(1);
        }
      
    }

    public void UpDamage()
    {
        GameObject weapon = GameObject.FindGameObjectWithTag("Weapon");
        weapon.GetComponent<WeaponMultiplayer>().UpDamage();
    }

    public void UpWeaponSpeed()
    {
        GameObject weapon = GameObject.FindGameObjectWithTag("Weapon");
        weapon.GetComponent<WeaponMultiplayer>().UpWeaponSpeed();
    }

    //[PunRPC]
    public void ChangeWeapon(GameObject weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
     Instantiate(weaponToEquip, transform.position, transform.rotation,transform);
    }
}
