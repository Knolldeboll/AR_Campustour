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
        GameManager.Instance().setLevel(3);
        SceneManager.LoadScene("General");
        
    }

    public void restart()
    {
        GameManager.Instance().restart();
        SceneManager.LoadScene("General");

    }
}
