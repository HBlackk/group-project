using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FleaCount : MonoBehaviour
{
    private Text fleacounter;
    public static int count;
    // Start is called before the first frame update
    void Start()
    {
        fleacounter = GetComponent<Text>();
        count = 0;
        
    }       

    // Update is called once per frame
    void Update()
    {
        fleacounter.text = "Flea Counter: " + count;
    }
}
