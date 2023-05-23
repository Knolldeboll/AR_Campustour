using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    // public GameObject mapImage;
    public List<GameObject> mapMarkers;

    // Start is called before the first frame update
    void Start()
    {

        // Vielleicht reichts auch, wenn beim Szenenwechsel der shit hier neu galden wird, 
        // Die markers entsprechend der aktuellen infos aus gamemanager zu setzen!
        // Add Poopy doodls

        int level = GameManager.Instance().getCurrentLevel();
        // Enable marker 1

        // Activate all current markers, draw the current goal red, the others green
        for (int i = 0; i < mapMarkers.Count; i++)
        {
        
            if(i < level)
            {
                mapMarkers[i].SetActive(true);
                mapMarkers[i].GetComponent<Image>().color = Color.green;
            }
            if(i == level)
            {
                mapMarkers[i].SetActive(true);
                mapMarkers[i].GetComponent<Image>().color = Color.red;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
