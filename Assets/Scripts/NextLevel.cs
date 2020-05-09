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

    void OnTriggerEnter2D(Collider2D other)
	{
        
            Debug.Log("Player Detected");
            SceneManager.LoadScene(LevelName);
		
	}
}
