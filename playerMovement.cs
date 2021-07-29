using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float way = 1;
    public Rigidbody2D rb;
    public GameObject camera;
    public GameObject blackLayer;
    public int jumpSpeed;
    public int moveSpeed;
    public float gravityOnWall;
    public int jumpTrigger = 1;
    public int onWall = 0;
    public int onGround = 0;
    public int onJump = 0;
    public int left = 0;
    public Animator animator;
    bool facingRight = true;
    public Tutorial tutorial;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        tutorial = box.GetComponent<Tutorial>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if(way == 1 && onJump == 0){
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if(way == -1 && onJump == 0){
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if(onWall == 1 && onGround == 1){
            animator.SetBool("isIdle", true);
        }
        else{
            animator.SetBool("isIdle", false);
        }
        if(onWall == 1 && onGround == 0){
            animator.SetBool("isClimb", true);
        }
        else{
            animator.SetBool("isClimb", false);
        }
        if(Input.GetKeyDown("space") && jumpTrigger == 1 && tutorial.onTutor == 0){
            animator.SetBool("isJumping", true);



            if (onWall == 1){
                if(left == 1){
                    rb.velocity = new Vector2(5, jumpSpeed);
                    way = 1;
                }
                else{
                    rb.velocity = new Vector2(-5, jumpSpeed);
                    way = -1;

                }
            }
            else{
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            rb.gravityScale = 2;
            jumpTrigger -= 1;
            onJump = 1;
        }
        else
        {
            animator.SetBool("isJumping", false);

        }
        if(camera.GetComponent<Transform>().position.x >= 0 && camera.GetComponent<Transform>().position.x <= 25){
            camera.GetComponent<Transform>().position = new Vector3(transform.position.x, camera.GetComponent<Transform>().position.y, camera.GetComponent<Transform>().position.z);
        }

        if(camera.GetComponent<Transform>().position.x < 0){
            camera.GetComponent<Transform>().position = new Vector3(0, camera.GetComponent<Transform>().position.y, camera.GetComponent<Transform>().position.z);
        }
        else if(camera.GetComponent<Transform>().position.x > 25){
            camera.GetComponent<Transform>().position = new Vector3(25, camera.GetComponent<Transform>().position.y, camera.GetComponent<Transform>().position.z);
        }

        if(camera.GetComponent<Transform>().position.y >= 0 && camera.GetComponent<Transform>().position.y <= 24){
            camera.GetComponent<Transform>().position = new Vector3(camera.GetComponent<Transform>().position.x, transform.position.y, camera.GetComponent<Transform>().position.z);
        }

        if(camera.GetComponent<Transform>().position.y < 0){
            camera.GetComponent<Transform>().position = new Vector3(camera.GetComponent<Transform>().position.x, 0, camera.GetComponent<Transform>().position.z);
        }
        else if(camera.GetComponent<Transform>().position.y > 24){
            camera.GetComponent<Transform>().position = new Vector3(camera.GetComponent<Transform>().position.x, 24, camera.GetComponent<Transform>().position.z);
        }

        blackLayer.GetComponent<Transform>().position = new Vector3(camera.GetComponent<Transform>().position.x, camera.GetComponent<Transform>().position.y, blackLayer.GetComponent<Transform>().position.z);
    
        if(way<0 && facingRight)
        {
            flip();
        }
        else if(way > 0 && !facingRight)
        {
            flip();
        }
    
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "wall"){
            if(transform.position.x < other.gameObject.GetComponent<Transform>().position.x){
                left = 0;
            }
            else{
                left = 1;
            }
            rb.velocity = new Vector2(0,0);
            rb.gravityScale = gravityOnWall;
            onWall = 1;
        }
        if (other.gameObject.tag == "ground"){
            onGround = 1;
        }
        if(other.gameObject.tag == "finish"){
            SceneManager.LoadScene(2);
        }
        jumpTrigger = 1;
        onJump = 0;
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "wall"){
            rb.gravityScale = 2;
            onWall = 0;
        }
        if (other.gameObject.tag == "ground"){
            onGround = 0;
        }
        //jumpTrigger -= 1;
    }

}
