using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float span = 0.6f;
    public float currentTime = 0f;
    public static int bulletcount = 0;
    EnemyDirector enemyDirector;
    PlayerDirector playerDirector;

    float invinciblespan = 2f;

    public GameObject bullet;
    AudioSource audio;
    Vector3 pos = new Vector3(0, 0.25f, 0);

    BoxCollider2D collider2D;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        enemyDirector = GameObject.Find("EnemyDirector").GetComponent<EnemyDirector>();
        playerDirector = GameObject.Find("PlayerDirector").GetComponent<PlayerDirector>();
        collider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(Invincible());
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(enemyDirector.enemyStart)
        {     
            //左右移動
            if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 3.4f)
            {
                transform.Translate(1*Time.deltaTime,0,0);
            }
            if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -3.4f)
            {
                transform.Translate(-1*Time.deltaTime,0,0);
            }

            if (Input.GetKeyDown(KeyCode.Space)) //&& currentTime > span)
            {
                audio.Play();
                currentTime = 0f;
                GameObject obj = Instantiate(bullet);
                obj.transform.position = transform.position + pos;
                bulletcount++;
            }
        }
        
    }
    public IEnumerator Invincible()
    {
        collider2D.enabled = false;
        yield return new WaitForSeconds(invinciblespan);
        collider2D.enabled = true;
    }
    
}

//SE,BGMをつける
//終了画面・タイトル画面の実装
//一時停止(可能であれば)
//打った弾の数の集計