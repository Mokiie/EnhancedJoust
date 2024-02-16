using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{
    Vector3 jump;
    Vector3 jumpleft;
    Vector3 jumpright;
    Rigidbody2D rb;
    public float strength;
    //bool faceright;
    bool ground = true;
    public Collider2D playerCollider;
    public Collider2D floorCollider;
    public Collider2D platformCollider;
    public Collider2D platformCollider2;
    public Collider2D platformCollider3;
   

    public Text player2Score;
    int player2Int = 0;
    public int maxScore;

    public Text win2;
    public GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f,2.0f,0.0f);
        jumpleft = new Vector3(-2.0f,2.0f,0.0f);
        jumpright = new Vector3(2.0f,2.0f,0.0f);
        //faceright = true;
    }

   
    private void checkGround(){
        if(playerCollider.IsTouching(floorCollider) || playerCollider.IsTouching(platformCollider)
            || playerCollider.IsTouching(platformCollider2)|| playerCollider.IsTouching(platformCollider3)){
            ground = true;
        }
        else{
            ground = false;
        }
    }

    //Update is called once per frame
    void Update()
    {

        if(transform.position.x >=2000){
            var pos = transform.position;
            pos.x = -2050;
            transform.position = pos;
        }

        if(transform.position.x <=-2100){
            var pos = transform.position;
            pos.x = 1950;
            transform.position = pos;
        }
      
        checkGround();

        if(ground){
        Vector3 v = rb.velocity;
        if(Input.GetKey("left") && (v.x >= -1500.0f)){
            v.x -= 15.0f;
            rb.velocity = v;
        }
            if(Input.GetKey("right") && (v.x <= 1500.0f)){
            v.x += 15.0f;
            rb.velocity = v;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            rb.AddForce(jump*strength, ForceMode2D.Impulse);
        }
    }
    else{
        if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey("left")){
            rb.AddForce(jumpleft*strength, ForceMode2D.Impulse);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey("right")){
            rb.AddForce(jumpright*strength, ForceMode2D.Impulse);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow)){
            rb.AddForce(jump*strength, ForceMode2D.Impulse);
        }
    }

        


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ow");
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            player2Int++;
            player2Score.text = player2Int.ToString();
            if(player2Int == maxScore){
                Debug.Log("Player 2 wins");
                win2.transform.gameObject.SetActive(true);
                restart.transform.gameObject.SetActive(true);
                
            }
        }
    }
}