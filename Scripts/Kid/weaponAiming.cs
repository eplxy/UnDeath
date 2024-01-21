using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAiming : MonoBehaviour
{
    public Texture2D cursorArrow;

    public Vector2 mousePosition;
  
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }
    // this is for the ops

   

}
