using UnityEngine;

public class Gente : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<GenteManager>().PickUpGente();
            gameObject.SetActive(false);
        }
    }
}
