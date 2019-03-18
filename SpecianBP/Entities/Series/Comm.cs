using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Comm : SeriesEntity
    {
        public DateTime TimeLocal { get; set; }

        //originalName = Comm_ETH_TX Message_C
        public int Comm_ETH_TX_Message_C { get; set; }

        //originalName = Comm_ETH_TX Data_C
        public float Comm_ETH_TX_Data_C { get; set; }

        //originalName = Comm_ETH_SYN WEB_C
        public int Comm_ETH_SYN_WEB_C { get; set; }

        //originalName = Comm_ETH_SYN RCV_C
        public int Comm_ETH_SYN_RCV_C { get; set; }

        //originalName = Comm_ETH_SYN MODBUS_C
        public int Comm_ETH_SYN_MODBUS_C { get; set; }

        //originalName = Comm_ETH_SYN KMB_C
        public int Comm_ETH_SYN_KMB_C { get; set; }

        //originalName = Comm_ETH_SYN ES_C
        public int Comm_ETH_SYN_ES_C { get; set; }

        //originalName = Comm_ETH_RX M. WEB_C
        public int Comm_ETH_RX_M__WEB_C { get; set; }

        //originalName = Comm_ETH_RX M. MODBUS_C
        public int Comm_ETH_RX_M__MODBUS_C { get; set; }

        //originalName = Comm_ETH_RX M. KMB_C
        public int Comm_ETH_RX_M__KMB_C { get; set; }

        //originalName = Comm_ETH_RX M. ES_C
        public int Comm_ETH_RX_M__ES_C { get; set; }

        //originalName = Comm_ETH_RX M. ALL_C
        public int Comm_ETH_RX_M__ALL_C { get; set; }

        //originalName = Comm_ETH_Open Sockets(min)_C
        public byte Comm_ETH_Open_Sockets_min__C { get; set; }

        //originalName = Comm_ETH CH_Time 4_C
        public DateTime Comm_ETH_CH_Time_4_C { get; set; }

        //originalName = Comm_ETH CH_Time 3_C
        public DateTime Comm_ETH_CH_Time_3_C { get; set; }

        //originalName = Comm_ETH CH_Time 2_C
        public DateTime Comm_ETH_CH_Time_2_C { get; set; }

        //originalName = Comm_ETH CH_Time 1_C
        public DateTime Comm_ETH_CH_Time_1_C { get; set; }

        //originalName = Comm_ETH CH_Time 0_C
        public DateTime Comm_ETH_CH_Time_0_C { get; set; }

        //originalName = Comm_ETH CH_Port 4_C
        public uint Comm_ETH_CH_Port_4_C { get; set; }

        //originalName = Comm_ETH CH_Port 3_C
        public uint Comm_ETH_CH_Port_3_C { get; set; }

        //originalName = Comm_ETH CH_Port 2_C
        public uint Comm_ETH_CH_Port_2_C { get; set; }

        //originalName = Comm_ETH CH_Port 1_C
        public uint Comm_ETH_CH_Port_1_C { get; set; }

        //originalName = Comm_ETH CH_Port 0_C
        public uint Comm_ETH_CH_Port_0_C { get; set; }

        //originalName = Comm_ETH CH_Locked 4_C
        public byte Comm_ETH_CH_Locked_4_C { get; set; }

        //originalName = Comm_ETH CH_Locked 3_C
        public byte Comm_ETH_CH_Locked_3_C { get; set; }

        //originalName = Comm_ETH CH_Locked 2_C
        public byte Comm_ETH_CH_Locked_2_C { get; set; }

        //originalName = Comm_ETH CH_Locked 1_C
        public byte Comm_ETH_CH_Locked_1_C { get; set; }

        //originalName = Comm_ETH CH_Locked 0_C
        public byte Comm_ETH_CH_Locked_0_C { get; set; }

        //originalName = Comm_ETH CH_IP 4_C
        public string Comm_ETH_CH_IP_4_C { get; set; }

        //originalName = Comm_ETH CH_IP 3_C
        public string Comm_ETH_CH_IP_3_C { get; set; }

        //originalName = Comm_ETH CH_IP 2_C
        public string Comm_ETH_CH_IP_2_C { get; set; }

        //originalName = Comm_ETH CH_IP 1_C
        public string Comm_ETH_CH_IP_1_C { get; set; }

        //originalName = Comm_ETH CH_IP 0_C
        public string Comm_ETH_CH_IP_0_C { get; set; }
        public DateTime Comm_Cleared_C { get; set; }

        //originalName = Comm_485_TX Message_C
        public int Comm_485_TX_Message_C { get; set; }

        //originalName = Comm_485_TX Data_C
        public float Comm_485_TX_Data_C { get; set; }

        //originalName = Comm_485_RX M. ALL_C
        public int Comm_485_RX_M__ALL_C { get; set; }

        //originalName = Comm_485_RX M. ACK_C
        public int Comm_485_RX_M__ACK_C { get; set; }

        //originalName = Comm_485_RX Data_C
        public int Comm_485_RX_Data_C { get; set; }
    }
}
