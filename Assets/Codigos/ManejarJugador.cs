using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public float VelocidadDeMovimiento =5f;
    public float VelocidadSalto = 5f;
    public int TipoDeMovimiento;
    public int Vidas = 3;
    public Transform puntoDeInicio;
    public float limiteCaida = -4.5f;

    public SpriteRenderer spriterender;
    public Animator animator;



     Rigidbody2D rb2b;

     void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y < limiteCaida){
            PerderVida();
        }        
        
    }

    void PerderVida()
    {
        Vidas--;
        if (Vidas <= 0)
        {
            GameOver();
        }else
        {
            Respawn();
        }
    }
    void Respawn(){
        transform.position = puntoDeInicio.position;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }




    private void FixedUpdate(){

        if (Input.GetKey("d")|| Input.GetKey("right")){

            rb2b.velocity = new Vector2(VelocidadDeMovimiento, rb2b.velocity.y);
            spriterender.flipX=false;


        } else if (Input.GetKey("a") || Input.GetKey("left")){

            rb2b.velocity = new Vector2(-VelocidadDeMovimiento, rb2b.velocity.y);
            spriterender.flipX = true;
        }
        else{
            rb2b.velocity = new Vector2(0, rb2b.velocity.y);

        }
        if (Input.GetKey("pace") && CheckGround.isGrounded)
        {
            rb2b.velocity = new Vector2(rb2b.velocity.x, VelocidadSalto); 

        }
       
    }
}
