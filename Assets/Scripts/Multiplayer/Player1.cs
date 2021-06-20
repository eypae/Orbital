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

    public int health;

    public Image[] hearts; //array to store all our hearts
    public Sprite redHeart; //red heart
    public Sprite blackHeart; //black heart

    private Transitions sceneTransitions;

    //public GameObject Camera;
    // Start is called before the first frame update

    private bool invincible = true;

    PhotonView view;

    void Awake()
    {
        anim = GetComponent<Animator>(); //Enables access to everything in the Animator, able to tweak Player Animator settings via code
        rb = GetComponent<Rigidbody2D>(); //setting rb variable equal to the rigidbody2d component that is attached to player character
        sceneTransitions = FindObjectOfType<Transitions>();
        view = GetComponent<PhotonView>();
      //  hehe();
    }

    //void hehe()
    //{
      //  if (view.IsMine)
        //{
          //  Camera.SetActive(true);
        //}
    //}

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
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

    public void TakeDamage(int enemyDamage)
    {
        if (!invincible)
        {
            health -= enemyDamage;
            UpdateHealthUI(health);
            if (health <= 0)
            {
                Destroy(gameObject);
                sceneTransitions.loadScene("GameOver 1");
            }
            else
            {
                invincible = true;
                Invoke("resetInvulnerability", 3);
            }
        }
    }

    void resetInvulnerability()
    {
        invincible = false;
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = redHeart;
            }
            else
            {
                hearts[i].sprite = blackHeart;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }
}
