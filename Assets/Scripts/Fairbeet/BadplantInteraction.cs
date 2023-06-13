using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadplantInteraction : MonoBehaviour, IInteractable
{

    public GameObject levelController;
    private FairbeetController fbcontroller;
    // Start is called before the first frame update
    void Start()
    {
        fbcontroller = FairbeetController.Instance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {
        if (!fbcontroller.weedIntreraction) return;
        // TODO: animation zum verschwinden 
        // TODO: cameraschaufel!
        //Testweise erstmal disablen
        fbcontroller.decreaseWeed();
        gameObject.SetActive(false);
    }
}
