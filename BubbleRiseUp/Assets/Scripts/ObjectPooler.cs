using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 10;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
            AddObjectToList();
    }

    private void AddObjectToList()
    {
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(false);
        pooledObjects.Add(obj);
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        AddObjectToList();
        return pooledObjects[pooledObjects.Count - 1];
    }
}
