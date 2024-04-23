using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;



public class demo : MonoBehaviour
{

    
    [SerializeField] private GameObject prefab; 

   [SerializeField] GameObject TargetObj; 

    public float x =90;
    public float y =0;
    public float z =0;

    public SocketIOUnity socket;
    public string serverUrlLink = "http://localhost:3000";

    private void Start() {

        var uri = new Uri(serverUrlLink);       
        socket = new SocketIOUnity(uri); 

        // socket.OnConnected += (sender, e) => 
        // {
        //     Debug.Log("socket.OnConnected");
        //     socket.Emit("join", "player");

        // };

        // socket.On("GameState", response =>{
        //     print(response.GetValue<string>());
        //     if(response.GetValue<string>()=="Ready")
        //         socket.Emit("GetMyID");
        // });
        // socket.On("MyID", response =>{
        //     Debug.Log("MyID" + response.ToString());
        // });
        

        socket.Connect();

        //aGameObject newPlayer=Instantiate(prefab,this.transform);
    }

        void OnDestroy()
        {
        socket.Disconnect();
        Debug.Log("destroy connection");
        }

        


    private void Update() {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      socket.EmitAsync("message", "Hello, server!"); 
      // replace with your message
    }
        // Vector3 target =TargetObj.transform.position;
        // Vector3 hedefYon = target - transform.position;
        // transform.rotation = Quaternion.LookRotation(new Vector3(hedefYon.x+x,hedefYon.y+y,hedefYon.z+z));

    //Vector3 hedefYon = TargetObj.transform.position - transform.position;
    
    //Quaternion hedefRotasyon = Quaternion.LookRotation(hedefYon);

       
    // x, y ve z değerlerini kullanarak dönüş rotasyonunu oluşturun
 
    // Hedefe bakma rotasyonunu hesaplayın

    // Dönüş rotasyonu ile hedef rotasyonunu birleştirin
    //hedefRotasyon =hedefRotasyon* Quaternion.Euler(90, 0, 0);

 
    // Roketi bu son rotasyon ile döndürün
   // transform.rotation = hedefRotasyon; 
    }



}
