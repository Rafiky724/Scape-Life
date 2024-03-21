using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        
        
    }

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
