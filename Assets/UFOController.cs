using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public Sprite explosion;
    public AudioClip UFOdethSound;
    GameObject UFO;

    void Update()
    {   
        if (transform.position.x >= 4)
        {
            Destroy(gameObject);
        }
        transform.Translate(1*Time.deltaTime,0,0);
    }
    
    public void Explosion()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion;
        Destroy(gameObject,0.1f);
        AudioSource.PlayClipAtPoint(UFOdethSound,transform.position);
    }
    public void UFOResetPos()
    {
        UFO.transform.position = new Vector3(4, 3.4f, 0);
    }

}