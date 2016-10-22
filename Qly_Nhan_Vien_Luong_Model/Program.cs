using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Nhan_Vien_Luong_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NhanVienLuongDBContext())
            {
                /*var ngach = new Ngach();
                
                Console.Write("Nhap ma ngach: ");
                ngach.ma_so = Console.ReadLine();
                Console.Write("Nhap ten ngach: ");
                ngach.ten_ngach = Console.ReadLine();
                Console.Write("Nhap mo ta: ");
                ngach.ten_ngach = Console.ReadLine();
                Console.Write("Nhap nien han: ");
                ngach.nien_han = Int32.Parse(Console.ReadLine());

                db.ngach.Add(ngach);
                db.SaveChanges();*/

                // Display all Blogs from the database 
                var query = from b in db.ngach
                            orderby b.id
                            select b;

                Console.WriteLine("All ngachs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.ma_so);
                    Console.WriteLine(item.ten_ngach);
                    Console.WriteLine(item.mo_ta);
                    Console.WriteLine(item.nien_han);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }
}
