using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiScript : MonoBehaviour
{


    private int hitpoints = 1;
    [SerializeField] private GameObject player;
    float speed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D()
    {
        
    }



}
