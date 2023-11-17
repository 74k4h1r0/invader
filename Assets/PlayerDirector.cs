using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirector : MonoBehaviour

{
    GameObject player;
    public float span = 3f;
    PlayerGenerator playerGenerator;
    public static int life = 3;
    public bool revival = false;

    Vector3 playerPos;
    bool isKilled = false;
    bool gameover = false;
    
    public void Start()
    {
        GetPlayer();

        playerGenerator = GameObject.Find("PlayerGenerator").GetComponent<PlayerGenerator>();
        playerPos = new Vector3(-0.46f,0.07f,0f);
    }

    public void ResetPos()
    {
        player.transform.position = new Vector3(-0.46f,0.07f,0);
    }

    public void SetKilled(bool b)
    {
        this.isKilled = b;
    }


    public void PlayerKill(GameObject target) 
    {
        player = target;
        StartCoroutine("Killed");
    }

    public IEnumerator Killed()
    {
        Destroy(player);

        yield return new WaitForSeconds(1.0f);

        if (life != 0)
        {
            life -= 1;
            isKilled = false;
            playerGenerator.revival(playerPos);
        }
        else
        {
            gameover = true;
        }    
    }
    public void GetPlayer()
    {
        
        player = GameObject.Find("Airframe");
        Debug.Log(player);
    }
}
