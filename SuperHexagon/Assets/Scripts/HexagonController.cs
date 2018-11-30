using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonController : MonoBehaviour {

    [SerializeField]
    private float shrinkSpeed;

    private bool hasBeenChanged;

	void Start ()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        shrinkSpeed = 2f;
        hasBeenChanged = false;
    }
	
	void Update () 
    {
        gameObject.transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (!hasBeenChanged && PlayerController.GetPoints() % 1000 == 0 && PlayerController.GetPoints() != 0)
        {
            shrinkSpeed++;
            hasBeenChanged = true;
        }

        if (gameObject.transform.localScale.x < 0.02f)
        {
            gameObject.SetActive(false);
            PlayerController.AddPoints();
            hasBeenChanged = false;
        }
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Rigidbody2D>().rotation = Random.Range(0f, 360f);
        gameObject.GetComponent<Transform>().localScale = Vector3.one * 15f;
    }
}
