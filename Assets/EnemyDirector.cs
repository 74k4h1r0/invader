using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
    bool bulletStart = false;
    public bool enemyStart = false;
    public int enemyDir = 1;
    int enemyHeight = 0;
    public int DethECount = 0;
    public float speed = 0.03f;
    public int rate = 5;
    public float dis = 0;
    public bool wallflag = false;

    string dire = "";
    PlayerDirector playerDirector; 
    EnemyGenerator enemyGenerator;
    UFOController ufoController;
    RoundDirector roundDirector;

    void Start()
    {
        playerDirector = GameObject.Find("PlayerDirector").GetComponent<PlayerDirector>();
        ufoController = GameObject.Find("UFOController").GetComponent<UFOController>();
        roundDirector = GameObject.Find("RoundDirector").GetComponent<RoundDirector>();
    }
    public void SetStart(bool b)
    {
        this.enemyStart = b;

        if (enemyStart == true)
        {
            StartCoroutine(EnemyMoveSE());
        }
    }

    public void Down(string d)
    {
        if (d != dire)
        {
            enemyHeight++;
            dire = d;
            Debug.Log("Down");
        }
    }

    public void SetGenerator(EnemyGenerator EG)
    {
        enemyGenerator = EG;
    }

    public int GetHeight()
    {
        return(enemyHeight);
    }
    
    public void SetBulletStart(bool b)
    {
        this.bulletStart = b;
    }
    public bool GetBulletStart()
    {
        return(this.bulletStart);
    }


    public void DethEnemy()
    {
        DethECount++;
        if (DethECount == 75)
        {
            enemyStart = false;
            bulletStart = false;
            enemyHeight = 0;
            DethECount = 0; 
            enemyDir = 1;
            speed += 0.015f;
            rate += 5;
            dire = "";
            playerDirector.ResetPos();
            roundDirector.roundend();
            GameObject ufo =  GameObject.Find("UFO");
            if(ufo != null)
                ufo.GetComponent<UFOController>().UFOResetPos();
            Debug.Log("nextRound");
        }
    }
    private IEnumerator EnemyMoveSE()
    {
        while (enemyStart)
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<AudioSource>().Play();
        }

    }
}
