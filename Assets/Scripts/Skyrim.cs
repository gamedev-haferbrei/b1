using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Skyrim : MonoBehaviour
{
    public float duration;

    [SerializeField] protected GameObject stateGO;
    protected GameState state;
    [SerializeField] protected GameObject mainGO;
    protected Main main;
    [SerializeField] GameObject audioGO;
    AudioManager audioManager;
    [SerializeField] AudioClip audioClip;

    [SerializeField] private Sprite[] sprites;
    

    private Image image;
    private int index = 0;
    private float timer = 0;

    void Start()
    {
        image = GetComponent<Image>();
        state = stateGO.GetComponent<GameState>();
        audioManager = audioGO.GetComponent<AudioManager>();
        audioManager.PlayBackground(audioClip);
    }
    private void Update()
    {
        if (this.isActiveAndEnabled)
        {
            if ((timer += Time.deltaTime) >= (duration / sprites.Length))
            {
                timer = 0;
                image.sprite = sprites[index];
                index = (index + 1) % sprites.Length;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            state.main.ReturnToMenu();
        }
    }
}