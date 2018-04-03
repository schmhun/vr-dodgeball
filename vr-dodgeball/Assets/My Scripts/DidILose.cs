using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DidILose : MonoBehaviour {

    private Lives _lives;
    private int count;


	// Use this for initialization
	void Start () {
        _lives = GetComponent<Lives>();
        Debug.Log("Lives start: " + _lives.AmIAlive());
        if (_lives == null)
        {
            Debug.Log("Error: No Lives object found. Ensure a lives script is on this object.");
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        count  = _lives.AmIAlive();
        //Debug.Log("This is count: " + count);
        if (count <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
        
	}
}
