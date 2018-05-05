namespace PCJ_System
{
    partial class Stocks_Gems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stocks_Gems));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrefresh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuMetroTextbox1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noofpiecesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gemTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noofGemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noofotherGemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherGemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightofotherGemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagepathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pCJ_SYSTEM_DBDataSet2 = new PCJ_System.PCJ_SYSTEM_DBDataSet2();
            this.stock_EntryTableAdapter = new PCJ_System.PCJ_SYSTEM_DBDataSet2TableAdapters.Stock_EntryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCJ_SYSTEM_DBDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 31);
            this.label3.TabIndex = 33;
            this.label3.Text = "Stocks [ Gem ]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnrefresh.BackColor = System.Drawing.Color.DarkCyan;
            this.btnrefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrefresh.BorderRadius = 0;
            this.btnrefresh.ButtonText = "   Refresh";
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.DisabledColor = System.Drawing.Color.Gray;
            this.btnrefresh.Iconcolor = System.Drawing.Color.Transparent;
            this.btnrefresh.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Iconimage")));
            this.btnrefresh.Iconimage_right = null;
            this.btnrefresh.Iconimage_right_Selected = null;
            this.btnrefresh.Iconimage_Selected = null;
            this.btnrefresh.IconMarginLeft = 0;
            this.btnrefresh.IconMarginRight = 0;
            this.btnrefresh.IconRightVisible = true;
            this.btnrefresh.IconRightZoom = 0D;
            this.btnrefresh.IconVisible = true;
            this.btnrefresh.IconZoom = 60D;
            this.btnrefresh.IsTab = false;
            this.btnrefresh.Location = new System.Drawing.Point(202, 98);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Normalcolor = System.Drawing.Color.DarkCyan;
            this.btnrefresh.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnrefresh.OnHoverTextColor = System.Drawing.Color.White;
            this.btnrefresh.selected = false;
            this.btnrefresh.Size = new System.Drawing.Size(136, 37);
            this.btnrefresh.TabIndex = 42;
            this.btnrefresh.Text = "   Refresh";
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Textcolor = System.Drawing.Color.White;
            this.btnrefresh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.DarkCyan;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "  Add Stock";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.ForeColor = System.Drawing.Color.Coral;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 60D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(53, 98);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.DarkCyan;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(136, 37);
            this.bunifuFlatButton1.TabIndex = 40;
            this.bunifuFlatButton1.Text = "  Add Stock";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // bunifuMetroTextbox1
            // 
            this.bunifuMetroTextbox1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuMetroTextbox1.BorderColorFocused = System.Drawing.Color.AliceBlue;
            this.bunifuMetroTextbox1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox1.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.bunifuMetroTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuMetroTextbox1.BorderThickness = 1;
            this.bunifuMetroTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuMetroTextbox1.ForeColor = System.Drawing.Color.Black;
            this.bunifuMetroTextbox1.isPassword = false;
            this.bunifuMetroTextbox1.Location = new System.Drawing.Point(988, 102);
            this.bunifuMetroTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMetroTextbox1.Name = "bunifuMetroTextbox1";
            this.bunifuMetroTextbox1.Size = new System.Drawing.Size(174, 27);
            this.bunifuMetroTextbox1.TabIndex = 63;
            this.bunifuMetroTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuMetroTextbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bunifuMetroTextbox1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(864, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Search Stock  :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.stockTypeDataGridViewTextBoxColumn,
            this.stockNoDataGridViewTextBoxColumn,
            this.noofpiecesDataGridViewTextBoxColumn,
            this.gemTypeDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.itemDescriptionDataGridViewTextBoxColumn,
            this.itemTypeDataGridViewTextBoxColumn,
            this.noofGemsDataGridViewTextBoxColumn,
            this.noofotherGemsDataGridViewTextBoxColumn,
            this.otherGemsDataGridViewTextBoxColumn,
            this.weightofotherGemsDataGridViewTextBoxColumn,
            this.imageDataGridViewImageColumn,
            this.costDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.updateUserIDDataGridViewTextBoxColumn,
            this.imagepathDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.stockEntryBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(52, 179);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1110, 650);
            this.dataGridView1.TabIndex = 64;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // stockTypeDataGridViewTextBoxColumn
            // 
            this.stockTypeDataGridViewTextBoxColumn.DataPropertyName = "Stock_Type";
            this.stockTypeDataGridViewTextBoxColumn.HeaderText = "Stock_Type";
            this.stockTypeDataGridViewTextBoxColumn.Name = "stockTypeDataGridViewTextBoxColumn";
            // 
            // stockNoDataGridViewTextBoxColumn
            // 
            this.stockNoDataGridViewTextBoxColumn.DataPropertyName = "Stock_No";
            this.stockNoDataGridViewTextBoxColumn.HeaderText = "Stock_No";
            this.stockNoDataGridViewTextBoxColumn.Name = "stockNoDataGridViewTextBoxColumn";
            // 
            // noofpiecesDataGridViewTextBoxColumn
            // 
            this.noofpiecesDataGridViewTextBoxColumn.DataPropertyName = "No_of_pieces";
            this.noofpiecesDataGridViewTextBoxColumn.HeaderText = "No_of_pieces";
            this.noofpiecesDataGridViewTextBoxColumn.Name = "noofpiecesDataGridViewTextBoxColumn";
            // 
            // gemTypeDataGridViewTextBoxColumn
            // 
            this.gemTypeDataGridViewTextBoxColumn.DataPropertyName = "Gem_Type";
            this.gemTypeDataGridViewTextBoxColumn.HeaderText = "Gem_Type";
            this.gemTypeDataGridViewTextBoxColumn.Name = "gemTypeDataGridViewTextBoxColumn";
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "Weight";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            // 
            // itemDescriptionDataGridViewTextBoxColumn
            // 
            this.itemDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Item_Description";
            this.itemDescriptionDataGridViewTextBoxColumn.HeaderText = "Item_Description";
            this.itemDescriptionDataGridViewTextBoxColumn.Name = "itemDescriptionDataGridViewTextBoxColumn";
            this.itemDescriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemTypeDataGridViewTextBoxColumn
            // 
            this.itemTypeDataGridViewTextBoxColumn.DataPropertyName = "Item_Type";
            this.itemTypeDataGridViewTextBoxColumn.HeaderText = "Item_Type";
            this.itemTypeDataGridViewTextBoxColumn.Name = "itemTypeDataGridViewTextBoxColumn";
            this.itemTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // noofGemsDataGridViewTextBoxColumn
            // 
            this.noofGemsDataGridViewTextBoxColumn.DataPropertyName = "No_of_Gems";
            this.noofGemsDataGridViewTextBoxColumn.HeaderText = "No_of_Gems";
            this.noofGemsDataGridViewTextBoxColumn.Name = "noofGemsDataGridViewTextBoxColumn";
            this.noofGemsDataGridViewTextBoxColumn.Visible = false;
            // 
            // noofotherGemsDataGridViewTextBoxColumn
            // 
            this.noofotherGemsDataGridViewTextBoxColumn.DataPropertyName = "No_of_other_Gems";
            this.noofotherGemsDataGridViewTextBoxColumn.HeaderText = "No_of_other_Gems";
            this.noofotherGemsDataGridViewTextBoxColumn.Name = "noofotherGemsDataGridViewTextBoxColumn";
            this.noofotherGemsDataGridViewTextBoxColumn.Visible = false;
            // 
            // otherGemsDataGridViewTextBoxColumn
            // 
            this.otherGemsDataGridViewTextBoxColumn.DataPropertyName = "Other_Gems";
            this.otherGemsDataGridViewTextBoxColumn.HeaderText = "Other_Gems";
            this.otherGemsDataGridViewTextBoxColumn.Name = "otherGemsDataGridViewTextBoxColumn";
            this.otherGemsDataGridViewTextBoxColumn.Visible = false;
            // 
            // weightofotherGemsDataGridViewTextBoxColumn
            // 
            this.weightofotherGemsDataGridViewTextBoxColumn.DataPropertyName = "Weight_of_other_Gems";
            this.weightofotherGemsDataGridViewTextBoxColumn.HeaderText = "Weight_of_other_Gems";
            this.weightofotherGemsDataGridViewTextBoxColumn.Name = "weightofotherGemsDataGridViewTextBoxColumn";
            this.weightofotherGemsDataGridViewTextBoxColumn.Visible = false;
            // 
            // imageDataGridViewImageColumn
            // 
            this.imageDataGridViewImageColumn.DataPropertyName = "Image";
            this.imageDataGridViewImageColumn.HeaderText = "Image";
            this.imageDataGridViewImageColumn.Name = "imageDataGridViewImageColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "Create_Date";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "Create_Date";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "Update_Date";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "Update_Date";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            // 
            // updateUserIDDataGridViewTextBoxColumn
            // 
            this.updateUserIDDataGridViewTextBoxColumn.DataPropertyName = "Update_UserID";
            this.updateUserIDDataGridViewTextBoxColumn.HeaderText = "Update_UserID";
            this.updateUserIDDataGridViewTextBoxColumn.Name = "updateUserIDDataGridViewTextBoxColumn";
            // 
            // imagepathDataGridViewTextBoxColumn
            // 
            this.imagepathDataGridViewTextBoxColumn.DataPropertyName = "Imagepath";
            this.imagepathDataGridViewTextBoxColumn.HeaderText = "Imagepath";
            this.imagepathDataGridViewTextBoxColumn.Name = "imagepathDataGridViewTextBoxColumn";
            this.imagepathDataGridViewTextBoxColumn.Visible = false;
            // 
            // stockEntryBindingSource
            // 
            this.stockEntryBindingSource.DataMember = "Stock_Entry";
            this.stockEntryBindingSource.DataSource = this.pCJ_SYSTEM_DBDataSet2;
            // 
            // pCJ_SYSTEM_DBDataSet2
            // 
            this.pCJ_SYSTEM_DBDataSet2.DataSetName = "PCJ_SYSTEM_DBDataSet2";
            this.pCJ_SYSTEM_DBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stock_EntryTableAdapter
            // 
            this.stock_EntryTableAdapter.ClearBeforeFill = true;
            // 
            // Stocks_Gems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bunifuMetroTextbox1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Stocks_Gems";
            this.Size = new System.Drawing.Size(1193, 860);
            this.Load += new System.EventHandler(this.Stocks_Gems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCJ_SYSTEM_DBDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton btnrefresh;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuMetroTextbox bunifuMetroTextbox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource stockEntryBindingSource;
        private PCJ_SYSTEM_DBDataSet2 pCJ_SYSTEM_DBDataSet2;
        private PCJ_SYSTEM_DBDataSet2TableAdapters.Stock_EntryTableAdapter stock_EntryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noofpiecesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gemTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noofGemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noofotherGemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherGemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightofotherGemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagepathDataGridViewTextBoxColumn;
    }
}
