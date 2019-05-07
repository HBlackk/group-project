using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public string dialogue;
    private DialogManage rat;

    // Start is called before the first frame update
    void Start()
    {
        rat = FindObjectOfType<DialogManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                rat.ShowBox(dialogue);
            }
        }
    }
}
