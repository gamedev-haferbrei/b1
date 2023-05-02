using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject stateGO;
    [SerializeField] GameObject roomsGO;

    Dictionary<string, Room> rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = new Dictionary<string, Room>();
        foreach (Room room in roomsGO.GetComponentsInChildren<Room>())
        {
            rooms.Add(nameof(room), room);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}