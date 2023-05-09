using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{

    public GameObject visuals;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.Instance().registerTargetVisuals(visuals);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        visuals.SetActive(true);
        GameManager.Instance().disableOtherTargetVisuals(visuals);
    }
}
