using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    
    private Material fixedMaterial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject interactor)
    {
        // use the interactors material for this fixable object instead of the ghost material
        // nextStep in level controller
    }
}
