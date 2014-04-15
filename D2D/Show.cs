using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2D
{
    class Show
    {
        public void eNodeB_State(UE[] UES)
        {
            Console.WriteLine("eNodeB： X_AXIS = " + UES[0].X_AXIS +
                    ", Y_AXIS = " + UES[0].Y_AXIS + ", Radius = " + UES[0].eNodeB_Radius);
            Console.WriteLine();
        }
        
        public void UEs_State(int UE_NUMBER, UE[] UES)
        {
            for (int UE_Number = 1; UE_Number <= UE_NUMBER; UE_Number++) 
            {
                Console.WriteLine("UE " + UES[UE_Number].UID + "  ：" + "X_AXIS = " + UES[UE_Number].X_AXIS 
                    + ", Y_AXIS = " + UES[UE_Number].Y_AXIS 
                    + ", Distance_between_eNodeB = " + UES[UE_Number].Distance_between_eNodeB
                    + ", MCS_level = " + UES[UE_Number].MCS_Level
                    + ", Remaining_Playback_Time = " + UES[UE_Number].Remaining_Playback_Time);
            }
            Console.WriteLine();
        }
    }
}
