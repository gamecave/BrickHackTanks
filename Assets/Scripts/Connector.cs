using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] Player[] playerArr = new Player[4];
    [DllImport("__Internal")] private static extern string GetInput();

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs(GetInput());
    }

    void GetPlayerInputs(string json)
    {
        print($"getting player inputs: {json}");
        JsonArray arr = JsonUtility.FromJson<JsonArray>(json);
        foreach (var obj in arr.inputs)
        {
            ApplyMovement(obj.id, obj.vertical, obj.horizontal, obj.action); 
        }
    }

    void ApplyMovement(string id, int forward, int right, int action)
    {
        print($"applying movement with id{id}, vert{forward}, hori{right}, action{action}");
        Player player = new Player();
        for (int i = 0; i < playerArr.Length; i++)
        {
            if (id == playerArr[i].id)
            {
                player = playerArr[i];
                print(player);
            }
        }
        // Call a movement function from Player script to move that specific player.
        player.PlayerMovement(forward, right);
        if (action == 1)
        {
            print("Firing");
            player.Fire();
        }
    }

    void CreatePlayer(string id)
    {
        print("Create Player has been called!");

        foreach (var obj in playerArr)
        {
            if (obj.id == null)
            {
                obj.id = id;
                return;
            }
        }
    }

    public class JsonObject
    {
        public string id;
        public int horizontal;
        public int vertical;
        public int action;
    }

    public class JsonArray
    {
        public JsonObject[] inputs;
    }
}
