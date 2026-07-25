using UnityEngine;

public class GenteManager : MonoBehaviour
{
    public static GenteManager instance;

    [SerializeField] private SpriteRenderer[] genteSpots;
    public int currentGente = 0, powerMeter = 0, powerLimit = 10;

    [SerializeField] private PowerUps powerUpManager;
    public Animator bubbleAnimator;
    private bool hasBubble;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip crash;

    private void Awake()
    {
        instance = this;
        hasBubble = false;
    }

    public void PickUpGente(int power)
    {
        genteSpots[currentGente].enabled = true;

        currentGente++;

        powerUpManager.GetPower(power);

        LevelManager.singleton.peopleRescued++;
    }

    public void Crash(int Damage)
    {
        if (hasBubble)
        {
            ToggleBubble(false);
            return;
        }

        audioSource.clip = crash;
        audioSource.Play();

        if (currentGente <= 0)
        {
            ScoreManager.instance.Lose();
            return;
        }

        for (int i = 0; i < Damage; i++)
        {
            currentGente--;
            if (currentGente >= 0)
            {
                genteSpots[currentGente].enabled = false;
            }
        }
    }

    public void ToggleBubble(bool getBubble)
    {
        hasBubble = getBubble;
        if (getBubble)
        {
            bubbleAnimator.Play("BubbleIdle");
            bubbleAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            bubbleAnimator.Play("BubblePop");
    }
}
