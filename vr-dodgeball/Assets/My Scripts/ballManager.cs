using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballManager : MonoBehaviour {
    public GameObject ballPrefab;
    public float cullTime = 5.0f;
    public float respawnTime = 2.5f;
    public float horRange = 2.0f;
    public float negVertRange = -10.0f;
    private Vector3 _spawnPos;
    private GameObject _myBall;
    private bool coroutineLock = false;
	private GameObject interactionManager;

	// Use this for initialization
	void Start () {
		interactionManager = GameObject.FindWithTag ("IM");
        _spawnPos = transform.position;
        _spawnPos.y += 1.5f;
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
            checkBall();
        }

	}

    private void checkBall()
    {
        if (_myBall.transform.position.y < negVertRange)
        {
            StartCoroutine(RespawnBall());
        }
		else if (System.Math.Abs(_myBall.transform.position.z - transform.position.z) > horRange)
        {
            StartCoroutine(RespawnBall());
        }
		else if (System.Math.Abs(_myBall.transform.position.x - transform.position.x) > horRange)
        {
            StartCoroutine(RespawnBall());
        }
    }

    private IEnumerator RespawnBall()
    {
        coroutineLock = true;
        yield return new WaitForSeconds(respawnTime);
        Destroy(_myBall, cullTime);
        var ball = (GameObject)Instantiate(ballPrefab, _spawnPos, transform.rotation);
        ball.transform.parent = transform;
        _myBall = ball;
        coroutineLock = false;
    }
}
