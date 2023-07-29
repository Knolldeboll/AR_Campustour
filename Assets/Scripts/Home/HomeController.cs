using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour, ILevelController
{
    // Start is called before the first frame update

    private int fid = 1;
    public int CurrentFixableID { get { return fid; } set { fid = value; } }

    // 0 = no pickup
    private int pid = 0;
    public int CurrentPickupID { get { return pid; } set { pid = value; } }
    public List<GameObject> fixables;

    private int state = 0;
    private int maxState = 23;
    private bool haspick = false;

    // Pickup Objects
    // CameraObjects
    // Stuff

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void nextState()
    {
        // Called after successful fixable interaction (pickup is placed on the right spot)
        if (state > maxState)
        {
            // TODO: Load general scene
            // TODO: Update gamemanager values

            return;
        }
        fid++;
        haspick = false;
        enableNextFixable();
        pid = 0;
        state++;
    }

    public void enableNextFixable()
    {
        // Enable Fixable with new fid. 
        fixables.ForEach(delegate (GameObject o)
        {

            if (o.GetComponent<FixableInteraction>().fixableID == fid)
            {
                Debug.Log("Activated fixobject nr " + fid);
                o.SetActive(true);
            }

        });
    }
    public void setPickup(bool value)
    {
        haspick = value;
    }
    public bool hasPickup()
    {
        return haspick;
    }

}
