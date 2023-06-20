using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadplantInteraction : MonoBehaviour, IInteractable
{

    public GameObject levelController;
    public GameObject cameraShovel;
    private CameraShovel camshov;
    private FairbeetController fbcontroller;

    // Start is called before the first frame update
    void Start()
    {
        fbcontroller = FairbeetController.Instance();
        // Geht das ? sollte gehen
        camshov = cameraShovel.GetComponent<CameraShovel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {
     //  if (!fbcontroller.weedInteraction) return;

        camshov.dig();
        fbcontroller.decreaseWeed();
        // TODO: animation zum verschwinden 
        //Testweise erstmal disablen
        gameObject.SetActive(false);
    }
}
