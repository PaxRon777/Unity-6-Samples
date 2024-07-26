using UnityEngine;

//Game manager that saves and loads player data from a ScriptableObject

public class GameManager : MonoBehaviour
{
    [SerializeField] private SO_Game _gameData; //ScriptableObject of the players data

    private FileSaveHandler _fileSaveHandler;  

    void Start()
    {
        _fileSaveHandler = new FileSaveHandler(Application.persistentDataPath);

        //Save data to file
        _gameData.Coins = 1000;
        _gameData.Health = 100;
        _fileSaveHandler.SaveGameData(_gameData, "GameData"); //Save

        //Load data from disk
        _gameData = _fileSaveHandler.LoadGameData(_gameData, "GameData"); //Load
        print("Player has " + _gameData.Coins + " coins.");
        print("Player has " + _gameData.Health + " health.");
    }
}
