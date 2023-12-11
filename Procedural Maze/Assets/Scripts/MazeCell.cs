using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum WallState
{
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8,
    VISITED = 128
}
public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;
    [SerializeField]
    private GameObject _rightWall;
    [SerializeField]
    private GameObject _upWall;
    [SerializeField]
    private GameObject _downWall;
    [SerializeField]
    private GameObject _visitedBlock;

    public WallState State {get; private set;}

    private void Awake()
    {
        //Default
        State = WallState.LEFT | WallState.RIGHT | WallState.UP | WallState.DOWN;
    }

    public void Visit()
    {
        State |= WallState.VISITED;
        _visitedBlock.SetActive(false);
    }

    public void ClearWall(WallState wall)
    {
        State &= ~wall;

        //Disable Corresponding Wall
        switch (wall)
        {
            case WallState.LEFT:
                _leftWall.SetActive(false);
                break;
            case WallState.RIGHT:
                _rightWall.SetActive(false);
                break;
            case WallState.UP:
                _upWall.SetActive(false);
                break;
            case WallState.DOWN:
                _downWall.SetActive(false);
                break;
        }
    }
}
