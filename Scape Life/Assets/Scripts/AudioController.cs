using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController Instance;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {

            Destroy(gameObject);

        }

        audioSource = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido)
    {

        audioSource.PlayOneShot(sonido);

    }

    public void Loop(AudioClip sonido, float tiempo)
    {
        StartCoroutine(ReproducirEnLoop(sonido, tiempo));
    }

    IEnumerator ReproducirEnLoop(AudioClip sonido, float tiempo)
    {
        float tiempoInicio = Time.time;

        while (Time.time - tiempoInicio < tiempo)
        {
            AudioSource.PlayClipAtPoint(sonido, transform.position);
            yield return new WaitForSeconds(sonido.length); // Esperar la duración del sonido
        }
    }


}
