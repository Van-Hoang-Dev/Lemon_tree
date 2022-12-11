/*BT
 * Name: Nguyen Van Hoang
 * Date:17/11/2022
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1_C5
{
    class Program
    {
        //o day la nhap menu ne
        //menu
        static void NhapMenu(ref char kiTu)
        {
            Console.WriteLine("A: Bai 2:in ra tat cac cac uoc so cua so do.");
            Console.WriteLine("B: Bai 3:kiem tra xem so do co phai la so nguyen to hay khong.");
            Console.WriteLine("C: Bai 4:kiem tra xem so do co phai la so chinh phuong hay khong.");
            Console.WriteLine("D: Bai 5:kiem tra xem so do co phai la hoan hao hay khong.");
            Console.WriteLine("E: Bai 6:Tim so hang thu n cua day fibonaci");
            Console.WriteLine("F: Bai 7: Tim USCLN va BSCNN");
            Console.WriteLine("*------------------------------:vv----------------------------------*");
            Console.Write("Nhap vao bai muon thuc hien: ");
            char.TryParse(Console.ReadLine(), out kiTu);
        }
        static int NhapSoNguyenDuong(int n)
        {
            Console.Write("Nhap vao so nguyen duong: ");
            do
            {
                int.TryParse(Console.ReadLine(), out n);
            } while (n <= 0);

            return n;
        }

        /// <summary>
        /// Ham tim uoc tat cac ca uoc so cua so do
        /// </summary>
        /// <param name="n">gia tri truyen vao</param>
        /// 
        static void TimUocSo(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    Console.Write(i + " ");
                }
            }

        }

        //Bai 2: in ra tay ca cac uoc so
        /// <summary>
        /// Ham kiem tra so nguyen to
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static bool KiemTraSNT(int n)
        {
            // dung la so nguyen to thi tr ve 1 nguoc lai 0
            for (int i = 2; i < n / 2; i++)
            {
                if (n % i == 0 && n != 0)
                {
                    return false;
                    break;
                }
            }
            if (n == 1)
            {
                return false;
            }
            return true;
            //if(dem == 0)
            //{
            //    return true;
            //}
            //return false;
        }


        //Bai 4: Kiem tra so chinh phuong

        //Bai 5: kiem tra so hoan hoa
        /// <summary>
        /// Ham kiem tra so hoan hoa
        /// </summary>
        /// <param name="n"></param>
        static bool KiemTraSHH(int n)
        {
            int tong = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    tong = tong + i;
                }
            }

            if (tong == n)
            {
                return true;
            }
            return false;
        }
        //Bai 6: tim thu han thu n cua dayx fibonaci
        static int TimThuHangFib(int n)
        {
            int num1 = 0;
            int num2 = 0;
            int fi = 1;
            for (int i = 1; i < n; i++)
            {
                num1 = num2;
                num2 = fi;
                fi = num1 + num2;
            }
            return fi;
        }
        //Bai 7: Tim USCLN, BSCNN
        static void TimUSCLN_BCSNN(ref int uscln, ref int bscnn)
        {
            int a = 0;
            int b = 0;

            Console.Write("Nhap vao gia tri a: ");
            int.TryParse(Console.ReadLine(), out a);
            Console.Write("Nhap vao gia tri b: ");
            int.TryParse(Console.ReadLine(), out b);
            int n = a;
            int m = b;
            while (a != 0 && b != 0)
            {
                if (a >= b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            uscln = a + b;
            bscnn = (n * m) / uscln;

        }
        //BT8: in ra bang cuu chuong
        static void InBangCuuChuong(int n)
        {

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{n} x {i} = {n * i}");
            }
        }

        static void Main(string[] args)
        {
            //khai bao bien 
            int n = 0;
            char kiTu = '\0';
            //input
            NhapMenu(ref kiTu);

            n = NhapSoNguyenDuong(n);
            //Processing
            switch (kiTu)
            {
                case 'A':
                    //Bai 2: in ra tay ca cac uoc so
                    TimUocSo(n);
                    break;
                case 'B':
                    //Bai 3: kiem tra so nguyen to
                    Console.WriteLine();
                    KiemTraSNT(n);
                    if (KiemTraSNT(n) == true)
                    {
                        Console.WriteLine($"{n} La so nguyen to \n");
                    }
                    else
                    {
                        Console.WriteLine($"{n} Khong la so nguyen to \n");
                    }
                    break;
                case 'C':
                    //Bai 4: Kiem tra so chinh phuong
                    KiemTraSCP(n);
                    if (KiemTraSCP(n) == true)
                    {
                        Console.WriteLine($"{n} La so chinh phuong \n");
                    }
                    else
                    {
                        Console.WriteLine($"{n} Khong la so chinh phuong \n");
                    }
                    break;
                case 'D':
                    //Bai 5: kiem tra so hoan hoa
                    KiemTraSHH(n);
                    if (KiemTraSHH(n) == true)
                    {
                        Console.WriteLine($"{n} La so hoan hao \n");
                    }
                    else
                    {
                        Console.WriteLine($"{n} Khong la so hoan hao \n");
                    }
                    break;
                case 'E':
                    int fi = TimThuHangFib(n);
                    Console.WriteLine($"Thu hang thu {n} cua day fibonaci la: {fi}");
                    break;
                case 'F':
                    int uscln = 0;
                    int bscnn = 0;
                    TimUSCLN_BCSNN(ref uscln, ref bscnn);
                    Console.WriteLine("Uoc so chung lon nhat la: " + uscln);
                    Console.WriteLine("Boi so chung nho nhat la: " + bscnn);
                    break;
                case 'G':
                    InBangCuuChuong(n);
                    break;
            }
            Console.ReadKey();
        }
    }
}
/*
Nguye Tien Dat da chinh sua o day
👌 
*/
