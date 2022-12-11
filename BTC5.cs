/*BT12: in ra cacs so nguyen to
 * Name:Nguyen Van Hoang
 * Date: 12/1/2022
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT12_C5
{
    //Nhap menu
   
    class BTC5
    {
        static char NhapMenu(char kiTu)
        {
            Console.WriteLine("A: In cac so nguyen to tu 2 den n");
            Console.WriteLine("B: In tam giac pascal");
            Console.WriteLine("C: In ra so dao nguoc cua n");
            Console.WriteLine("D: Kiem tra so dao nguoc co phai la so doi xung khong");
            Console.WriteLine("E: In cac so nguyen tu 10-99 sao cho tich cua 2 so bangwf 2 lan tong cua 2 chu so do");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.Write("Nhap vao lua chon cua ban: ");
            char.TryParse(Console.ReadLine(), out kiTu);

            return kiTu;
        }

        //Nhap 
        static int NhapSoNguyenDuong(int n)
        {
            Console.Write("Nhap vao so nguyen duong n: ");
            int.TryParse(Console.ReadLine(), out n);
            return n;
        }
        static void Main(string[] args)
        {
             char kiTu = '\0';
            kiTu = NhapMenu(kiTu);
            //Khai bao bien
            int n = 0;
            n = NhapSoNguyenDuong(n);
            switch (kiTu)
            {
                case 'A':

                    //Bai 12: in ra so nguyen to
                   
                    InCacSNT(n);
                    break;

                case 'B':
                    //Bai13
                    //TinhGiaiThua(n);
                    InTamGiacPascal(n);
                    break;
                case 'C':
                    //Bai 14
                    int kQ = InSoDaoNguoc(n);
                    Console.WriteLine("So dao nguoc la: {0:0000}", kQ);
                    break;
                case 'D':
                    //Bai 15 
                    if (KiemTraSoDoiXung(n) == true)
                    {
                        Console.WriteLine($"{n}La so doi xung");
                    }
                    else
                    {
                        Console.WriteLine($"{n} Khong Phai la so doi xung");
                    }
                    break;
                case 'E':
                    InCacSo();
                    break;
                default:
                    Console.WriteLine("Nhap sao roi kia, nhap lai di");
                    break;

            }
            Console.ReadKey();
        }//end Main

        //Bai 12: in ra so nguyen to 
        //ham kiem tra so nguyen to
        static bool KiemTraSNT(int n)
        {
            for(int i= 2; i<=n/2; i++)
            {
                if(n % i== 0 && n!= 1)
                {
                    return false;
                }
            }
            return true;
        }
        //Ham in ra so nguyen to
        static void InCacSNT(int n)
        {
            
            for(int i=2; i<=n; i++)
            {
               if(KiemTraSNT(i)==true)
                {
                    Console.Write(i + " ");
                }
            }
        }

        //bai 13
        //ham tinh giai thua
        static long TinhGiaiThua(double n)
        {
            long tich = 1;
            for(int i =1; i<=n; i++)
            {
                tich = tich * i;
            }
            return tich;
        }
        //Ham tinh to hop
        static double TinhToHop(int k, int n)
        {
            double toHop = 0;
            toHop = TinhGiaiThua(n) / (TinhGiaiThua(n - k) * TinhGiaiThua(k));
            return toHop;
        }

        static void InTamGiacPascal(int n)
        {
           
            for(int i =0; i< n; i++)
            {
                //for(int m =i; m<=n; m++)
                //{
                //    Console.Write(" ");
                //}
                for(int k=0; k<= i;k++)
                {
                    Console.Write(TinhToHop(k, i) + " ");
                }
                Console.WriteLine();
            }
        }

        //Bai 14
        static int InSoDaoNguoc(int n)
        {
           
            int soDao = 0;
            while (n > 0)
            {
                soDao = soDao * 10 + (n % 10);
                n = n / 10;
            }
            return soDao;
        }

        //Bai 15: kiem tra so doi cung
        static bool KiemTraSoDoiXung(int n)
        {
            if(InSoDaoNguoc(n) == n)
            {
                return true;
            }
            return false;
        }

        //bai 16
        static void InCacSo()
        {
            int a = 0;
            int b = 0;
            for (int i = 10; i <= 99; i++)
            {
                a = i / 10;
                b = i % 10;
                if((a*b) == (2*(a+b)))
                {
                    Console.Write(i + " ");
                }
            }
        }

    }//
}
