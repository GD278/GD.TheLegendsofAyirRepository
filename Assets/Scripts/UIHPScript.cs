using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHPScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCombat.currentHealth < 0)
		{
            playerCombat.currentHealth = 0;
		}
        if (playerCombat.currentHealth > 50)
        {
            hpText.color = Color.green;
        }
         if (playerCombat.currentHealth <= 50)
        {
            hpText.color = Color.yellow;
        }
         if (playerCombat.currentHealth <= 25)
		{
            hpText.color = Color.red;
        }
       
        hpText.SetText($"HP: {playerCombat.currentHealth}");
    }
}
