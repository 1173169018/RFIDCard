namespace WindowsFormsApp1
{
    partial class User
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rFIDBookDataSet = new WindowsFormsApp1.RFIDBookDataSet();
            this.studentTableAdapter = new WindowsFormsApp1.RFIDBookDataSetTableAdapters.StudentTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rFIDBookDataSet1 = new WindowsFormsApp1.RFIDBookDataSet();
            this.rFIDBookDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rFIDBookDataSet11 = new WindowsFormsApp1.RFIDBookDataSet1();
            this.rootBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rootTableAdapter = new WindowsFormsApp1.RFIDBookDataSet1TableAdapters.RootTableAdapter();
            this.cardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.rFIDBookDataSet2 = new WindowsFormsApp1.RFIDBookDataSet2();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookTableAdapter = new WindowsFormsApp1.RFIDBookDataSet2TableAdapters.BookTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookAuthorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.rFIDBookDataSet3 = new WindowsFormsApp1.RFIDBookDataSet3();
            this.borrowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.borrowTableAdapter = new WindowsFormsApp1.RFIDBookDataSet3TableAdapters.BorrowTableAdapter();
            this.cardDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.card1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.card1DataGridViewTextBoxColumn,
            this.name1DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.studentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(121, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(295, 154);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.rFIDBookDataSet;
            // 
            // rFIDBookDataSet
            // 
            this.rFIDBookDataSet.DataSetName = "RFIDBookDataSet";
            this.rFIDBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.rootBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(514, 13);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // rFIDBookDataSet1
            // 
            this.rFIDBookDataSet1.DataSetName = "RFIDBookDataSet";
            this.rFIDBookDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rFIDBookDataSet1BindingSource
            // 
            this.rFIDBookDataSet1BindingSource.DataSource = this.rFIDBookDataSet1;
            this.rFIDBookDataSet1BindingSource.Position = 0;
            // 
            // rFIDBookDataSet11
            // 
            this.rFIDBookDataSet11.DataSetName = "RFIDBookDataSet1";
            this.rFIDBookDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rootBindingSource
            // 
            this.rootBindingSource.DataMember = "Root";
            this.rootBindingSource.DataSource = this.rFIDBookDataSet11;
            // 
            // rootTableAdapter
            // 
            this.rootTableAdapter.ClearBeforeFill = true;
            // 
            // cardDataGridViewTextBoxColumn
            // 
            this.cardDataGridViewTextBoxColumn.DataPropertyName = "Card";
            this.cardDataGridViewTextBoxColumn.HeaderText = "Card";
            this.cardDataGridViewTextBoxColumn.Name = "cardDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.bookNameDataGridViewTextBoxColumn,
            this.bookAuthorDataGridViewTextBoxColumn,
            this.borrowDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.bookBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(121, 220);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(446, 150);
            this.dataGridView3.TabIndex = 2;
            // 
            // rFIDBookDataSet2
            // 
            this.rFIDBookDataSet2.DataSetName = "RFIDBookDataSet2";
            this.rFIDBookDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataMember = "Book";
            this.bookBindingSource.DataSource = this.rFIDBookDataSet2;
            // 
            // bookTableAdapter
            // 
            this.bookTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // bookNameDataGridViewTextBoxColumn
            // 
            this.bookNameDataGridViewTextBoxColumn.DataPropertyName = "BookName";
            this.bookNameDataGridViewTextBoxColumn.HeaderText = "BookName";
            this.bookNameDataGridViewTextBoxColumn.Name = "bookNameDataGridViewTextBoxColumn";
            // 
            // bookAuthorDataGridViewTextBoxColumn
            // 
            this.bookAuthorDataGridViewTextBoxColumn.DataPropertyName = "BookAuthor";
            this.bookAuthorDataGridViewTextBoxColumn.HeaderText = "BookAuthor";
            this.bookAuthorDataGridViewTextBoxColumn.Name = "bookAuthorDataGridViewTextBoxColumn";
            // 
            // borrowDataGridViewTextBoxColumn
            // 
            this.borrowDataGridViewTextBoxColumn.DataPropertyName = "Borrow";
            this.borrowDataGridViewTextBoxColumn.HeaderText = "Borrow";
            this.borrowDataGridViewTextBoxColumn.Name = "borrowDataGridViewTextBoxColumn";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardDataGridViewTextBoxColumn1,
            this.bookNameDataGridViewTextBoxColumn1,
            this.timeDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.borrowBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(121, 421);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.Size = new System.Drawing.Size(346, 150);
            this.dataGridView4.TabIndex = 3;
            // 
            // rFIDBookDataSet3
            // 
            this.rFIDBookDataSet3.DataSetName = "RFIDBookDataSet3";
            this.rFIDBookDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // borrowBindingSource
            // 
            this.borrowBindingSource.DataMember = "Borrow";
            this.borrowBindingSource.DataSource = this.rFIDBookDataSet3;
            // 
            // borrowTableAdapter
            // 
            this.borrowTableAdapter.ClearBeforeFill = true;
            // 
            // cardDataGridViewTextBoxColumn1
            // 
            this.cardDataGridViewTextBoxColumn1.DataPropertyName = "Card";
            this.cardDataGridViewTextBoxColumn1.HeaderText = "Card";
            this.cardDataGridViewTextBoxColumn1.Name = "cardDataGridViewTextBoxColumn1";
            // 
            // bookNameDataGridViewTextBoxColumn1
            // 
            this.bookNameDataGridViewTextBoxColumn1.DataPropertyName = "BookName";
            this.bookNameDataGridViewTextBoxColumn1.HeaderText = "BookName";
            this.bookNameDataGridViewTextBoxColumn1.Name = "bookNameDataGridViewTextBoxColumn1";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Student表：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Root管理表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Book书籍表：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Borrow借阅表：";
            // 
            // card1DataGridViewTextBoxColumn
            // 
            this.card1DataGridViewTextBoxColumn.DataPropertyName = "Card1";
            this.card1DataGridViewTextBoxColumn.HeaderText = "Card1";
            this.card1DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.card1DataGridViewTextBoxColumn.Name = "card1DataGridViewTextBoxColumn";
            // 
            // name1DataGridViewTextBoxColumn
            // 
            this.name1DataGridViewTextBoxColumn.DataPropertyName = "Name1";
            this.name1DataGridViewTextBoxColumn.HeaderText = "Name1";
            this.name1DataGridViewTextBoxColumn.Name = "name1DataGridViewTextBoxColumn";
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 662);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "User";
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDBookDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private RFIDBookDataSet rFIDBookDataSet;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private RFIDBookDataSetTableAdapters.StudentTableAdapter studentTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource rFIDBookDataSet1BindingSource;
        private RFIDBookDataSet rFIDBookDataSet1;
        private RFIDBookDataSet1 rFIDBookDataSet11;
        private System.Windows.Forms.BindingSource rootBindingSource;
        private RFIDBookDataSet1TableAdapters.RootTableAdapter rootTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView3;
        private RFIDBookDataSet2 rFIDBookDataSet2;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private RFIDBookDataSet2TableAdapters.BookTableAdapter bookTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookAuthorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView4;
        private RFIDBookDataSet3 rFIDBookDataSet3;
        private System.Windows.Forms.BindingSource borrowBindingSource;
        private RFIDBookDataSet3TableAdapters.BorrowTableAdapter borrowTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn card1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name1DataGridViewTextBoxColumn;
    }
}