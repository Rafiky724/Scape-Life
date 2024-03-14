using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{

    private HealthManager healthMan;
    public float waiToHurt = 2f;
    public bool isTouching;

    [SerializeField]
    private int damageToGive = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindAnyObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (reloading)
        {

            waiToLoad -= Time.deltaTime;
            Debug.Log(waiToLoad);

            if (waiToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

        }*/

        if (isTouching)
        {

            waiToHurt -= Time.deltaTime;

            if (waiToHurt <= 0)
            {

                healthMan.HurtPlayer(damageToGive);
                waiToHurt = 2f;

            }

        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
     
        if(other.collider.tag == "Player")
        {
            //other.gameObject.SetActive(false);

            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            //reloading = true;

        }
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.collider.tag == "Player")
        {

            isTouching = true;

        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {

        isTouching = false;
        waiToHurt = 2f;
        
    }

}
