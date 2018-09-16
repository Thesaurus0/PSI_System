namespace Tg029.Storage.UI
{
    partial class FrmStockOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockOut));
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("销货单录入");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("作废我的销货单");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("冲销我的销货单");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("查询我的销货单");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("我的销货单", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("查询全部销货单");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("作废全部销货单");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("冲销全部销货单");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("全部销货单", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("客户退货单录入");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("客户退货单作废");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("退货单查询");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("客户退货", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("按商品汇总销量");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("按品种汇总销量");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("按产地汇总销量");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("按开票员汇总销量");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("销量查询", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35});
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbShowTree = new System.Windows.Forms.ToolStripButton();
            this.tsbHideTree = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowTree,
            this.tsbHideTree});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(530, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbShowTree
            // 
            this.tsbShowTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowTree.Image")));
            this.tsbShowTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowTree.Name = "tsbShowTree";
            this.tsbShowTree.Size = new System.Drawing.Size(89, 24);
            this.tsbShowTree.Text = "显示导航栏";
            this.tsbShowTree.ToolTipText = "显示左侧导航菜单";
            this.tsbShowTree.Click += new System.EventHandler(this.tsbShowTree_Click);
            // 
            // tsbHideTree
            // 
            this.tsbHideTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideTree.Image")));
            this.tsbHideTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideTree.Name = "tsbHideTree";
            this.tsbHideTree.Size = new System.Drawing.Size(89, 24);
            this.tsbHideTree.Text = "隐藏导航栏";
            this.tsbHideTree.ToolTipText = "显示左侧导航菜单";
            this.tsbHideTree.Click += new System.EventHandler(this.tsbHideTree_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(530, 384);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(208, 382);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Indent = 23;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode19.ImageKey = "WRITE1.ICO";
            treeNode19.Name = "节点9";
            treeNode19.SelectedImageKey = "REDTICK.ICO";
            treeNode19.Tag = "录入单据";
            treeNode19.Text = "销货单录入";
            treeNode20.ImageKey = "MISC1096.ICO";
            treeNode20.Name = "节点10";
            treeNode20.SelectedImageKey = "REDTICK.ICO";
            treeNode20.Tag = "作废开票人本人的单据";
            treeNode20.Text = "作废我的销货单";
            treeNode21.ImageKey = "MISC1096.ICO";
            treeNode21.Name = "节点11";
            treeNode21.SelectedImageKey = "REDTICK.ICO";
            treeNode21.Text = "冲销我的销货单";
            treeNode22.ImageKey = "MISC1096.ICO";
            treeNode22.Name = "节点12";
            treeNode22.SelectedImageKey = "REDTICK.ICO";
            treeNode22.Text = "查询我的销货单";
            treeNode23.ImageKey = "reading material.ico";
            treeNode23.Name = "节点8";
            treeNode23.SelectedImageKey = "reading material.ico";
            treeNode23.Tag = "执行操作人所关联的开票工作！";
            treeNode23.Text = "我的销货单";
            treeNode24.ImageKey = "MISC1096.ICO";
            treeNode24.Name = "节点3";
            treeNode24.SelectedImageKey = "REDTICK.ICO";
            treeNode24.Tag = "查询全部开票员的单据";
            treeNode24.Text = "查询全部销货单";
            treeNode25.ImageKey = "MISC1096.ICO";
            treeNode25.Name = "节点1";
            treeNode25.SelectedImageKey = "REDTICK.ICO";
            treeNode25.Text = "作废全部销货单";
            treeNode26.ImageKey = "MISC1096.ICO";
            treeNode26.Name = "节点2";
            treeNode26.SelectedImageKey = "REDTICK.ICO";
            treeNode26.Text = "冲销全部销货单";
            treeNode27.ImageKey = "reading material.ico";
            treeNode27.Name = "节点4";
            treeNode27.SelectedImageKey = "reading material.ico";
            treeNode27.Text = "全部销货单";
            treeNode28.ImageKey = "MISC1096.ICO";
            treeNode28.Name = "节点5";
            treeNode28.SelectedImageKey = "REDTICK.ICO";
            treeNode28.Text = "客户退货单录入";
            treeNode29.ImageKey = "MISC1096.ICO";
            treeNode29.Name = "节点6";
            treeNode29.SelectedImageKey = "REDTICK.ICO";
            treeNode29.Text = "客户退货单作废";
            treeNode30.ImageKey = "MISC1096.ICO";
            treeNode30.Name = "节点7";
            treeNode30.SelectedImageKey = "REDTICK.ICO";
            treeNode30.Text = "退货单查询";
            treeNode31.ImageKey = "reading material.ico";
            treeNode31.Name = "节点4";
            treeNode31.SelectedImageKey = "reading material.ico";
            treeNode31.Text = "客户退货";
            treeNode32.ImageKey = "MISC1096.ICO";
            treeNode32.Name = "节点6";
            treeNode32.SelectedImageKey = "REDTICK.ICO";
            treeNode32.Text = "按商品汇总销量";
            treeNode33.ImageKey = "MISC1096.ICO";
            treeNode33.Name = "节点13";
            treeNode33.SelectedImageKey = "REDTICK.ICO";
            treeNode33.Text = "按品种汇总销量";
            treeNode34.ImageKey = "MISC1096.ICO";
            treeNode34.Name = "节点5";
            treeNode34.SelectedImageKey = "REDTICK.ICO";
            treeNode34.Text = "按产地汇总销量";
            treeNode35.ImageKey = "MISC1096.ICO";
            treeNode35.Name = "节点7";
            treeNode35.SelectedImageKey = "REDTICK.ICO";
            treeNode35.Text = "按开票员汇总销量";
            treeNode36.ImageKey = "reading material.ico";
            treeNode36.Name = "节点0";
            treeNode36.SelectedImageKey = "reading material.ico";
            treeNode36.Text = "销量查询";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode27,
            treeNode31,
            treeNode36});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(208, 300);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MISC1096.ICO");
            this.imageList1.Images.SetKeyName(1, "reading material.ico");
            this.imageList1.Images.SetKeyName(2, "REDTICK.ICO");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明：";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(3, 17);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(199, 58);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // FrmStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 411);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmStockOut";
            this.ShowIcon = false;
            this.Text = "销售出库";
            this.Load += new System.EventHandler(this.FrmStockIN_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbShowTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ToolStripButton tsbHideTree;
    }
}