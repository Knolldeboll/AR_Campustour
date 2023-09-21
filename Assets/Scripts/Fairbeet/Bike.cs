using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
   public GameObject cam;
   public Animator BikeMator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(cam.transform.position, this.transform.position);
        Debug.Log(distance);
        if(distance <= 2.5)
        {
            Debug.Log("BIKE GO");
            BikeMator.SetBool("Bikestart", true);
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
