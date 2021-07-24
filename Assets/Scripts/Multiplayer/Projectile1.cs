using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Projectile1 : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explosion;

    public int damage;
    PhotonView view;

    public GameObject heart;
    PhotonView heartPhoton;

   // public GameObject shootsound;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        Invoke("DestroyProjectile", lifeTime);
      //  Instantiate(shootsound, transform.position, transform.rotation);
        heart = GameObject.FindGameObjectWithTag("Health");
        heartPhoton = heart.GetComponent<PhotonView>();
}
    public void UpDamage()
    {
        damage =2;

        Invoke("Wait", 5);

    }

    void Wait()
    {
        damage = 1;
    }

    public void UpWeaponSpeed()
    {
        speed = 20;

        Invoke("WaitHeh", 5);

    }

    void WaitHeh()
    {
        speed =15;
    }
    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    [PunRPC]
    void DestroyProjectile()
    {
        if (view.IsMine)
        {
            PhotonNetwork.Instantiate(explosion.name, transform.position, Quaternion.identity);
            PhotonNetwork.Destroy(gameObject);
        }  
        
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Boss")
        {
            //collision.GetComponent<Enemy1>().TakeDamage(damage);
            view.RPC("DestroyProjectile", RpcTarget.All);
        }
        if (collision.tag == "Decoy")
        {
            view.RPC("DestroyProjectile", RpcTarget.All);
            heartPhoton.RPC("TakeDamage", RpcTarget.All, 1); 

        }
       
    }
}
