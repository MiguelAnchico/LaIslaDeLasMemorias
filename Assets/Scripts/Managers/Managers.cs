using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public List<Component> _managers = new List<Component>();

    public enum GameState { Splash, Configuration, Inicio, Experiencia, Victory, Fail }
    [SerializeField] GameState _gameState = GameState.Splash;
    public GameState gameState {
        get=>_gameState;
        set{
            _gameState = value;
            ChangeGameState();
        }
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);

        Component[] children = GetComponentsInChildren<Component>();
        foreach (Component child in children)
        {
            if (child is IManager manager)
            {
                _managers.Add((Component)manager);
            }
        }
    }

    private void Start()
    {
        //
    }
    public void SetGameState(int newGameState){
        gameState = (GameState)newGameState;
    }
    void ChangeGameState(){
        Debug.Log("GAME: Se cambió el estado de juego a: "+gameState);
        switch(gameState){
            case GameState.Configuration:
            Debug.Log("GAME: Se carga la escena de configuración, se activan los managers");
            SceneManager.LoadScene(1);
            
            break;
            default:
            break;
        }
    }
}