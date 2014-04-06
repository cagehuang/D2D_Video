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

            Console.SetWindowSize(80, 51);

            System.Diagnostics.Stopwatch stoptime = new System.Diagnostics.Stopwatch();////程式計時，引用stopwatch物件
            stoptime.Reset();//碼表歸零
            stoptime.Start();//碼表開始計時

            //StreamWriter sw = new StreamWriter("d:\\MS_simulation.txt"); //輸出成檔案
            //String result;

            int RUNTIME = 1 ; //程式執行次數
            int UE_NUMBER = 10; //UE的個數
            int VIDEO_NUMBER = 3; //影片的個數


            //**程式執行次數
            for (int runtime; runtime <= RUNTIME; runtime++) { 
                //**部屬環境 (撒點、計算MCS、Conflict Graph...)


                //**沒有設計的排法


                //**提出的新排法


                //**紀錄每次結果
            

            }

            Console.ReadLine();

        }
    }
}
