using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Animator animator;
    int hitpoints;
    public float moveSpeed = 5.0f;
    [SerializeField] private GameObject player;
    private Camera mainCam;
    private float camVelocity = 0f;
    public bool alive = true;
    public string phase;
    public Gamerules gamerules;
    public SpriteRenderer spriteRenderer;

    bool isTap = false;
    float time1 = 0f;
    float time2 = 0f;




    public void flip(Vector3 rotation)
    {
        if (rotation.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        phase = "Scythe";
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.hitpoints = 5;
        gamerules = GameObject.FindGameObjectWithTag("Gamerules").GetComponent<Gamerules>();

    }

    // Update is called once per frame
    void Update()
    {
        if (checkAlive())
        {
            moveDown();
            moveUp();
            moveRight();
            moveLeft();
            dashW();
            dashS();
            dashA();
            dashD();
        }
        else
        {
            animator.SetBool("Alive", false);
            alive = false;
        }

        OnDeath();


    }

    public void phaseSwitch(string phaseToSwitchTo)
    {
        this.phase = phaseToSwitchTo;

    }

    void killAllEnemies()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }

    void cameraOnDeath()
    {

        mainCam.transform.position = new Vector3(
            mainCam.transform.position.x - 0.02f * Mathf.Abs(transform.position.x - mainCam.transform.position.x),
            mainCam.transform.position.y + 0.02f * (transform.position.y - mainCam.transform.position.y), -1);
        mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 2f, ref camVelocity, 0.25f);
    }
    void OnDeath()
    {
        if (!checkAlive())
            if (phase == "Scythe")
            {
                gameOver();

            }
            else
            {
                phaseSwitch("Scythe");
                Gamerules.scytheCount++;

                hitpoints = 5;
                
            }
    }

    public void gameOver()
    {
        killAllEnemies();
        Vector3 p = new Vector3(transform.position.x, transform.position.y, -1);
        cameraOnDeath();
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
        return (transform.position.y + Time.deltaTime * moveSpeed < 12.5);
    }

    bool withinRightBounds()
    {
        return (transform.position.x + Time.deltaTime * moveSpeed < 20.5);
    }

    bool withinLeftBounds()
    {
        return (transform.position.x - Time.deltaTime * moveSpeed > -20.5);
    }

    bool withinBottomBounds()
    {
        return (transform.position.y - Time.deltaTime * moveSpeed > -12.5);
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

    void moveRight()
    {
        if (Input.GetKey((KeyCode.D)))
            if (withinRightBounds())
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    void moveLeft()
    {
        if (Input.GetKey((KeyCode.A)))
        {
            if (withinLeftBounds())
                transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }

    void dashW()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isTap == true)
            {
                time1 = Time.time;
                isTap = false;

                if (time1 - time2 < 0.2f) // interval between two clicked
                {
                    transform.position = transform.position + new Vector3(0, 1, 0);
                }
            }
        }
        else // first of all, enter here because the mouse is not clicked
        {
            if (isTap == false)
            {
                time2 = Time.time;
                isTap = true;
            }
        }



    }


    // transform.position = transform.position +   new Vector3(0,1,0);

    void dashS()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isTap == true)
            {
                time1 = Time.time;
                isTap = false;

                if (time1 - time2 < 0.2f) // interval between two clicked
                {
                    transform.position = transform.position + new Vector3(0, -1, 0);
                }
            }
        }
        else // first of all, enter here because the mouse is not clicked
        {
            if (isTap == false)
            {
                time2 = Time.time;
                isTap = true;
            }
        }


    }

    void dashD()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isTap == true)
            {
                time1 = Time.time;
                isTap = false;

                if (time1 - time2 < 0.2f) // interval between two clicked
                {
                    transform.position = transform.position + new Vector3(1, 0, 0);
                }
            }
        }
        else // first of all, enter here because the mouse is not clicked
        {
            if (isTap == false)
            {
                time2 = Time.time;
                isTap = true;
            }
        }

    }

    void dashA()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isTap == true)
            {
                time1 = Time.time;
                isTap = false;

                if (time1 - time2 < 0.2f) // interval between two clicked
                {
                    transform.position = transform.position + new Vector3(-1, 0, 0);
                }
            }
        }
        else // first of all, enter here because the mouse is not clicked
        {
            if (isTap == false)
            {
                time2 = Time.time;
                isTap = true;
            }
        }


    }
}
