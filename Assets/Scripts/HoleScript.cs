using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class HoleScript : MonoBehaviour
{
    /// <summary>
	/// This script kills the player when he falls in a hole. It also makes the camera stop following the player. 
	/// </summary>
    // Start is called before the first frame update
    PlayerCombat combat;
    PlayerController controller;
    [SerializeField] private GameObject Player;
    [SerializeField] CinemachineVirtualCamera vcam1;
    [SerializeField] CinemachineVirtualCamera vcam2;
    void Start()
    {
        Debug.Log("Hole script initialized.");
        combat = Player.GetComponent<PlayerCombat>();
        controller = Player.GetComponent<PlayerController>();
        vcam1.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
		{
            controller.canUseController2 = false;
            vcam1.enabled = false;
            vcam2.enabled = true;
            Debug.Log("You have entered the hole trigger.");
            combat.currentHealth = 0;
		}
    }

}
