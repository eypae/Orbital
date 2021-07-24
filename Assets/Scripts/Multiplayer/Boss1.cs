using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public int health;
    public GameObject[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public PhotonView view;

   private Slider healthBar;


    [PunRPC]
    public void TakeDamage(int enemyDamage)
    {
     //   if (view.IsMine)
       // {
            health -= enemyDamage;
            view.RPC("value", RpcTarget.All); 
            if (health <= 0)
            {
                int randomNumber = Random.Range(0, 101);
                if (randomNumber < pickupChance)
                {
                    GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                    PhotonNetwork.Instantiate(randomPickup.name, transform.position, transform.rotation);
                }
                PhotonNetwork.Destroy(this.gameObject);
                healthBar.gameObject.SetActive(false);
               // view.RPC("off", RpcTarget.All);
            }
            if (health <= halfHealth)
            {
                anim.SetTrigger("stage2");
            }

            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
            PhotonNetwork.Instantiate(randomEnemy.name, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation); //Boss spawns an enemy whenever she gets hit
        //}
    }

    [PunRPC]
    public void value()
    {
        healthBar.value = health;
    }

  //  [PunRPC]
    //public void off()
    //{
      //  healthBar.gameObject.SetActive(false);
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            //collision.GetComponent<Enemy1>().TakeDamage(damage);
            view.RPC("TakeDamage", RpcTarget.All, 1);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }
}
