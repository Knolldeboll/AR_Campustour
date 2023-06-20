using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShovel : MonoBehaviour
{
    // Hängt an camerashovel, nur für animate da! Animate wird getriggert bei badplantinteraction, wenn weedactive
    // Start is called before the first frame update

    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dig()
    {
        anim.Play("Dig", -1, 0f);
    }
}
