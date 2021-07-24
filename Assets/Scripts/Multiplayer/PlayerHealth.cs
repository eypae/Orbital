using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts; //array to store all our hearts
    public Sprite redHeart; //red heart
    public Sprite blackHeart; //black heart
    public int health;

    public Animator hurtAnim;
    private Transitions sceneTransitions;
    GameObject[] players;
   // private bool invincible = false;

    PhotonView view;
    //private Transitions sceneTransitions;
    public GameObject deathsound;
    public GameObject hurtsound;

    public GameObject music;

    void Start()
    {
        view = GetComponent<PhotonView>();
        sceneTransitions = FindObjectOfType<Transitions>();
        music = GameObject.FindGameObjectWithTag("gamemusic");
    }

 ///   void resetInvulnerability()
//    {
   //     invincible = false;
//    }
    
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

    }
    [PunRPC]
    public void TakeDamage(int enemyDamage)
    {
       // if (view.IsMine)
        //{

           // if (!invincible)
         //   {
               
                health -= enemyDamage;
                UpdateHealthUI(health);
       Instantiate(hurtsound, transform.position, transform.rotation);
        hurtAnim.SetTrigger("hurt");
        //view.RPC("UpdateHealthUI", RpcTarget.All, health);
        //heartPhoton = heart.GetComponent<PhotonView>();
        //UpdateHealthUI(health);
        if (health <= 0)
                {
            foreach (GameObject i in players)
            {
                Destroy(i);
            }
            Destroy(music);
            Instantiate(deathsound, transform.position, transform.rotation);
            sceneTransitions.loadScene("GameOver 1");
                //     PhotonNetwork.Destroy(gameObject);
                // PhotonNetwork.LoadLevel("GameOver 1");
            }
            //   else
              ////  {
               //     invincible = true;
                  //  Invoke("resetInvulnerability", 1);
               // }
         //   }
         //}
    }
    [PunRPC]
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
        //UpdateHealthUI(health);

    }

    //    [PunRPC]
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
}
