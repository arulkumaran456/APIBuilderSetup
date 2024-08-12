namespace APIBuilderSetup
{
    partial class Code_Review
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
            richTextBox1 = new RichTextBox();
            loginGroupBox = new GroupBox();
            button1 = new Button();
            label4 = new Label();
            ddlProject = new ComboBox();
            lblDomain = new Label();
            txtAccessToken = new TextBox();
            lblPassword = new Label();
            lblUserName = new Label();
            txtUserName = new TextBox();
            txtLogin = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            lblFlowName = new Label();
            lblJSBlockName = new Label();
            loginGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(374, 168);
            richTextBox1.Margin = new Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(764, 435);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // loginGroupBox
            // 
            loginGroupBox.Controls.Add(button1);
            loginGroupBox.Controls.Add(label4);
            loginGroupBox.Controls.Add(ddlProject);
            loginGroupBox.Controls.Add(lblDomain);
            loginGroupBox.Controls.Add(txtAccessToken);
            loginGroupBox.Controls.Add(lblPassword);
            loginGroupBox.Controls.Add(lblUserName);
            loginGroupBox.Controls.Add(txtUserName);
            loginGroupBox.Location = new Point(5, 69);
            loginGroupBox.Name = "loginGroupBox";
            loginGroupBox.Size = new Size(364, 211);
            loginGroupBox.TabIndex = 4;
            loginGroupBox.TabStop = false;
            loginGroupBox.Text = "Bitbucket Login";
            // 
            // button1
            // 
            button1.Location = new Point(228, 164);
            button1.Name = "button1";
            button1.Size = new Size(62, 23);
            button1.TabIndex = 11;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 124);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 10;
            label4.Text = "Project";
            // 
            // ddlProject
            // 
            ddlProject.FormattingEnabled = true;
            ddlProject.Items.AddRange(new object[] { "OMINTCTMS", "OMINTSUBM", "OMINTQMS" });
            ddlProject.Location = new Point(83, 122);
            ddlProject.Name = "ddlProject";
            ddlProject.Size = new Size(220, 23);
            ddlProject.TabIndex = 3;
            // 
            // lblDomain
            // 
            lblDomain.AutoSize = true;
            lblDomain.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDomain.Location = new Point(135, 19);
            lblDomain.Name = "lblDomain";
            lblDomain.Size = new Size(155, 13);
            lblDomain.TabIndex = 8;
            lblDomain.Text = "@boehringer-ingelheim.com";
            // 
            // txtAccessToken
            // 
            txtAccessToken.Location = new Point(83, 82);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.Size = new Size(220, 23);
            txtAccessToken.TabIndex = 2;
            txtAccessToken.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(8, 83);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "BI Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(8, 43);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(56, 15);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "BI Mail Id";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(83, 41);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(161, 23);
            txtUserName.TabIndex = 1;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(554, 608);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(62, 23);
            txtLogin.TabIndex = 4;
            txtLogin.Text = "Login";
            txtLogin.UseVisualStyleBackColor = true;
            txtLogin.Click += txtLogin_Click;
            // 
            // button2
            // 
            button2.Location = new Point(649, 608);
            button2.Name = "button2";
            button2.Size = new Size(62, 23);
            button2.TabIndex = 5;
            button2.Text = "NEXT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(428, 88);
            label1.Name = "label1";
            label1.Size = new Size(64, 13);
            label1.TabIndex = 12;
            label1.Text = "Flow Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(428, 120);
            label2.Name = "label2";
            label2.Size = new Size(118, 13);
            label2.TabIndex = 13;
            label2.Text = "Javascript Block Name";
            // 
            // lblFlowName
            // 
            lblFlowName.AutoSize = true;
            lblFlowName.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFlowName.Location = new Point(577, 88);
            lblFlowName.Name = "lblFlowName";
            lblFlowName.Size = new Size(64, 13);
            lblFlowName.TabIndex = 14;
            lblFlowName.Text = "Flow Name";
            // 
            // lblJSBlockName
            // 
            lblJSBlockName.AutoSize = true;
            lblJSBlockName.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJSBlockName.Location = new Point(577, 120);
            lblJSBlockName.Name = "lblJSBlockName";
            lblJSBlockName.Size = new Size(64, 13);
            lblJSBlockName.TabIndex = 15;
            lblJSBlockName.Text = "Flow Name";
            // 
            // Code_Review
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 637);
            Controls.Add(lblJSBlockName);
            Controls.Add(lblFlowName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(loginGroupBox);
            Controls.Add(richTextBox1);
            Controls.Add(txtLogin);
            Margin = new Padding(2);
            Name = "Code_Review";
            Text = "Code_Review";
            loginGroupBox.ResumeLayout(false);
            loginGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private GroupBox loginGroupBox;
        private Label label4;
        private ComboBox ddlProject;
        private Label lblDomain;
        private TextBox txtAccessToken;
        private Button txtLogin;
        private Label lblPassword;
        private Label lblUserName;
        private TextBox txtUserName;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label lblFlowName;
        private Label lblJSBlockName;
    }
}