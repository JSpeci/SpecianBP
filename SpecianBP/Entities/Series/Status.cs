using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Status : SeriesEntity
    {
        public DateTime TimeLocal { get; set; }
        public string Status_Flow_C { get; set; }
        public string Status_Flags_C { get; set; }
        public bool Status_Flagging_UIP3_C { get; set; }
        public bool Status_Flagging_UIP2_C { get; set; }
        public bool Status_Flagging_UIP1_C { get; set; }
        public bool Status_Flagging_Time_C { get; set; }
        public bool Status_Flagging_Pst3_C { get; set; }
        public bool Status_Flagging_Pst2_C { get; set; }
        public bool Status_Flagging_Pst1_C { get; set; }
        public bool Status_Flagging_Plt3_C { get; set; }
        public bool Status_Flagging_Plt2_C { get; set; }
        public bool Status_Flagging_Plt1_C { get; set; }
        public bool Status_Flagging_LW3_C { get; set; }
        public bool Status_Flagging_LW2_C { get; set; }
        public bool Status_Flagging_LW1_C { get; set; }
        public bool Status_Flagging_Freq_C { get; set; }
        public bool Status_Flagging_FLEX_C { get; set; }
        public bool Status_Flagging_10mTick_C { get; set; }
        //originalName = Status_ADC Zeroing_U4_C
        public bool Status_ADC_Zeroing_U4_C { get; set; }
        //originalName = Status_ADC Zeroing_U3_C
        public bool Status_ADC_Zeroing_U3_C { get; set; }
        //originalName = Status_ADC Zeroing_U2_C
        public bool Status_ADC_Zeroing_U2_C { get; set; }
        //originalName = Status_ADC Zeroing_U1_C
        public bool Status_ADC_Zeroing_U1_C { get; set; }
        //originalName = Status_ADC Zeroing_I4_C
        public bool Status_ADC_Zeroing_I4_C { get; set; }
        //originalName = Status_ADC Zeroing_I3_C
        public bool Status_ADC_Zeroing_I3_C { get; set; }
        //originalName = Status_ADC Zeroing_I2_C
        public bool Status_ADC_Zeroing_I2_C { get; set; }
        //originalName = Status_ADC Zeroing_I1_C
        public bool Status_ADC_Zeroing_I1_C { get; set; }
        //originalName = Status_ADC Clipping_U4_C
        public bool Status_ADC_Clipping_U4_C { get; set; }
        //originalName = Status_ADC Clipping_U3_C
        public bool Status_ADC_Clipping_U3_C { get; set; }
        //originalName = Status_ADC Clipping_U2_C
        public bool Status_ADC_Clipping_U2_C { get; set; }
        //originalName = Status_ADC Clipping_U1_C
        public bool Status_ADC_Clipping_U1_C { get; set; }
        //originalName = Status_ADC Clipping_I4_C
        public bool Status_ADC_Clipping_I4_C { get; set; }
        //originalName = Status_ADC Clipping_I3_C
        public bool Status_ADC_Clipping_I3_C { get; set; }
        //originalName = Status_ADC Clipping_I2_C
        public bool Status_ADC_Clipping_I2_C { get; set; }
        //originalName = Status_ADC Clipping_I1_C
        public bool Status_ADC_Clipping_I1_C { get; set; }
    }
}
