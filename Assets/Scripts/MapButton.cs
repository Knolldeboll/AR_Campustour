using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{

    public GameObject map;
    public Sprite world;
    public Sprite x;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMap()
    {
        map.SetActive(!map.activeSelf);
        if (map.activeSelf)
        {
            GetComponent<Image>().sprite = x;
        }
        else
        {
            GetComponent<Image>().sprite = world;
        }

    }

}
