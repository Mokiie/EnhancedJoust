using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1 : MonoBehaviour
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

    public Text player1Score;
    int player1Int = 0;
    public int maxScore;
   
    public Text win1;
    public Text win2;

    public GameObject prefab;
    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {     
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f,2.0f,0.0f);
        jumpleft = new Vector3(-2.0f,2.0f,0.0f);
        jumpright = new Vector3(2.0f,2.0f,0.0f);
        //faceright = true;

        if(menu.enhanced == true){
            InvokeRepeating("spawnPowerUp", 3.0f, 3.0f);
        }
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
        if(Input.GetKey("a") && (v.x >= -1500.0f)){
            v.x -= 15.0f;
            rb.velocity = v;
        }
            if(Input.GetKey("d") && (v.x <= 1500.0f)){
            v.x += 15.0f;
            rb.velocity = v;
        }

        if(Input.GetKeyDown("w")){
            rb.AddForce(jump*strength, ForceMode2D.Impulse);
        }
    }
    else{
        if(Input.GetKeyDown("w") && Input.GetKey("a")){
            rb.AddForce(jumpleft*strength, ForceMode2D.Impulse);
        }
        else if(Input.GetKeyDown("w") && Input.GetKey("d")){
            rb.AddForce(jumpright*strength, ForceMode2D.Impulse);
        }
        else if(Input.GetKeyDown("w")){
            rb.AddForce(jump*strength, ForceMode2D.Impulse);
        }
    }

    

    }

    void spawnPowerUp(){
        Debug.Log("bap");
        int x = Random.Range(-1800,1800);
        int y = Random.Range(-500,700);
        Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ow");
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            player1Int++;
            player1Score.text = player1Int.ToString();
            if(player1Int == maxScore){
                Debug.Log("Player 1 wins");
                win1.transform.gameObject.SetActive(true);
                restart.transform.gameObject.SetActive(true);
            }
        }

        if(collision.gameObject.name == "Player 2"){
            if(transform.position.y >= collision.gameObject.transform.position.y){
                Debug.Log("Player 1 wins");
                win1.transform.gameObject.SetActive(true);
                restart.transform.gameObject.SetActive(true);
                Destroy(collision.gameObject);
                
            }
            else{
                Debug.Log("Player 2 wins");
                foreach (Transform child in transform)
                {
                    win2.transform.gameObject.SetActive(true);
                    Destroy(child.gameObject);
                    restart.transform.gameObject.SetActive(true);
                }
            }
        }
    }
    }
    