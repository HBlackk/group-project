using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Transform pfHealthBar;
    // Start is called before the first frame update
    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);
        HealthBarScr healthBar = pfHealthBar.GetComponent<HealthBarScr>();
        healthBar.Setup(healthSystem);
    }
}
