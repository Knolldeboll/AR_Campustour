using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    // public GameObject mapImage;
    public List<GameObject> mapMarkers;
    public GameObject debugtext;
    public GameObject infofield;
    public GameObject infotext;
    public GameObject locationtext;
   // public Sprite greenMarker;
  //  public Sprite redMarker;
    private TMP_Text tmp_info;
    private TMP_Text tmp_debug;
    private TMP_Text tmp_location;

    // Start is called before the first frame update
    void Start()
    {
        updateMap();
        tmp_debug = debugtext.GetComponent<TMP_Text>();
        tmp_info = infotext.GetComponent<TMP_Text>();
        tmp_location = locationtext.GetComponent<TMP_Text>();
    }

    void updateMap()
    {

        return;
        // Vielleicht reichts auch, wenn beim Szenenwechsel der shit hier neu galden wird, 
        // Die markers entsprechend der aktuellen infos aus gamemanager zu setzen!
        // Add Poopy doodls
        int level = GameManager.Instance().getCurrentLevel();
        // Enable marker 1


        // Activate all current markers, draw the current goal red, the others green
        for (int i = 0; i < mapMarkers.Count; i++)
        {

            // TODO: Change setting color to setting red or green sprite
            // TODO: Apply text (1,2,3)
            if (i < level)
            {
                mapMarkers[i].SetActive(true);
                mapMarkers[i].GetComponent<Image>().color = Color.green;
            }
            if (i == level)
            {
                mapMarkers[i].SetActive(true);
                mapMarkers[i].GetComponent<Image>().color = Color.red;
            }

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
