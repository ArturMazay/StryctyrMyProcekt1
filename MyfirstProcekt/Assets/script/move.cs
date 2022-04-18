using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
private Rigidbody2D playerRB;

 private float horizontal;
 private float vertical;
  public int  maxHP = 100;
    public int currentHP;
    public float timeProtect = 2f;

    bool isProtect;
    float protectTime;

 private void Start()
 {
     playerRB = GetComponent<Rigidbody2D>();
     currentHP = maxHP;
 }
    public void ChangeHealth (int amout)
    {
       if(amout < 0)
       {
         if (isProtect)
            return;

            isProtect = true;
            protectTime = timeProtect;
       }

      currentHP = Mathf.Clamp(currentHP + amout, 0, maxHP);
      Debug.Log(currentHP + "/" + maxHP);   
    }

 private void Update()
 {
     horizontal = Input.GetAxis("Horizontal");
     vertical = Input.GetAxis("Vertical");

     if (isProtect)
     {
         protectTime -= Time.deltaTime;
         if(protectTime < 0)
         {
              isProtect = false;
         }
            
         
     }
 }

 private void FixedUpdate()
{
     Vector2 position = playerRB.position;


     position.x = position.x + 3.0f * horizontal * Time.deltaTime;
     position.y = position.y + 3.0f * vertical * Time.deltaTime;

     playerRB.MovePosition(position);
    }
}
