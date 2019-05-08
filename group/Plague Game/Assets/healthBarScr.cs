using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScr : MonoBehaviour
{ 
    private HealthSystem healthSystem;

    public void Setup (HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        healthSystem.OnhealthChange += HealthSystem_OnHealthChanged;
    }

   private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }


    // Update is called once per frame
    private void Update()
    {
        //transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
}
