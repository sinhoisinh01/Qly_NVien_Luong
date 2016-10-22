using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class HeSoLuong
    {
        public int id { get; set; }
        public virtual Ngach ngach { get; set; }
        public int bac_luong { get; set; }
        public float he_so { get; set; }
        public float? vuot_khung { get; set; }
    }
}
