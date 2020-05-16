using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI youWinTB;
    PlayerController controller;
    [SerializeField] private GameObject Player;
    void Start()
    {
        controller = Player.GetComponent<PlayerController>();
        youWinTB.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.gameObject.name == "Player")
		{
            controller.canUseController2 = false;
            youWinTB.enabled = true;
		}
	}
}
