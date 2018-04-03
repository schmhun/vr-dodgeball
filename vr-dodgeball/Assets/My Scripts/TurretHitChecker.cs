using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretHitChecker : MonoBehaviour {

    private int health;
    public int killTime;

    public string death_by_incoming;
    //ParticleSystem ps = new ParticleSystem();

    // Use this for initialization
    void Start () {
        health = 3;
        //ps.transform.position = this.transform.position;
        //ps.Pause();
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            StartCoroutine(Kill());
        }

	}

    //did I get hit with a ball
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision name: " + collision.gameObject.name);
        if(collision.gameObject.name == death_by_incoming)
        {
            //decrease lives counter for turret
            Debug.Log("THWACK!");
            Hit();
        }
    }

    private void Hit()
    {
        health--;
    }

    IEnumerator Kill()
    {
        //ps.Play();
        Debug.Log("Killing self: " + this.transform.name);
        Destroy(this.gameObject, killTime);
        yield return new WaitForSeconds(1);
        //Destroy(ps);
    }
}
