using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{


    public List<GameObject> targets = new List<GameObject>();
    // Start is called before the first frame update
    private static GameManager instance;

    // The currentLevel
    private int currentLevel = 1;
    private int levelCount = 3;



    public static GameManager Instance()
    {

        if(instance == null)
        {
            instance = new GameManager();

        }
        return instance;

    }




    public void registerTargetVisuals(GameObject targetVisuals)
    {
        // Will be called automatically for targets in a scene if it is loaded! (start method is called)
        targets.Add(targetVisuals);
        // Maybe deactivate target visuals at register ?

    }

    public void disableOtherTargetVisuals(GameObject currentTargetVisuals)
    {

        foreach (var item in targets)
        {

            if(item != currentTargetVisuals)
            {

                item.SetActive(false);

            }

        }


    }
    public void nextLevel()
    {
        // 

        
        currentLevel++;

        if(currentLevel > levelCount)
        {
            // Maybe restart/main menu etc. ? 
            return;
        }
        switch (currentLevel)
        {
            case 1:
                // Do nothing?


                break;
            case 2:

               // SceneManager.LoadScene("Level2");

                // Load scene, etc.  -> geht hier (no monobehaviour!) loadscene ? 
                // oder soll auf currrentlevel ein extra manager zugreifen, der dann die neuen scenes lädt,
                // Map updates in eigenem mapmanager, der currentlevel abcheckt ? 

                // Maybe reset current Targets, so that the targets from the old level are not known here
                break;

        }

    }


    public int getCurrentLevel()
    {
        return currentLevel;
    }

   


    public string targetsToText()
    {

        string ret = " ";

        if (targets == null || targets.Count == 0) return ret;
        foreach (var item in targets)
        {
            ret += item.name + "isActive: " + item.activeSelf + ",  ";



        }
        return ret;

    }
}
