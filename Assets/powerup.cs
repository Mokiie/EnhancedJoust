using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player 1"){
           Debug.Log("AAAAAAAAAAA");
           
            player1 playerScript = collision.gameObject.GetComponent<player1>();
            
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();

            int s = Random.Range(1,6);

            switch(s){
                case 1: playerScript.strength += 50;
                Debug.Log(s);
                        break;
                case 2: float massShrink = (float)body.mass * (float)0.75;
                Debug.Log(s);
                        body.mass = massShrink;
                        break;
                case 3: float massGrow = (float)body.mass * (float)1.5;
                Debug.Log(s);
                        body.mass = massGrow;
                        break;
                case 4: playerScript.strength += 100;
                Debug.Log(s);
                        break;
                case 5: float gravDown = (float)body.gravityScale * (float)0.75;
                Debug.Log(s);
                        body.gravityScale = gravDown;
                        break;
                case 6: float gravUp = (float)body.gravityScale * (float)1.5;
                Debug.Log(s);
                        body.gravityScale = gravUp;
                        break;
            }
            
           Destroy(this.gameObject);
        }
        
        if(collision.gameObject.name == "Player 2"){
            Debug.Log("BBBBBBBBBB");

            player2 playerScript = collision.gameObject.GetComponent<player2>();
            
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();

            int s = Random.Range(1,6);

            switch(s){
                case 1: playerScript.strength += 50;
                Debug.Log(s);
                        break;
                case 2: float massShrink = (float)body.mass * (float)0.75;
                Debug.Log(s);
                        body.mass = massShrink;
                        break;
                case 3: float massGrow = (float)body.mass * (float)1.5;
                Debug.Log(s);
                        body.mass = massGrow;
                        break;
                case 4: playerScript.strength += 100;
                Debug.Log(s);
                        break;
                case 5: float gravDown = (float)body.gravityScale * (float)0.75;
                Debug.Log(s);
                        body.gravityScale = gravDown;
                        break;
                case 6: float gravUp = (float)body.gravityScale * (float)1.5;
                Debug.Log(s);
                        body.gravityScale = gravUp;
                        break;
            }

            Destroy(this.gameObject);
        }
    }





}
