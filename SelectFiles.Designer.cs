namespace APIBuilderSetup
{
    partial class SelectFiles
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
            btnApply = new Button();
            treeView1 = new TreeView();
            chkSelectAll = new CheckBox();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Location = new Point(191, 793);
            btnApply.Margin = new Padding(4, 5, 4, 5);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(107, 38);
            btnApply.TabIndex = 0;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += button1_Click;
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new Point(4, 2);
            treeView1.Margin = new Padding(4, 5, 4, 5);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(561, 751);
            treeView1.TabIndex = 1;
            // 
            // chkSelectAll
            // 
            chkSelectAll.AutoSize = true;
            chkSelectAll.Location = new Point(17, 779);
            chkSelectAll.Name = "chkSelectAll";
            chkSelectAll.Size = new Size(109, 29);
            chkSelectAll.TabIndex = 2;
            chkSelectAll.Text = "Select All";
            chkSelectAll.UseVisualStyleBackColor = true;
            chkSelectAll.CheckedChanged += chkSelectAll_CheckedChanged;
            // 
            // SelectFiles
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 860);
            Controls.Add(chkSelectAll);
            Controls.Add(treeView1);
            Controls.Add(btnApply);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectFiles";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Files";
            Load += SelectFiles_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnApply;
        private TreeView treeView1;
        private CheckBox chkSelectAll;
    }
}