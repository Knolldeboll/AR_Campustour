using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadplantInteraction : MonoBehaviour, IInteractable
{

    public GameObject levelController;
    public GameObject cameraShovel;
    public GameObject UI;
    public GameObject flower;
    private UIManager uimanager;
    private CameraShovel camshov;
    //private FairbeetController fbcontroller;

    // Start is called before the first frame update
    void Start()
    {
        //fbcontroller = FairbeetController.Instance();
        FairbeetController.Instance().weedCount += 1;
        camshov = cameraShovel.GetComponent<CameraShovel>();
        uimanager = UI.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interact()
    {
        if (!FairbeetController.Instance().weedInteraction) return;

        camshov.dig();
        FairbeetController.Instance().decreaseWeed();

        if (FairbeetController.Instance().weedCount == 0)
        {
            uimanager.setInfoText("Toll! Beende das Level mit der Blume");
            flower.SetActive(true);
            cameraShovel.SetActive(false);
        }
        else
        {
            uimanager.setInfoText("Noch übrig: " + FairbeetController.Instance().weedCount);
        }

        // TODO: animation zum verschwinden 
        //Testweise erstmal disablen
        gameObject.SetActive(false);
    }
}
