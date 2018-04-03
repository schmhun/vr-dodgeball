using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {

    private GameObject firingBattery;

    // Use this for initialization
    void Start()
    {

        firingBattery = GameObject.FindGameObjectWithTag("battery");
        Debug.Log(firingBattery.transform.childCount);
        if (firingBattery == null)
        {
            Debug.Log("No firing battery detected.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if there are no more children in the battery GO, then we have succeeded. 
        if (firingBattery.transform.childCount == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
