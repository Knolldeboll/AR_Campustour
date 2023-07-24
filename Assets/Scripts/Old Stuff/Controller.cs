using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject box;
    public GameObject lever;
    public GameObject plant;
    public GameObject hitMarker;
    private float time = 0f;
    Animator ani;
    Animator plantimator;
    Animator uimator;

    void Start()
    {
        // anim = GetComponent<Animator>();
        ani = lever.GetComponent<Animator>();
        plantimator = plant.GetComponent<Animator>();
        uimator = hitMarker.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // https://www.youtube.com/watch?v=hi_KDpC1nzk
        // Wenn min. ein Touch ist und der erste davon gerade anfängt
        // -Läuft!

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {



            // Hmmmm... https://stackoverflow.com/questions/24110254/problems-with-raycast-for-arcamera-in-unity3d-with-vuforia-sdk?

            Vector2 touchpos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchpos);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if(hit.collider != null && hit.collider.gameObject.CompareTag("Interactable"))
            {
                //    box.GetComponent<MeshRenderer>().material.color = Color.blue; - Lief das ?!?
            bool state = !ani.GetBool("isLeverUp");
            // If true, show something fancy!
            ani.SetBool("isLeverUp", state);
            hitMarker.transform.position = new Vector3(touchpos.x, touchpos.y, 0f);
            uimator.SetTrigger("targetHit");
            plantimator.SetBool("Grow",state);

            }
        }
    }
}
