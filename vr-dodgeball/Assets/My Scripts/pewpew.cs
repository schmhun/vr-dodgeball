using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour {

    public GameObject bulletPrefab;
    public float bulletSpeed = 6.0f;
    public float bulletLife = 2.0f;
    public float minFireTime = 0.5f;
    public float maxFireTime = 1.5f;

	// Use this for initialization
	void Start () {
        Invoke("Fire", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, bulletLife);
        Invoke("Fire", Random.Range(minFireTime, maxFireTime));
    }
}
