using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{

    public AudioClip soundClip;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = soundClip;
        source.playOnAwake = false;
       

        button.onClick.AddListener(() => PlaySound());
    }
    
    void PlaySound()
    {
        source.PlayOneShot(soundClip);
    }
}
