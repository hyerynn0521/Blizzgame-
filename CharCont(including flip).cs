using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour{
  public float moveSpeed = 5f;
  public bool isGrounded;
  public bool facingRight;

  


  void FixedUpdate(){
    float horizontal = Input.GetAxis("Horizontal");

    Flip(horizontal);
  }
  private void Flip (float horizontal){
    if (horizontal >0 && !facingRight || horizontal <0 && facingRight){
      facingRight = !facingRight;
      Vector3 theScale = transform.localScale;
      theScale.x*=-1;
      transform.localScale = theScale;
    }
  }

    // Start is called before the first frame update
  void Start(){
    facingRight =true;

  }

  // Update is called once per frame
  void Update(){
    Jump();
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    transform.position += movement * Time.deltaTime * moveSpeed;


  }
  void Jump(){
    if (Input.GetButtonDown("Jump") && isGrounded == true){
      gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
    }
  }

}
