using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollision : MonoBehaviour
{
    [SerializeField] private GameObject crate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
	{
        if(col.gameObject.name == "Crate")
		{
            if (Input.GetMouseButtonDown(0))
                Destroy(crate);
		}
	}
}
