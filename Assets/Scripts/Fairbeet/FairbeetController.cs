using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FairbeetController : ILevelController
{

    // Intended for level-specific state management and interactions

    //Ablauf des Levels in States:
    // 1. Anzeige "Schaufel aufsammeln" - TODO
    //    Schaufel aufsammeln -> interact > nextState - DONE 
    // 2. Anzeige "Unkraut jäten" - TODO
    //    Unkraut jäten, bis alle weg ->interact - DONE
    // 3. Blume geht auf, iwas interessantes drin - TODO
    //    -> interact > nextState=exitState  - TODO


    // Start is called before the first frame update

    // TODO: How is this loaded/initiated ?!? - initiateScene
    // TODO: finish states and switching of states!


    public int state = 1;
    public int exitState = 3;
    public int weedCount = 5;
    public bool weedInteraction = false;

    private static FairbeetController instance;

    public static FairbeetController Instance()
    {
        if(instance == null)
        {
            instance = new FairbeetController();
        }
        return instance;
    }

    public void intiateScene()
    {
        // Muss hier was rein ? 
    }

    public void activateWeedInteraction()
    {
        weedInteraction = true;
    }

    // Called in BadplantInteraction

    public void shovelPickup()
    {
        activateWeedInteraction();


    }

    public void decreaseWeed()
    {
        // Wird nur bei Badplant.interact aufgerufen!
        weedCount--;
        if(weedCount == 0)
        {
            // End! Show something
            // nextstate quasi
        }
    }


    public void nextState()
    {
        state++;

        if(state == 3)
        {
            GameManager.Instance().nextLevel();
            // TODO: load general scene
        }
    }
}
