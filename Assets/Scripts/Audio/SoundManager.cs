using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource audioGeneral;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioGeneral.clip = clip;
        audioGeneral.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        audioGeneral.PlayOneShot(clip);
    }
}
