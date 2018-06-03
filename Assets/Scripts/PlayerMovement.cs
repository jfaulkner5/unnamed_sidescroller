using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables

    public float maxPlayerHieght;
    public float minPlayerHieght;

    //Key Customiation
    public KeyCode playerMovementUp;
    public KeyCode playerMovementDown;

    //Border Variables
    float dist;
    //Vector3 leftBorder;
    //Vector3 rightBorder;
    Vector3 topBorder;
    Vector3 bottomBorder;
    #endregion


    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        maxPlayerHieght = topBorder.y;
        minPlayerHieght = bottomBorder.y;
        playerMovementUp = KeyCode.W;
        playerMovementDown = KeyCode.S;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            BoundarySetup();
        }
    }

    void Move()
    {
        if (Input.GetKey(playerMovementUp))
        {
            Debug.Log("Move up key pressed");
            transform.position = Vector3.MoveTowards(transform.position, topBorder, Time.deltaTime);
        }

        else if (Input.GetKey(playerMovementDown))
        {
            Debug.Log("Move down key pressed");
            transform.position = Vector3.MoveTowards(transform.position, bottomBorder, Time.deltaTime);
        }

        else
        {
            //Lerps player back to centre
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(maxPlayerHieght, minPlayerHieght, 0.5f), transform.position.z);
        }


    }

    public void BoundarySetup()
    {
        dist = (transform.position - Camera.main.transform.position).z;
        //leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        //rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        topBorder = transform.position;
        bottomBorder = transform.position;
        topBorder.y = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        bottomBorder.y = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;

        // On each border, reverse an object's velocity as long as it's not on its way back in.
        //https://answers.unity.com/questions/62189/detect-edge-of-screen.html
        //if ((transform.position.x <= leftBorder) && rigidbody.velocity.x < 0f)
        //{
        //    rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y, 0);
        //}

        //if ((transform.position.x >= rightBorder) && rigidbody.velocity.x > 0)
        //{
        //    rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y, 0);
        //}

        //if ((transform.position.y <= bottomBorder) && rigidbody.velocity.y < 0)
        //{
        //    rigidbody.velocity = new Vector3(rigidbody.velocity.x, -rigidbody.velocity.y, 0);
        //}

        //if ((transform.position.y >= topBorder) && rigidbody.velocity.y > 0)
        //{
        //    rigidbody.velocity = new Vector3(rigidbody.velocity.x, -rigidbody.velocity.y, 0);
        //}
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
    }
}
