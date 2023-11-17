using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOGenerator : MonoBehaviour
{
    public GameObject UFO;
    Vector3 pos;
    public float span = 25f;
    private float currentTime = 0f;
    EnemyDirector enemyDirector;

    void Start()
    {
        enemyDirector = GameObject.Find("EnemyDirector").GetComponent<EnemyDirector>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(enemyDirector.enemyStart)
        {
            if(currentTime > span && enemyDirector.DethECount < 55)
            {
                Generate();
                currentTime = 0f;
            }
        }
    }

    void Generate()
    {
        pos = new Vector3(-4, 3.4f, 0);

        GameObject go;
        go = Instantiate(UFO) as GameObject;
        go.transform.position = pos;
    }

}
