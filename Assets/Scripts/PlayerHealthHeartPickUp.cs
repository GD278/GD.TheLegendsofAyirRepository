using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHeartPickUp : MonoBehaviour
{
    PlayerCombat playerCombat;
     private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCombat = player.GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.name == "Player" && playerCombat.currentHealth < playerCombat.maxHealth)
		{
            playerCombat.currentHealth = playerCombat.currentHealth + 25;
            Destroy(gameObject);
            if(playerCombat.currentHealth > playerCombat.maxHealth)
			{
                playerCombat.currentHealth = playerCombat.maxHealth;
			}
        }
	}
}
