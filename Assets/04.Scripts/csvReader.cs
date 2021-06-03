using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData
{
    public int ID;
    public string Name;
    public int Hp;
    public int Atk;
    public int Def;
    public float AtkSpeed;
    public float AtkRange;
    public float Speed;
    public string PrefabName;
}

public class csvReader : MonoBehaviour
{
    public static Dictionary<TKey, TData> LoadData<TKey, TData>(string filePath) where TData : class, new()
    {
        Dictionary<TKey, TData> result = new Dictionary<TKey, TData>();

        TextAsset tableData = Resources.Load(filePath) as TextAsset;

        var readLine = tableData.text.Split('\n');

        if (readLine.Length <= 1) return result;

        var header = readLine[0].Split(',');

        System.Type type = typeof(TData);
        System.Reflection.FieldInfo[] arrayFieldInfo = type.GetFields();

        
        for (int i = 1; i < readLine.Length; i++)
        {
            TData newData = new TData();

            var words = readLine[i].Split(',');
            if (words.Length == 0 || words[0] == "") continue;

            object key = null;
            for (int j = 0; j < header.Length && j < words.Length; j++)
            {
                string word = words[j];

                object finalValue = word;
                int n;
                float f;
                if (int.TryParse(word, out n))
                    finalValue = n;
                else if (float.TryParse(word, out f))
                    finalValue = f;

                if (key == null)
                    key = finalValue;

                arrayFieldInfo[j].SetValue(newData, finalValue);
            }

            result.Add((TKey)key, newData);
        }

        return result;
    }

    //public static Dictionary<string, MonsterData> LoadData(string filePath)
    //{
    //    Dictionary<string, MonsterData> list = new Dictionary<string, MonsterData>();

    //    TextAsset tableData = Resources.Load(filePath) as TextAsset;

    //    var readLine = tableData.text.Split('\n');

    //    if (readLine.Length <= 1) return list;

    //    var header = readLine[0].Split(',');

    //    MonsterData temp = new MonsterData();
    //    for (int i = 1; i < readLine.Length - 1; i++)
    //    {
    //        var words = readLine[i].Split(',');
    //        if (words.Length == 0 || words[0] == "") continue;

    //        for (int j = 0; j < header.Length && j < words.Length; j++)
    //        {
    //            string word = words[j];

    //            object finalValue = word;
    //            int n;
    //            float f;
    //            if (int.TryParse(word, out n))
    //                finalValue = n;
    //            else if (float.TryParse(word, out f))
    //                finalValue = f;
    //        }
    //    }

    //    return list;
    //}

    //public static List<Dictionary<string, object>> ReadFile(string fileName)
    //{
    //    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
    //    TextAsset data = Resources.Load(fileName) as TextAsset;
        
    //    var readLine = data.text.Split('\n');

    //    if (readLine.Length <= 1) return list;

    //    var header = readLine[0].Split(',');
    //    for (int i = 1; i < readLine.Length; i++)
    //    {
    //        var words = readLine[i].Split(',');
    //        if (words.Length == 0 || words[0] == "") continue;
            
    //        Dictionary<string, object> dic = new Dictionary<string, object>();
    //        for (int j = 0; j < header.Length && j < words.Length; j++)
    //        {
    //            string word = words[j];

    //            object finalValue = word;
    //            int n;
    //            float f;
    //            if (int.TryParse(word, out n))
    //                finalValue = n;
    //            else if (float.TryParse(word, out f))
    //                finalValue = f;
    //            dic[header[j]] = finalValue;
    //        }
    //        list.Add(dic);
    //    }
        
    //    return list;
    //}
}
