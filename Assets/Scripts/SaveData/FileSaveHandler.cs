using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

// Load/Save game data from/to file
// Path to saved file on PC will be: C:\Users\yourusername\AppData\LocalLow\Unity6Examples\Unity 6 Samples\ (See console)

public class FileSaveHandler
{
    private bool _isHashed = false; // make this true to hash the file contents
    private string _dirPath;
    private string _fullPath;
    private string _hash = "4926#1968!4865$8230%"; //hash key
    
    public FileSaveHandler(string dirPath)
    {        
        this._dirPath = dirPath;
    }

    //Load main game data from file
    public SO_Game LoadGameData(SO_Game loadData, string fileName)
    {
        _fullPath = Path.Combine(_dirPath, fileName);
        if (File.Exists(_fullPath))
        {
            try
            {
                string dataToLoad = null;
                using (FileStream fileStream = new FileStream(_fullPath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        if (_isHashed)
                        {
                            dataToLoad = PixelData(streamReader.ReadToEnd());
                        }
                        else
                        {
                            dataToLoad = streamReader.ReadToEnd();
                        }
                    }
                }
                loadData = JsonConvert.DeserializeObject<SO_Game>(dataToLoad);
                Debug.Log("Game Data Loaded");
            }
            catch (Exception ex)
            {
                Debug.LogError("Error loading save file: " + _fullPath + "\n" + ex);
            }
        }
        
        return loadData;
    }

    //Save main game data to file
    public void SaveGameData(SO_Game saveData, string fileName)
    {
        _fullPath = Path.Combine(_dirPath, fileName);
        try
        {
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_fullPath));
            }
            string dataToSave = JsonConvert.SerializeObject(saveData, Newtonsoft.Json.Formatting.Indented);
            if (_isHashed)
            {
                dataToSave = PixelData(dataToSave);
            }
            using (FileStream fileStream = new FileStream(_fullPath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(dataToSave);
                }
            }
            Debug.Log("Game Data Saved to: " + _fullPath);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error writing save file: " + _fullPath + "\n" + ex);
        }
    }

    //Hash the file
    private string PixelData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ _hash[i % _hash.Length]);
        }
        return result;
    }
}
