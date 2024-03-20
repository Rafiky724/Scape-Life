using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemySpawner[] spawns; // Arreglo que contiene los spawns de enemigos
    public float tiempoParaActivarSpawn1 = 0f; // Tiempo en segundos para activar el primer spawn
    public float tiempoParaActivarSpawn2 = 80f; // Tiempo en segundos para activar el segundo spawn
    public float tiempoParaActivarSpawn3 = 150f; // Tiempo en segundos para activar el segundo spawn
    public float tiempoParaActivarSpawn4 = 220f; // Tiempo en segundos para activar el segundo spawn
    public float tiempoParaActivarSpawn5 = 420f; // Tiempo en segundos para activar el segundo spawn

    private float tiempoTranscurrido = 0f;

    void Update()
    {
        // Actualizar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si es tiempo de activar el primer spawn
        if (tiempoTranscurrido >= tiempoParaActivarSpawn1)
        {
            // Activar el primer spawn si a�n no est� activado
            if (!spawns[0].estaActivo)
            {
                spawns[0].ActivarSpawn();
                spawns[0].estaActivo = true;
            }

            if (!spawns[1].estaActivo)
            {
                spawns[1].ActivarSpawn();
                spawns[1].estaActivo = true;
            }

            if (!spawns[2].estaActivo)
            {
                spawns[2].ActivarSpawn();
                spawns[2].estaActivo = true;
            }

        }

        // Verificar si es tiempo de activar el segundo spawn
        if (tiempoTranscurrido >= tiempoParaActivarSpawn2)
        {
            // Activar el segundo spawn si a�n no est� activado
            if (!spawns[3].estaActivo)
            {
                spawns[3].ActivarSpawn();
                spawns[3].estaActivo = true;
            }

            if (!spawns[4].estaActivo)
            {
                spawns[4].ActivarSpawn();
                spawns[4].estaActivo = true;
            }

            if (!spawns[5].estaActivo)
            {
                spawns[5].ActivarSpawn();
                spawns[5].estaActivo = true;
            }

        }

        if (tiempoTranscurrido >= tiempoParaActivarSpawn3)
        {
            // Activar el segundo spawn si a�n no est� activado
            if (!spawns[6].estaActivo)
            {
                spawns[6].ActivarSpawn();
                spawns[6].estaActivo = true;
            }

            if (!spawns[7].estaActivo)
            {
                spawns[7].ActivarSpawn();
                spawns[7].estaActivo = true;
            }

            if (!spawns[8].estaActivo)
            {
                spawns[8].ActivarSpawn();
                spawns[8].estaActivo = true;
            }

        }

        if (tiempoTranscurrido >= tiempoParaActivarSpawn4)
        {
            // Activar el segundo spawn si a�n no est� activado
            if (!spawns[9].estaActivo)
            {
                spawns[9].ActivarSpawn();
                spawns[9].estaActivo = true;
            }

            if (!spawns[10].estaActivo)
            {
                spawns[10].ActivarSpawn();
                spawns[10].estaActivo = true;
            }

        }

        if (tiempoTranscurrido >= tiempoParaActivarSpawn5)
        {
            // Activar el segundo spawn si a�n no est� activado
            if (!spawns[11].estaActivo)
            {
                spawns[11].ActivarSpawn();
                spawns[11].estaActivo = true;
            }

        }

    }
}