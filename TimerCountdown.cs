using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text tex;
    public TMP_Text Minutes;
    public TMP_Text Seconds;
    public TMP_Text ElapsedTime;
    float countdown=300;
    float time_elapsed;
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
            time_elapsed=initial_value-countdown;
        }
        float min=Mathf.FloorToInt(countdown/60);
        float sec=Mathf.FloorToInt(countdown%60);
        Minutes.text="Minutes:"+min.ToString();
        Seconds.text="Seconds:"+sec.ToString();
        tex.text=string.Format("{0,00}:{1,00}",min,sec);
        //Minutes and seconds calculation for elapsed time
        float min_e=Mathf.FloorToInt(time_elapsed/60);
        float sec_e=Mathf.FloorToInt(time_elapsed%60);
        ElapsedTime.text=string.Format("Elapsed Time: {0,00}:{1,00}",min_e,sec_e);
    }

}