using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapThiThu
{
    internal class NuocNgot0Calo : NuocNgot // : class cần kế thừa
    {
        private string huongVi;

        public NuocNgot0Calo()
        {
            
        }

        //sửa ctor có tham số
        //B1: quay về ctor có tham số của class cha, copy toàn bộ thuộc tính
        //B2: paste vào đầu trước thuộc tính của class con
        //B3: :base(<các thuộc tính đang bị mờ>)
        public NuocNgot0Calo(string ma, string ten, double luongCalo, int theTich, string huongVi):base(ma, ten, luongCalo, theTich)
        {
            this.huongVi = huongVi;
        }

        public string HuongVi { get => huongVi; set => huongVi = value; }

        public override void InThongTin()
        {
            base.InThongTin(); //  Console.WriteLine($"{ma} | {ten} | {luongCalo} | {theTich}");
            Console.WriteLine($"{huongVi}");
        }
    }
}
