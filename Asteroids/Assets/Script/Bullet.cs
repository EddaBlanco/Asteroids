using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{
    /*public static float xLimit, yLimit;*/

    public float Speed = 10f;
    public float maxLife = 5f; //valor maximo de vida

    public Vector3 targetVector = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        /*yLimit = Camera.main.orthographicSize + 1;
        xLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;*/
        //Destroy(gameObject,maxLife); //gameOnject somos nosotros
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * Speed); //translate modifica el translate osea teletransporte

        transform.Translate(targetVector * Speed * Time.deltaTime); //translate modifica el translate osea teletransporte

        var newPos = transform.position;
        /*if (newPos.x > xLimit || newPos.x < -xLimit || newPos.y > yLimit || newPos.y < -yLimit)
            gameObject.SetActive(false);*/
        if (newPos.x > Ship.xBlackHole || newPos.x < -Ship.xBlackHole || newPos.y > Ship.yBlackHole || newPos.y < -Ship.yBlackHole)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            // Desactiva la bala en lugar de destruirla
            gameObject.SetActive(false);
            Destroy(collider.gameObject);
        }
    }

    private void IncreaseScore()
    {
        Ship.SCORE++;
        Debug.Log(Ship.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score : " + Ship.SCORE;
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }*/
}