using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    public GameObject interactionController;
    public GameObject homeController;
    public GameObject cameraPickup;
    public int fixableID;
    public Material fixedMaterial;
    //private InteractionController interactioncontroller;
    private HomeController levelcontroller;

    // TODO: Extraimplementierung für pedale, dort die Materials separat setzen
    void Start()
    {

        // interactioncontroller = interactionController.GetComponent<InteractionController>();
        levelcontroller = homeController.GetComponent<HomeController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interact(GameObject interactor)
    {
        if (levelcontroller.hasPickup() && levelcontroller.CurrentPickupID == this.fixableID)
        {

            // So macht das gar keinen sinn. der interactor ist einfach das angeklickte objekt... also dieses selbst. es wird wieder auf ghostgesetzt
            this.GetComponent<MeshRenderer>().material = fixedMaterial;
            this.GetComponent<Collider>().enabled = false;
            cameraPickup.SetActive(false);
            levelcontroller.nextState();

        }
        else { return; }
    }
}
