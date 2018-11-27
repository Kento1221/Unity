using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometController : MonoBehaviour {

    [SerializeField]
    private float minSpeed = 5f, maxSpeed = 15f;
    private float speed;

    private void Start()
    {
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate () {
        Fall();
        CheckY();
	}

    private void CheckY()
    {
        if (gameObject.transform.position.y <= GameObject.Find("EndPool").transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }

    private void Fall()
    {
        gameObject.GetComponent<Transform>().position -= new Vector3(0, speed);
    }
}
