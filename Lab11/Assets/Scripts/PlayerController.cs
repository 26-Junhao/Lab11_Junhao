using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject healthText;
    public float speed;
    public float rotateSpeed;
    public float damageRate;
    public float health;
    bool alive = true;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("IsWalkBool", true);
            }

            if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("IsWalkBool", true);
            }

            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("IsWalkBool", true);
            }
            if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("IsWalkBool", true);
            }
            if(Input.anyKey == false)
            {
                animator.SetBool("IsWalkBool", false);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("AttackTrigger");
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fire" && alive == true)
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health: " + health;
            if(health <= 0)
            {
                animator.SetTrigger("DeadTrigger");
                healthText.GetComponent<Text>().text = "Health: 0";
                alive = false;
            }
        }
    }
}
