using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRController : MonoBehaviour
{
    // Start is called before the first frame update++
    float timer = 0f;

    // One hit every 0.57 seconds
    public float pumpPeriod = 0.5769f;
    float overflowtimer = 0f;
    public float maxOverflow = 0.25f;

    bool overflow = false;
    public GameObject ui;
    public GameObject hitbox;
    private Animator hitani;
    private UIManager uimanager;
    int streak = 0;
    // TODO: Audio source controlling, stying alive


    void Start()
    {

        hitani = hitbox.GetComponent<Animator>();
        uimanager = ui.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > pumpPeriod)
        {   
            Debug.Log("Pump!" + timer);
            
            hitani.Play("pump", -1 ,0f);
            // Allow hits
            timer = 0f;
            overflow = true;
            
            // UI.showpumpingsign, red screen etc.

        }

        // Overflow = active pumping timeframe
        if (overflow)
        {

            overflowtimer += Time.fixedDeltaTime;
            if (overflowtimer > maxOverflow)
            {
                overflow = false;
                overflowtimer = 0f;
                streak = 0;
                // UI.info 0 /30
                Debug.Log("Fail!");
            }

        }

    }

    public void pump()
    {
        if (overflow)
        {
            // Successful hit
            overflow = false;
            overflowtimer = 0f;
            streak++;
            // UI.info streak /30
            Debug.Log("Hit!");
            uimanager.setInfoText(streak + "/30");

        }
        else
        {
            // Out of time hit
            streak = 0;
            // UI.info 0 /30
            Debug.Log("Fail!");
        }
    }

}
