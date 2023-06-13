using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaufelInteraction : MonoBehaviour, IInteractable
{
    public GameObject cameraSchaufel;
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
        // TODO: alle unkrauts werden interagierbar, fb activateweeds
        fbcontroller.activateWeedInteraction();
        cameraSchaufel.SetActive(true);
        fbcontroller.nextState();
        gameObject.SetActive(false);
    }
}
