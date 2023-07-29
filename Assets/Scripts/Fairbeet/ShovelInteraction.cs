using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelInteraction : MonoBehaviour, IInteractable
{
    GameObject CameraShovel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject interactor)
    {

        CameraShovel.SetActive(true);
    }

}
