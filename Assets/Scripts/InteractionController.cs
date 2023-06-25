using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    // Start is called before the first frame update
    
  //  public GameObject box;
   // public GameObject lever;
   // public GameObject image;
    public GameObject hitMarker;
    public GameObject UImanager;
    private UIManager ui;
    public Camera camera;
   // public GameObject arrow;

    Animator uimator;
    //    public GameObject plant;
    void Start()
    {
        uimator = hitMarker.GetComponent<Animator>();
        ui = UImanager.GetComponent<UIManager>();
       // debug = UIdebug.GetComponent<UIDebug>();
    }

    // Update is called once per frame
    void Update()
    {
        aim();       
    }

    void aim()
    {
        // https://www.youtube.com/watch?v=hi_KDpC1nzk
        // Wenn min. ein Touch ist und der erste davon gerade anfängt
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            // Hmmmm... https://stackoverflow.com/questions/24110254/problems-with-raycast-for-arcamera-in-unity3d-with-vuforia-sdk?
            Vector2 touchpos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchpos);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                //    box.GetComponent<MeshRenderer>().material.color = Color.blue; - Lief das ?!?

                //Show and animate hitmarker
                hitMarker.transform.position = new Vector3(touchpos.x, touchpos.y, 0f);
                uimator.SetTrigger("targetHit");
                GameObject hitObject =   hit.transform.gameObject;
                IInteractable interactable;

                // IF component could be received
                if (hitObject.TryGetComponent<IInteractable>(out interactable))
                {
                    ui.setDebugText("Interactable touched!");
                    // Call its interact function
                    interactable.interact();
                }
               
            }
        }else if (Input.GetMouseButtonDown(0))
        {
           // Mouse clicking for debug purposes
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject hitObject = hitInfo.collider.gameObject;
                if(hitObject != null)
                {
                    IInteractable inter;
                    if(hitObject.TryGetComponent<IInteractable>(out inter))
                    {
                        ui.setDebugText("Interactabe klicked");
                        inter.interact();
                    }
                }
            }
        }
    }
}
