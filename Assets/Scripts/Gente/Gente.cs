using UnityEngine;

public class Gente : MonoBehaviour
{
    private int powerMeter = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<GenteManager>().PickUpGente(powerMeter);
            gameObject.SetActive(false);
        }
    }
}
