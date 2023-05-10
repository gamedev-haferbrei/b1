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
    [SerializeField] GameObject charactersGO;
    [SerializeField] GameObject choicePrefab;

    Dictionary<string, Room> rooms;
    Room lastRoom;
    Room currentRoom;
    TextMeshProUGUI description;
    Characters characters;

    public void SetRoom(string room)
    {
        lastRoom = currentRoom;
        currentRoom = rooms[room];
    }

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
        characters = charactersGO.GetComponent<Characters>();

        Redraw();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Redraw()
    {
        characters.UndrawAll();
        description.text = currentRoom.GetDescription(lastRoom == null ? "" : lastRoom.GetType().Name);
        currentRoom.Draw();

        while (choicesGO.transform.childCount > 0) DestroyImmediate(choicesGO.transform.GetChild(0).gameObject);

        int i = 1;
        foreach ((string label, System.Func<string> action) in currentRoom.GetChoices())
        {
            GameObject choiceGO = Instantiate(choicePrefab, choicesGO.transform);
            Choice choice = choiceGO.GetComponent<Choice>();
            choice.Initialize(this, i, label, action);
            i++;
        }
    }
}