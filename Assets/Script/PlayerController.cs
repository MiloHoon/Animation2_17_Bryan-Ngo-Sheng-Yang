using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;
    float jumpForce = 5.0f;
    int health = 10;

    bool isOnPlane = true;
    bool isAlive = true;

    public Rigidbody PlayerRb;
    public Animator PlayerAnimation;
    public Text Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            //Player Move Foward
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnimation.SetBool("isMove", true);
            }
            //Player Move Back
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnimation.SetBool("isMove", true);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                PlayerAnimation.SetBool("isMove", false);
            }
            //Player Move Left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                PlayerAnimation.SetBool("isMove", true);
            }
            //Player Move Right
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnimation.SetBool("isMove", true);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                PlayerAnimation.SetBool("isMove", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnPlane)
            {
                PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                PlayerAnimation.SetTrigger("trigFlip");
                isOnPlane = false;
            }
        }
        //Trigger Death
        if (Input.GetKeyDown(KeyCode.K))
        {
            health --;
            Health.GetComponent<Text>().text = "Health : " + health;
            //Death State
            if (health <= 0)
            {
                PlayerAnimation.SetTrigger("trigDeath");
                isAlive = !isAlive;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnPlane = true;
        }
    }
}
