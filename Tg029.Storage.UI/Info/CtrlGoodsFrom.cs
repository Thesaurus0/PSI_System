/*****************************************************************
 * 
 * 本代码仅供【众志进销存管理系统视频教程】配套学习使用，不得用于
 * 任何商业用途，违者必究！
 * 
 * =====不得传播、转载！=====
 * 
 * 版权所有： 众志教程网(www.tg029.com)
 * 作者    ： 王继彬
 * 
 * *************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tg029.Storage.Model;
using Tg029.Storage.Core;

namespace Tg029.Storage.UI.Info
{
    public partial class CtrlGoodsFrom : UserControl
    {
        public CtrlGoodsFrom()
        {
            InitializeComponent();
        }

        public void RefreshListView()
        {
            ModelService service = new ModelService();
            List<GoodsFrom> modelList =  service.GetAllGoodsFroms();

            this.dataGridView1.Rows.Clear();
            foreach (GoodsFrom model in modelList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell cell = null;
                cell = new DataGridViewCheckBoxCell();
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Code;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Name;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Actived ? "否" : "是";
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Remark;
                row.Cells.Add(cell);

                this.dataGridView1.Rows.Add(row);
                row.Tag = model;
            }

        }

        private List<GoodsFrom> GetSelectedModelList()
        {
            List<GoodsFrom> selectedModelList = new List<GoodsFrom>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.EditedFormattedValue != null && (bool)cell.EditedFormattedValue == true)
                {
                    GoodsFrom selectedStorehouse = (GoodsFrom)row.Tag;
                    selectedModelList.Add(selectedStorehouse);
                }
            }

            if (selectedModelList.Count == 0)
            {
                throw new ApplicationException("请先选择要操作的内容。");
            }
            return selectedModelList;
        }


        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshListView();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            FrmGoodsFrom frm = new FrmGoodsFrom();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.RefreshListView();
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                List<GoodsFrom> selectedModelList = GetSelectedModelList();
                if (selectedModelList.Count != 1)
                {
                    throw new ApplicationException("请选择唯一的内容进行修改。");
                }

                FrmGoodsFrom frm = new FrmGoodsFrom(selectedModelList[0]);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    this.RefreshListView();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<GoodsFrom> selectedModelList = GetSelectedModelList();
                ModelService service = new ModelService();
                foreach (GoodsFrom model in selectedModelList)
                {
                    service.DeleteGoodsFrom(model, PermissionService.GetCurrentUser().Name);
                }
                this.RefreshListView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbDisable_Click(object sender, EventArgs e)
        {
            try
            {
                List<GoodsFrom> selectedModelList = GetSelectedModelList();
                ModelService service = new ModelService();
                foreach (GoodsFrom model in selectedModelList)
                {
                    model.Actived = false;
                    service.SaveGoodsFrom(model, PermissionService.GetCurrentUser().Name);
                }
                this.RefreshListView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbEnable_Click(object sender, EventArgs e)
        {
            try
            {
                List<GoodsFrom> selectedModelList = GetSelectedModelList();
                ModelService service = new ModelService();
                foreach (GoodsFrom model in selectedModelList)
                {
                    model.Actived = true;
                    service.SaveGoodsFrom(model, PermissionService.GetCurrentUser().Name);
                }
                this.RefreshListView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}
