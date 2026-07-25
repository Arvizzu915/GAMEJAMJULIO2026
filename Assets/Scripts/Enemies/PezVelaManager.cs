using System.Collections;
using UnityEngine;

public class PezVelaManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Vector2 spawnLimits;

    [SerializeField] private GameObject warning;
    [SerializeField] private PezVelaObject pezVela;

    int direction = 1;

    private void OnEnable()
    {
        Debug.Log("pez");

        warning.SetActive(true);

        pezVela.transform.position = transform.position;
        pezVela.transform.SetParent(transform, false);

        direction = Random.Range(-1, 2);

        Debug.Log(direction);

        if (direction <= 0)
        {
            direction = -1;
            transform.localScale = new Vector3 (1, 1, 1);
        }
        else
        {
            direction = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        Vector2 spawnPos = new(spawnLimits.x * direction, Random.Range(-spawnLimits.y, spawnLimits.y));

        transform.position = spawnPos;

        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        yield return new WaitForSeconds(5);

        warning.SetActive(false);

        yield return new WaitForSeconds(1f);

        pezVela.gameObject.SetActive(true);
        pezVela.Fly(this, speed * direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<GenteManager>().Crash(2);
        }

        Deactivate();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
