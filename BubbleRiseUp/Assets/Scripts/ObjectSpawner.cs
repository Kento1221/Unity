using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public int rangeX = 130;

    private void Start()
    {
        InvokeRepeating("ActivateObstacle", 1f, 0.5f);
    }

    private void ActivateObstacle()
    {
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = new Vector3(UnityEngine.Random.Range(-rangeX, rangeX), transform.Find("StartPool").position.y);
            obj.SetActive(true);
        }
    }
}
