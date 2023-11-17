using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyS;
    public GameObject EnemyC;
    public GameObject EnemyO;
    public GameObject Player;
    EnemyDirector enemyDirector;

    void FixedUpdate()
    {
        bool reverse = false;        
    }

    void Start()
    {
        enemyDirector = GameObject.Find("EnemyDirector").GetComponent<EnemyDirector>();
        enemyDirector.SetGenerator(this);
        StartCoroutine("SetEnemy");
    }

    public void EnemyGenerate()
    {
        StartCoroutine("SetEnemy");
    }

    IEnumerator SetEnemy()
    {           
        for(int EnemyCnt = 0; EnemyCnt < 15; EnemyCnt++)
        {
            SetColumn(EnemyCnt);
            yield return new WaitForSeconds(.5f);
        }
        enemyDirector.SetStart(true);
        enemyDirector.SetBulletStart(true);
    }


    void SetColumn(int c){
        for(int enemyCnt = 0; enemyCnt < 5; enemyCnt++)
        {
            GameObject go;
    
            if(enemyCnt == 0)
            {
                go = Instantiate(EnemyS) as GameObject;
    
            }
            else if(enemyCnt < 3)
            {
                go = Instantiate(EnemyC) as GameObject;
            }
            else
            {
                go = Instantiate(EnemyO) as GameObject;
            }
            go.transform.position = new Vector3((-3 + c * 0.3f), (3 - enemyCnt * 0.2f), 0);
    
        }
    }
}