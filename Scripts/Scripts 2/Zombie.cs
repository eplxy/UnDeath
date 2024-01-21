using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{


    private int hitpoints = 2;
    private Player player;
    float speed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        checkHealth();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            hitpoints--;
        }
        else if (col.tag == "Swing")
        {
            hitpoints -= 2;
        }
        else if (col.tag == "ChargedSwing")
        { hitpoints -= 3; }
    }

    void checkHealth()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
            Gamerules.score++;
            if (player.phase == "Scythe")
            {
                Gamerules.revivalKillCount++;

            }

        }

    }



}
