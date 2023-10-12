using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour, ILevelController
{
    // Start is called before the first frame update

    private int fid = 1;
    public int CurrentFixableID { get { return fid; } set { fid = value; } }

    // 0 = no pickup
    private int pid = 0;
    public int CurrentPickupID { get { return pid; } set { pid = value; } }
    public List<GameObject> fixables;
    public Timer timer;
    public UIManager ui;
    private int maxState;

    private int state = 0;
    private bool haspick = false;


    // Pickup Objects
    // CameraObjects
    // Stuff

    void Start()
    {
        maxState = fixables.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinished())
        {
            GameManager.Instance().nextLevel();
            SceneManager.LoadScene("End");
        }
    }
    public void nextState()
    {
        state++;
        // Called after successful fixable interaction (pickup is placed on the right spot)
        if (state > maxState)
        {

            timer.startTimer(6);
            ui.setInfoText("Geschafft!");
            return;
        }
        fid++;
        haspick = false;
        enableNextFixable();
        pid = 0;
 
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
