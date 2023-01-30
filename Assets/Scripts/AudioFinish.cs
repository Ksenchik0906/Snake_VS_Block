using UnityEngine;

public class AudioFinish : MonoBehaviour
{
    private void OnEnable()
    {
        AudioSource _audio = GetComponent<AudioSource>();
        _audio.Play();
    }
}
