using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SO_Game _gameData; //Players game data stored in a ScriptableObject

    private FileSaveHandler _fileSaveHandler;  

    void Start()
    {
        _fileSaveHandler = new FileSaveHandler(Application.persistentDataPath);

        //Save data to file
        _gameData.Coins = 1000;
        _gameData.Health = 100;
        _fileSaveHandler.SaveGameData(_gameData, "GameData");

        //Load data from disk
        _gameData = _fileSaveHandler.LoadGameData(_gameData, "GameData");
        print("Player has " + _gameData.Coins + " coins.");
        print("Player has " + _gameData.Health + " health.");
    }
}
