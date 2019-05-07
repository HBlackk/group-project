using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManage : MonoBehaviour
{

    public GameObject box;
    public Text text;
    public bool active;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            box.SetActive(false);
            active = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        active = true;
        box.SetActive(true);
        text.text = dialogue;
    }
}
