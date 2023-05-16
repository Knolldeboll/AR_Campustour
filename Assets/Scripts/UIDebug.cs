using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDebug : MonoBehaviour
{
    // Start is called before the first frame update

   public GameObject debugtext;
   private TMP_Text text;
    void Start()
    {
        text = debugtext.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(GameManager.Instance().targetsToText());
    }

   public void showDebugText(string msg)
    {
      //  text.SetText(msg);
    }

}

