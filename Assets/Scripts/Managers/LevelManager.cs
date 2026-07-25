using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public static LevelManager singleton;
    public Vector2 mapLeftDownPoint, mapRightTopPoint;
    private List<Vector2> availableMapSpots = new List<Vector2>();
    private List<Vector2> occupiedMapSpots = new List<Vector2>();
    private Tilemap mapTilemap;

    private void Awake()
    {
        //This ensures there is only one instance of this class
        if (singleton == null)
        {
            singleton = this;
            TryGetComponent(out mapTilemap);
            MapSetup();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetRandomRow()
    {
        Vector3Int leftDownGridPoint = mapTilemap.WorldToCell(mapLeftDownPoint);
        Vector3Int rightTopGridPoint = mapTilemap.WorldToCell(mapRightTopPoint);
        int randomRow = Random.Range(leftDownGridPoint.y, rightTopGridPoint.y);
        return randomRow + 0.5f;
    }

    public Vector2 GetRandomAvailableSpot()
    {
        //If there are elements in available spots, returns a random element from the list
        if (availableMapSpots.Count == 0) return Vector2.zero;
        int randomIndex = Random.Range(0, availableMapSpots.Count);
        Vector2 spot = availableMapSpots[randomIndex];
        availableMapSpots.Remove(spot);
        occupiedMapSpots.Add(spot);
        return spot;
    }

    public void OccupySpot(Transform spotTransform)
    {
        //A preset object in map returns its position to save it in the occupied positions list
        Vector3Int gridPos = mapTilemap.WorldToCell(spotTransform.position);
        Vector2 fixedPos = mapTilemap.CellToWorld(gridPos);
        fixedPos.x += 0.5f;
        fixedPos.y += 0.5f;
        spotTransform.position = fixedPos;

        availableMapSpots.Remove(fixedPos);
        occupiedMapSpots.Add(fixedPos);
    }

    public void ReturnOccupiedSpot(Vector2 spot)
    {
        //Objects on map have to call this method before they leave so their spot in the map gets available again
        occupiedMapSpots.Remove(spot);
        availableMapSpots.Add(spot);
    }

    private void MapSetup()
    {
        //Starting from left bottom, it iterates through each grid cell until it gets to top right, to save them in the avilable map spots
        Vector3Int leftDownGridPoint = mapTilemap.WorldToCell(mapLeftDownPoint);
        Vector3Int rightTopGridPoint = mapTilemap.WorldToCell(mapRightTopPoint);
        for (int i = leftDownGridPoint.x; i < rightTopGridPoint.x; i++)
        {
            for (int j = leftDownGridPoint.y; j < rightTopGridPoint.y; j++)
            {
                Vector2 worldPos = mapTilemap.CellToWorld(new Vector3Int(i, j));
                worldPos.x += 0.5f;
                worldPos.y += 0.5f;
                availableMapSpots.Add(worldPos);
            }
        }
    }
}
