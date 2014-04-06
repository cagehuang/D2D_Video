using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace D2D
{
    class Program
    {
        static void Main(string[] args)
        {
            //**設定執行環境

            Console.SetWindowSize(150, 46);

            System.Diagnostics.Stopwatch stoptime = new System.Diagnostics.Stopwatch();////程式計時，引用stopwatch物件
            stoptime.Reset();//碼表歸零
            stoptime.Start();//碼表開始計時

            //StreamWriter sw = new StreamWriter("d:\\MS_simulation.txt"); //輸出成檔案
            //String result;

            int RUNTIME = 1 ; //程式執行次數
            int UE_NUMBER = 3; //UE的個數
            int VIDEO_NUMBER = 3; //影片的個數

            Show SHOW = new Show();


            //**程式執行次數
            for (int runtime=0; runtime <= RUNTIME; runtime++) { 
                
                //**部屬環境 (撒點、計算MCS、Conflict Graph...)
                
                //***部屬eNodeB & UE
                UE[] UEs = new UE[UE_NUMBER + 1];//UE_Number +1 是因為要把eNodeB也算進去

                //部屬eNodeB
                UEs[0] = new UE();
                UEs[0].UID = 0;
                UEs[0].Set_eNodeB();

                //部屬UEs
                for (int UE_Number_Count = 1; UE_Number_Count < UE_NUMBER + 1; UE_Number_Count++){ //UE_NUMBER + 1是因為要算進eNodeB
                    UEs[UE_Number_Count] = new UE(UE_Number_Count, UEs);
                    UEs[UE_Number_Count].UID = UE_Number_Count;
                    UEs[UE_Number_Count].Set_UE();
                }

                SHOW.eNodeB_State(UEs);
                SHOW.UEs_State(UE_NUMBER, UEs);

                

                //**沒有設計的排法


                //**提出的新排法


                //**紀錄每次結果
            

            }

            Console.ReadLine();

        }
    }
}
