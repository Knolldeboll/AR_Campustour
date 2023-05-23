using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{

    public GameObject uidebugger;
    public GameObject mapScreen;
    public GameObject overlayScreen;

    private bool mapOn = false;
    private UIDebug p;

    // Start is called before the first frame update
    void Start()
    {
        p = uidebugger.GetComponent<UIDebug>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMap()
    {

        mapOn = !mapOn;

        if (mapOn)
        {
            mapScreen.SetActive(true);
            overlayScreen.SetActive(false);

        }
        else
        {
            mapScreen.SetActive(false);
            overlayScreen.SetActive(true);
        }
        p.showDebugText("MAP:" + mapScreen.activeSelf + " Over:" + overlayScreen.activeSelf);
        // switch map on / off

    }


}
