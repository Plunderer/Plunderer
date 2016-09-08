using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class goal : MonoBehaviour {
    AudioSource sound01;
    // Use this for initialization
    void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound01.Play();
        StartCoroutine("ending");
    }

    // Update is called once per frame
    IEnumerator ending()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("title");
    }
}
