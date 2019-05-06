using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScr : MonoBehaviour
{ 
    private HealthSystem healthSystem;

    public void Setup (HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Find("HealthBar").localScale = new Vector3(healthSystem.GetHealth(), 1);
    }
}
