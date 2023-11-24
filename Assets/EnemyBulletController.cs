using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    GameObject EnemyS;
    PlayerDirector playerDirector;
    float speed = -1f;
    public AudioClip PlayerdethSound;
    public void Start()
    {
        playerDirector = GameObject.Find("PlayerDirector").GetComponent<PlayerDirector>();
    }

    void Update()
    {
        if (transform.position.y <= -1)
        {
            Destroy(gameObject);
        }
        transform.Translate(0,this.speed*Time.deltaTime,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
            if (other.gameObject.tag == "Player")
            {
                playerDirector.PlayerKill(other.gameObject);
                AudioSource.PlayClipAtPoint(PlayerdethSound,transform.position);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

}