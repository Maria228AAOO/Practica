namespace WinFormsApp4
{
    partial class MainForm
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
            button1 = new Button();
            lblUserFIO = new Label();
            txtSearch = new TextBox();
            cmbSort = new ComboBox();
            lstProducts = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(71, 37);
            button1.TabIndex = 0;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblUserFIO
            // 
            lblUserFIO.AutoSize = true;
            lblUserFIO.Location = new Point(694, 12);
            lblUserFIO.Name = "lblUserFIO";
            lblUserFIO.Size = new Size(38, 15);
            lblUserFIO.TabIndex = 1;
            lblUserFIO.Text = "label1";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(161, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(336, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbSort
            // 
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(514, 20);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(73, 23);
            cmbSort.TabIndex = 3;
            // 
            // lstProducts
            // 
            lstProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstProducts.DrawMode = DrawMode.OwnerDrawVariable;
            lstProducts.FormattingEnabled = true;
            lstProducts.Location = new Point(12, 71);
            lstProducts.Name = "lstProducts";
            lstProducts.Size = new Size(776, 379);
            lstProducts.TabIndex = 4;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstProducts);
            Controls.Add(cmbSort);
            Controls.Add(txtSearch);
            Controls.Add(lblUserFIO);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblUserFIO;
        private TextBox txtSearch;
        private ComboBox cmbSort;
        private ListBox lstProducts;
    }
}