using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save 
{
   static int numEnemies = 0;

   public static void SavePlayer(PlayerController player){
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/player.txt";
      FileStream stream = new FileStream (path, FileMode.Create);
      
      PlayerData data = new PlayerData(player);
      formatter.Serialize(stream, data);

      SaveEnemies(formatter, stream);

      stream.Close();


   }

   public static PlayerData LoadPlayer(){
      string path = Application.persistentDataPath+ "/player.txt";

      if (File.Exists(path)){
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         PlayerData data = formatter.Deserialize(stream) as PlayerData;
         LoadEnemies();
         stream.Close();
         
         return data;
      }else{
         Debug.LogError("Save file not found in " + path);
         return null;
      }
   }

   private static void SaveEnemies(BinaryFormatter formatter, FileStream stream){
      GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
      numEnemies = enemies.Length;
      for(int i = 0; i < enemies.Length; i++){
         string path = Application.persistentDataPath + "/enemy"+(i+1)+".txt";
         stream = new FileStream (path, FileMode.Create);
         EnemySave data = new EnemySave(enemies[i]);
         formatter.Serialize(stream,data);
         
      }
      stream.Close();

   }

   public static EnemySave[] LoadEnemies(){
      EnemySave[] enemies = new EnemySave[numEnemies]; 

      for(int i = 0; i < numEnemies; i++){
       string path = Application.persistentDataPath+ "/enemy"+(i+1)+".txt";

         if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            EnemySave data = formatter.Deserialize(stream) as EnemySave;
            enemies[i] = data;
            stream.Close();
         }else{
            Debug.LogError("Save file not found in " + path);
            return null;
         }
      }
      return enemies;

   }
   
}
