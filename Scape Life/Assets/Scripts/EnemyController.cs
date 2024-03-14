using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float range;

    public int currentHealth;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {

        myAnim = GetComponent<Animator>();
        target = FindAnyObjectByType<PlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Vector3.Distance(target.position, transform.position) >= range)
        {

            FollowPlayer();

        }*/
        FollowPlayer();

    }

    public void FollowPlayer()
    {

        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    public void HurtEnemy(int damageToGive)
    {

        currentHealth -= damageToGive;

        if (currentHealth <= 0)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "MyWeapon")
        {

            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + (difference.x*2), transform.position.y + (difference.y*2));

        }

    }

}
