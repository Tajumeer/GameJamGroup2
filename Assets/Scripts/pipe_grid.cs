using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_grid : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private GameObject pipe_emptyPrefab;
    [SerializeField] private GameObject pipe_player_emptyPrefab;
    [SerializeField] private GameObject pipe_L_downleftPrefab;
    [SerializeField] private GameObject pipe_L_rightdownPrefab;
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
    [SerializeField] private GameObject pipe_T_leftdownrightPrefab;
    [SerializeField] private GameObject pipe_T_leftdownright_min15Prefab;
    [SerializeField] private GameObject pipe_T_leftdownright_cplus5Prefab;
    [SerializeField] private GameObject pipe_T_updownleftPrefab;
    [SerializeField] private GameObject pipe_T_updownleft_min5Prefab;
    [SerializeField] private GameObject pipe_T_updownleft_cmin5Prefab;
    [SerializeField] private GameObject pipe_T_uprightdownPrefab;
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
                    case 5:
                        var spawnedtile2 = Instantiate(pipe_player_emptyPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile2.name = $"pipe_tile {x} {y}";
                        break;
                    case 334:
                        var spawnedtile3 = Instantiate(pipe_L_downleftPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile3.name = $"pipe_tile {x} {y}";
                        break;
                    case 323:
                        var spawnedtile4 = Instantiate(pipe_L_rightdownPrefab, new Vector3(x, -y), Quaternion.identity);
                        spawnedtile4.name = $"pipe_tile {x} {y}";
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
                    case 3234:
                        var spawnedtile19 = Instantiate(pipe_T_leftdownrightPrefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 180));
                        spawnedtile19.name = $"pipe_tile {x} {y}";
                        break;
                    case -215234:
                        var spawnedtile20 = Instantiate(pipe_T_leftdownright_min15Prefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 180));
                        spawnedtile20.name = $"pipe_tile {x} {y}";
                        break;
                    case 15234:
                        var spawnedtile21 = Instantiate(pipe_T_leftdownright_cplus5Prefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 180));
                        spawnedtile21.name = $"pipe_tile {x} {y}";
                        break;
                    case 3134:
                        var spawnedtile22 = Instantiate(pipe_T_updownleftPrefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 90));
                        spawnedtile22.name = $"pipe_tile {x} {y}";
                        break;
                    case -25134:
                        var spawnedtile23 = Instantiate(pipe_T_updownleft_min5Prefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 90));
                        spawnedtile23.name = $"pipe_tile {x} {y}";
                        break;
                    case -15134:
                        var spawnedtile24 = Instantiate(pipe_T_updownleft_cmin5Prefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 90));
                        spawnedtile24.name = $"pipe_tile {x} {y}";
                        break;
                    case 3123:
                        var spawnedtile25 = Instantiate(pipe_T_uprightdownPrefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 270));
                        spawnedtile25.name = $"pipe_tile {x} {y}";
                        break;
                    case -25123:
                        var spawnedtile26 = Instantiate(pipe_T_uprightdown_min5Prefab, new Vector3(x, -y), Quaternion.Euler(0, 0, 270));
                        spawnedtile26.name = $"pipe_tile {x} {y}";
                        break;
                    case -210123:
                        var spawnedtile27 = Instantiate(pipe_T_uprightdown_min10Prefab, new Vector3(x, -y), Quaternion.Euler(0,0,270));
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
        pipe_logic = new int[,]{{ 313, -11013, 5, -25123, 313, 5, 0},{ -21023, 5, 11013, 5, 313, 3124, 0},{ 15234, 5, 1013, -210123, -1513, 5, 0},{ 314, 21024, 0, 324, 0, -2524, 0},{ 0, -215234, 2513, 5, 313, 151234, 312},{ 0, 5, 0, 0, 0, 324, 2524},{ 313, -15134, 5, 313, 313, -25134, 5}};
    }
}