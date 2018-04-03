using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballManager : MonoBehaviour {
    public GameObject ballPrefab;
    public float cullTime = 5.0f;
    public float respawnTime = 2.5f;
    public float horRange = 20.0f;
    public float negVertRange = -10.0f;
    private Vector3 _spawnPos;
    private GameObject _myBall;
    private bool coroutineLock = false;

	// Use this for initialization
	void Start () {
        _spawnPos = transform.position;
        Debug.Log("Default y pos: " + _spawnPos);
        _spawnPos.y += 2.0f;
        var ball = (GameObject)Instantiate(
           ballPrefab,
           _spawnPos,
           transform.rotation);
        ball.transform.parent = transform;
        _myBall = ball;

    }
	
	// Update is called once per frame
	void Update () {

        if (!coroutineLock)
        {
            CheckBall();
        }

	}

    private void CheckBall()
    {
        /*
        if (_myBall.transform.position.y < negVertRange)
        {
            Debug.Log("First condition at frame " + Time.frameCount);
            StartCoroutine(RespawnBall());
        }
        else if (_myBall.transform.position.z > horRange || _myBall.transform.position.z < -1*horRange)
        {
            Debug.Log("Second condition at frame " + Time.frameCount);
            StartCoroutine(RespawnBall());
        }
        else if (_myBall.transform.position.x > horRange || _myBall.transform.position.x < -1*horRange)
        {
            Debug.Log("Third condition at frame " + Time.frameCount);
            StartCoroutine(RespawnBall());
        }
        */
        if (Vector3.Distance(_myBall.transform.position, transform.position) > horRange)
        {
            StartCoroutine(RespawnBall());
        }
    }

    private IEnumerator RespawnBall()
    {
        coroutineLock = true;
        yield return new WaitForSeconds(respawnTime);
        Destroy(_myBall, cullTime);
        //Debug.Log("Fuck me right?");
        var ball = (GameObject)Instantiate(ballPrefab, _spawnPos, transform.rotation);
        ball.transform.parent = transform;
        _myBall = ball;
        coroutineLock = false;
        //yield return new WaitForSeconds(respawnTime);
    }
}
