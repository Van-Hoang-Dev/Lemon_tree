/*BT1: Thuc hien tao mang va goi ham
 * Name: Nguyen Van Hooang
 * Date: 15/12/202
 * Modifed:23/12/2022
 */
using System;

namespace BT1_Chuong_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Khai bao bien
            char chon = '\0';
            char luaChonBai = '\0'; 
            int viTri = 0;
            // tao mang so nguyen
            int[] arr = new int[] { };
            int[] arr1 = new int[] { };
            int[] arr2 = new int[] { };
            //input
            //Processing
            TaoMenu();
            arr = NhapMang();
            arr1 = SaoChepMang(arr);
            arr2 = SaoChepMang(arr);
            do
            {
                Console.Write("- Nhap Y de tiep tuc. Nhap N de ket thuc: ");
                char.TryParse(Console.ReadLine(), out chon);
                if(chon =='Y' || chon =='y')
                {
                    Console.Write("BaiTap: ");
                    char.TryParse(Console.ReadLine(), out luaChonBai);
                    switch(luaChonBai)
                    {
                        case 'a':
                            NhapMang();
                            break;
                        case 'b':
                            XuatMang(arr);
                            break;
                        case 'c':
                            XuatCacSoChan(arr);
                            break;
                        case 'd':
                            XuatCacSoNguyenTo(arr);
                            break;
                        case 'e':
                            double tong = TinhTrungBinhCong(arr);
                            Console.WriteLine("Trung binh cong cua mang la: " + tong);
                            break;
                        case 'f':
                            //So Luon so hoan hao
                            int dem = DemSoLuongSoHoanThien(arr);
                            Console.Write($"So luon so hoan thien trong mang la: {dem}");
                            break;
                        case 'g':
                            int x = 0;
                            Console.Write("Nhap vao gia tri x can tim: ");
                            int.TryParse(Console.ReadLine(), out x);
                             viTri = TimViTriCuoiCung(arr, x);
                            Console.WriteLine($"Vi tri cuoi cung cua pha tu {x} la: {viTri}");
                            break;
                        case 'h':
                             viTri = TimViTriSoNguyenToDauTien(arr);
                            Console.WriteLine($"Vi tri dau tien so nguyen to cua mang la: {viTri}");
                            break;
                        case 'i':
                            Console.WriteLine($"Tim gia tri lon nhat trong mang {TimPhanTuLonNhatTrongMang(arr)}");
                            break;
                        case 'j':
                            Console.WriteLine($"Tim gia tri duong nho nhat trong mang {TimSoDuongNhoNhatTrongMang(arr)}");
                            break;
                        case 'k':
                            Console.WriteLine("Mang theo thu tu tang dan: ");
                            SapXepMangTheoThuTuTangDan(ref arr1);
                            XuatMang(arr1);
                            break;
                        case 'l':
                            if(KiemTraThuTuTangDanCuaMang(arr, arr2) == true)
                            {
                                Console.WriteLine("Mang co thu tu tang dan");
                            }
                            else
                            {
                                Console.WriteLine("Mang khong co thu tu tang dan");
                            }
                            break;
                        default:
                            Console.WriteLine("Chua co chuc nang nay");
                            break;
                    }
                }
               
                

               
            } while (chon != 'n' && chon != 'N');
            Console.ReadKey();
        }// end main

        //l: Kiem tra mang co thu tu tang dan khong
        //Ham copy mang
        static int [] SaoChepMang(int[] arr)
        {
            int[] arr1 = new int[arr.Length];
            for(int i =0; i< arr.Length; i++)
            {
                arr1[i] = arr[i];
            }
            return arr1;
        }
        //Kiem tra thu tu cua mang
        static bool KiemTraThuTuTangDanCuaMang(int [] arr, int[] arr2)
        {
            SapXepMangTheoThuTuTangDan(ref arr);
            bool kiemTra = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != arr2[i])
                {
                    kiemTra = false;
                    break;
                }
            }
            return kiemTra;
        }
        //k: sap xep cac phan tu theo thu tu tang dan

        static void SapXepMangTheoThuTuTangDan(ref int [] arr)
        {
            int temp = 0;
            for(int i=0; i<arr.Length -1; i++)
            {
                for(int j= i+1; j<arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        //i: tim phan tu lon mhat trong mang
        //ham tim vi tri so duong dau tien
        static int TimViTriSoDuongDauTien(int[] arr)
        {
            int viTri = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    viTri = i;
                    break;
                }
            }
            return viTri;
        }
        static int TimSoDuongNhoNhatTrongMang(int[] arr)
        {
            int viTri = TimViTriSoDuongDauTien(arr);
            int min = 0;
            if (viTri != -1)
            {
                min = arr[viTri];
                for (int i = viTri; i < arr.Length; i++)
                {
                   if(min >= arr[i] && arr[i] > 0)
                    {
                        min = arr[i];
                    }
                }
            }
            return min;
        }
        static int TimPhanTuLonNhatTrongMang(int [] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max <= arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }
        //h: tim vi tri so nguyen to dau tien
       
        //Ham tin so nguyen to dau tien trong mang
        static int TimViTriSoNguyenToDauTien(int [] arr)
        {
            int viTri = -1;
            for(int i=0; i< arr.Length; i++)
            {
                if (KiemTraSoNguyenTo(arr[i]) == true)
                {
                    viTri = i;
                    break;
                }
            }
            return viTri;
        }
        //g: tim vi tri cuoi cung cua mang
        static int TimViTriCuoiCung(int [] arr, int x)
        {
            int viTri = -1;
            for(int i = arr.Length -1; i >=0; i--)
            {
                if(arr[i] == x)
                {
                    viTri = i;
                    break;
                }
            }
            return viTri;
        }
        //f: dem so hoan thien trong mang
        //ham kiem tra so hoan hao
        static bool KiemTraSoHoanHao(int n)
        {
            int tong = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    tong = tong + i;
                }

            }
            if (tong ==n)
            {
                return true;
            }
            return false;
        }
        //Dem so hoan thien trong mang
        static int DemSoLuongSoHoanThien(int[] arr)
        {
            int dem = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(KiemTraSoHoanHao(arr[i]) == true)
                {
                    dem++;
                }
            }
            return dem;
        }
        //b: Xuat cac so chan
        static void XuatCacSoChan(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
        //d: Xuat cac so nguyen to
        public static bool KiemTraSoNguyenTo(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        static void XuatCacSoNguyenTo(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (KiemTraSoNguyenTo(arr[i]) == true)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
        //e: Tinh trung binh cong cac phan tu trong mang
        /// <summary>
        /// Ham tinh tong cac phan tu cua mang
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static double TinhTrungBinhCong(int[] arr)
        {
            
            double tbc = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                tbc = tbc + arr[i];
            }
            tbc = tbc / arr.Length;
            return tbc;
        }
        //Ham nhap so nguyen
        static int[] NhapMang()
        {
            //Khai bao so luong phan tu cua mang arr
            int n = 0;
            do
            {
                Console.Write("Nhap vao so luong phan tu cua mang: ");
                int.TryParse(Console.ReadLine(), out n);
            } while (n < 1 || n > 100);
            //Khoi tao mang
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    Console.Write($"Nhap phan tu thu {i}: ");

                } while (int.TryParse(Console.ReadLine(), out arr[i]) == false);
            }
            return arr;
        }
        //Ham xuat mang
        static void XuatMang(int[] arr)
        {
            Console.Write("Cac phan tu cua mang la: ");
            foreach(int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        //Menu 
        static void TaoMenu()
        {
            Console.WriteLine("a: Nhap mang");
            Console.WriteLine("b: Xuat mang vua nhap");
            Console.WriteLine("c: Xuat ca so chan trong mang");
            Console.WriteLine("d: Xuat cac so nguyen to trong mang");
            Console.WriteLine("e: Tinh trung binh cong cac phan tu trong mang");
            Console.WriteLine("f: Dem so luong so hoan thien");
            Console.WriteLine("g: Tim vi tri cuoi cung cua mang");
            Console.WriteLine("h: Tim vi tri so nguyen to dau tien cua mang");
            Console.WriteLine("i: Tim phan tu lon nhat trong mang");
            Console.WriteLine("j: Tim so duong nho nhat trong mang");
            Console.WriteLine("k: Sap xep cac phan tu cua mang theo thu tu tang dan");
            Console.WriteLine("l: Kiem tra xem mang co thu tu tang dan khong");
            Console.WriteLine("______________----------_____________________");
        }

    }
}
