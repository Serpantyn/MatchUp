using MatchUp.Utilities;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatchUp.Model
{
    public class SaveData
    {
        private static readonly string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        private static readonly string FilePath = Path.Combine(DirectoryPath, "saved_data.json");

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("AmountOfCards")]
        public int AmountOfCards { get; set; }

        [JsonPropertyName("AmountOfAttempts")]
        public int AmountOfAttempts { get; set; }

        [JsonPropertyName("Time")]
        public string Time { get; set; }

        public SaveData() { }

        public SaveData(string name, DateTime date, int amountOfCards, int amountOfAttempts, string time)
        {
            Name = name;
            Date = date;
            AmountOfCards = amountOfCards;
            AmountOfAttempts = amountOfAttempts;
            Time = time;
        }

        public static List<SaveData> Load()
        {
            try
            {
                if (!File.Exists(FilePath) || new FileInfo(FilePath).Length <= 3)
                {
                    return new List<SaveData>();
                }

                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<SaveData>>(json) ?? new List<SaveData>();
            }
            catch(Exception ex)
            {
                ErrorHandling.LogError(ex);
                return new List<SaveData>();
            }
            
        }

        public static void Save(List<SaveData> saveDataList)
        {
            try
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                string json = JsonSerializer.Serialize(saveDataList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                ErrorHandling.LogError(ex);
                return;
            }
        }

        public static void AddNew(List<SaveData> newSaveData)
        {
            try
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                List<SaveData> existingData = Load();
                existingData.AddRange(newSaveData);

                string json = JsonSerializer.Serialize(existingData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                ErrorHandling.LogError(ex);
            }
        }
    }
}
