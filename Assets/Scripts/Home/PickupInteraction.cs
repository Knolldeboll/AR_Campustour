using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    public GameObject interactionController;
    public GameObject homeController;
    public GameObject cameraPickup;
    public int pickupID;
    // private InteractionController interactioncontroller;
    private HomeController levelcontroller;
    void Start()
    {

        //  interactioncontroller = interactionController.GetComponent<InteractionController>();
        levelcontroller = homeController.GetComponent<HomeController>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    //called if touched
    public void interact(GameObject interactor)
    {
        if (this.pickupID == levelcontroller.CurrentFixableID)
        {
            levelcontroller.CurrentPickupID = this.pickupID;
            levelcontroller.setPickup(true);
            cameraPickup.SetActive(true);
            // Echt so ?
            gameObject.SetActive(false);

        }
    }
}
