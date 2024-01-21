using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    [SerializeField] private GameObject player;

    bool isTap = false;
    float time1 = 0f;
    float time2 = 0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveDown();
       // moveDownLeft();
        //moveDownRight();

        moveUp();
       // moveUpRight();
       // moveUpLeft();

        moveRight();
        moveLeft();
        dashW();
        dashS();
        dashA();
        dashD();
    }

    void moveUp()
    {
        if(Input.GetKey((KeyCode.W)))
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }

    void moveDown()
    {
        if(Input.GetKey((KeyCode.S)))
           { transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
             Debug.Log("S pressed");
           }
    }

    void moveRight()
    {
        if(Input.GetKey((KeyCode.D)))
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    void moveLeft()
    {
        if(Input.GetKey((KeyCode.A)))
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }
    void moveUpRight()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed + Vector2.up * Time.deltaTime * moveSpeed);
        }
    }

    void moveUpLeft()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed + Vector2.up * Time.deltaTime * moveSpeed);
        }

    }

    void moveDownRight()
    {
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed + Vector2.down * Time.deltaTime * moveSpeed);
        }
    }

    void moveDownLeft()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed + Vector2.down * Time.deltaTime * moveSpeed);
        }
    }

    void dashW()
    {if (Input.GetKeyDown(KeyCode.W))
      {
        if (isTap == true)
		{
			time1 = Time.time;
			isTap = false;
			
			if (time1 - time2 < 0.2f) // interval between two clicked
			{
				transform.position = transform.position +   new Vector3(0,1,0);
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
    {if (Input.GetKeyDown(KeyCode.S))
      {
        if (isTap == true)
		{
			time1 = Time.time;
			isTap = false;
			
			if (time1 - time2 < 0.2f) // interval between two clicked
			{
				transform.position = transform.position +   new Vector3(0,-1,0);
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
    {if (Input.GetKeyDown(KeyCode.D))
      {
        if (isTap == true)
		{
			time1 = Time.time;
			isTap = false;
			
			if (time1 - time2 < 0.2f) // interval between two clicked
			{
				transform.position = transform.position +   new Vector3(1,0,0);
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
    {if (Input.GetKeyDown(KeyCode.A))
      {
        if (isTap == true)
		{
			time1 = Time.time;
			isTap = false;
			
			if (time1 - time2 < 0.2f) // interval between two clicked
			{
				transform.position = transform.position +   new Vector3(-1,0,0);
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

   

    






