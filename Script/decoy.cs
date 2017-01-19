using UnityEngine;
using System.Collections;

public class decoy : MonoBehaviour {    
    private AudioSource sound01;
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
    }
    public void Damage(float damage)
    {
        sound01.Play();
    }
    public void stunDamage(float stundamage)
    {
    }
}
