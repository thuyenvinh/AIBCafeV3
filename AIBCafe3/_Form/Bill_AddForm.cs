using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;

namespace AIBCafe3
{
    public partial class Bill_AddForm : DevExpress.XtraEditors.XtraForm
    {
        public Bill_AddForm()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        IniWorker ini = new IniWorker("/Setting.ini", true);
        private void Bill_AddForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 15000;
            timer1.Start();
            employeeBindingSource.DataSource = Program.cafe.Employees.ToList();
            orderTypeBindingSource.DataSource = Program.cafe.OrderTypes.ToList();
            productGroupBindingSource.DataSource = Program.cafe.ProductGroups.OrderBy(p => p.DisplayOrder).Where(p => p.ProductGroupID != ClassInfo.ThoiGianID); ;
            aibSoftListView1.bind();

            productBindingSource.DataSource = Program.cafe.Products
                .OrderBy(p => p.DisplayOrder)
                .Where(p => p.Active == true)
                .Where(p => p.Show == true).Where(p => p.ProductID != ClassInfo.ThoiGianID).ToList();

            unitBindingSource.DataSource = Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID); ;
            productBindingSource1.DataSource = Program.cafe.Products;
            gridView1.ExpandAllGroups();
            var View1 = ini.IniReadValue("View", "CheDo");
            switch (View1)
            {
                case "Tile":
                    aibSoftListView1.View = View.Tile;
                    break;
                case "LargeIcon":
                    aibSoftListView1.View = View.LargeIcon;
                    break;
                case "List":
                    aibSoftListView1.View = View.List;
                    break;
                case "SmallIcon":
                    aibSoftListView1.View = View.SmallIcon;
                    break;
                default:
                    aibSoftListView1.View = View.SmallIcon;
                    break;

            }
            Cursor.Current = Cursors.Default;

        }
        /// <summary>
        /// Nhấp đôi chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aibSoftListView1_ItemActivate(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (aibSoftListView1.SelectedItems.Count >= 1)
            {
                if (aibSoftListView1.SelectedItems[0].ImageIndex == 1)
                {
                    //Tự cập nhật h ra cho Ngàn lộc// 3 dòng
                    timeEdit2.EditValue = DateTime.Now;
                    billBindingSource.EndEdit();
                    Program.cafe.SaveChanges();
                    var a = Guid.Parse(iniClass.IniReadValue("HoaDon", aibSoftListView1.SelectedItems[0].Name));
                    Rpt_BillForm frm = new Rpt_BillForm(a, (Guid.Parse(aibSoftListView1.SelectedItems[0].Name.Trim().ToString())));
                    frm.ShowDialog();
                    aibSoftListView1.bind();

                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng chọn bàn tính tiền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        // int currentIndex = 0;
        private void aibSoftListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (aibSoftListView1.SelectedItems.Count >= 1)
            {
                groupControl1.Text = aibSoftListView1.SelectedItems[0].Text.ToUpper() + " (" + ini.IniReadValue("Phieu", aibSoftListView1.SelectedItems[0].Name.ToString()) + ")";
                LoadChitiet(aibSoftListView1.SelectedItems[0]);
            }
            Cursor.Current = Cursors.Default;
        }

        private void simpleButtonHuyBan_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            aibSoftListView1.SelectedItems[0].ImageIndex = 1;
            Cursor.Current = Cursors.Default;
        }

        void ThemBillmoi(ListViewItem lvBan, Guid _Product, decimal _Price, int _Quantity)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (lvBan.ImageIndex == 1) //Có khách
            {
                var BillID = GetBillID_Ban(lvBan);
                if (BillID != null)//Có lưu hóa hóa đơn trong file ini không?
                {
                    //Lấy toàn bộ hóa đơn chi tiết của hóa đơn
                    var HoaDon_ChiTiet_Tam = Program.cafe.BillDetails
                        .Where(p => p.BillID == BillID).ToList();

                    if (HoaDon_ChiTiet_Tam != null)
                    {
                        var HoaDon_ChiTiet = HoaDon_ChiTiet_Tam.ToList();
                        if (HoaDon_ChiTiet.Count >= 1)
                        {
                            //Lấy hóa đơn chi tiết theo thực đơn của danh sách hóa đơn
                            var tem2 = HoaDon_ChiTiet.Where(p => p.ProductID == _Product).ToList();
                            if (tem2.Count >= 1)
                            {
                                var Product_in_BillDetail = tem2.Select(p => p.ProductID).Single();
                                ///////
                                var a = (from p in Program.cafe.BillDetails
                                         where p.ProductID == Product_in_BillDetail &&
                                           p.BillID == BillID
                                         select p).Single();
                                a.Quantity += _Quantity;
                            }
                            else // Chưa có thì thêm vào
                            {
                                BillDetail bdt = new BillDetail();
                                bdt.BillDetailID = Guid.NewGuid();
                                bdt.BillID = BillID.Value;

                                bdt.ProductID = _Product;
                                bdt.Quantity = _Quantity;
                                bdt.Price = _Price;
                                Program.cafe.AddToBillDetails(bdt);
                                Program.cafe.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bàn này đánh dấu là có khách nhưng không tìm thấy gọi món nào hết!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không ghi được file vui lòng liên hệ nhà cung cấp để sửa lỗi!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    // 
                }
                //var bidDetai = cafe.BillDetails.Where(p=>p.BillID=
            }
            else //Không có khách
            {
                Bill _bill = new Bill();
                _bill.BillID = Guid.NewGuid();
                iniClass.IniWriteValue("HoaDon", lvBan.Name, _bill.BillID.ToString());
                string inc = iniClass.IniReadValue("TuTang", "TuTang");

                _bill.Amount = 0;
                _bill.Date = DateTime.Now;
                _bill.DateEnd = DateTime.Now;
                int inc1 = 0;
                _bill.Description = (!int.TryParse(inc, out inc1) ? 0 : inc1 + 1).ToString();
                iniClass.IniWriteValue("TuTang", "TuTang", (inc1 + 1).ToString());
                _bill.Discount = 0;
                _bill.EmployeesID = ClassInfo.NhanVien;
                _bill.ItemID = Guid.Parse(lvBan.Name);
                Program.cafe.AddToBills(_bill);

                var nhomBan = Guid.Parse(lvBan.Group.Name);
                var tGian = Program.cafe.ItemTypes.Where(p => p.ItemTypeID == nhomBan).FirstOrDefault();
                if (tGian.Timing.Value == true)
                {

                    BillDetail _bdt1 = new BillDetail();
                    _bdt1.BillDetailID = Guid.NewGuid();
                    _bdt1.BillID = _bill.BillID;
                    _bdt1.Price = tGian.Price;
                    _bdt1.ProductID = ClassInfo.ThoiGianID;
                    _bdt1.Quantity = 0.25F;
                    Program.cafe.AddToBillDetails(_bdt1);
                }

                BillDetail _bdt = new BillDetail();
                _bdt.BillDetailID = Guid.NewGuid();
                _bdt.BillID = _bill.BillID;
                _bdt.Price = _Price;
                _bdt.ProductID = _Product;
                _bdt.Quantity = 1;
                Program.cafe.AddToBillDetails(_bdt);
                lvBan.ImageIndex = 1;
                iniClass.IniWriteValue("Ban", lvBan.Name, "1");
                Program.cafe.SaveChanges();

            }
            Cursor.Current = Cursors.Default;
        }

        void CapNhatTongTien(byte Discount, ListViewItem _Ban)
        {
            //var t1 = Environment.TickCount;
            Cursor.Current = Cursors.WaitCursor;
            if (timeEdit2.EditValue.ToString() == "" || timeEdit1.EditValue.ToString() == "")
            {
                timeEdit2.EditValue = DateTime.Now;
                timeEdit1.EditValue = DateTime.Now;
            }
            var nhomBan = Guid.Parse(_Ban.Group.Name);
            var TinhTGian = Program.cafe.ItemTypes.Where(p => p.ItemTypeID == nhomBan).First();
            var IDHoaDon = GetBillID_Ban(_Ban);
            //
            if (IDHoaDon != null)
            {
                if (TinhTGian.Timing.Value)
                {
                    var tt = Program.cafe.BillDetails
                          .Where(p => p.BillID == IDHoaDon)
                          .Where(t => t.ProductID == ClassInfo.ThoiGianID)
                          .First();
                    var Phutc = ((DateTime)timeEdit2.EditValue - (DateTime)timeEdit1.EditValue).TotalMinutes;
                    tt.Quantity = (float)Math.Round((float)Phutc / (float)60, 2);
                    //Program.cafe.SaveChanges();
                }
                //  Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.BillDetails);
                var HoaDoChiTiet = Program.cafe.BillDetails.Where(p => p.BillID == IDHoaDon).ToList();
                decimal TongTien = 0;
                foreach (var item in HoaDoChiTiet)
                {
                    TongTien += (Convert.ToDecimal(item.Quantity.Value) * item.Price.Value);
                }
                var c = Program.cafe.Bills.Where(p => p.BillID == IDHoaDon).Single();
                c.Amount = TongTien;
                c.Discount = Discount;
                //Program.cafe.SaveChanges();
                ini.IniWriteValue("Phieu", _Ban.Name.ToString(), c.Amount.Value.ToString());
            }
            Program.cafe.SaveChanges();
            Cursor.Current = Cursors.Default;

            // var t2 = Environment.TickCount;
            //MessageBox.Show("Cập nhật thời gian " + (t2-t1).ToString());
        }

        Guid? GetBillID_Ban(ListViewItem Ban)
        {
            string a = iniClass.IniReadValue("HoaDon", Ban.Name);
            // return (a == "") ? null:Guid.Parse(a);
            if (a == "")
            {
                return null;
            }
            else
            {
                return Guid.Parse(a);
            }
        }

        void LoadChitiet(ListViewItem _Ban)
        {
            if (_Ban.ImageIndex == 1)
            {
                Guid? bid = GetBillID_Ban(_Ban);
                if (bid != null)
                {
                    billBindingSource.DataSource = Program.cafe.Bills.Where(p => p.BillID == bid).ToList();
                    var _BillDetail = Program.cafe.BillDetails.Where(p => p.BillID == bid).ToList();

                    billDetailBindingSource.DataSource = _BillDetail;
                }
                else
                {
                    billDetailBindingSource.DataSource = typeof(BillDetail);
                }
            }
            else
            {
                billDetailBindingSource.DataSource = typeof(BillDetail);
                billBindingSource.DataSource = typeof(Bill);
            }
        }
        void ChuyenBan(ListViewItem _BanChuyenDi, ListViewItem _BanChuyenDen)
        {
            if (_BanChuyenDen.ImageIndex == 1)// Bàn chuyển đến có khách
            {
                var C_ID_HoaDonChuyen_Den = GetBillID_Ban(_BanChuyenDen);
                var C_ID_HoaDonChuyen_Di = GetBillID_Ban(_BanChuyenDi);

                if (C_ID_HoaDonChuyen_Den != null && C_ID_HoaDonChuyen_Di != null)
                {
                    var C_HoaDonChiTietChuyen_Di_Tam = Program.cafe.BillDetails.Where(p => p.BillID == C_ID_HoaDonChuyen_Di.Value);
                    var C_HoaDonChiTietChuyen_Den_Tam = Program.cafe.BillDetails.Where(p => p.BillID == C_ID_HoaDonChuyen_Den.Value);
                    if (C_HoaDonChiTietChuyen_Di_Tam != null && C_HoaDonChiTietChuyen_Den_Tam != null)
                    {
                        var C_HoaDonChiTietChuyen_Di = C_HoaDonChiTietChuyen_Di_Tam.ToList();
                        var C_HoaDonChiTietChuyen_Den = C_HoaDonChiTietChuyen_Den_Tam.ToList();
                        foreach (var item in C_HoaDonChiTietChuyen_Di)
                        {
                            ThemBillmoi(_BanChuyenDen, item.ProductID.Value, item.Price.Value, (int)item.Quantity.Value);
                            Program.cafe.DeleteObject(item);
                        }

                        _BanChuyenDi.ImageIndex = 0;
                        _BanChuyenDen.ImageIndex = 1;

                        iniClass.IniWriteValue("HoaDon", _BanChuyenDi.Name, "");
                        iniClass.IniWriteValue("HoaDon", _BanChuyenDen.Name, C_ID_HoaDonChuyen_Den.ToString());

                        iniClass.IniWriteValue("Ban", _BanChuyenDi.Name, "0");
                        iniClass.IniWriteValue("Ban", _BanChuyenDen.Name, "1");
                        // cafe.DeleteObject(cafe.Bills.Where(p => p.BillID == C_ID_HoaDonChuyen_Di));
                        Program.cafe.SaveChanges();

                    }
                }
            }
            else //Bàn chuyển đến không có khách
            {
                var ID_HoaDon_ChuyenDi = GetBillID_Ban(_BanChuyenDi);
                // var ID_HoaDon_ChuyenDen = GetBillID_Ban(_BanChuyenDen);
                if (ID_HoaDon_ChuyenDi != null)
                {
                    var HoaDon_Tam = Program.cafe.Bills.Where(p => p.BillID == ID_HoaDon_ChuyenDi.Value);
                    if (HoaDon_Tam.ToList().Count >= 1)
                    {
                        var HoaDon = HoaDon_Tam.First();
                        HoaDon.ItemID = Guid.Parse(_BanChuyenDen.Name);
                        //HoaDon.Description = string.Format("Chuyển từ {0} sang ", _BanChuyenDi.Text.Trim());
                        _BanChuyenDi.ImageIndex = 0;
                        _BanChuyenDen.ImageIndex = 1;

                        iniClass.IniWriteValue("HoaDon", _BanChuyenDi.Name, "");
                        iniClass.IniWriteValue("HoaDon", _BanChuyenDen.Name, HoaDon.BillID.ToString());

                        iniClass.IniWriteValue("Ban", _BanChuyenDi.Name, "0");
                        iniClass.IniWriteValue("Ban", _BanChuyenDen.Name, "1");

                        Program.cafe.SaveChanges();
                    }
                }
            }
        }
        private void aibSoftListView1_DragDrop(object sender, DragEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            ListViewItem t = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            ListViewItem itm1 = new ListViewItem();
            Point clientPoint = aibSoftListView1.PointToClient(new Point(e.X, e.Y));
            itm1 = aibSoftListView1.GetItemAt(clientPoint.X, clientPoint.Y);
            if (itm1 != null)
            {
                if (t != itm1)
                {
                    if (MessageBox.Show("Bạn có muốn chuyển bàn không?", "Xác nhận?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (t != itm1)
                        {
                            ChuyenBan(t, itm1);
                            CapNhatTongTien(0, itm1);
                            itm1.Selected = false;
                            itm1.Selected = true;
                        }
                    }

                }
            }
        }
        //Hiệu ứng cho con trỏ chuột trên lưới chi tiết 2
        private void gridControl1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                e.UseDefaultCursors = false;
                gCursorLib.gCursor a = new gCursorLib.gCursor();
                a.gText = pt.ProductName;
                a.gHotSpot = ContentAlignment.TopLeft;
                a.gEffect = gCursorLib.gCursor.eEffect.Copy;
                a.MakeCursor(true);
                Cursor.Current = a.gCursor;
            }
        }

        //Nhấp đôi chuột
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.RowHandle >= 0)
                {
                    if (aibSoftListView1.SelectedItems.Count >= 1)
                    {
                        var lp = (IEnumerable<Product>)productBindingSource.DataSource;

                        var pl = lp.Where(p => p._Check == true).ToList();
                        if (pl.Count >= 1)
                        {
                            foreach (var item in pl)
                            {
                                ThemBillmoi(aibSoftListView1.SelectedItems[0], item.ProductID, item.Price.Value, 1);
                                item._Check = false;
                            }
                        }
                        else
                        {
                            Product pt = productBindingSource.Current as Product;
                            if (aibSoftListView1.SelectedItems.Count == 1)
                            {
                                ThemBillmoi(aibSoftListView1.SelectedItems[0], pt.ProductID, (decimal)pt.Price, 1);
                                //  CapNhatTongTien(0, aibSoftListView1.SelectedItems[0]);
                                //   LoadChitiet(aibSoftListView1.SelectedItems[0]);
                            }
                        }
                        CapNhatTongTien((byte)GiamGia_spinEdit.Value, aibSoftListView1.SelectedItems[0]);
                        LoadChitiet(aibSoftListView1.SelectedItems[0]);
                        productBindingSource.ResetBindings(false);
                        gridView1.RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("Xin vui lòng chọn một bàn để thêm thực đơn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        bool drop = false;
        Product pt;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            view.FocusedRowHandle = hitInfo.RowHandle;
            var hit = view.CalcHitInfo(e.Location);

            if (hit.RowHandle >= 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pt = productBindingSource.Current as Product;
                AllowDrop = true;
                drop = true;
            }
            else
            {
                drop = false;
            }
        }

        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && drop)
            {
                gridControl1.DoDragDrop(pt, DragDropEffects.All);
                drop = false;
            }
        }

        private void gridControl2_DragOver(object sender, DragEventArgs e)
        {
            var pt = e.Data.GetData(typeof(Product));
            if (pt != null)
            {
                e.Effect = DragDropEffects.Copy;
            };
        }

        private void gridControl2_DragDrop(object sender, DragEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (aibSoftListView1.SelectedItems.Count == 1)
            {
                var pt = e.Data.GetData(typeof(Product));
                if (pt != null)
                {
                    var lp = (IEnumerable<Product>)productBindingSource.DataSource;

                    var pl = lp.Where(p => p._Check == true).ToList();
                    if (pl.Count >= 1)
                    {
                        foreach (var item in pl)
                        {
                            ThemBillmoi(aibSoftListView1.SelectedItems[0], item.ProductID, item.Price.Value, 1);
                            item._Check = false;
                        }
                    }
                    else
                    {
                        //MessageBox.Show((pt as Product).ProductName);
                        Product ps = new Product();
                        ps = pt as Product;
                        ThemBillmoi(aibSoftListView1.SelectedItems[0], ps.ProductID, ps.Price.Value, 1);
                    }
                    CapNhatTongTien((byte)GiamGia_spinEdit.Value, aibSoftListView1.SelectedItems[0]);
                    LoadChitiet(aibSoftListView1.SelectedItems[0]);
                    productBindingSource.ResetBindings(false);
                    gridView1.RefreshData();
                }
            }
            Cursor.Current = Cursors.WaitCursor;
        }

        #region Kéo trên Bàn




        private void aibSoftListView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem lvit = new ListViewItem();
            lvit = (ListViewItem)e.Item;
            if (lvit.ImageIndex == 1)
            {
                aibSoftListView1.DoDragDrop(e.Item, DragDropEffects.Move);
            }

        }

        private void aibSoftListView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem itm1 = new ListViewItem();
                Point clientPoint = aibSoftListView1.PointToClient(new Point(e.X, e.Y));
                itm1 = aibSoftListView1.GetItemAt(clientPoint.X, clientPoint.Y);
                if (itm1 != null)
                {
                    e.Effect = DragDropEffects.Move;
                    itm1.Selected = true;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void aibSoftListView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem a;
                a = aibSoftListView1.GetItemAt(e.X, e.Y);
                if (a != null)
                {
                    if (a.ImageIndex != 10)
                    {
                        popupMenu1.ShowPopup(new Point(Cursor.Position.X, Cursor.Position.Y)); //(this, new Point(e.X, e.Y));
                    }
                }
            }

        }

        private void aibSoftListView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                e.UseDefaultCursors = false;
                gCursorLib.gCursor a = new gCursorLib.gCursor();
                a.gText = pt.ProductName;
                a.gHotSpot = System.Drawing.ContentAlignment.TopLeft;
                a.gEffect = gCursorLib.gCursor.eEffect.Copy;
                a.MakeCursor(true);
                Cursor.Current = a.gCursor;
            }
        }

        #endregion

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (aibSoftListView1.SelectedItems.Count == 1)
            {
                var a = (productBindingSource.DataSource as IEnumerable<Product>).Where(p => p._Check).ToList();
                foreach (var item in a)
                {
                    ThemBillmoi(aibSoftListView1.SelectedItems[0], item.ProductID, (decimal)item.Price, 1);
                    item._Check = false;
                }
                gridView1.RefreshData();
                LoadChitiet(aibSoftListView1.SelectedItems[0]);
            }
            Cursor.Current = Cursors.Default;
        }


        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aibSoftListView1.View = View.SmallIcon;
            ini.IniWriteValue("View", "CheDo", "SmallIcon");
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aibSoftListView1.View = View.LargeIcon;
            ini.IniWriteValue("View", "CheDo", "LargeIcon");
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aibSoftListView1.View = View.Tile;
            ini.IniWriteValue("View", "CheDo", "Tile");
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aibSoftListView1.View = View.List;
            ini.IniWriteValue("View", "CheDo", "List");
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (aibSoftListView1.SelectedItems.Count >= 1)
            {
                Program.cafe.SaveChanges();
                CapNhatTongTien(0, aibSoftListView1.SelectedItems[0]);
            }

        }

        private void gridView2_RowClick(object sender, RowClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Clicks == 2)
            {
                if (e.RowHandle >= 0)
                {
                    if (aibSoftListView1.SelectedItems.Count >= 1)
                    {
                        if (billDetailBindingSource.Position >= 0)
                        {
                            //  if (((BillDetail)billDetailBindingSource.Current).ProductID != ClassInfo.ThoiGianID)
                            //  {
                            var bill = Guid.Parse(iniClass.IniReadValue("HoaDon", aibSoftListView1.SelectedItems[0].Name));
                            var n = Guid.Parse(aibSoftListView1.SelectedItems[0].Group.Name);
                            var billcheck = Program.cafe.BillDetails.Where(p => p.BillID == bill).Where(t => t.ProductID != n).ToList();
                            Program.cafe.BillDetails.DeleteObject((BillDetail)billDetailBindingSource.Current);
                            billDetailBindingSource.RemoveCurrent();
                            Program.cafe.SaveChanges();
                            if (billcheck.Count == 1) //Kiểm tra nếu bàn còn có món nào không?
                            {
                                Bill del = Program.cafe.Bills.Where(p => p.BillID == bill).First();
                                Program.cafe.Bills.DeleteObject(del);

                                aibSoftListView1.SelectedItems[0].ImageIndex = 0;
                                iniClass.IniWriteValue("Ban", aibSoftListView1.SelectedItems[0].Name.ToString(), "0");
                                iniClass.IniWriteValue("HoaDon", aibSoftListView1.SelectedItems[0].Name.ToString(), "");
                                Program.cafe.SaveChanges();
                            }
                            CapNhatTongTien((byte)GiamGia_spinEdit.Value, aibSoftListView1.SelectedItems[0]);
                            //  }
                            //  else
                            //  {
                            //      MessageBox.Show("Không thể xóa thời gian đi được","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //  }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (aibSoftListView1.SelectedItems.Count >= 1)
            {
                if (aibSoftListView1.SelectedItems[0].ImageIndex == 1)
                {
                    //Tự cập nhật h ra cho Ngàn lộc// 3 dòng
                    timeEdit2.EditValue = DateTime.Now;
                    billBindingSource.EndEdit();
                    Program.cafe.SaveChanges();
                    var a = Guid.Parse(iniClass.IniReadValue("HoaDon", aibSoftListView1.SelectedItems[0].Name));
                    Rpt_BillForm frm = new Rpt_BillForm(a, (Guid.Parse(aibSoftListView1.SelectedItems[0].Name.ToString())));
                    frm.ShowDialog();
                    aibSoftListView1.bind();
                }
                else
                {
                    MessageBox.Show("Bàn đang chọn không có khách, vui lòng chọn bàn có khách để tính tiền", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("xin vui lòng chọn một bàn để tính tiền", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tong_spinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (GiamGia_spinEdit.Value >= 0 && GiamGia_spinEdit.Value <= 100)
            {
                GiaTriGiam_spinEdit.Value = (Tong_spinEdit.Value * (GiamGia_spinEdit.Value)) / 100;
                ConLai_spinEdit.Value = Tong_spinEdit.Value - GiaTriGiam_spinEdit.Value;
            }
        }

        private void GiamGia_spinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (GiamGia_spinEdit.Value >= 0 && GiamGia_spinEdit.Value <= 100)
            {
                GiaTriGiam_spinEdit.Value = (Tong_spinEdit.Value * (GiamGia_spinEdit.Value)) / 100;
                ConLai_spinEdit.Value = Tong_spinEdit.Value - GiaTriGiam_spinEdit.Value;
            }
        }

        private void GiaTriGiam_spinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //  productBindingSource.Filter =
            this.colProductName.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ProductName LIKE '{0}%'", textEdit1.Text)); ;
            //string.Format( "ProductName LIKE '{0}%'",textEdit1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aibSoftListView1.SelectedItems.Count >= 1)
            {
                if (aibSoftListView1.SelectedItems[0].ImageIndex == 1)
                {
                    timeEdit2.EditValue = DateTime.Now;
                }
            }

        }

        private void timeEdit2_Enter(object sender, EventArgs e)
        {
            timeEdit2.EditValue = DateTime.Now;
        }

        private void timeEdit2_Leave(object sender, EventArgs e)
        {
            if (aibSoftListView1.SelectedItems.Count == 1)
            {
                var a = timeEdit1.EditValue;
                timeEdit1.EditValue = a;
                var b = timeEdit2.EditValue;
                timeEdit2.EditValue = b;
                billBindingSource.EndEdit();
                if (GiamGia_spinEdit.Text == "")
                {
                    CapNhatTongTien((byte)0, aibSoftListView1.SelectedItems[0]);
                }
                else
                {
                    CapNhatTongTien(byte.Parse("0" + GiamGia_spinEdit.EditValue.ToString()), aibSoftListView1.SelectedItems[0]);
                }

                Program.cafe.SaveChanges();
            }
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            textEdit1.SelectAll();
        }

        private void textEdit1_Enter(object sender, EventArgs e)
        {
            textEdit1.SelectAll();
        }

        private void simpleButtonTinhTien_Click(object sender, EventArgs e)
        {
            if (aibSoftListView1.SelectedItems.Count >= 1)
            {
                if (aibSoftListView1.SelectedItems[0].ImageIndex == 1)
                {
                    var a = Guid.Parse(iniClass.IniReadValue("HoaDon", aibSoftListView1.SelectedItems[0].Name));
                    Rpt_BillForm frm = new Rpt_BillForm(a, (Guid.Parse(aibSoftListView1.SelectedItems[0].Name.ToString())));
                    frm.ShowDialog();
                    aibSoftListView1.bind();
                }
                else
                {
                    MessageBox.Show("Bàn đang chọn không có khách, vui lòng chọn bàn có khách để tính tiền", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("xin vui lòng chọn một bàn để tính tiền", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void aibSoftListView1_DragLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}