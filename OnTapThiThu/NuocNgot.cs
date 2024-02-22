using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapThiThu
{
    internal class NuocNgot
    {
        //B1: tạo các thuộc tính private
        //lưu ý: ko viết hoa chữ cái đầu
        private string ma;
        private string ten;
        private double luongCalo;
        private int theTich;

        //B2: tạo ctor không thaM số
        // cú pháp: ctor + tab
        public NuocNgot()
        {
            
        }

        //B3: tạo ctor có tham số
        //cú pháp:
        /*
         * 1. bôi đen toàn bộ thuộc tính ở B1
         * 2. ctrl + . (chuột phải quick action and refactoring)
         * 3. Generate constructor .......
        */
        public NuocNgot(string ma, string ten, double luongCalo, int theTich)
        {
            this.ma = ma;
            this.ten = ten;
            this.luongCalo = luongCalo;
            this.theTich = theTich;
        }

        //B4: Tạo các public trung gian của các thuộc tính 
        // để làm việc với các class khác
        //cú pháp:
        /*
         * 1. bôi đen toàn bộ thuộc tính ở B1
         * 2. ctrl + . (chuột phải quick action and refactoring)
         * 3. encapsulate fields (but still use field)
        */

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public double LuongCalo { get => luongCalo; set => luongCalo = value; }
        public int TheTich { get => theTich; set => theTich = value; }

        //B5: hàm in thông tin
        //để phục vụ kế thừa: thêm key word : virtual
        public virtual void InThongTin()
        {
            Console.WriteLine($"{ma} | {ten} | {luongCalo} | {theTich}");
        }

    }
}
