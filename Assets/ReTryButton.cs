using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReTryButton : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("title_scene", LoadSceneMode.Single);
        ScoreDirector.score = 0;
        PlayerDirector.life = 3;
        PlayerController.bulletcount = 0;
    }
}