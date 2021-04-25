using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;


// disallowed chars: {}\",:

public class Leaderboard : MonoBehaviour
{
    public InputField _playername;
    public InputField _score;
    public GameObject _valueUIElements;
    public GameObject[] _rows;
    // public GameObject _rowPrefab;
    // use Application.persistentDataPath ?
    private string _filepath = "./Assets/escape-the-web/Data/Leaderboard.json";
    private int _rawScore;

    void Start()
    {
        // Save();
        _rawScore = (int)(GetComponent<ScoreManager>().GetScore());
        _score.text = "Your   Score: " + _rawScore.ToString();
        Render();
    }

    public void Save(string name)
    {
        string playername = _playername.text.Trim();
        if (playername.Length == 0) return;

        Debug.Log("Saving leaderboard...");
        Dictionary<string, int> currLeaderboard = Load();

        if (currLeaderboard.ContainsKey(playername))
        {
            currLeaderboard.Remove(playername);
        }
        currLeaderboard.Add(playername, _rawScore);

        System.IO.File.WriteAllText(_filepath, Serialize(currLeaderboard));
        Debug.Log("Saved leaderboard!");
        _valueUIElements.transform.Find("Name").gameObject.GetComponent<InputField>().interactable = false;
        // Destroy(_valueUIElements);
        Render();
    }

    Dictionary<string, int> Load()
    {
        using (StreamReader r = new StreamReader(_filepath))
        {
            string data = r.ReadToEnd();
            Dictionary<string, int> currLeaderboard = Deserialize(data);
            return currLeaderboard;
        }
    }

    Dictionary<string, int> Deserialize(string data)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string[] nameScores = data.Substring(1, data.Length - 2).Split(',');

        foreach (string nameScore in nameScores)
        {
            string[] ns = nameScore.Split(':');

            if (ns.Length == 1)
            {
                return dict;
            }

            try
            {
                dict.Add(ns[0].Replace('"', ' ').Trim(), Int32.Parse(ns[1].Replace('"', ' ').Trim()));
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{ns[1]}'");
            }
        }

        return dict;
    }

    string Serialize(Dictionary<string, int> dict)
    {
        string res = "";
        int i = 0;
        int sz = dict.Keys.Count;
        foreach (KeyValuePair<string, int> kvp in dict)
        {
            string playername = kvp.Key.Trim();
            string score = kvp.Value.ToString().Trim();
            res += "\"" + playername + "\"" + " : " + "\"" + score + "\"";
            if (i < sz - 1)
            {
                res += ",";
            }
            res += "\n";
            i++;
        }
        return "{\n" + res + "}";
    }
    void Render()
    {
        Transform display = transform.Find("Display");
        Dictionary<string, int> leaderboard = Load();
        GameObject row;


        int i = 0, MAX_SCORES = _rows.Length;
        foreach (KeyValuePair<string, int> kvp in leaderboard.OrderByDescending(key => key.Value))
        {
            string playername = kvp.Key.Trim();
            string score = kvp.Value.ToString().Trim();
            row = _rows[i];
            row.transform.Find("Col1").GetComponent<TMP_Text>().text = playername;
            row.transform.Find("Col2").GetComponent<TMP_Text>().text = score;
            row.transform.parent = display;
            i++;

            if (i >= MAX_SCORES) break;
        }
    }
}
