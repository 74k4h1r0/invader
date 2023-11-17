using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public GameObject playerPlefab;

    PlayerController playerController;
    PlayerDirector playerDirector;
    void Start()
    {
        playerDirector = GameObject.Find("PlayerDirector").GetComponent<PlayerDirector>();
    }
    public void revival(Vector3 pos)
    {
        GameObject go;
        go = Instantiate(playerPlefab) as GameObject;
        go.name = "Airframe";
        playerDirector.GetPlayer();
        go.transform.position = pos;
    }
}
