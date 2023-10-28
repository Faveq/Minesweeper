using Minesweeper.Models;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Minesweeper.Appdata
{
    public class AppData
    {
        public static void SaveData(GameBoardSizeModel gameBoardSizeModel)
        {
            if (gameBoardSizeModel != null)
            {
                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string folderPath = Path.Combine(appDataFolder, "Minesweeper");
                string filePath = Path.Combine(folderPath, "data.json");

                // Zapisz obiekt do pliku w formacie JSON
                string jsonData = JsonSerializer.Serialize(gameBoardSizeModel);
                File.WriteAllText(filePath, jsonData);
            }
        }

        public GameBoardSizeModel ReadSavedData()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(appDataFolder, "Minesweeper");
            string filePath = Path.Combine(folderPath, "data.json");

            GameBoardSizeModel gameBoardSizeModel;


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string jsonData = File.ReadAllText(filePath);

            if (!string.IsNullOrEmpty(jsonData))
            {
                gameBoardSizeModel = JsonSerializer.Deserialize<GameBoardSizeModel>(jsonData);
                return gameBoardSizeModel;
            }
            else
            {
                return new GameBoardSizeModel(8,8,10);
            }

            
        }
    }
}
