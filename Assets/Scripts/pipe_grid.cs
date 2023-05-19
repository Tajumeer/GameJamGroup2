using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_grid : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private GameObject pipe_tilePrefab;

    [SerializeField] private Transform _cam;

    private char[,] pipe_logic;


    private void Awake()
    {
        pipe_logic = new char[_width, _height];
    }
    private void Start()
    {
        generategrid();
    }
    private void generategrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedtile = Instantiate(pipe_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedtile.name = $"pipe_tile {x} {y}";
            }

        }
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}