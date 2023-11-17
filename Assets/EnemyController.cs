using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Sprite explosion; 

    public GameObject enemy_bullet;
    Vector3 pos = new Vector3(0, 0.25f, 0);
    EnemyDirector enemyDirector;

    int random;
    bool done = false;
    public bool start = false;
    public bool moveRight = true;
    public int enemyHeight = 0;
    float initY;
    Animator anime;
    public void reverse()
    {
        transform.Translate(0 , -0.3f, 0);
    }
    void Start()
    {   
        anime = gameObject.GetComponent<Animator>();
        anime.enabled = false;
        initY = transform.position.y;
        enemyDirector = GameObject.Find("EnemyDirector").GetComponent<EnemyDirector>();
    }

    void Update()
    {
        pos = transform.position;
        if (!(done))
        {
            if (enemyDirector.enemyStart)
            {
                done = true;
                StartCoroutine(RepeatFunction());
            }
            else
            {
                anime.enabled = false;
            } 
        }

        if(transform.position.x < -3.4f)
        {
            enemyDirector.Down("L");
            enemyDirector.enemyDir = 1;
        }
        else if(transform.position.x > 3.4f)
        {
            enemyDirector.Down("R");
            enemyDirector.enemyDir = -1;
        }

        enemyHeight = enemyDirector.GetHeight();
        if (enemyDirector.enemyStart)
        {
        pos.y = initY -0.1f * enemyHeight;
        transform.position = pos;
        }

        random = Random.Range(1,1000000);
        if (random < enemyDirector.rate && enemyDirector.GetBulletStart())
        {
            GameObject obj = Instantiate(enemy_bullet);
            obj.transform.position = transform.position;

        }    
        // デバック用(完成時削除)
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy (gameObject);
            enemyDirector.DethEnemy();
        }

    }

    private IEnumerator RepeatFunction()
    {
        anime.enabled = true;
        while(enemyDirector.enemyStart)
        {
            yield return new WaitForSeconds(0.2f);
            if (enemyDirector.enemyStart)
            {
                transform.Translate(enemyDirector.speed * enemyDirector.enemyDir, 0, 0);
            }
        }
    }



    public void Explosion()
    {
        anime.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion;
        Destroy(gameObject,0.1f);
        enemyDirector.DethEnemy();
        GetComponent<AudioSource>().Play();
    }
}