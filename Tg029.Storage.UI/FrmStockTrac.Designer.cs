namespace Tg029.Storage.UI
{
    partial class FrmStockTrac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockTrac));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("调拨出库单");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("调拨出库单作废");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("调拨出库", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("调拨入库单");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("调拨入库单作废");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("调拨入库", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("调拨出库单查询");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("调拨入库单查询");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("调拨单查询", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(533, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(89, 24);
            this.toolStripButton1.Text = "显示导航栏";
            this.toolStripButton1.ToolTipText = "显示左侧导航菜单";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(89, 24);
            this.toolStripButton2.Text = "隐藏导航栏";
            this.toolStripButton2.ToolTipText = "显示左侧导航菜单";
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
            this.splitContainer1.Size = new System.Drawing.Size(533, 371);
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
            this.splitContainer2.Size = new System.Drawing.Size(208, 369);
            this.splitContainer2.SplitterDistance = 287;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Indent = 23;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "WRITE1.ICO";
            treeNode1.Name = "节点9";
            treeNode1.SelectedImageKey = "REDTICK.ICO";
            treeNode1.Tag = "录入单据";
            treeNode1.Text = "调拨出库单";
            treeNode2.ImageKey = "MISC1096.ICO";
            treeNode2.Name = "节点10";
            treeNode2.SelectedImageKey = "REDTICK.ICO";
            treeNode2.Tag = "作废开票人本人的单据";
            treeNode2.Text = "调拨出库单作废";
            treeNode3.ImageKey = "reading material.ico";
            treeNode3.Name = "节点8";
            treeNode3.SelectedImageKey = "reading material.ico";
            treeNode3.Tag = "执行操作人所关联的开票工作！";
            treeNode3.Text = "调拨出库";
            treeNode4.ImageKey = "MISC1096.ICO";
            treeNode4.Name = "节点3";
            treeNode4.SelectedImageKey = "REDTICK.ICO";
            treeNode4.Tag = "查询全部开票员的单据";
            treeNode4.Text = "调拨入库单";
            treeNode5.ImageKey = "MISC1096.ICO";
            treeNode5.Name = "节点1";
            treeNode5.SelectedImageKey = "REDTICK.ICO";
            treeNode5.Text = "调拨入库单作废";
            treeNode6.ImageKey = "reading material.ico";
            treeNode6.Name = "节点4";
            treeNode6.SelectedImageKey = "reading material.ico";
            treeNode6.Text = "调拨入库";
            treeNode7.ImageKey = "MISC1096.ICO";
            treeNode7.Name = "节点6";
            treeNode7.SelectedImageKey = "REDTICK.ICO";
            treeNode7.Text = "调拨出库单查询";
            treeNode8.ImageKey = "MISC1096.ICO";
            treeNode8.Name = "节点13";
            treeNode8.SelectedImageKey = "REDTICK.ICO";
            treeNode8.Text = "调拨入库单查询";
            treeNode9.ImageKey = "reading material.ico";
            treeNode9.Name = "节点0";
            treeNode9.SelectedImageKey = "reading material.ico";
            treeNode9.Text = "调拨单查询";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(208, 287);
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
            // FrmStockTrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 398);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmStockTrac";
            this.ShowIcon = false;
            this.Text = "调拨";
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}