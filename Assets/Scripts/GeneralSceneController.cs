using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GeneralSceneController : MonoBehaviour, ILevelController
{
    // Start is called before the first frame update

    //Was macht der ? Eig nur, wenn Target XY gescannt, lade scene xy

    public bool fairbeet = false;
    public bool fr = false;
    public bool home = false;
    public GameObject notifyBlob;
    private Animator blobAnimator;
    //public image

    void Start()
    {
        

        if(GameManager.Instance().getCurrentLevel() > 0)
        {
            // Play Notify Animation
            notifyBlob.GetComponent<Animator>().SetTrigger("Notify");

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fairbeet)
        {
            startFairbeet();
        }
        if (fr)
        {
            startFirstResponders();
        }
        if (home)
        {
            startHome();
        }
    }

    public void startFairbeet()
    {
        // If level already finished, skip loading
        if (GameManager.Instance().getCurrentLevel() != 0 ) return;
        SceneManager.LoadScene("Fairbeet");
        
    }

    public void startFirstResponders()
    {
        if (GameManager.Instance().getCurrentLevel() != 1) return;
        SceneManager.LoadScene("FirstResponders");
    }

    public void startHome()
    {
        if (GameManager.Instance().getCurrentLevel() != 2) return;
        SceneManager.LoadScene("Home");
    }

    public void devSetLevel(int level)
    {
        GameManager.Instance().setLevel(level);
        SceneManager.LoadScene("General");

    }
}
