using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDirector : MonoBehaviour
{
    GameObject life;

    public void Start()
    {
        life = GameObject.Find("life");
    }

    public void Update()
    {
        life.GetComponent<Text>().text = "x" + PlayerDirector.life.ToString();
    }

}
