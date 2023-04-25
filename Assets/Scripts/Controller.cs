using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject box;
    public GameObject lever;
    void Start()
    {
        // anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // https://www.youtube.com/watch?v=hi_KDpC1nzk
        // Wenn min. ein Touch ist und der erste davon gerade anfängt
        // -Läuft!


        Animator ani = lever.GetComponent<Animator>();


        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

        

            // Hmmmm... https://stackoverflow.com/questions/24110254/problems-with-raycast-for-arcamera-in-unity3d-with-vuforia-sdk?

            
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if(hit.collider != null)
            {
            //    box.GetComponent<MeshRenderer>().material.color = Color.blue; - Lief das ?!?
            bool state = !ani.GetBool("isLeverUp");
            // If true, show something fancy!
            ani.SetBool("isLeverUp", state);
                
            }
        }
    }
}
