using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FRController : MonoBehaviour
{
    // Start is called before the first frame update++
    float timer = 0f;

    // One hit every 0.57 seconds
    public float pumpPeriod = 0.5769f;
    float overflowtimer = 0f;
    public float maxOverflow = 0.25f;
    public int maxPumps = 30;
    public bool started = false;
    bool revive = true;
    bool overflow = false;
    public GameObject ui;
    public GameObject hitbox;
    public GameObject human;
    public Timer endTimer;
    private Animator hitani;
    private Animator humanani;
    private UIManager uimanager;
    int streak = 0;

    // TODO: Audio source controlling, stying alive


    void Start()
    {

        hitani = hitbox.GetComponent<Animator>();
        humanani = human.GetComponent<Animator>();
        uimanager = ui.GetComponent<UIManager>();
        // timer.GetComponent<Timer>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (revive)
        {
            reviving();
        }
        else
        {

        }
        if (endTimer.isFinished())
        {
            //
            GameManager.Instance().setLevel(2);
            SceneManager.LoadScene("General");
        }

    }

    public void reviving()
    {
        timer += Time.fixedDeltaTime;
        if (timer > pumpPeriod)
        {
            Debug.Log("Pump!" + timer);

            hitani.Play("pump", -1, 0f);
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
                if (started)
                {
                    uimanager.setInfoText("0/30");
                }
            }
        }
    }

    // Called when touching the hitbox
    public void pump()
    {
        if (!revive)
        {
            return;
        }

        if (overflow)
        {
            // Successful hit
            overflow = false;
            overflowtimer = 0f;
            streak++;
            // UI.info streak /30
            Debug.Log("Hit!");
            uimanager.setInfoText(streak + "/" + maxPumps);
            if (streak == maxPumps)
            {
                hitbox.SetActive(false);
                humanani.SetBool("getUp", true);
                revive = false;
                endTimer.startTimer(10);
                uimanager.setInfoText("Geschafft! Das Fahrrad ist aber noch kaputt, auf zum H.O.M.E.");
            }
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
