using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2D
{
    class UE
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());   //實作random
        public int UID = -1;            //UE的編號
        public int X_AXIS = -1;         //X軸座標
        public int Y_AXIS = -1;         //Y軸座標
        public int MCS_Level = -1;            //速率 (bits / slot)
        public int eNodeB_Radius = -1;    //eNodeB的覆蓋半徑
        public int Distance_between_eNodeB = -1;
        public int Practical_Trans_Segment = -1;    //實際傳輸的Segment ; KB
        public int Practical_Trans_Time = -1;       //實際傳輸Segment所需的時間 ; ms

        public int Watching_Video = -1;             //希望看的Video ID
        public int Watching_StartTime = -1;         //開始看的時間
        public int Finish_Time = -1;                //Segment都載完的時間

        public int Remaining_Playback_Time = -1;    //剩餘可撥放的時間 (以完全還沒開始撥的segment計算)


        public UE()
        {

        }

        public UE(int UE_Number, UE[] UEs) 
        {           
            //確保UE是在eNodeB的覆蓋範圍內，座標不可以落在正方形減去圓形的位置
            double tmp_eNodeB_distance = -1; //UE與eNodeB之間的距離
            
            do{
                X_AXIS = 2 * random.Next(Convert.ToInt16(UEs[0].eNodeB_Radius)); //最長不超過BS的直徑
                Y_AXIS = 2 * random.Next(Convert.ToInt16(UEs[0].eNodeB_Radius));

                tmp_eNodeB_distance = Math.Sqrt(Math.Pow((X_AXIS - UEs[0].X_AXIS), 2) + Math.Pow((Y_AXIS - UEs[0].Y_AXIS), 2));
            } while (UEs[0].eNodeB_Radius < tmp_eNodeB_distance);

            this.Distance_between_eNodeB = Convert.ToInt16(tmp_eNodeB_distance);
        }

        public void Set_eNodeB() 
        {   
            //設定eNodeB   
            this.eNodeB_Radius = Convert.ToInt16(MCS_Calculate.Radius(0, 6)); //eNodeB的半徑，單位m;
            this.X_AXIS = Convert.ToInt16(this.eNodeB_Radius);
            this.Y_AXIS = Convert.ToInt16(this.eNodeB_Radius);
        }

        public void Set_UE(int Video_Number, int User_Start_Watching_Range)
        {   
            //設定UE
            this.MCS_Level = Convert.ToInt16(MCS_Calculate.DataRate_Cal(0, this.Distance_between_eNodeB));

            //設定想要看的影片以及觀看時間
            Watching_Video = (random.Next(Video_Number) + 1);                              //Random只會取"小於"()的值，有可能為0，故+1
            Watching_StartTime = (random.Next(User_Start_Watching_Range) + 1);             //Random希望使用者開始看的時間
            Remaining_Playback_Time = 0;
        }

    }
}
