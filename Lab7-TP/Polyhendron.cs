using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_TP
{
    internal class Polyhendron
    {
        protected double side = 0, S = 0, V = 0;
        protected int ribs = 0, ribs_at_vecrtex = 0, facets = 0;
        protected bool Flag_Polyhendron = false;

        private bool Calculate_Facets()
        {
            if (ribs_at_vecrtex == ribs && ribs == 4) return false;
            double facets_buf;
            facets_buf = (4 * ribs_at_vecrtex) / (4 - (ribs - 2) * (ribs_at_vecrtex - 2));
            facets = Convert.ToInt32(facets_buf);
            if(facets <= 3) { return false; }
            if(Math.Abs(facets_buf - facets) > 0.001) { return false; }
            return true;
        }
        private void Calculate_S()
        {
            S = (side / 2) * (side / 2) * facets * ribs * (1 / Math.Tan(Math.PI / ribs));
        }
        protected virtual void Calculate_V() { return; }
        protected virtual bool Update_virtual() { return true; }

        private bool Update_class()
        {
            if (ribs <= 2 || ribs >= 8 || ribs_at_vecrtex <= 2 || ribs_at_vecrtex >= 6 || side <= 0) return false;
            if (!Calculate_Facets()) return false;
            Calculate_S();
            if (Update_virtual()) Calculate_V();
            Flag_Polyhendron = true;
            return true;
        }

        private void Clean_class()
        {
            side = 0;
            ribs = 0;
            ribs_at_vecrtex = 0;
            facets = 0;
            Flag_Polyhendron = false;
            S = 0;
            V = 0;
        }
        public Polyhendron(int ribs_, int ribs_at_vecrtex_, double side_)
        {
            ribs = ribs_;
            ribs_at_vecrtex = ribs_at_vecrtex_;
            side = side_;
            if (!Update_class()) 
                Clean_class();
        }
        public double S_get
        {
            get { return S; }
        }
        public bool get_flag_Poly
        {
            get { return Flag_Polyhendron; }
        }
    }
    internal class Dodecahedron: Polyhendron
    {
        private const int c_ribs = 5, c_ribs_at_vecrtex = 3;
        private bool Flag_Dodecahedron = false;
        private bool Test_Dodec()
        {
            if (ribs != c_ribs || ribs_at_vecrtex != c_ribs_at_vecrtex)
            {
                Flag_Dodecahedron = false;
                return false;
            }
            else
            {
                Flag_Dodecahedron = true;
                return true;
            }
        }
        protected override void Calculate_V()
        {
            if(Flag_Dodecahedron) V = (Math.Pow(side, 3) / 4 * (15 + 7 * Math.Sqrt(5)));
        }
        protected override bool Update_virtual()
        {
            if (!Test_Dodec()) return false;
            else return true;
        }
        public Dodecahedron(int ribs_, int ribs_at_vecrtex_, double side_) : base(ribs_, ribs_at_vecrtex_, side_) { }
        public double V_get
        {
            get { return V; }
        }
        public bool get_flag_Dodec
        {
            get { return Flag_Dodecahedron; }
        }
    }
}
