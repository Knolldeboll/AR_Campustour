using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endbuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close()
    {
        GameManager.Instance().nextLevel();
        GameManager.Instance().nextLevel();
        GameManager.Instance().nextLevel();
        SceneManager.LoadScene("General");
        
    }

    public void restart()
    {
        GameManager.Instance().restart();
        SceneManager.LoadScene("General");

    }
}
