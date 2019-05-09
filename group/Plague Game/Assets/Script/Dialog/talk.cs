using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : MonoBehaviour
{
    public bool invent;
    public bool open;
    public bool locks;
    public GameObject item;
    public Animator animate;
    public bool talks;

    public string text;

    public void Interact()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        animate.SetBool("open", true);
    }  
    
    public void Talk()
    {
        Debug.Log(text);
    }
}
