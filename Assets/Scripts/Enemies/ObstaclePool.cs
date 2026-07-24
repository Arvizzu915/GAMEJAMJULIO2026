using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public static ObstaclePool singleton;
    [SerializeField] GameObject bombPrefab, sharkPrefab;
    private Stack<Bomb> bombsInMap = new Stack<Bomb>();
    private Stack<Shark> sharksInMap = new Stack<Shark>();
    private int initialObstacles = 5;

    private void Awake()
    {
        //This ensures there is only one instance of this class
        if (singleton == null)
        {
            singleton = this;
            for (int i = 0; i < initialObstacles; i++)
            {
                Bomb newBomb = GetNewBomb();
                newBomb.gameObject.SetActive(false);
                bombsInMap.Push(newBomb);
                Shark newShark = GetNewShark();
                newShark.gameObject.SetActive(false);
                sharksInMap.Push(newShark);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Bomb GetBomb()
    {
        //returns a bomb from the pool, if pool is empty creates a new one
        if (bombsInMap.Count > 0)
            return bombsInMap.Pop();
        else
            return GetNewBomb();
    }

    private Bomb GetNewBomb()
    {
        //creates a new bomb
        GameObject newBomb = Instantiate(bombPrefab, transform.position, transform.rotation);
        return newBomb.GetComponent<Bomb>();
    }

    public void ReturnBombToPool(Bomb bomb)
    {
        //bombs should call this method before they go so they can be added back to the pool
        LevelManager.singleton.ReturnOccupiedSpot(bomb.transform.position);
        bomb.gameObject.SetActive(false);
        bombsInMap.Push(bomb);
    }

    public Shark GetShark()
    {
        //returns a shark from the pool, if pool is empty creates a new one
        if (sharksInMap.Count > 0)
            return sharksInMap.Pop();
        else
            return GetNewShark();
    }

    private Shark GetNewShark()
    {
        //creates a new bomb
        GameObject newShark = Instantiate(sharkPrefab, transform.position, transform.rotation);
        return newShark.GetComponent<Shark>();
    }

    public void ReturnSharkToPool(Shark shark)
    {
        //bombs should call this method before they go so they can be added back to the pool
        LevelManager.singleton.ReturnOccupiedSpot(shark.transform.position);
        shark.gameObject.SetActive(false);
        sharksInMap.Push(shark);
    }
}
