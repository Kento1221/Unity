using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private KeyCode up;
    private KeyCode down;
    private KeyCode left;
    private KeyCode right;

    [SerializeField]
    private float speed = 4f;

    public void Start()
    {
        SetDefaultKeys();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(left))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(-speed, 0);
        }
        if (Input.GetKey(right))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(speed, 0);
        }
        if (Input.GetKey(up))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0, (int)speed / 2);
        }
        if (Input.GetKey(down))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0, (int)-speed / 2);
        }
    }

    public void SetDefaultKeys()
    {
        up = KeyCode.UpArrow;
        down = KeyCode.DownArrow;
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        Debug.Log("You die!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
