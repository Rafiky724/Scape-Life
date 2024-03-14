using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;

    public string messageToShow;
    public TextMeshProUGUI messageText;

    public int potenciaMonedas = 1;
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        myRB.velocity = inputVector * speed;
        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {

            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        }

        if (isAttacking)
        {

            myRB.velocity = Vector2.zero;

            attackCounter -= Time.deltaTime;

            if (attackCounter <= 0)
            {

                myAnim.SetBool("isAttacking", false);
                isAttacking = false;

            }

        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Moneda")
        {

            Destroy(other.gameObject);

            coins += potenciaMonedas;
            MonedasActualizar();

        }


    }

    public void MonedasActualizar()
    {

        messageToShow = "Monedas: " + coins.ToString();
        messageText.text = messageToShow;

    }


}
