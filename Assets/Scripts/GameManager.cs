using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{


    public List<GameObject> targets;
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


}
