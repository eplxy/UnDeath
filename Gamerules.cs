using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamerules : MonoBehaviour
{

    public static int scytheCount = 1;
    public GameObject grass, graveyard, hell, zombiePrefab;
    public Camera mainCam;
    public bool initialCutsceneOver = false;
    float camVelocity = 0.0f;
    public Player player;

    public static int revivalKillCount;


    public static int score;


    // Start is called before the first frame update
    void Start()
    {
        revivalKillCount = 0;
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        grass = GameObject.FindGameObjectWithTag("Grass");
        graveyard = GameObject.FindGameObjectWithTag("Graveyard");
        hell = GameObject.FindGameObjectWithTag("Hell");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    void spawnZombie()
    {
        int randomChoice = (Random.Range(1, 4));
        if (randomChoice == 1)
        {
            Instantiate(zombiePrefab, new Vector3(Random.Range(-22f, 22f), 15, 0), new Quaternion(0f, 0f, 0f, 0f));
        }
        else if (randomChoice == 2)
        {
            Instantiate(zombiePrefab, new Vector3(Random.Range(-22f, 22f), -15, 0), new Quaternion(0f, 0f, 0f, 0f));
        }
        else if (randomChoice == 3)
        {
            Instantiate(zombiePrefab, new Vector3(-24, Random.Range(-15, 15), 0), new Quaternion(0f, 0f, 0f, 0f));
        }
        else
        {
            Instantiate(zombiePrefab, new Vector3(24, Random.Range(-15, 15), 0), new Quaternion(0f, 0f, 0f, 0f));
        }

    }


    void initialCutscene()
    {
        if (mainCam.orthographicSize != 13f && initialCutsceneOver == false)
        {
            backgroundSwitch("Hell");

            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13f, ref camVelocity, 0.25f);

        }
        else
        {
            initialCutsceneOver = true;

        }
    }

    void checkRevival(){
        if (player.phase == "Scythe" && revivalKillCount>=2){
            revivalKillCount = 0;
            phaseToGrass();
        }
    }

    void phaseToHell()
    {
        player.phaseSwitch("Scythe");
        backgroundSwitch("Hell");


    }
    void phaseToGrass()
    {
        player.phaseSwitch("Gun");
        backgroundSwitch("Grass");

    }
    void phaseToGraveyard()
    {
        player.gameOver();
        backgroundSwitch("Graveyard");

    }

    void backgroundSwitch(string phaseName)
    {
        if (phaseName == "Hell")
        {
            hell.transform.position = new Vector3(0, 0, 1);
            grass.transform.position = new Vector3(0, 0, -20);
            graveyard.transform.position = new Vector3(0, 0, -20);
        }
        if (phaseName == "Grass")
        {
            hell.transform.position = new Vector3(0, 0, -200);
            grass.transform.position = new Vector3(0, 0, 1);
            graveyard.transform.position = new Vector3(0, 0, -200);

        }
        if (phaseName == "Graveyard")
        {
            hell.transform.position = new Vector3(0, 0, -20);
            grass.transform.position = new Vector3(0, 0, -20);
            graveyard.transform.position = new Vector3(0, 0, 1);

        }
    }


    int timer = 0;

    // Update is called once per frame
    void Update()
    {

        checkRevival();

        if (timer < 180)
        {
            timer++;
        }
        else
        {
            timer = 0;
            spawnZombie();
        }
        
        if (!initialCutsceneOver)
        {
            initialCutscene();
        }


    }
}
