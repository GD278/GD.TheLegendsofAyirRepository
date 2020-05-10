using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string LevelName;
    void Start()
    {
        Debug.Log("Next Level Initalized");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
		{
            Debug.Log("Player detected");
            SceneManager.LoadScene(LevelName);
		}
    }
}
