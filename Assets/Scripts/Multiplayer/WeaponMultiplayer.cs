using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponMultiplayer : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotTime;
    PhotonView view;
    public GameObject shootsound;
    public GameObject sound;
    void Start()
    {
   view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
   //     view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;

            if (Input.GetMouseButton(0))
            {
                if (Time.time >= shotTime)
                {
                    PhotonNetwork.Instantiate(projectile.name, shotPoint.position, transform.rotation);
                    Instantiate(shootsound, transform.position, transform.rotation);
                    shotTime = Time.time + timeBetweenShots;
                }
            }
        }
    }

    public void UpDamage()
    {
        Instantiate(sound, transform.position, transform.rotation);
        projectile.GetComponent<Projectile1>().UpDamage();
    }

    public void UpWeaponSpeed()
    {
        Instantiate(sound, transform.position, transform.rotation);
        timeBetweenShots = 0.25f;
        Invoke("Wait", 5);
        projectile.GetComponent<Projectile1>().UpWeaponSpeed();
    }

    void Wait()
    {
        timeBetweenShots = 0.5f;
    }
}
