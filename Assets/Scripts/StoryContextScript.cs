using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryContextScript : MonoBehaviour
{
    PlayerController controller;
    PlayerCombat combat;
    [SerializeField] private GameObject LivingPanel;
    [SerializeField] private GameObject StoryPanel;
    [SerializeField] private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = Player.GetComponent<PlayerController>();
        controller.canUseController2 = false;
        combat = Player.GetComponent<PlayerCombat>();
        combat.enabled = false;
        LivingPanel.SetActive(false);
        StoryPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseSM()
	{
        combat.enabled = true;
        controller.canUseController2 = true;
        StoryPanel.SetActive(false);
        LivingPanel.SetActive(true);
	}
}
