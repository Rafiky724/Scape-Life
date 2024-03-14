using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private HealthManager healthMan;
    public Slider healtBar;

    // Start is called before the first frame update
    void Start()
    {
        
        healthMan = FindObjectOfType<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {

        healtBar.maxValue = healthMan.maxHealth;
        healtBar.value = healthMan.currentHealth;

    }
}
