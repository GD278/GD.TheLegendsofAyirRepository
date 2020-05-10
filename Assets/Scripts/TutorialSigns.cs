using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialSigns : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private string tutorialString;
    [SerializeField] private Image signImage;
    private AudioSource source;
    [SerializeField] private AudioClip clip;
    void Start()
    {
        tutorialText.enabled = false;
        signImage.enabled = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.clip = clip;
            source.volume = 0.2f;
            source.Play();
            Debug.Log("Entered trigger.");
            tutorialText.SetText(tutorialString);
            signImage.enabled = true;
            tutorialText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            source.clip = clip;
            source.volume = 0.2f;
            source.Play();
            Debug.Log("Exited Trigger");
            signImage.enabled = false;
            tutorialText.enabled = false;
        }
    }
}
