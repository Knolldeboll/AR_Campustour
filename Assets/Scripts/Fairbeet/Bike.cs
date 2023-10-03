using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
   public GameObject cam;
   public Animator BikeMator;
   public GameObject timerObject;
   public Timer timer;
   public GameObject UI;
   bool startTimer = false;
    
    void Start()
    {
        //  timer = new Timer();
        timer.GetComponent<Timer>();
        AnimationEvent end = new AnimationEvent();

        for (int i = 0; i < BikeMator.runtimeAnimatorController.animationClips.Length; i++)
        {
            AnimationClip clip = BikeMator.runtimeAnimatorController.animationClips[i];


            AnimationEvent animationEndEvent = new AnimationEvent();
            animationEndEvent.time = clip.length;
            animationEndEvent.functionName = "aniEnd";
            animationEndEvent.stringParameter = clip.name;
            clip.AddEvent(animationEndEvent);
        }
    }

    // Update is called once per frame
    void Update()
    {



        float distance = Vector3.Distance(cam.transform.position, this.transform.position);
        Debug.Log(distance);
        if(distance <= 2.5 && startTimer == false)
        {
            Debug.Log("BIKE GO");
            BikeMator.SetBool("Bikestart", true);
      //      startTimer = true;
       //     timer.startTimer(12);
        }


       if (timer.isFinished())
        {
            // Should be final state
            FairbeetController.Instance().nextState();
        }


    }

    public void aniEnd(string name)
    {
        Debug.Log(name + " ended");
        
        if(name == "Bikeanimation")
        {
        timer.startTimer(6);
            UI.GetComponent<UIManager>().setInfoText("Unfall! Ab zu den First Responders!");
        }



    }

    // If cam/player gets close to bike

   
    
    /*private void OnCollisionEnter(Collision other)
    {

        Debug.Log("BIKE GO");
        BikeMator.SetBool("Bikestart", true);
    }

    */

    /*
    public void interact(GameObject i)
    {


        BikeMator.SetBool("Bikestart", true);
    }
    */


}
