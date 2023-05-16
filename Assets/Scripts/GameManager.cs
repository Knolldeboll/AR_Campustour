using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{


    public List<GameObject> targets = new List<GameObject>();
    // Start is called before the first frame update
    private static GameManager instance;
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
