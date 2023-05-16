using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public GameObject uidebugger;
    private UIDebug p;
    public GameObject visuals;
    public string name;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.Instance().registerTargetVisuals(visuals);
        p = uidebugger.GetComponent<UIDebug>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
       // p.showDebugText(name + " activated!"  );
       
        visuals.SetActive(true);
        GameManager.Instance().disableOtherTargetVisuals(visuals);
    }
}
