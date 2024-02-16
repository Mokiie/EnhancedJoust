using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Collider2D player1Collider;
    public Collider2D player2Collider;
    public Collider2D myCollider;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myCollider.IsTouching(player1Collider)){
           // Object.Destroy(this.gameObject);
        }


       if(left == true){
        transform.position -= new Vector3(600 * Time.deltaTime, 0, 0);
        }
        else{
         transform.position += new Vector3(600 * Time.deltaTime, 0, 0);
        }
    }
}
