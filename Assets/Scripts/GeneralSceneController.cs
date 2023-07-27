using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GeneralSceneController : MonoBehaviour, ILevelController
{
    // Start is called before the first frame update

    //Was macht der ? Eig nur, wenn Target XY gescannt, lade scene xy

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFairbeet()
    {
        SceneManager.LoadScene("Fairbeet");
    }

    public void startFirstResponders()
    {

    }

    public void startHome()
    {

    }
}
