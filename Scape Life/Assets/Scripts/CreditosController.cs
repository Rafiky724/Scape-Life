using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{

    public float tiempoCredtos = 40f;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("VolverMenu", tiempoCredtos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverMenu()
    {

        SceneManager.LoadScene("Menu");

    }

}
