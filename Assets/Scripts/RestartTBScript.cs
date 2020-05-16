using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestartTBScript : MonoBehaviour
{
    public bool isDead = false;
    [SerializeField] private TextMeshProUGUI replayText;
    // Start is called before the first frame update
    void Start()
    {
        replayText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (isDead)
		{
            replayText.enabled = true;
		}
    }
}
