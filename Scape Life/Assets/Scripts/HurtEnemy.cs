using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive = 2;

    [SerializeField]
    private AudioClip sonidoDa�oEnemigo;
    public float volumenDeseado = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ReducirVolumen(sonidoDa�oEnemigo, volumenDeseado);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ReducirVolumen(AudioClip audioClip, float volumen)
    {
        // Crear un GameObject temporal para reproducir el sonido y ajustar su volumen
        GameObject tempGameObject = new GameObject("TempAudio");
        AudioSource tempAudioSource = tempGameObject.AddComponent<AudioSource>();
        tempAudioSource.clip = audioClip;
        tempAudioSource.volume = volumen;
        tempAudioSource.Play();

        // Destruir el GameObject temporal despu�s de que termine de reproducirse el sonido
        Destroy(tempGameObject, audioClip.length);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            AudioController.Instance.EjecutarSonido(sonidoDa�oEnemigo);
            EnemyController enemy;
            enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.HurtEnemy(damageToGive);

        }

    }

}
