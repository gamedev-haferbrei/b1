using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject gameGroupGO;
    [SerializeField] GameObject menuGroupGO;

    [SerializeField] GameObject stateGO;
    [SerializeField] GameObject roomsGO;
    [SerializeField] GameObject descriptionGO;
    [SerializeField] GameObject choicesGO;
    [SerializeField] GameObject charactersGO;
    [SerializeField] GameObject backgroundGO;

    [SerializeField] GameObject choicePrefab;

    [SerializeField] GameObject audioGO;
    AudioManager audioManager;

    [SerializeField] GameObject options;
    [SerializeField] GameObject optionsButton;
    [SerializeField] GameObject walkthrough;
    [SerializeField] GameObject skyrim;

    Dictionary<string, Room> rooms;
    Room lastRoom;
    Room currentRoom;
    TextMeshProUGUI description;
    Characters characters;
    Image background;

    public bool isOptions = false;
    public bool isWalkthrough = false;

    public void SetRoom(string room)
    {
        lastRoom = currentRoom;
        currentRoom = rooms[room];
    }

    // Start is called before the first frame update
    void Start()
    {
        gameGroupGO.SetActive(false);
        menuGroupGO.SetActive(true);
        skyrim.SetActive(false);

        rooms = new Dictionary<string, Room>();
        foreach (Room room in roomsGO.GetComponentsInChildren<Room>())
        {
            rooms.Add(room.GetType().Name, room);
        }

        description = descriptionGO.GetComponent<TextMeshProUGUI>();
        characters = charactersGO.GetComponent<Characters>();
        background = backgroundGO.GetComponent<Image>();
        audioManager = audioGO.GetComponent<AudioManager>();
    }

    public void StartGame()
    {
        currentRoom = rooms[nameof(Entrance)];
        gameGroupGO.SetActive(true);
        menuGroupGO.SetActive(false);
        options.SetActive(false);
        walkthrough.SetActive(false);

        StartCoroutine(nameof(RedrawAfterOneFrame));
    }

    public IEnumerator RedrawAfterOneFrame()
    {
        yield return null;
        Redraw();
    }

    public void ReturnToMenu()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void Skyrim()
    {
        skyrim.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Redraw()
    {

        audioManager.PlayAudio();
        characters.UndrawAll();
        description.text = currentRoom.GetDescription(lastRoom == null ? "" : lastRoom.GetType().Name);
        currentRoom.Draw();
        background.sprite = currentRoom.background;
        audioManager.PlayBackground(currentRoom.audioClip);


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

    public void ToggleOptions()
    {
        isOptions = !isOptions;
        options.SetActive(isOptions);
    }
    public void ToggleWalkthrough()
    {
        isWalkthrough = !isWalkthrough;
        walkthrough.SetActive(isWalkthrough);
    }
}