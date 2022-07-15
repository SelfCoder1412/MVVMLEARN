
namespace WpfApp1.View
{
    partial class Form2
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
            this.saleDataGridView = new System.Windows.Forms.DataGridView();
            this.totalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.totalAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesmanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.saleDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleDetailsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // saleDataGridView
            // 
            this.saleDataGridView.AllowUserToAddRows = false;
            this.saleDataGridView.AllowUserToDeleteRows = false;
            this.saleDataGridView.MultiSelect = false;
            this.saleDataGridView.ReadOnly = true;
            this.saleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleDataGridView.AutoGenerateColumns = false;
            this.saleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totalAmountDataGridViewTextBoxColumn,
            this.salesmanDataGridViewTextBoxColumn,
            this.clientDataGridViewTextBoxColumn,
            this.saleDateDataGridViewTextBoxColumn});
            this.saleDataGridView.DataSource = this.saleBindingSource;
            this.saleDataGridView.Location = new System.Drawing.Point(13, 13);
            this.saleDataGridView.Name = "saleDataGridView";
            this.saleDataGridView.RowHeadersWidth = 62;
            this.saleDataGridView.RowTemplate.Height = 28;
            this.saleDataGridView.Size = new System.Drawing.Size(1033, 267);
            this.saleDataGridView.TabIndex = 0;
            // 
            // totalAmountDataGridViewTextBoxColumn
            // 
            this.totalAmountDataGridViewTextBoxColumn.DataPropertyName = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.HeaderText = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.totalAmountDataGridViewTextBoxColumn.Name = "totalAmountDataGridViewTextBoxColumn";
            this.totalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalAmountDataGridViewTextBoxColumn.Width = 150;
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataSource = typeof(WpfApp1.Model.Sale);
            // 
            // saleDetailsDataGridView
            // 
            this.saleDetailsDataGridView.AllowUserToAddRows = false;
            this.saleDetailsDataGridView.AllowUserToDeleteRows = false;
            this.saleDetailsDataGridView.MultiSelect = false;
            this.saleDetailsDataGridView.ReadOnly = true;
            this.saleDetailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleDetailsDataGridView.AutoGenerateColumns = false;
            this.saleDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Product,
                this.Quantity,
                this.UnitPrice,
            this.totalAmountDataGridViewTextBoxColumn1});
            this.saleDetailsDataGridView.DataSource = this.saleDetailsBindingSource;
            this.saleDetailsDataGridView.Location = new System.Drawing.Point(13, 296);
            this.saleDetailsDataGridView.Name = "saleDetailsDataGridView";
            this.saleDetailsDataGridView.RowHeadersWidth = 62;
            this.saleDetailsDataGridView.RowTemplate.Height = 28;
            this.saleDetailsDataGridView.Size = new System.Drawing.Size(1033, 267);
            this.saleDetailsDataGridView.TabIndex = 1;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // totalAmountDataGridViewTextBoxColumn1
            // 
            this.totalAmountDataGridViewTextBoxColumn1.DataPropertyName = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn1.HeaderText = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.totalAmountDataGridViewTextBoxColumn1.Name = "totalAmountDataGridViewTextBoxColumn1";
            this.totalAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            this.totalAmountDataGridViewTextBoxColumn1.Width = 150;
            // 
            // saleDetailsBindingSource
            // 
            this.saleDetailsBindingSource.DataMember = "SaleDetails";
            this.saleDetailsBindingSource.DataSource = this.saleBindingSource;
            // 
            // saleDateDataGridViewTextBoxColumn
            // 
            this.saleDateDataGridViewTextBoxColumn.DataPropertyName = "SaleDate";
            this.saleDateDataGridViewTextBoxColumn.HeaderText = "SaleDate";
            this.saleDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.saleDateDataGridViewTextBoxColumn.Name = "saleDateDataGridViewTextBoxColumn";
            this.saleDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Client";
            this.clientDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.Width = 150;
            // 
            // salesmanDataGridViewTextBoxColumn
            // 
            this.salesmanDataGridViewTextBoxColumn.DataPropertyName = "Salesman";
            this.salesmanDataGridViewTextBoxColumn.HeaderText = "Salesman";
            this.salesmanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.salesmanDataGridViewTextBoxColumn.Name = "salesmanDataGridViewTextBoxColumn";
            this.salesmanDataGridViewTextBoxColumn.Width = 150;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 601);
            this.Controls.Add(this.saleDetailsDataGridView);
            this.Controls.Add(this.saleDataGridView);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saleDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleDetailsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView saleDataGridView;
        private System.Windows.Forms.BindingSource saleBindingSource;
        private System.Windows.Forms.DataGridView saleDetailsDataGridView;
        private System.Windows.Forms.BindingSource saleDetailsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesmanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleDateDataGridViewTextBoxColumn;
    }
}