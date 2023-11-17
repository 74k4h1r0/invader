using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject player;
    ScoreDirector scorecon;
    int Uscore;
    float speed = 0f;
    void Start()
    {
        scorecon = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();
        speed = 1f;
    }

    void Update()
    {
        if (transform.position.y >= 4)
        {
            Destroy(gameObject);
        }
        transform.Translate(0,this.speed*Time.deltaTime,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Explosion();
            scorecon.setScore(20);
        }
       
        else if(other.gameObject.tag == "UFO")
        {
            Uscore = Random.Range(1,5) * 50;
            other.gameObject.GetComponent<UFOController>().Explosion();
            scorecon.setScore(Uscore);
        }
    }
}