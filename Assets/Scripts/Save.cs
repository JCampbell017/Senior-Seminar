using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save 
{
   public static void SavePlayer(PlayerController player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
    FileStream stream = new FileStream (path, FileMode.Create);
    PlayerDate data = new PlayerData(player);
    formatter.Serialize(stream, data);



   }
}
