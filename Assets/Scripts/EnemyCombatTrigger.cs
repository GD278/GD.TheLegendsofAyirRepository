using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemy;
    
    public bool inCombat;
    void Start()
    {
        inCombat = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You have entered combat.");
            inCombat = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You have exited combat");
            inCombat = false;
        }
    }
}
