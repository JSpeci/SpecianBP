using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    /*
    public class Harmonics : Entity
    {
        public DateTime TimeLocal { get; set; }
        //originalName = Harmonics/Uh_U4_h,9_C
        public float Harmonics_Uh_U4_h_9_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,7_C
        public float Harmonics_Uh_U4_h_7_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,5_C
        public float Harmonics_Uh_U4_h_5_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,3_C
        public float Harmonics_Uh_U4_h_3_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,19_C
        public float Harmonics_Uh_U4_h_19_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,17_C
        public float Harmonics_Uh_U4_h_17_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,15_C
        public float Harmonics_Uh_U4_h_15_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,13_C
        public float Harmonics_Uh_U4_h_13_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,11_C
        public float Harmonics_Uh_U4_h_11_C { get; set; }
        //originalName = Harmonics/Uh_U4_h,1_C
        public float Harmonics_Uh_U4_h_1_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,9_C
        public float Harmonics_Uh_U3_h_9_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,7_C
        public float Harmonics_Uh_U3_h_7_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,5_C
        public float Harmonics_Uh_U3_h_5_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,3_C
        public float Harmonics_Uh_U3_h_3_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,19_C
        public float Harmonics_Uh_U3_h_19_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,17_C
        public float Harmonics_Uh_U3_h_17_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,15_C
        public float Harmonics_Uh_U3_h_15_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,13_C
        public float Harmonics_Uh_U3_h_13_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,11_C
        public float Harmonics_Uh_U3_h_11_C { get; set; }
        //originalName = Harmonics/Uh_U3_h,1_C
        public float Harmonics_Uh_U3_h_1_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,9_C
        public float Harmonics_Uh_U2_h_9_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,7_C
        public float Harmonics_Uh_U2_h_7_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,5_C
        public float Harmonics_Uh_U2_h_5_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,3_C
        public float Harmonics_Uh_U2_h_3_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,19_C
        public float Harmonics_Uh_U2_h_19_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,17_C
        public float Harmonics_Uh_U2_h_17_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,15_C
        public float Harmonics_Uh_U2_h_15_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,13_C
        public float Harmonics_Uh_U2_h_13_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,11_C
        public float Harmonics_Uh_U2_h_11_C { get; set; }
        //originalName = Harmonics/Uh_U2_h,1_C
        public float Harmonics_Uh_U2_h_1_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,9_C
        public float Harmonics_Uh_U1_h_9_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,7_C
        public float Harmonics_Uh_U1_h_7_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,5_C
        public float Harmonics_Uh_U1_h_5_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,3_C
        public float Harmonics_Uh_U1_h_3_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,19_C
        public float Harmonics_Uh_U1_h_19_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,17_C
        public float Harmonics_Uh_U1_h_17_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,15_C
        public float Harmonics_Uh_U1_h_15_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,13_C
        public float Harmonics_Uh_U1_h_13_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,11_C
        public float Harmonics_Uh_U1_h_11_C { get; set; }
        //originalName = Harmonics/Uh_U1_h,1_C
        public float Harmonics_Uh_U1_h_1_C { get; set; }
        //originalName = Harmonics/Ufh_φU_4fh_C
        public float Harmonics_Ufh_φU_4fh_C { get; set; }
        //originalName = Harmonics/Ufh_φU_3fh_C
        public float Harmonics_Ufh_φU_3fh_C { get; set; }
        //originalName = Harmonics/Ufh_φU_2fh_C
        public float Harmonics_Ufh_φU_2fh_C { get; set; }
        //originalName = Harmonics/Ufh_φU_1fh_C
        public float Harmonics_Ufh_φU_1fh_C { get; set; }
        //originalName = Harmonics/Ufh_U_4fh_C
        public float Harmonics_Ufh_U_4fh_C { get; set; }
        //originalName = Harmonics/Ufh_U_3fh_C
        public float Harmonics_Ufh_U_3fh_C { get; set; }
        //originalName = Harmonics/Ufh_U_2fh_C
        public float Harmonics_Ufh_U_2fh_C { get; set; }
        //originalName = Harmonics/Ufh_U_1fh_C
        public float Harmonics_Ufh_U_1fh_C { get; set; }
        //originalName = Harmonics/Ufh_Phase Order_C
        public float Harmonics_Ufh_Phase_Order_C { get; set; }
        //originalName = Harmonics/THDU_avg_THDU4_C
        public float Harmonics_THDU_avg_THDU4_C { get; set; }
        //originalName = Harmonics/THDU_avg_THDU3_C
        public float Harmonics_THDU_avg_THDU3_C { get; set; }
        //originalName = Harmonics/THDU_avg_THDU2_C
        public float Harmonics_THDU_avg_THDU2_C { get; set; }
        //originalName = Harmonics/THDU_avg_THDU1_C
        public float Harmonics_THDU_avg_THDU1_C { get; set; }
        //originalName = Harmonics/THDU_avg_THD-RU4_C
        public float Harmonics_THDU_avg_THD_RU4_C { get; set; }
        //originalName = Harmonics/THDU_avg_THD-RU3_C
        public float Harmonics_THDU_avg_THD_RU3_C { get; set; }
        //originalName = Harmonics/THDU_avg_THD-RU2_C
        public float Harmonics_THDU_avg_THD_RU2_C { get; set; }
        //originalName = Harmonics/THDU_avg_THD-RU1_C
        public float Harmonics_THDU_avg_THD_RU1_C { get; set; }
        //originalName = Harmonics/THDI_avg_THD-RI4_C
        public float Harmonics_THDI_avg_THD_RI4_C { get; set; }
        //originalName = Harmonics/THDI_avg_THD-RI3_C
        public float Harmonics_THDI_avg_THD_RI3_C { get; set; }
        //originalName = Harmonics/THDI_avg_THD-RI2_C
        public float Harmonics_THDI_avg_THD_RI2_C { get; set; }
        //originalName = Harmonics/THDI_avg_THD-RI1_C
        public float Harmonics_THDI_avg_THD_RI1_C { get; set; }
        //originalName = Harmonics/THDI_avg_THDI4_C
        public float Harmonics_THDI_avg_THDI4_C { get; set; }
        //originalName = Harmonics/THDI_avg_THDI3_C
        public float Harmonics_THDI_avg_THDI3_C { get; set; }
        //originalName = Harmonics/THDI_avg_THDI2_C
        public float Harmonics_THDI_avg_THDI2_C { get; set; }
        //originalName = Harmonics/THDI_avg_THDI1_C
        public float Harmonics_THDI_avg_THDI1_C { get; set; }
        //originalName = Harmonics/Qfh_avg_Qfh4+_C
        public float Harmonics_Qfh_avg_Qfh4_C { get; set; }
        //originalName = Harmonics/Qfh_avg_Qfh4-_C
        //public float Harmonics_Qfh_avg_Qfh4_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh4_C
        //public float Harmonics_Qfh_avg_Qfh4_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh3+_C
        //public float Harmonics_Qfh_avg_Qfh3_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh3-_C
        //public float Harmonics_Qfh_avg_Qfh3_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh3_C
        //public float Harmonics_Qfh_avg_Qfh3_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh2+_C
        //public float Harmonics_Qfh_avg_Qfh2_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh2-_C
        //public float Harmonics_Qfh_avg_Qfh2_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh2_C
        //public float Harmonics_Qfh_avg_Qfh2_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh1+_C
        //public float Harmonics_Qfh_avg_Qfh1_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh1-_C
        //public float Harmonics_Qfh_avg_Qfh1_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_Qfh1_C
        //public float Harmonics_Qfh_avg_Qfh1_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_3Qfh+_C
        //public float Harmonics_Qfh_avg_3Qfh_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_3Qfh-_C
        //public float Harmonics_Qfh_avg_3Qfh_C { get; set; }
        ////originalName = Harmonics/Qfh_avg_3Qfh_C
        //public float Harmonics_Qfh_avg_3Qfh_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh4+_C
        //public float Harmonics_Pfh_avg_Pfh4_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh4-_C
        //public float Harmonics_Pfh_avg_Pfh4_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh4_C
        //public float Harmonics_Pfh_avg_Pfh4_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh3+_C
        //public float Harmonics_Pfh_avg_Pfh3_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh3-_C
        //public float Harmonics_Pfh_avg_Pfh3_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh3_C
        //public float Harmonics_Pfh_avg_Pfh3_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh2+_C
        //public float Harmonics_Pfh_avg_Pfh2_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh2-_C
        //public float Harmonics_Pfh_avg_Pfh2_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh2_C
        //public float Harmonics_Pfh_avg_Pfh2_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh1+_C
        //public float Harmonics_Pfh_avg_Pfh1_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh1-_C
        //public float Harmonics_Pfh_avg_Pfh1_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_Pfh1_C
        //public float Harmonics_Pfh_avg_Pfh1_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_3Pfh+_C
        //public float Harmonics_Pfh_avg_3Pfh_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_3Pfh-_C
        //public float Harmonics_Pfh_avg_3Pfh_C { get; set; }
        ////originalName = Harmonics/Pfh_avg_3Pfh_C
        //public float Harmonics_Pfh_avg_3Pfh_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,9_C
        public float Harmonics_Ih_I4_h_9_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,7_C
        public float Harmonics_Ih_I4_h_7_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,5_C
        public float Harmonics_Ih_I4_h_5_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,3_C
        public float Harmonics_Ih_I4_h_3_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,19_C
        public float Harmonics_Ih_I4_h_19_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,17_C
        public float Harmonics_Ih_I4_h_17_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,15_C
        public float Harmonics_Ih_I4_h_15_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,13_C
        public float Harmonics_Ih_I4_h_13_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,11_C
        public float Harmonics_Ih_I4_h_11_C { get; set; }
        //originalName = Harmonics/Ih_I4_h,1_C
        public float Harmonics_Ih_I4_h_1_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,9_C
        public float Harmonics_Ih_I3_h_9_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,7_C
        public float Harmonics_Ih_I3_h_7_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,5_C
        public float Harmonics_Ih_I3_h_5_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,3_C
        public float Harmonics_Ih_I3_h_3_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,19_C
        public float Harmonics_Ih_I3_h_19_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,17_C
        public float Harmonics_Ih_I3_h_17_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,15_C
        public float Harmonics_Ih_I3_h_15_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,13_C
        public float Harmonics_Ih_I3_h_13_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,11_C
        public float Harmonics_Ih_I3_h_11_C { get; set; }
        //originalName = Harmonics/Ih_I3_h,1_C
        public float Harmonics_Ih_I3_h_1_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,9_C
        public float Harmonics_Ih_I2_h_9_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,7_C
        public float Harmonics_Ih_I2_h_7_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,5_C
        public float Harmonics_Ih_I2_h_5_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,3_C
        public float Harmonics_Ih_I2_h_3_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,19_C
        public float Harmonics_Ih_I2_h_19_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,17_C
        public float Harmonics_Ih_I2_h_17_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,15_C
        public float Harmonics_Ih_I2_h_15_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,13_C
        public float Harmonics_Ih_I2_h_13_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,11_C
        public float Harmonics_Ih_I2_h_11_C { get; set; }
        //originalName = Harmonics/Ih_I2_h,1_C
        public float Harmonics_Ih_I2_h_1_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,9_C
        public float Harmonics_Ih_I1_h_9_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,7_C
        public float Harmonics_Ih_I1_h_7_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,5_C
        public float Harmonics_Ih_I1_h_5_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,3_C
        public float Harmonics_Ih_I1_h_3_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,19_C
        public float Harmonics_Ih_I1_h_19_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,17_C
        public float Harmonics_Ih_I1_h_17_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,15_C
        public float Harmonics_Ih_I1_h_15_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,13_C
        public float Harmonics_Ih_I1_h_13_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,11_C
        public float Harmonics_Ih_I1_h_11_C { get; set; }
        //originalName = Harmonics/Ih_I1_h,1_C
        public float Harmonics_Ih_I1_h_1_C { get; set; }
        //originalName = Harmonics/Ifh_φI_4fh_C
        public float Harmonics_Ifh_φI_4fh_C { get; set; }
        //originalName = Harmonics/Ifh_φI_3fh_C
        public float Harmonics_Ifh_φI_3fh_C { get; set; }
        //originalName = Harmonics/Ifh_φI_2fh_C
        public float Harmonics_Ifh_φI_2fh_C { get; set; }
        //originalName = Harmonics/Ifh_φI_1fh_C
        public float Harmonics_Ifh_φI_1fh_C { get; set; }
        //originalName = Harmonics/Ifh_I_4fh_C
        public float Harmonics_Ifh_I_4fh_C { get; set; }
        //originalName = Harmonics/Ifh_I_3fh_C
        public float Harmonics_Ifh_I_3fh_C { get; set; }
        //originalName = Harmonics/Ifh_I_2fh_C
        public float Harmonics_Ifh_I_2fh_C { get; set; }
        //originalName = Harmonics/Ifh_I_1fh_C
        public float Harmonics_Ifh_I_1fh_C { get; set; }
    }
    */
}
