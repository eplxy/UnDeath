using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayer : MonoBehaviour
{


    public Animator animator;
    int hitpoints, damage;
    public float moveSpeed = 5.0f;
    [SerializeField] private GameObject player;
    private Camera mainCam;
    private float camVelocity = 0f;
    public bool alive = true;
    

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.hitpoints = 5;
        this.damage = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (checkAlive())
        {
            moveDown();
            moveUp();
        } else {
            animator.SetBool("Alive", false);
            alive = false;
        }

        OnDeath();


    }

    void killAllEnemies()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }

    void cameraOnDeath()
    {
        if (!(-7.2 < mainCam.transform.position.x && -6.9 > mainCam.transform.position.x))
        {

            mainCam.transform.position = new Vector3(
                mainCam.transform.position.x - 0.02f * Mathf.Abs(transform.position.x - 1.5f - mainCam.transform.position.x),
                mainCam.transform.position.y + 0.02f * (transform.position.y - mainCam.transform.position.y), -1);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 2f, ref camVelocity, 0.25f);
        }
    }
    void OnDeath()
    {
        if (!checkAlive())
        {

            killAllEnemies();
            Vector3 p = new Vector3(transform.position.x, transform.position.y, -1);
            cameraOnDeath();
            //mainCam.transform.position = p;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
            //TODO:Subtract Damage
            hitpoints--;
    }

    bool checkAlive()
    {
        return this.hitpoints > 0;
    }


    bool withinTopBounds()
    {
        return (transform.position.y + Time.deltaTime * moveSpeed < 3.7);
    }

    bool withinBottomBounds()
    {
        return (transform.position.y - Time.deltaTime * moveSpeed > -4.1);
    }

    void moveUp()
    {
        if (Input.GetKey((KeyCode.W)))
        {
            if (withinTopBounds())
            {
                transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
            }
        }
    }

    void moveDown()
    {
        if (Input.GetKey((KeyCode.S)))
        {
            if (withinBottomBounds())
            {
                transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
            }
        }
    }


}