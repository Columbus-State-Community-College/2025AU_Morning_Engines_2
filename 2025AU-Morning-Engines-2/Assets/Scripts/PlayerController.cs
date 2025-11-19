using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float movespeed = 10f;
    public float jumpheight = 5f;
    public float Dodge = 15f;
    public Rigidbody rb;

    public GameObject hitbox;

    public float sensitivity = 30f;
    Vector2 look;

    [SerializeField] Transform cameraTransform;
    [SerializeField] float mousesensitivity = 3f;



    // Start is called before the first frame update
    void Start()
    {
        hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;

        transform.Translate(x, 0, z);

        look.x += Input.GetAxis("Mouse X") * mousesensitivity;
        look.y += Input.GetAxis("Mouse Y") * mousesensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);

    
        
        //Jump Button
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            rb.linearVelocity = Vector3.up * jumpheight;
        }


        //Sprint Button
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            movespeed += 5f;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            movespeed -= 5f;
        }

        //Dodge Button
        if (Input.GetButtonUp("Fire1") == true)
        {
            transform.position += (Vector3.back * Dodge) * Time.deltaTime;
        }

        //Attack Button
        //Attack is a hitbox that on press it becomes active and on release becomes false
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            hitbox.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Q) == true)
        {
            hitbox.SetActive(false);
        }




    }


}
