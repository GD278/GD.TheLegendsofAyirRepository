using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    bool byLadder = false;
    private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject player;
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (byLadder && Input.GetKeyDown("W"))
        {
            playerRigidbody.velocity = new Vector3(0, 1, 0);
        }
        if (byLadder && Input.GetKeyDown("S"))
        {
            playerRigidbody.velocity = new Vector3(0, -1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "Player")
        {
            byLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            byLadder = false;
        }
    }
}
