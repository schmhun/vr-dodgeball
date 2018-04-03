using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int Startlives = 0;
    private int lives;
    public GameObject weapon;
    public string death_by_n;
    

    public void DieALittle()
    {
        lives--;
    }

    public int AmIAlive()
    {
        return lives;
    }

    // Use this for initialization
    void Start()
    {
        lives = Startlives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision object is: "+ collision.gameObject.name);
        //Debug.Log("Weapon is: "+weapon);
        if (collision.gameObject.name == death_by_n)
        {
            Debug.Log("Ouch, that hit me...");
            DieALittle();
        }
    }
}