using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject stateGO;
    [SerializeField] GameObject roomsGO;
    [SerializeField] GameObject descriptionGO;
    [SerializeField] GameObject choicesGO;
    [SerializeField] GameObject choicePrefab;

    Dictionary<string, Room> rooms;
    Room currentRoom;
    TextMeshProUGUI description;

    // Start is called before the first frame update
    void Start()
    {
        rooms = new Dictionary<string, Room>();
        foreach (Room room in roomsGO.GetComponentsInChildren<Room>())
        {
            rooms.Add(room.GetType().Name, room);
        }

        currentRoom = rooms[nameof(Entrance)];

        description = descriptionGO.GetComponent<TextMeshProUGUI>();

        Redraw();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Redraw()
    {
        currentRoom.Draw();

        description.text = currentRoom.GetDescription();

        while (choicesGO.transform.childCount > 0) DestroyImmediate(choicesGO.transform.GetChild(0).gameObject);

        int i = 1;
        foreach ((string label, UnityAction action) in currentRoom.GetChoices())
        {
            GameObject choiceGO = Instantiate(choicePrefab, choicesGO.transform);
            Choice choice = choiceGO.GetComponent<Choice>();
            choice.Initialize(this, i, label, action);
            i++;
        }
    }
}