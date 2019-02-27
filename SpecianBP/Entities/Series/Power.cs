using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Power : Entity
    {
        public DateTime TimeLocal { get; set; }
        public float S_avg_S4_C { get; set; }
        public float S_avg_S3_C { get; set; }
        public float S_avg_S2_C { get; set; }
        public float S_avg_S1_C { get; set; }
        public float S_avg_3S_C { get; set; }
        //originalName = Q_avg_Q4+_C
        public float Q_avg_Q4plus_C { get; set; }
        //originalName = Q_avg_Q4-_C
        public float Q_avg_Q4minus_C { get; set; }
        public float Q_avg_Q4_C { get; set; }
        //originalName = Q_avg_Q3+_C
        public float Q_avg_Q3plus_C { get; set; }
        //originalName = Q_avg_Q3-_C
        public float Q_avg_Q3minus_C { get; set; }
        public float Q_avg_Q3_C { get; set; }
        //originalName = Q_avg_Q2+_C
        public float Q_avg_Q2plus_C { get; set; }
        //originalName = Q_avg_Q2-_C
        public float Q_avg_Q2minus_C { get; set; }
        public float Q_avg_Q2_C { get; set; }
        //originalName = Q_avg_Q1+_C
        public float Q_avg_Q1plus_C { get; set; }
        //originalName = Q_avg_Q1-_C
        public float Q_avg_Q1minus_C { get; set; }
        public float Q_avg_Q1_C { get; set; }
        //originalName = Q_avg_3Q+_C
        public float Q_avg_3Qplus_C { get; set; }
        //originalName = Q_avg_3Q-_C
        public float Q_avg_3Qminus_C { get; set; }
        public float Q_avg_3Q_C { get; set; }
        public float PF_PF4_C { get; set; }
        public float PF_PF3_C { get; set; }
        public float PF_PF2_C { get; set; }
        public float PF_PF1_C { get; set; }
        public float PF_3PF_C { get; set; }
        //originalName = P_avg_P4+_C
        public float P_avg_P4plus_C { get; set; }
        //originalName = P_avg_P4-_C
        public float P_avg_P4minus_C { get; set; }
        public float P_avg_P4_C { get; set; }
        //originalName = P_avg_P3+_C
        public float P_avg_P3plus_C { get; set; }
        //originalName = P_avg_P3-_C
        public float P_avg_P3minus_C { get; set; }
        public float P_avg_P3_C { get; set; }
        //originalName = P_avg_P2+_C
        public float P_avg_P2plus_C { get; set; }
        //originalName = P_avg_P2-_C
        public float P_avg_P2minus_C { get; set; }
        public float P_avg_P2_C { get; set; }
        //originalName = P_avg_P1+_C
        public float P_avg_P1plus_C { get; set; }
        //originalName = P_avg_P1-_C
        public float P_avg_P1minus_C { get; set; }
        public float P_avg_P1_C { get; set; }
        //originalName = P_avg_3P+_C
        public float P_avg_3Pplus_C { get; set; }
        //originalName = P_avg_3P-_C
        public float P_avg_3Pminus_C { get; set; }
        public float P_avg_3P_C { get; set; }
    }
}
