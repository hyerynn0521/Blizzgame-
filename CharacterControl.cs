using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour{
  public float moveSpeed = 5f;
  public float speed;
  public float jumpForce;
  private float moveInput;

  private Rigidbody2D rb;
  private bool facingRight = true;
    // Start is called before the first frame update
    void Start(){
      rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update(){
      Jump();
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
      transform.position += movement * Time.deltaTime * moveSpeed;
      if(facingRight == false && moveInput >0){
        flip();
      }else if(facingRight == true && moveInput <0){
        flip();
      }
    }
    void Jump (){
      if (Input.GetButtonDown("Jump")){
      gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
      }
    }
    void flip(){
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *=-1;
      transform.localScale = Scaler;
    }
}
