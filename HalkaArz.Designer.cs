namespace WinFormsApp1
{
    partial class HalkaArz
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            listView2 = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            listView3 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader6 });
            listView1.Location = new Point(11, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(347, 556);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Hisse Adı";
            columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Adet";
            columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Fiyat";
            columnHeader3.Width = 75;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Tutar";
            columnHeader6.Width = 75;
            // 
            // listView2
            // 
            listView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5 });
            listView2.Location = new Point(367, 12);
            listView2.Name = "listView2";
            listView2.Size = new Size(166, 556);
            listView2.TabIndex = 20;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Hisse Adı";
            columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Kar/Zarar";
            columnHeader5.Width = 75;
            // 
            // listView3
            // 
            listView3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8 });
            listView3.Location = new Point(539, 12);
            listView3.Name = "listView3";
            listView3.Size = new Size(166, 556);
            listView3.TabIndex = 21;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Hisse Adı";
            columnHeader7.Width = 75;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Kar/Zarar";
            columnHeader8.Width = 75;
            // 
            // HalkaArz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(716, 580);
            ControlBox = false;
            Controls.Add(listView3);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Name = "HalkaArz";
            Text = "HalkaArz";
            ResumeLayout(false);
        }

        #endregion

        public ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader6;
        public ListView listView2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        public ListView listView3;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
    }
}