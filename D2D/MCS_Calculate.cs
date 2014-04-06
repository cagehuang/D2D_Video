using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2D
{
    class MCS_Calculate
    {
        public static int SINR_Cal(int BS_RS, double distance) //計算SINR，前參數代表算的是BS還是RS，0為BS，不是則為RS
        {
            //前導公式
            //dBm = 10*log10(mW)
            //mw=10^(dBm/10)

            double SINR;
            double P_Receiver = 0.0;
            const double Bandwidth = 10000000; //10MHz

            double N0 = 1.38 * Math.Pow(10, -20) * 300; //-120dBm -> mW，10的負20次方，不懂

            const double Interence = 0; //T表示會干擾不能用，F代0，所以加總後還是0

            const double Gi = 1; //都代1
            const double Gj = 1; //都代1

            double P_Transmit = (BS_RS == 0 ? 20000 : 10000); //20000mw，20W  BS帶20W，RS帶10W

            double Pass_Loss = 0.0;

            double A = 0.0;
            const double r = (4.6 - 0.0075 * 30 + 12.6 / 30); // r = (a - b*hb + c/hb);

            const double d0 = 100; //100m
            double Distance = distance; //跟RS或BS的距離，單位m
            const double Shadowing_effect = 8.2;  //8.2 ~ 10.6 dB

            const double Lambda = 0.12; //0.12m，2.5GHz = (3 * (10^8) / Lamba) => Lamba = 0.12

            A = 20 * Math.Log10(4 * Math.PI * d0 / Lambda);

            double PLf = 6 * Math.Log10((2.5 * 1000) / 2000);
            double PLh = -10.8 * Math.Log10(2 / 2);

            Pass_Loss = Math.Pow(10, (A + (10 * r) * Math.Log10(Distance / d0) + Shadowing_effect + PLf + PLh) / 10); //單位，dBm

            P_Receiver = ((Gi * Gj * P_Transmit) / Pass_Loss); //單位，mW

            SINR = Math.Ceiling(10 * Math.Log10((P_Receiver / (Bandwidth * N0 + Interence)))); //單位，dBm


            //比較出適合哪個MCS Level
            double[] SINR_Threshold = { 6, 8.5, 11.5, 15, 19, 21 };
            int MCS_Level = 0;

            for (int a = 0; a < 6; a++)
            {
                if (SINR >= SINR_Threshold[a])
                {
                    MCS_Level++;
                }
                else
                    break;
            }

            switch (MCS_Level)
            {
                case 1:
                    return 48;
                case 2:
                    return 72;
                case 3:
                    return 96;
                case 4:
                    return 144;
                case 5:
                    return 192;
                case 6:
                    return 216;
                default:
                    return -1;
            }
            //return data carried by a slot (bits)
        }

        public static double Radius(int BS_RS, double min_dBm) //計算半徑，前參數代表算的是BS還是RS，0為BS，不是則為RS
        {
            double SINR = min_dBm;
            const double Bandwidth = 10000000; //10MHz

            double N0 = 1.38 * Math.Pow(10, -20) * 300; //-120dBm -> mW

            const double Interence = 0; //T表示會干擾不能用，F代0，所以加總後還是0

            double P_Receiver = Math.Pow(10, (SINR / 10)) * (Bandwidth * N0 + Interence); //mW

            const double Gi = 1; //都代1
            const double Gj = 1; //都代1
            double P_Transmit = (BS_RS == 0 ? 20000 : 10000); //BS帶20W，RS帶10W

            double Pass_Loss = ((Gi * Gj * P_Transmit) / P_Receiver); //mW

            //Pass_Loss = 10 * Math.Log10(Pass_Loss);

            const double Shadowing_effect = 8.2;  //8.2 ~ 10.6 dB
            const double d0 = 100; //100m
            const double Lambda = 0.12; //0.12m
            double A = 20 * Math.Log10(4 * Math.PI * d0 / Lambda);
            double r = (4.6 - 0.0075 * (BS_RS == 0 ? 30 : 10) + 12.6 / (BS_RS == 0 ? 30 : 10)); // r = (a - b*hb + c/hb)，BS的hb為30m，RS的hb為10m;

            double PLf = 6 * Math.Log10((2.5 * 1000) / 2000);
            double PLh = -10.8 * Math.Log10(2 / 2);

            double Radius = Math.Pow(10, ((10 * Math.Log10(Pass_Loss) - Shadowing_effect - A - PLf - PLh) / (10 * r))) * d0;

            return Radius; //半徑長度，單位m
        }
    }
}
