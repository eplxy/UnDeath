using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 0.25f;
    void Start()
    {
        //rb.velocity = transform.right * speed;
    }

    void FunctionForDestroying(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        Debug.Log(hitInfo.name);
        if(hitInfo.name == "Zombie" && gameObject.tag == "Swing"){
            Destroy(gameObject);
        }
        Invoke("FunctionForDestroying", 1f);        
    }


}
