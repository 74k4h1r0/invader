using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RoundDirector : MonoBehaviour
{
    int round = 1;
    int life;
    Text roundClear;
    EnemyGenerator enemyGenerator;
    void Start()
    {
        enemyGenerator = GameObject.Find("Object_no_deta").GetComponent<EnemyGenerator>();
        roundClear = GameObject.Find("RoundClear").GetComponent<Text>();
        roundClear.text = "";
    }
    void Update()
    {
        life = PlayerDirector.life;
        if(life == 0)
        {
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }
    }

    public void roundend()
    {
        if(round < 15)
        {
            round++;
            StartCoroutine(RoundChange());
        }
        else
        {
            SceneManager.LoadScene("ClearScene", LoadSceneMode.Single);
        }

    }

    private IEnumerator RoundChange()
    {
        roundClear.text = "Round"+round;
        yield return new WaitForSeconds(2.0f);
        enemyGenerator.EnemyGenerate();
        roundClear.text = "";
    } 
}
