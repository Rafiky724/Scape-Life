using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reintentar()
    {

        SceneManager.LoadScene("SampleScene");

    }

    public void MenuInicio()
    {

        SceneManager.LoadScene("Menu");

    }

}
