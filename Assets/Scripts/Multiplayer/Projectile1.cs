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
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }


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
        //PhotonView target = collision.gameObject.GetComponent<PhotonView>();
        if (view.IsMine)
            if (collision.tag == "Enemy" || collision.tag == "Decoy")
            {
             //   target.RPC("TakeDamage", PhotonTargets.All, damage);
                collision.GetComponent<Enemy1>().TakeDamage(damage);
                DestroyProjectile();
            }
            if (collision.tag == "Boss")
            {
                collision.GetComponent<Boss>().TakeDamage(damage);
                DestroyProjectile();
            }
    }
}
