using System.Text;

namespace OnTapThiThu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            //Khai báo và khởi tạo class services
            Services services = new Services();
            //B1: khai báo biến lựa chọn
            int choice;
            //B2: tạo vòng lặp do while với điều kiện choice != thoát
            do 
            {
                //B3: code trong dowhile, cw menu trong này
                Console.WriteLine("1. Thêm đối tượng");
                Console.WriteLine("2. Xuất danh sách");
                Console.WriteLine("3. Xuất danh sách đối tượng theo thể tích");
                Console.WriteLine("4. Xóa đối tượng calo > 50");
                Console.WriteLine("0. Thoát");
                //B4: nhập lựa chọn từ bàn phím
                Console.WriteLine("Xin mời nhập lựa chọn:");
                choice = Convert.ToInt32(Console.ReadLine());
                //choice = int.Parse(Console.ReadLine());
                //B5: sử dụng switch case với biến choice
                switch(choice)
                {
                    //B5.1: viết case và break mỗi case
                    case 1:
                        services.ThemCoYesNo();
                        break;
                    case 2:
                        services.XuatDS();
                        break;
                    case 3:
                        services.XuatDSTheoTheTich1();
                        break;
                    case 4:
                        services.XoaTheoCalo();
                        break; 
                    case 5:
                        services.KeThua();
                        break;
                    case 0:
                        Console.WriteLine("bye bye");
                        break;
                    //B5.2: default: dùng cho các lựa chọn ko có trong menu
                    default:
                        Console.WriteLine("ko có trong menu, nhập lại");
                        break;
                }
            } while (choice != 0); //bị lỗi, tuy nhiên sau khi mình readline thì sẽ hết


        }
    }
}