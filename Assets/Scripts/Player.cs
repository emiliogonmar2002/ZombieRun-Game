using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]//Para editarlos en el Inspector Pannel
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 15f;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG="Ground";
    private string ENEMY_TAG="Enemy";
    private bool isGrounded=true;

    [SerializeField]
    private float maxVelocity = 22f;

    // When the game starts
    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();       //Obtener referencia del cuerpo
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
        PlayerMoveKeyboard();
        PlayerJump();
    }

    void FixedUpdate(){
        
    }


    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;        //Mover al jugador horizontalmente
    }

    void AnimatePlayer(){

        if(movementX > 0){
            //Ir a la derecha
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if(movementX < 0){
            //Ir a la izquierda
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{
            //No se mueve ni izq ni der
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // myBody.Velocity();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }
}
