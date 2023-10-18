using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    // public GameObject mapImage;
    public List<GameObject> mapMarkers;
    public List<GameObject> progressBars;
    public GameObject debugtext;
    public GameObject infofield;
    public GameObject infotext;
    public GameObject locationtext;
    public Sprite greenMarker;
    public Sprite redMarker;
    public Sprite redProgress;
    public Sprite greenProgress;
    public Sprite grayProgress;
    private Color32 green = new Color32(171,230,80,255);
    private Color32 red = new Color32(245,103,80,255);
    private Color32 gray = new Color32(228,228,228,255);
    private TMP_Text tmp_info;
    private TMP_Text tmp_debug;
    private TMP_Text tmp_location;

    // Start is called before the first frame update
    void Start()
    {
        
        tmp_debug = debugtext.GetComponent<TMP_Text>();
        tmp_info = infotext.GetComponent<TMP_Text>();
        tmp_location = locationtext.GetComponent<TMP_Text>();
        updateMap();
    }

    void updateMap()
    {

        //return;
        // Vielleicht reichts auch, wenn beim Szenenwechsel der shit hier neu galden wird, 
        // Die markers entsprechend der aktuellen infos aus gamemanager zu setzen!
        // Add Poopy doodls
        int level = GameManager.Instance().getCurrentLevel();
        // Enable marker 1


        // Activate all current markers, draw the current goal red, the others green
        for (int i = 0; i < mapMarkers.Count; i++)
        {

            
            // TODO: Apply text (1,2,3)
            if (i < level)
            {
                mapMarkers[i].SetActive(true);
                mapMarkers[i].GetComponent<Image>().sprite = greenMarker;
            }
            if (i == level)
            {
                mapMarkers[i].SetActive(true);
                mapMarkers[i].GetComponent<Image>().sprite = redMarker;
            }

        }

        switch (level)
        {
            case 0:
                // 1 red 2 grey 3 grey
                // TMP Colors ? 
                progressBars[0].GetComponent<Image>().sprite = redProgress;
                progressBars[0].GetComponentInChildren<TMP_Text>().color = red;

                progressBars[1].GetComponent<Image>().sprite = grayProgress;
                progressBars[1].GetComponentInChildren<TMP_Text>().color = gray;

               progressBars[2].GetComponent<Image>().sprite = grayProgress;
                progressBars[2].GetComponentInChildren<TMP_Text>().color = gray;


                break;
            case 1:

                progressBars[0].GetComponent<Image>().sprite = greenProgress;
                progressBars[0].GetComponentInChildren<TMP_Text>().color = green;
                progressBars[1].GetComponent<Image>().sprite = redProgress;
                progressBars[1].GetComponentInChildren<TMP_Text>().color = red;
                progressBars[2].GetComponent<Image>().sprite = grayProgress;
                progressBars[2].GetComponentInChildren<TMP_Text>().color = gray;
                // 1 green, 2 red

                break;
            case 2:

                progressBars[0].GetComponent<Image>().sprite = greenProgress;
                progressBars[0].GetComponentInChildren<TMP_Text>().color = green;
               progressBars[1].GetComponent<Image>().sprite = greenProgress;
                progressBars[1].GetComponentInChildren<TMP_Text>().color = green;
               progressBars[2].GetComponent<Image>().sprite = redProgress;
                progressBars[2].GetComponentInChildren<TMP_Text>().color = red;
                break;
            case 3:
                progressBars[0].GetComponent<Image>().sprite = greenProgress;
                progressBars[0].GetComponentInChildren<TMP_Text>().color = green;
               progressBars[1].GetComponent<Image>().sprite = greenProgress;
                progressBars[1].GetComponentInChildren<TMP_Text>().color = green;
               progressBars[2].GetComponent<Image>().sprite = greenProgress;
                progressBars[2].GetComponentInChildren<TMP_Text>().color = green;
                break;
        }
    }

   public void setDebugText(string debugtext)
    {
     //  tmp_debug.SetText(debugtext);

    }

    /*
     * Issue an information text
     */
    public void setInfoText(string text)
    {
        infofield.SetActive(true);
        tmp_info.SetText(text);
    }

    public void setLocationText(string text)
    {
        tmp_location.SetText(text);
    }

    public void disableInfo()
    {
        infofield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
