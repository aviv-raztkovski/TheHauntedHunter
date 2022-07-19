using System;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float bulletForce = 30f;
    public float fireRate = 5f;

    public Camera cam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            shoot();
        }
    }

    void shoot()
    {
        muzzleFlash.Play();
        transform.GetComponent<AudioSource>().Play();

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EntityHealthScript healthScript = hit.transform.GetComponent<EntityHealthScript>();
            if(healthScript != null)
            {
                healthScript.takeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * bulletForce);
            }
        }

    }
}
