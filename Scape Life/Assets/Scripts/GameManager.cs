using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJuego()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("Inicio");
    }

    public void SalirJuego()
    {
        // Salir de la aplicación
        Application.Quit();
    }

}
