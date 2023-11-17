using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RuleDirector : MonoBehaviour
{
    Text start;
    Text invadergame;
    Text PTrandom;
    Text PT20;

    GameObject enemys;

    string startText;
    string invadergameText;
    string PTrandomText;
    string PT20Text;
    void Start()
    {
        start = GameObject.Find("start").GetComponent<Text>();
        invadergame = GameObject.Find("invadergame").GetComponent<Text>();
        PTrandom = GameObject.Find("PTrandom").GetComponent<Text>();
        PT20 = GameObject.Find("PT20").GetComponent<Text>();
        enemys = GameObject.Find("Enemys");

        startText = start.text;
        invadergameText = invadergame.text;
        PTrandomText = PTrandom.text;
        PT20Text = PT20.text;

        enemys.SetActive(false);

        start.text = "";
        invadergame.text = "";
        PTrandom.text = "";
        PT20.text = "";

        StartCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        string text = "";
        foreach(char c in startText)
        {
            text += c;
            start.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in invadergameText)
        {
            text += c;
            invadergame.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text ="";

        enemys.SetActive(true);
        
        foreach(char c in PTrandomText)
        {
            text += c;
            PTrandom.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        text = "";
        foreach(char c in PT20Text)
        {
            text += c;
            PT20.text = text;
            yield return new WaitForSeconds(0.2f);
        }
        
        yield return new WaitForSeconds(2.0F);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    void Update()
    {
        
    }
}
