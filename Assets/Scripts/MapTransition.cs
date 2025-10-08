using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoudry;
    [SerializeField] Direction direction;
    CinemachineConfiner2D confiner;
    [SerializeField] float addNum = 2;

    enum Direction { Up, Down, Left, Right}

    public void Awake()
    {
        confiner = FindAnyObjectByType <CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        confiner.BoundingShape2D = mapBoudry;
    }

    public void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up: newPos.y += addNum; break;
            case Direction.Down: newPos.y -= addNum; break;
            case Direction.Left: newPos.x += addNum; break;
            case Direction.Right: newPos.x -= addNum; break;
        }
    }

}
