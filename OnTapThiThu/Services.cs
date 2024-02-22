using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnTapThiThu
{
    internal class Services
    {
        //Cực kỳ quan trọng 1: khai báo danh sách đối tượng
        private List<NuocNgot> lst;

        //Cực kỳ quan trọng 2: tạo ctor của class
        // ctor + tab
        public Services()
        {
            //Cực kỳ quan trọng 3: khởi tạo danh sách đối tượng
            lst = new List<NuocNgot>();
        }
        //code xong 3 cái quan trọng, quay về main, để khai báo vào khởi tạo service
        // đặt ở trên phần khai báo biến biến choice

        #region Thêm đối tượng
        public void ThemCoBan()
        {
            //B1: khai báo và khởi tạo đối tượng
            NuocNgot nuocNgot = new NuocNgot();
            //B2: nhập từ bán phím vào các thuộc tính
            Console.WriteLine("Xin mời nhập mã:");
            //doituong.<tên thuộc tính>
            nuocNgot.Ma = Console.ReadLine();
            Console.WriteLine("Xin mời nhập tên:");
            nuocNgot.Ten = Console.ReadLine();
            Console.WriteLine("Xin mời nhập lượng calo:");
            nuocNgot.LuongCalo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Xin mời nhập thể tích:");
            nuocNgot.LuongCalo = Convert.ToInt32(Console.ReadLine());
            //B3: thêm vào danh sách và thông báo thành công
            lst.Add(nuocNgot);
            Console.WriteLine("Thêm thành công");
        }

        public void ThemCoYesNo()
        {
            //khai báo biến yesno
            string yesno = "N";
            do
            {
                //B1: khai báo và khởi tạo đối tượng
                NuocNgot nuocNgot = new NuocNgot();
                //B2: nhập từ bán phím vào các thuộc tính
                Console.WriteLine("Xin mời nhập mã:");
                //doituong.<tên thuộc tính>
                nuocNgot.Ma = Console.ReadLine();
                Console.WriteLine("Xin mời nhập tên:");
                nuocNgot.Ten = Console.ReadLine();
                Console.WriteLine("Xin mời nhập lượng calo:");
                nuocNgot.LuongCalo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Xin mời nhập thể tích:");
                nuocNgot.TheTich = Convert.ToInt32(Console.ReadLine());
                //B3: thêm vào danh sách và thông báo thành công
                lst.Add(nuocNgot);
                Console.WriteLine("Thêm thành công");
                //------------
                //hỏi nhập tiếp hay ko
                Console.WriteLine("Có nhập tiếp ko? (chọn N để thoát/ phím khác để tiếp tục):");
                yesno = Console.ReadLine();
            } while (yesno != "N");// yesno != N
        }
        #endregion

        #region Xuất danh sách
        public void XuatDS()
        {
            //B1: tạo vòng lặp foreach
            foreach (var nuoc in lst) 
            {
                //B2: inThongTin
                nuoc.InThongTin();
            }
        }
        #endregion

        #region Xuất danh sách theo yêu cầu
        public void XuatDSTheoTheTich1() // foreach
        {
            bool isfound = false;// mặc định là không thấy đối tượng nào
            //B1: tạo vòng lặp foreach
            foreach (var nuoc in lst)
            {
                //B2: tạo điều kiện if 
                if(nuoc.TheTich >= 180 && nuoc.TheTich <= 360)
                {
                    //B3: inthongtin
                    nuoc.InThongTin();
                    isfound = true;//đánh dấu là có tìm thấy
                }
            }
            if(isfound == false)
            {
                Console.WriteLine("Không tìm thấy");
            }
        }

        public void XuatDSTheoTheTich2() // linq
        {
            //với list thì .ToList() | với đối tượng: .FirstOrdefault()
            var dsCanTim = lst.Where(nuoc => nuoc.TheTich >= 180 && nuoc.TheTich <= 360).ToList();
            if(dsCanTim.Count > 0) 
            {
                foreach (var nuoc in dsCanTim)
                {
                    nuoc.InThongTin();
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy");
            }
        }
        #endregion

        #region Xóa theo yêu cầu
        // khi gặp xóa
        // sẽ cần tạo 1 danh sách để xóa
        // ko được xóa luôn trong danh sách gốc
        public void XoaTheoCalo()
        {
            bool isFound = false;
            //B1: tạo 1 danh sách lưu tạm đối tượng cần xóa
            // ko được gán với danh sách gốc: liên kết với danh sách gốc
            List<NuocNgot> dsXoa = new List<NuocNgot>();
            foreach (var nuoc in lst) //chú ý sử dụng danh sách gốc
            {
                if(nuoc.LuongCalo > 50)
                {
                    //thêm vào danhsach cần xóa
                    dsXoa.Add(nuoc);
                    isFound = true;
                }
            }
            if(isFound == false)
            {
                Console.WriteLine("không tìm thấy đối tượng thỏa mãn để xóa");
                return;
            }
            foreach(var nuoc in dsXoa)
            {
                lst.Remove(nuoc);
            }
            Console.WriteLine("Xóa thành công");
        }

        public void Xoa1DoiTuong()
        {
            NuocNgot nuocCanXoa = new NuocNgot();
            foreach (var nuoc in lst)
            {
                if (nuoc.LuongCalo > 50)
                {
                    //gán giá trị vào đối tượng cần xóa
                    nuocCanXoa = nuoc;
                }
            }
            //ra ngoài vòng lặp mới xóa
            lst.Remove(nuocCanXoa);
            Console.WriteLine("Xóa thành công");
        }
        #endregion

        #region Sửa đối tượng
        public void SuaDoiTuongTheoMa()
        {
            //tạo biến input để nhập mã cần sửa
            Console.WriteLine("Xin mời nhập mã cần sửa");
            string input = Console.ReadLine();
            foreach (var nuoc in lst)
            {
                if(nuoc.Ma == input)
                {
                    Console.WriteLine("Xin mời nhập mã mới:");
                    nuoc.Ma = Console.ReadLine();
                    Console.WriteLine("Xin mời nhập tên mới:");
                    nuoc.Ten = Console.ReadLine();
                    Console.WriteLine("Xin mời nhập lượng calo mới:");
                    nuoc.LuongCalo = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Xin mời nhập thể tích mới:");
                    nuoc.TheTich = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Sửa thành công");
                }
            }
        }
        #endregion

        #region kế thừa
        public void KeThua()
        {
            //B1: khai báo đối tượng
            NuocNgot0Calo nuocNgot0Calo;
            //B2: khởi tạo đối tượng cùng tham số
            nuocNgot0Calo = new NuocNgot0Calo("ocalo", "pepsi", 0, 180, "Chanh");
            //B3:In ra màn hình
            nuocNgot0Calo.InThongTin();
        }
        #endregion

        #region Sắp xếp 

        public void SapXepTangDan()
        {
            //B1: tạo danh sách để hiển thị
            List<NuocNgot> sorted = new List<NuocNgot>();
            //B2: thêm vào danh sách các đối tượng ở ds gốc
            foreach (var item in lst)
            {
                sorted.Add(item);
            }
            //B3: linq để sort
            sorted = sorted.OrderBy(nuoc => nuoc.Ma).ToList();
            //B4:foreach để inThoong tin
            foreach (var item in sorted)
            {
                item.InThongTin();
            }
          
        }

        public void SapXepGiamDan()
        {
            //B1: tạo danh sách để hiển thị
            List<NuocNgot> sorted = new List<NuocNgot>();
            //B2: thêm vào danh sách các đối tượng ở ds gốc
            foreach (var item in lst)
            {
                sorted.Add(item);
            }
            //B3: linq để sort
            sorted = sorted.OrderByDescending(nuoc => nuoc.TheTich).ToList();
            //B4:foreach để inThoong tin
            foreach (var item in sorted)
            {
                item.InThongTin();
            }

        }
        #endregion
    }
}
