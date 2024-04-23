using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardMovePlayer : SkateboardMove
{
    // set web input 


    new
    void Start()
    {
     base.Start();
     HorizontalInput=Input.GetAxis("Horizontal");
     ForwardInput=Input.GetAxis("Vertical"); 
    }

    // Update is called once per frame
    new 
    void Update()
    {
        base.Update();
        SocketManager.socket.Emit("SetMove",HorizontalInput,ForwardInput);

        
    }
}
