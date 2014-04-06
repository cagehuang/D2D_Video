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
        public int MCS = -1;            //速率 (bits / slot)
        public double eNodeB_Radius = -1;    //eNodeB的覆蓋半徑

        public UE()
        {

        }

        public UE(int UE_Number, UE[] UEs) {
            
            //確保UE是在eNodeB的覆蓋範圍內，座標不可以落在正方形減去圓形的位置
            double tmp_eNodeB_distance = -1; //UE與eNodeB之間的距離
            
            do{
                X_AXIS = 2 * random.Next(Convert.ToInt16(UEs[0].eNodeB_Radius)); //最長不超過BS的直徑
                Y_AXIS = 2 * random.Next(Convert.ToInt16(UEs[0].eNodeB_Radius));

                tmp_eNodeB_distance = Math.Sqrt(Math.Pow((X_AXIS - UEs[0].X_AXIS), 2) + Math.Pow((Y_AXIS - UEs[0].Y_AXIS), 2));
            } while (UEs[0].eNodeB_Radius < tmp_eNodeB_distance);
        }

        public void Set_eNodeB() {      //設定eNodeB   
            this.eNodeB_Radius = Convert.ToInt16(MCS_Calculate.Radius(0, 6)); //eNodeB的半徑，單位m;
            this.X_AXIS = Convert.ToInt16(this.eNodeB_Radius);
            this.Y_AXIS = Convert.ToInt16(this.eNodeB_Radius);
        }

    }
}
