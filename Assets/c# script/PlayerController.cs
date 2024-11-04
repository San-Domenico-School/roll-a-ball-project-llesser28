using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float speed;              // How hard the ball is pushed
    private float xDirection;         // Move the ball left and right
    private float zDirection;         // Move the ball forward and backwards;
    private int count;                // Counts the pickups

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MoveBall();
    }

    private void MoveBall()
    {
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    // Listen for player pressing arrow or WASD keys
    private void GetPlayerInput()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");
    }

    private void SetCountText()
    {
        countText.text = "count" + count.ToString();
        if(count >= 13)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUP"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}