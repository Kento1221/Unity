using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	void FixedUpdate () {
        gameObject.GetComponent<Camera>().transform.RotateAround(Vector3.zero, Vector3.forward, 0.2f);
	}
}
