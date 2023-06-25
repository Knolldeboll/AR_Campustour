using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadplantInteraction : MonoBehaviour, IInteractable
{

    public GameObject levelController;
    public GameObject cameraShovel;
    public GameObject UI;
    private UIManager uimanager;
    private CameraShovel camshov;
    private FairbeetController fbcontroller;

    // Start is called before the first frame update
    void Start()
    {
        fbcontroller = FairbeetController.Instance();
        fbcontroller.weedCount += 1;
        camshov = cameraShovel.GetComponent<CameraShovel>();
        uimanager = UI.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {
       if (!fbcontroller.weedInteraction) return;

        camshov.dig();
        fbcontroller.decreaseWeed();
        uimanager.setInfoText("Noch übrig: " + FairbeetController.Instance().weedCount);
        // TODO: animation zum verschwinden 
        //Testweise erstmal disablen
        gameObject.SetActive(false);
    }
}
