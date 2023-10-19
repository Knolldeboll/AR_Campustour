using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public GameObject FRcontroller;
    private FRController levelcontroller;
    void Start()
    {
        levelcontroller = FRcontroller.GetComponent<FRController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void interact(GameObject o)
    {
        if (!levelcontroller.started)
        {
            levelcontroller.started = true;
        }
        levelcontroller.pump();
    }
}
