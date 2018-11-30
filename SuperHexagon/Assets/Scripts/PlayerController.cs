using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Text pointsText, highScoreText;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject center;

    private static int points;

    private void Start()
    {
        speed = 400f;
        points = 0;
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highScore");
    }

    void FixedUpdate () {


        pointsText.text = "" + points;

        if (PlayerPrefs.GetInt("highScore") < points)
        {
            PlayerPrefs.SetInt("highScore", points);
            highScoreText.text = "Highscore: " + points;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(Camera.main.ScreenToWorldPoint(touch.position).x < center.transform.position.x)
            {
                gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.fixedDeltaTime);
            }
            if (Camera.main.ScreenToWorldPoint(touch.position).x >= center.transform.position.x)
            {
                gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, -speed * Time.fixedDeltaTime);
            }
        }
        //if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, -speed * Time.fixedDeltaTime);
        //}
        //else if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.fixedDeltaTime);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void AddPoints()
    {
        points += 100;
    } 

    public static int GetPoints()
    {
        return points;
    }
}
