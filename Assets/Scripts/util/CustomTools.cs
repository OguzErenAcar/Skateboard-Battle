using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomTool
{
   public class CustomTools : MonoBehaviour
{

    private float Timertime=0;

    public delegate void MyTimerDelegate(); // Örnek bir delegat tanımladık

      public void Alarm(float time,MyTimerDelegate myDelegate)
      {
        Timertime+=Time.deltaTime;
        if(Timertime>=time){
          Timertime=0f;
          myDelegate(); // Delegeyi çalıştır
        }
      }
       public IEnumerator AlarmbyCoroutine(float time,MyTimerDelegate myDelegate)
      {
          yield return new WaitForSeconds(time); 
          myDelegate(); // Delegeyi çalıştır
        
      }
} 
}

