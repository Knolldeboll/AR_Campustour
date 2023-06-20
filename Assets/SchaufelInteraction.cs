using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaufelInteraction : MonoBehaviour, IInteractable
{
    public GameObject cameraSchaufel;
    public GameObject levelController;
    public GameObject UI;
    private UIManager uimanager;
    private FairbeetController fbcontroller;
    // Start is called before the first frame update
    void Start()
    {
        fbcontroller = FairbeetController.Instance();
        uimanager = UI.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void interact()
    {
        // TODO: alle unkrauts werden interagierbar, fb activateweeds
        cameraSchaufel.SetActive(true);
        uimanager.disableInfo();
        fbcontroller.shovelPickup();
        gameObject.SetActive(false);
    }
}
