using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public TMP_Text tex;
    public TMP_Text ElapsedTime;
    float countdown=30;
    float initial_value;

    void Start()
    {
        initial_value=countdown;
    }
    
    void Update()
    {
        if(countdown>0)
        {
            countdown-=Time.deltaTime;
        }
        float min=Mathf.FloorToInt(countdown/60);
        float sec=Mathf.FloorToInt(countdown%60);
        tex.text=string.Format("{00}",sec);
        }

}