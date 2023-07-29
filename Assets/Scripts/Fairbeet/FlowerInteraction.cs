using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteraction : MonoBehaviour, IInteractable
{
    public GameObject UI;
    //private FairbeetController fbcontroller;
    private UIManager uimanager;

    // Start is called before the first frame update
    void Start()
    {
       // fbcontroller = FairbeetController.Instance();
        uimanager = UI.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interact(GameObject interactor)
    {
        uimanager.setInfoText("You made it!");
        FairbeetController.Instance().nextState();
    }
}
