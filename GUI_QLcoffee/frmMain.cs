using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLcoffee;

namespace GUI_QLcoffee
{
    public partial class frmMain : Form
    {
        public static string mail;
        public static int vaitro = 0;
        public static bool check = false;
        BUS_NhanVien bus_NhanVien = new BUS_NhanVien();
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Refresh();
            ResetValues();
        }

        public void ResetValues()
        {
            lblNameLogin.Text = "Chào " + frmMain.mail;
            lblUserName.Text = bus_NhanVien.getTenNV(frmMain.mail);
            dangXuatToolStripMenuItem.Visible = true;
            doiMatKhauToolStripMenuItem.Visible = true;
            thoatToolStripMenuItem.Visible = true;
            hoaDonToolStripMenuItem.Visible = true;
            khachHangToolStripMenuItem.Visible = true;
            nhanVienToolStripMenuItem.Visible = true;
            thongKeToolStripMenuItem.Visible = true;
            //unHidencontrol
            lblNameLogin.Visible = true;
            lblTenDN.Visible = true;
            lblTextMain.Visible = true;
            lblUserName.Visible = true;
            lblUser.Visible = true;
            //picMain.Visible = true;
            pnlMain.Visible = true;
            //end
            if (vaitro == 0)
            {
                VaiTroNV();
            }
        }

        public void VaiTroNV()
        {
            thongKeToolStripMenuItem.Visible = false;
            nhanVienToolStripMenuItem.Visible = false;
        }

        public bool CheckExistForm(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public void ActiveChildForm(string name)
        {
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
                
            }
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMK profilenv = new frmDoiMK();
            if (!CheckExistForm("frmDoiMK"))
            {
                this.IsMdiContainer = true;
                profilenv.MdiParent = this;
                profilenv.FormClosed += new FormClosedEventHandler(frmDoiMK_FormClosed);
                profilenv.Show();
                pnlMain.Visible = false;
            }
            else
            {
                ActiveChildForm("frmDoiMK");
            }
        }
        void frmDoiMK_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            frmMain_Load(sender, e);
            if (check == true)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void hoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmHoaDon"))
            {
                this.IsMdiContainer = true;
                frmHoaDon hoaDon = new frmHoaDon(lblUserName.Text);
                hoaDon.MdiParent = this;
                hoaDon.FormClosed += new FormClosedEventHandler(frmHoaDon_FormClosed);
                hoaDon.Show();
                pnlMain.Visible = false;
            }
            else
            {
                ActiveChildForm("frmHoaDon");
            }
        }
        void frmHoaDon_FormClosed(object sender, EventArgs e)
        {
            this.Refresh();
            frmMain_Load(sender, e);
        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmKhachHang"))
            {
                this.IsMdiContainer = true;
                frmKhachHang khachHang = new frmKhachHang();
                khachHang.MdiParent = this;
                khachHang.FormClosed += new FormClosedEventHandler(frmKhachHang_FormClosed);
                khachHang.Show();
                pnlMain.Visible = false;
            }
            else
            {
                ActiveChildForm("frmKhachHang");
            }
        }
        void frmKhachHang_FormClosed(object sender, EventArgs e)
        {
            this.Refresh();
            frmMain_Load(sender, e);
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmNhanVien"))
            {
                this.IsMdiContainer = true;
                frmNhanVien nhanVien = new frmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.FormClosed += new FormClosedEventHandler(frmNhanVien_FormClosed);
                nhanVien.Show();
                pnlMain.Visible = false;
            }
            else
            {
                ActiveChildForm("frmNhanVien");
            }
        }

        void frmNhanVien_FormClosed(object sender, EventArgs e)
        {
            this.Refresh();
            frmMain_Load(sender, e);
        }

        private void thucDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmThucDon"))
            {
                this.IsMdiContainer = true;
                frmThucDon thongKe = new frmThucDon();
                thongKe.MdiParent = this;
                thongKe.FormClosed += new FormClosedEventHandler(frmThucDon_FormClosed);
                thongKe.Show();
                pnlMain.Visible = false;
            }
            else
            {
                ActiveChildForm("frmThucDon");
            }
        }

        void frmThucDon_FormClosed(object sender, EventArgs e)
        {
            this.Refresh();
            frmMain_Load(sender, e);
        }

        private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmThongKe"))
            {
                this.IsMdiContainer = true;
                frmThongKe thongKe = new frmThongKe();
                thongKe.MdiParent = this;
                thongKe.FormClosed += new FormClosedEventHandler(frmThongKe_FormClosed);
                thongKe.Show();
                pnlMain.Visible = false;
            }
            else
            {
                ActiveChildForm("frmThongKe");
            }
        }
        void frmThongKe_FormClosed(object sender, EventArgs e)
        {
            this.Refresh();
            frmMain_Load(sender, e);
        }

        private void huongDanSuDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string file = @"User_manual.docx";
                var path = Path.Combine(Directory.GetCurrentDirectory(), file);
                System.Diagnostics.Process.Start(path);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("The file is not found in the specified location");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file is not found in the specified location");
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
