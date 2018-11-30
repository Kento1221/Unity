using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int amountToSpawn;

    private float spawnRate = 1f, nextTimeToSpawn = 0f;
    private List<GameObject> objectsToSpawn;


    private void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;

        objectsToSpawn = new List<GameObject>();

        for(int i = 0; i < amountToSpawn; i++)
        {
            AddToList();
        }
    }

    void Update () {
		if(Time.time >= nextTimeToSpawn)
        {
            GameObject obj = GetPooledObject();
            obj.SetActive(true);

            nextTimeToSpawn = Time.time + 1 / spawnRate;
        }
	}
    private void AddToList()
    {
        GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        obj.SetActive(false);
        objectsToSpawn.Add(obj);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
            if (!objectsToSpawn[i].activeInHierarchy)
                return objectsToSpawn[i];
        }
        AddToList();
        return objectsToSpawn[objectsToSpawn.Count - 1];
    }
}
