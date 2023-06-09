using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_grid : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private GameObject pipe_emptyPrefab;
    [SerializeField] private GameObject pipe_player_emptyPrefab0;
    [SerializeField] private GameObject pipe_player_emptyPrefab1;
    [SerializeField] private GameObject pipe_player_emptyPrefab2;
    [SerializeField] private GameObject pipe_player_emptyPrefab3;
    [SerializeField] private GameObject pipe_player_emptyPrefab4;
    [SerializeField] private GameObject pipe_player_emptyPrefab5;
    [SerializeField] private GameObject pipe_player_emptyPrefab6;
    [SerializeField] private GameObject pipe_player_emptyPrefab7;
    [SerializeField] private GameObject pipe_player_emptyPrefab8;
    [SerializeField] private GameObject pipe_player_emptyPrefab9;
    [SerializeField] private GameObject pipe_L_rightdown_min10Prefab;
    [SerializeField] private GameObject pipe_L_upleftPrefab;
    [SerializeField] private GameObject pipe_L_uprightPrefab;
    [SerializeField] private GameObject pipe_quad_cplus5Prefab;
    [SerializeField] private GameObject pipe_straight_horizontalPrefab;
    [SerializeField] private GameObject pipe_straight_horizontal_plus5Prefab;
    [SerializeField] private GameObject pipe_straight_horizontal_plus10Prefab;
    [SerializeField] private GameObject pipe_straight_horizontal_min5Prefab;
    [SerializeField] private GameObject pipe_straight_verticalPrefab;
    [SerializeField] private GameObject pipe_straight_vertical_plus5Prefab;
    [SerializeField] private GameObject pipe_straight_vertical_cmin5Prefab;
    [SerializeField] private GameObject pipe_straight_vertical_cmin10Prefab;
    [SerializeField] private GameObject pipe_straight_vertical_c0Prefab;
    [SerializeField] private GameObject pipe_straight_vertical_cplus10Prefab;
    [SerializeField] private GameObject pipe_T_leftdownright_min15Prefab;
    [SerializeField] private GameObject pipe_T_leftdownright_cplus5Prefab;
    [SerializeField] private GameObject pipe_T_updownleft_min5Prefab;
    [SerializeField] private GameObject pipe_T_updownleft_cmin5Prefab;
    [SerializeField] private GameObject pipe_T_uprightdown_min5Prefab;
    [SerializeField] private GameObject pipe_T_uprightdown_min10Prefab;
    [SerializeField] private GameObject pipe_T_uprightleftPrefab;

    [SerializeField] private Transform _cam;

    private int[,] pipe_logic;


    private void Awake()
    {
        pipe_logic = new int[_width, _height];
    }

    private void Start()
    {
        set_pipe_logic();
        generategrid();
    }

    private void generategrid()
    {
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)-_height / 2 +0.5f, -10);

        for (int y = 0; y < _width; y++)
        {
            for (int x = 0; x < _height; x++)
            {
                switch (pipe_logic[x,y])
                {
                    case 0:
                        var spawnedtile1 = Instantiate(pipe_emptyPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile1.name = $"pipe_tile {x} {y}";
                        break;
                    case 50:
                        var spawnedtile30 = Instantiate(pipe_player_emptyPrefab0, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile30.name = $"pipe_tile {x} {y}";
                        break;
                    case 51:
                        var spawnedtile31 = Instantiate(pipe_player_emptyPrefab1, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile31.name = $"pipe_tile {x} {y}";
                        break;
                    case 52:
                        var spawnedtile32 = Instantiate(pipe_player_emptyPrefab2, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile32.name = $"pipe_tile {x} {y}";
                        break;
                    case 53:
                        var spawnedtile33 = Instantiate(pipe_player_emptyPrefab3, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile33.name = $"pipe_tile {x} {y}";
                        break;
                    case 54:
                        var spawnedtile34 = Instantiate(pipe_player_emptyPrefab4, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile34.name = $"pipe_tile {x} {y}";
                        break;
                    case 55:
                        var spawnedtile35 = Instantiate(pipe_player_emptyPrefab5, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile35.name = $"pipe_tile {x} {y}";
                        break;
                    case 56:
                        var spawnedtile36 = Instantiate(pipe_player_emptyPrefab6, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile36.name = $"pipe_tile {x} {y}";
                        break;
                    case 57:
                        var spawnedtile37 = Instantiate(pipe_player_emptyPrefab7, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile37.name = $"pipe_tile {x} {y}";
                        break;
                    case 58:
                        var spawnedtile38 = Instantiate(pipe_player_emptyPrefab8, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile38.name = $"pipe_tile {x} {y}";
                        break;
                    case 59:
                        var spawnedtile39 = Instantiate(pipe_player_emptyPrefab9, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile39.name = $"pipe_tile {x} {y}";
                        break;
                    case -21023:
                        var spawnedtile5 = Instantiate(pipe_L_rightdown_min10Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile5.name = $"pipe_tile {x} {y}";
                        break;
                    case 314:
                        var spawnedtile6 = Instantiate(pipe_L_upleftPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile6.name = $"pipe_tile {x} {y}";
                        break;
                    case 312:
                        var spawnedtile7 = Instantiate(pipe_L_uprightPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile7.name = $"pipe_tile {x} {y}";
                        break;
                    case 151234:
                        var spawnedtile8 = Instantiate(pipe_quad_cplus5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile8.name = $"pipe_tile {x} {y}";
                        break;
                    case 324:
                        var spawnedtile9 = Instantiate(pipe_straight_horizontalPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile9.name = $"pipe_tile {x} {y}";
                        break;
                    case 2524:
                        var spawnedtile10 = Instantiate(pipe_straight_horizontal_plus5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile10.name = $"pipe_tile {x} {y}";
                        break;
                    case 21024:
                        var spawnedtile11 = Instantiate(pipe_straight_horizontal_plus10Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile11.name = $"pipe_tile {x} {y}";
                        break;
                    case -2524:
                        var spawnedtile12 = Instantiate(pipe_straight_horizontal_min5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile12.name = $"pipe_tile {x} {y}";
                        break;
                    case 313:
                        var spawnedtile13 = Instantiate(pipe_straight_verticalPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile13.name = $"pipe_tile {x} {y}";
                        break;
                    case 2513:
                        var spawnedtile14 = Instantiate(pipe_straight_vertical_plus5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile14.name = $"pipe_tile {x} {y}";
                        break;
                    case -1513:
                        var spawnedtile15 = Instantiate(pipe_straight_vertical_cmin5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile15.name = $"pipe_tile {x} {y}";
                        break;
                    case -11013:
                        var spawnedtile16 = Instantiate(pipe_straight_vertical_cmin10Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile16.name = $"pipe_tile {x} {y}";
                        break;
                    case 1013:
                        var spawnedtile17 = Instantiate(pipe_straight_vertical_c0Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile17.name = $"pipe_tile {x} {y}";
                        break;
                    case 11013:
                        var spawnedtile18 = Instantiate(pipe_straight_vertical_cplus10Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile18.name = $"pipe_tile {x} {y}";
                        break;
                    case -215234:
                        var spawnedtile20 = Instantiate(pipe_T_leftdownright_min15Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile20.name = $"pipe_tile {x} {y}";
                        break;
                    case 15234:
                        var spawnedtile21 = Instantiate(pipe_T_leftdownright_cplus5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile21.name = $"pipe_tile {x} {y}";
                        break;
                    case -25134:
                        var spawnedtile23 = Instantiate(pipe_T_updownleft_min5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile23.name = $"pipe_tile {x} {y}";
                        break;
                    case -15134:
                        var spawnedtile24 = Instantiate(pipe_T_updownleft_cmin5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile24.name = $"pipe_tile {x} {y}";
                        break;
                    case -25123:
                        var spawnedtile26 = Instantiate(pipe_T_uprightdown_min5Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile26.name = $"pipe_tile {x} {y}";
                        break;
                    case -210123:
                        var spawnedtile27 = Instantiate(pipe_T_uprightdown_min10Prefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile27.name = $"pipe_tile {x} {y}";
                        break;
                    case 3124:
                        var spawnedtile28 = Instantiate(pipe_T_uprightleftPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile28.name = $"pipe_tile {x} {y}";
                        break;
                }
            }
        }
       
    }

    private void set_pipe_logic()
    {
        pipe_logic = new int[,]{{ 313, -11013, 50, -25123, 313, 51, 0},{ -21023, 52, 11013, 53, 313, 3124, 0},{ 15234, 54, 1013, -210123, -1513, 55, 0},{ 314, 21024, 0, 324, 0, -2524, 0},{ 0, -215234, 2513, 56, 313, 151234, 312},{ 0, 57, 0, 0, 0, 324, 2524},{ 313, -15134, 58, 313, 313, -25134, 59}};
    }
}