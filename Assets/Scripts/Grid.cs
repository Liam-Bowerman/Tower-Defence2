using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TowerDefense
{
    public class Grid : MonoBehaviour
    {
        public static float cellSize = 1.0f;
        public static Transform gridOrigin;
        private Dictionary<Vector3Int, GameObject> gameObjects = new Dictionary<Vector3Int, GameObject>();

        public bool Add(Vector3Int tileCoordinates, GameObject gameObject)
        {
            if (gameObjects.ContainsKey(tileCoordinates)) return false;

            gameObjects.Add(tileCoordinates, gameObject);
            return true;
        }

        public void Remove(Vector3Int tileCoordinates)
        {
            if (!gameObjects.ContainsKey(tileCoordinates)) return;

            Destroy(gameObjects[tileCoordinates]);
            gameObjects.Remove(tileCoordinates);
        }

        public static Vector3Int WorldToGrid(Vector3 position)
        {
            int x = (int)Mathf.Round(position.x);
            int y = (int)Mathf.Round(position.y);
            int z = (int)Mathf.Round(position.z);
            return new Vector3Int(x, y, z);
        }

        public static Vector3 GridToWorld(Vector3Int tileCoordinates)
        {
            float x = tileCoordinates.x * cellSize;
            float y = tileCoordinates.y * cellSize;
            float z = tileCoordinates.z * cellSize;
            Vector3 localPosition = new Vector3(x, y, z);
            return gridOrigin.TransformPoint(localPosition);
        }
    }
}

