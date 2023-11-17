using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverDirector : MonoBehaviour
{
    Text gameover;
    Text poor;
    Text  yourscore;
    Text enemyknockdownpointsN;
    Text remaininglifeN;
    Text bulletusedN;
    Text total;
    Text totalN;

    GameObject points;
    public GameObject lifeSCR;
    public GameObject scoreSCR;
    public GameObject BcountSCR;
    public GameObject totalscoreSCR;

    int life;
    int score;
    int Bcount;
    int totalscore = 0;
    float i = 0f;


    string gameoverText;
    string poorText;
    string yourscoreText;
    string enemyknockdownpointsNText;
    string remaininglifeNText;
    string bulletusedNText;
    string totalText;
    string totalNText;

    void Start()
    {
        gameover = GameObject.Find("gameover").GetComponent<Text>();
        poor = GameObject.Find("poor").GetComponent<Text>();
        yourscore = GameObject.Find("yourscore").GetComponent<Text>();
        enemyknockdownpointsN = GameObject.Find("enemyknockdownpointsN").GetComponent<Text>();
        remaininglifeN = GameObject.Find("remaininglifeN").GetComponent<Text>();
        bulletusedN = GameObject.Find("bulletusedN").GetComponent<Text>();
        total = GameObject.Find("total").GetComponent<Text>();
        totalN = GameObject.Find("totalN").GetComponent<Text>();

        points = GameObject.Find("Points");

        life = PlayerDirector.life;
        score = ScoreDirector.score;
        Bcount = PlayerController.bulletcount;

        i = life * 0.1f + 1;
        Debug.Log(Bcount);

        totalscore = (int)(score * i - Bcount);

        gameoverText = gameover.text;
        poorText = poor.text;
        yourscoreText = yourscore.text;
        enemyknockdownpointsNText = enemyknockdownpointsNText;
        remaininglifeNText = remaininglifeNText;
        bulletusedNText = bulletusedNText;
        totalText = total.text;
        totalNText = totalNText;


        points.SetActive(false);

        gameover.text = "";
        poor.text = "";
        yourscore.text = "";
        enemyknockdownpointsN.text = "";
        remaininglifeN.text = "";
        bulletusedN.text = "";
        total.text = "";
        totalN.text = "";

        StartCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        string text = "";
        foreach(char c in gameoverText)
        {
            text += c;
            gameover.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in poorText)
        {
            text += c;
            poor.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text ="";
        foreach(char c in yourscoreText)
        {
            text += c;
            yourscore.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text ="";

        points.SetActive(true);
        
        foreach(char c in score.ToString())
        {
            text += c;
            enemyknockdownpointsN.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in life.ToString())
        {
            text += c;
            remaininglifeN.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in Bcount.ToString())
        {
            text += c;
            bulletusedN.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in totalText)
        {
            text += c;
            total.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in totalscore.ToString())
        {
            text += c;
            totalN.text = text;
            yield return new WaitForSeconds(0.2f);
        }
    }
}

