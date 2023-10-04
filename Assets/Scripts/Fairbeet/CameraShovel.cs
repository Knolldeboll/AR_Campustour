using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShovel : MonoBehaviour
{
    // Hängt an camerashovel, nur für animate da! Animate wird getriggert bei badplantinteraction, wenn weedactive
    // Start is called before the first frame update

    Animator anim;
    AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dig()
    {
        anim.Play("spaten", -1, 0f);
        audioSource.Play();
        // Sound play

    }
}
