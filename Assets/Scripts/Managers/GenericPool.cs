using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GenericPool : MonoBehaviour
{
    [Header("Flying Arrows")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialAmount = 20;


    private readonly Queue<GameObject> gameObjects = new();

    private void Awake()
    {
        CreateObjects();
    }

    private void CreateObjects()
    {
        for (int i = 0; i < initialAmount; i++)
        {
            GameObject gameObject = Instantiate(prefab, transform);
            gameObject.SetActive(false);
            gameObjects.Enqueue(gameObject);
        }
    }

    public GameObject GetObject(Vector2 position)
    {
        GameObject gameObject;

        if (gameObjects.Count > 0)
        {
            gameObject = gameObjects.Dequeue();
        }
        else
        {
            gameObject = Instantiate(prefab, transform);
        }

        gameObject.transform.position = position;
        gameObject.gameObject.SetActive(true);

        return gameObject;
    }

    public void ReturnObject(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        gameObject.transform.SetParent(transform);
        gameObjects.Enqueue(gameObject);
    }
}
