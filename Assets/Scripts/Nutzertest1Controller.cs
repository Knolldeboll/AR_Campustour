using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutzertest1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    
  //  public GameObject box;
    public GameObject lever;
    public GameObject image;
    public GameObject hitMarker;
    public GameObject arrow;

    Animator uimator;
    //    public GameObject plant;
    void Start()
    {
        // anim = GetComponent<Animator>();
        uimator = hitMarker.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // https://www.youtube.com/watch?v=hi_KDpC1nzk
        // Wenn min. ein Touch ist und der erste davon gerade anfängt
        // -Läuft!


        Animator ani = lever.GetComponent<Animator>();
      //  Animator plantimator = plant.GetComponent<Animator>();

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {



            // Hmmmm... https://stackoverflow.com/questions/24110254/problems-with-raycast-for-arcamera-in-unity3d-with-vuforia-sdk?

            Vector2 touchpos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchpos);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if(hit.collider != null)
            {
                //    box.GetComponent<MeshRenderer>().material.color = Color.blue; - Lief das ?!?

                //image.SetActive(state);
                hitMarker.transform.position = new Vector3(touchpos.x, touchpos.y, 0f);
                uimator.SetTrigger("targetHit");
                

                bool state = !ani.GetBool("isLeverUp");
                image.SetActive(state);
                arrow.SetActive(state);
                // If true, show something fancy!
                ani.SetBool("isLeverUp", state);
         //   plantimator.SetBool("Grow",state);

            }
        }
    }
}
