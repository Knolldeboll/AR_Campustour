using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

   public Animator BikeMator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject i)
    {


        BikeMator.SetBool("Bikestart", true);
    }


}
