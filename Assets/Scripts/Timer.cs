using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    float timeTotal = 0f;
    float timeleft = 0f;
    bool finished = false;
    float percentage = 0f;
    public Image loader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(timeleft > 0)
        {
            timeleft -= Time.deltaTime;
            percentage = 1-(timeleft/ timeTotal);

            Debug.Log(percentage);
            loader.fillAmount = percentage;
            if (timeleft < 0)
            {
                timeleft = 0;
                finished = true;
            }
      }
    }

    public void startTimer(float time)
    {
        
        
        finished = false;
        if (timeleft == 0f && time > 0) 
        {
            timeleft += time;
            timeTotal = time;
            percentage = 0;
        }
            
    }

    public bool isFinished()
    {
        
        return finished;
    }
}
