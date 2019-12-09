using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{

    public AudioClip firstSound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = firstSound;
        source.playOnAwake = false;
       

        button.onClick.AddListener(() => StartCoroutine(FullyPlaySound()));
    }
    
    IEnumerator FullyPlaySound()
    {
        source.PlayOneShot(firstSound);
        yield return new WaitForSeconds(firstSound.length);

    }
}
