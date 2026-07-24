using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    public static BombPool singleton;
    [SerializeField] GameObject bombPrefab;
    private Stack<Bomb> bombsInMap = new Stack<Bomb>();
    private int initialBombs = 5;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            for (int i = 0; i < initialBombs; i++)
            {
                Bomb newBomb = GetNewBomb();
                newBomb.gameObject.SetActive(false);
                bombsInMap.Push(newBomb);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Bomb GetBomb()
    {
        if (bombsInMap.Count > 0)
            return bombsInMap.Pop();
        else
            return GetNewBomb();
    }

    private Bomb GetNewBomb()
    {
        GameObject newBomb = Instantiate(bombPrefab, transform.position, transform.rotation);
        return newBomb.GetComponent<Bomb>();
    }

    public void ReturnToPool(Bomb bomb)
    {
        bomb.gameObject.SetActive(false);
        bombsInMap.Push(bomb);
    }

    public bool IsPositionEmpty(Vector3 pos)
    {
        foreach (Bomb bomb in bombsInMap)
        {
            if (bomb.gameObject.activeSelf)
            {
                if (bomb.transform.position == pos) return false;
            }
        }
        return true;
    }
}
