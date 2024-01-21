using UnityEngine;
using System.Collections;

 //Add this Script Directly to The Death Zone
public class Powpow : MonoBehaviour
{
	public AudioClip saw; 
	void Start ()   
	{
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = saw;
	}  

    void Update()
{ 
 // If the left mouse button is pressed down...
 if(Input.GetMouseButtonDown(0) == true)
 {
  GetComponent<AudioSource>().Play();
 } 

	void OnCollisionEnter ()  //Plays Sound Whenever collision detected
	{
		GetComponent<AudioSource> ().Play ();
	}
}
}