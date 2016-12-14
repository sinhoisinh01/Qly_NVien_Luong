using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qly_NVien_Luong_Form
{
    public class DataCounter
    {
        public static void autoIncrementTable(DataGridView table)
        {
            for(int i = 0; i < table.RowCount; i++)
                table["clmCounter", i].Value = i + 1;
        }
    }
}
