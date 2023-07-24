using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapButton : MonoBehaviour  //, IPointerDownHandler
{

    public GameObject map;
    public Sprite world;
    public Sprite x;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
       button.onClick.AddListener(toggleMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void toggleMap()
    {
        Debug.Log("Mapbutton");
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
/*
    public void OnPointerDown(PointerEventData eventData)
    {
        toggleMap(); //throw new System.NotImplementedException();
    }
*/
}
