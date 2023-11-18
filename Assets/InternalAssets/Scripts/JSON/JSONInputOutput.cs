using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class JSONInputOutput<T> where T : Savable
{
    private const string _jsonFormat = @".json";
    private readonly string _jsonDataPath = Application.streamingAssetsPath + @"\";

    public bool HasData()
    {
        return File.Exists($"{_jsonDataPath}{typeof(T).Name}{_jsonFormat}");
    }

    public void Write(T data)
    {
        string output = JsonConvert.SerializeObject(data);
        File.WriteAllText($"{_jsonDataPath}{typeof(T).Name}{_jsonFormat}", output);
    }

    public T Read()
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText($"{_jsonDataPath}{typeof(T).Name}{_jsonFormat}"));
    }
}
