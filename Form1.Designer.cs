namespace APIBuilderSetup
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            loginGroupBox = new GroupBox();
            BtnLogin = new MaterialSkin.Controls.MaterialButton();
            label4 = new Label();
            ddlProject = new ComboBox();
            lblDomain = new Label();
            txtAccessToken = new TextBox();
            lblPassword = new Label();
            lblUserName = new Label();
            txtUserName = new TextBox();
            RepositoryGroupBox = new GroupBox();
            BtnRevealExplorer = new MaterialSkin.Controls.MaterialButton();
            btnNpmStart = new MaterialSkin.Controls.MaterialButton();
            btnApplyTemplate = new MaterialSkin.Controls.MaterialButton();
            label5 = new Label();
            panel1 = new Panel();
            rdbOtherProject = new MaterialSkin.Controls.MaterialRadioButton();
            rdbService = new MaterialSkin.Controls.MaterialRadioButton();
            rdbTrigger = new MaterialSkin.Controls.MaterialRadioButton();
            label1 = new Label();
            ddlTargetRepo = new ComboBox();
            ddlTemplateRepo = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            logGroupBox = new GroupBox();
            btnClear = new MaterialSkin.Controls.MaterialButton();
            richTextBox1 = new RichTextBox();
            loginGroupBox.SuspendLayout();
            RepositoryGroupBox.SuspendLayout();
            panel1.SuspendLayout();
            logGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // loginGroupBox
            // 
            loginGroupBox.Controls.Add(BtnLogin);
            loginGroupBox.Controls.Add(label4);
            loginGroupBox.Controls.Add(ddlProject);
            loginGroupBox.Controls.Add(lblDomain);
            loginGroupBox.Controls.Add(txtAccessToken);
            loginGroupBox.Controls.Add(lblPassword);
            loginGroupBox.Controls.Add(lblUserName);
            loginGroupBox.Controls.Add(txtUserName);
            loginGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginGroupBox.Location = new Point(12, 69);
            loginGroupBox.Name = "loginGroupBox";
            loginGroupBox.Size = new Size(508, 197);
            loginGroupBox.TabIndex = 3;
            loginGroupBox.TabStop = false;
            loginGroupBox.Text = "Bitbucket Login";
            // 
            // BtnLogin
            // 
            BtnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnLogin.Depth = 0;
            BtnLogin.HighEmphasis = true;
            BtnLogin.Icon = null;
            BtnLogin.Location = new Point(238, 151);
            BtnLogin.Margin = new Padding(4, 6, 4, 6);
            BtnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            BtnLogin.Name = "BtnLogin";
            BtnLogin.NoAccentTextColor = Color.Empty;
            BtnLogin.Size = new Size(64, 36);
            BtnLogin.TabIndex = 11;
            BtnLogin.Text = "Login";
            BtnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            BtnLogin.UseAccentColor = false;
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(8, 123);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 10;
            label4.Text = "Project";
            // 
            // ddlProject
            // 
            ddlProject.BackColor = Color.White;
            ddlProject.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ddlProject.FormattingEnabled = true;
            ddlProject.Items.AddRange(new object[] { "OMINTCTMS", "OMINTSUBM", "OMINTQMS" });
            ddlProject.Location = new Point(133, 120);
            ddlProject.Name = "ddlProject";
            ddlProject.Size = new Size(313, 23);
            ddlProject.TabIndex = 3;
            // 
            // lblDomain
            // 
            lblDomain.AutoSize = true;
            lblDomain.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDomain.Location = new Point(295, 42);
            lblDomain.Name = "lblDomain";
            lblDomain.Size = new Size(161, 15);
            lblDomain.TabIndex = 8;
            lblDomain.Text = "@boehringer-ingelheim.com";
            // 
            // txtAccessToken
            // 
            txtAccessToken.BackColor = Color.White;
            txtAccessToken.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAccessToken.Location = new Point(133, 79);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.Size = new Size(313, 23);
            txtAccessToken.TabIndex = 2;
            txtAccessToken.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(8, 82);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "BI Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(8, 42);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(56, 15);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "BI Mail Id";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.White;
            txtUserName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(133, 39);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(161, 23);
            txtUserName.TabIndex = 1;
            // 
            // RepositoryGroupBox
            // 
            RepositoryGroupBox.Controls.Add(BtnRevealExplorer);
            RepositoryGroupBox.Controls.Add(btnNpmStart);
            RepositoryGroupBox.Controls.Add(btnApplyTemplate);
            RepositoryGroupBox.Controls.Add(label5);
            RepositoryGroupBox.Controls.Add(panel1);
            RepositoryGroupBox.Controls.Add(label1);
            RepositoryGroupBox.Controls.Add(ddlTargetRepo);
            RepositoryGroupBox.Controls.Add(ddlTemplateRepo);
            RepositoryGroupBox.Controls.Add(label2);
            RepositoryGroupBox.Controls.Add(label3);
            RepositoryGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RepositoryGroupBox.Location = new Point(12, 271);
            RepositoryGroupBox.Name = "RepositoryGroupBox";
            RepositoryGroupBox.Size = new Size(508, 268);
            RepositoryGroupBox.TabIndex = 9;
            RepositoryGroupBox.TabStop = false;
            RepositoryGroupBox.Text = "Repository";
            // 
            // BtnRevealExplorer
            // 
            BtnRevealExplorer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRevealExplorer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnRevealExplorer.Depth = 0;
            BtnRevealExplorer.HighEmphasis = true;
            BtnRevealExplorer.Icon = null;
            BtnRevealExplorer.Location = new Point(327, 218);
            BtnRevealExplorer.Margin = new Padding(4, 6, 4, 6);
            BtnRevealExplorer.MouseState = MaterialSkin.MouseState.HOVER;
            BtnRevealExplorer.Name = "BtnRevealExplorer";
            BtnRevealExplorer.NoAccentTextColor = Color.Empty;
            BtnRevealExplorer.Size = new Size(169, 36);
            BtnRevealExplorer.TabIndex = 20;
            BtnRevealExplorer.Text = "REVEAL IN EXPLORER";
            BtnRevealExplorer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            BtnRevealExplorer.UseAccentColor = false;
            BtnRevealExplorer.UseVisualStyleBackColor = true;
            BtnRevealExplorer.Click += BtnRevealExplorer_Click;
            // 
            // btnNpmStart
            // 
            btnNpmStart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNpmStart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNpmStart.Depth = 0;
            btnNpmStart.HighEmphasis = true;
            btnNpmStart.Icon = null;
            btnNpmStart.Location = new Point(188, 218);
            btnNpmStart.Margin = new Padding(4, 6, 4, 6);
            btnNpmStart.MouseState = MaterialSkin.MouseState.HOVER;
            btnNpmStart.Name = "btnNpmStart";
            btnNpmStart.NoAccentTextColor = Color.Empty;
            btnNpmStart.Size = new Size(129, 36);
            btnNpmStart.TabIndex = 19;
            btnNpmStart.Text = "BUILD AND RUN";
            btnNpmStart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnNpmStart.UseAccentColor = false;
            btnNpmStart.UseVisualStyleBackColor = true;
            btnNpmStart.Click += btnNpmStart_Click_1;
            // 
            // btnApplyTemplate
            // 
            btnApplyTemplate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnApplyTemplate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnApplyTemplate.Depth = 0;
            btnApplyTemplate.HighEmphasis = true;
            btnApplyTemplate.Icon = null;
            btnApplyTemplate.Location = new Point(30, 218);
            btnApplyTemplate.Margin = new Padding(4, 6, 4, 6);
            btnApplyTemplate.MouseState = MaterialSkin.MouseState.HOVER;
            btnApplyTemplate.Name = "btnApplyTemplate";
            btnApplyTemplate.NoAccentTextColor = Color.Empty;
            btnApplyTemplate.Size = new Size(145, 36);
            btnApplyTemplate.TabIndex = 12;
            btnApplyTemplate.Text = "Apply Template";
            btnApplyTemplate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnApplyTemplate.UseAccentColor = false;
            btnApplyTemplate.UseVisualStyleBackColor = true;
            btnApplyTemplate.Click += btnApplyTemplate_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(19, 57);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 18;
            label5.Text = "(Template)";
            // 
            // panel1
            // 
            panel1.Controls.Add(rdbOtherProject);
            panel1.Controls.Add(rdbService);
            panel1.Controls.Add(rdbTrigger);
            panel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(154, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(348, 47);
            panel1.TabIndex = 16;
            // 
            // rdbOtherProject
            // 
            rdbOtherProject.AutoSize = true;
            rdbOtherProject.Depth = 0;
            rdbOtherProject.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbOtherProject.Location = new Point(213, 6);
            rdbOtherProject.Margin = new Padding(0);
            rdbOtherProject.MouseLocation = new Point(-1, -1);
            rdbOtherProject.MouseState = MaterialSkin.MouseState.HOVER;
            rdbOtherProject.Name = "rdbOtherProject";
            rdbOtherProject.Ripple = true;
            rdbOtherProject.Size = new Size(126, 37);
            rdbOtherProject.TabIndex = 23;
            rdbOtherProject.TabStop = true;
            rdbOtherProject.Text = "Other Project";
            rdbOtherProject.UseVisualStyleBackColor = true;
            // 
            // rdbService
            // 
            rdbService.AutoSize = true;
            rdbService.Depth = 0;
            rdbService.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbService.Location = new Point(111, 5);
            rdbService.Margin = new Padding(0);
            rdbService.MouseLocation = new Point(-1, -1);
            rdbService.MouseState = MaterialSkin.MouseState.HOVER;
            rdbService.Name = "rdbService";
            rdbService.Ripple = true;
            rdbService.Size = new Size(86, 37);
            rdbService.TabIndex = 22;
            rdbService.TabStop = true;
            rdbService.Text = "Service";
            rdbService.UseVisualStyleBackColor = true;
            // 
            // rdbTrigger
            // 
            rdbTrigger.AutoSize = true;
            rdbTrigger.Depth = 0;
            rdbTrigger.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdbTrigger.Location = new Point(3, 5);
            rdbTrigger.Margin = new Padding(0);
            rdbTrigger.MouseLocation = new Point(-1, -1);
            rdbTrigger.MouseState = MaterialSkin.MouseState.HOVER;
            rdbTrigger.Name = "rdbTrigger";
            rdbTrigger.Ripple = true;
            rdbTrigger.Size = new Size(85, 37);
            rdbTrigger.TabIndex = 21;
            rdbTrigger.TabStop = true;
            rdbTrigger.Text = "Trigger";
            rdbTrigger.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 135);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 8;
            label1.Text = "Template Type";
            // 
            // ddlTargetRepo
            // 
            ddlTargetRepo.BackColor = Color.White;
            ddlTargetRepo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ddlTargetRepo.FormattingEnabled = true;
            ddlTargetRepo.Items.AddRange(new object[] { "OMINTCTMS", "OMINTSUBM", "OMINTQMS" });
            ddlTargetRepo.Location = new Point(175, 83);
            ddlTargetRepo.Name = "ddlTargetRepo";
            ddlTargetRepo.Size = new Size(313, 23);
            ddlTargetRepo.TabIndex = 7;
            // 
            // ddlTemplateRepo
            // 
            ddlTemplateRepo.BackColor = Color.White;
            ddlTemplateRepo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ddlTemplateRepo.FormattingEnabled = true;
            ddlTemplateRepo.Items.AddRange(new object[] { "OMINTCTMS", "OMINTSUBM", "OMINTQMS" });
            ddlTemplateRepo.Location = new Point(175, 39);
            ddlTemplateRepo.Name = "ddlTemplateRepo";
            ddlTemplateRepo.Size = new Size(313, 23);
            ddlTemplateRepo.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 86);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 5;
            label2.Text = "Target Repository";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 42);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 4;
            label3.Text = "Source Repository";
            // 
            // logGroupBox
            // 
            logGroupBox.Controls.Add(btnClear);
            logGroupBox.Controls.Add(richTextBox1);
            logGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logGroupBox.Location = new Point(526, 69);
            logGroupBox.Name = "logGroupBox";
            logGroupBox.Size = new Size(358, 470);
            logGroupBox.TabIndex = 11;
            logGroupBox.TabStop = false;
            logGroupBox.Text = "Logs";
            // 
            // btnClear
            // 
            btnClear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClear.Depth = 0;
            btnClear.HighEmphasis = true;
            btnClear.Icon = null;
            btnClear.Location = new Point(152, 420);
            btnClear.Margin = new Padding(4, 6, 4, 6);
            btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            btnClear.Name = "btnClear";
            btnClear.NoAccentTextColor = Color.Empty;
            btnClear.Size = new Size(66, 36);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnClear.UseAccentColor = false;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.White;
            richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(9, 20);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(343, 391);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(893, 549);
            Controls.Add(logGroupBox);
            Controls.Add(RepositoryGroupBox);
            Controls.Add(loginGroupBox);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Axway API Builder Interface Template";
            Load += Form1_Load;
            loginGroupBox.ResumeLayout(false);
            loginGroupBox.PerformLayout();
            RepositoryGroupBox.ResumeLayout(false);
            RepositoryGroupBox.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            logGroupBox.ResumeLayout(false);
            logGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox loginGroupBox;
        private TextBox txtAccessToken;
        private Label lblPassword;
        private Label lblUserName;
        private TextBox txtUserName;
        private Label lblDomain;
        private GroupBox RepositoryGroupBox;
        private Label label2;
        private Label label3;
        private ComboBox ddlProject;
        private Label label4;
        private ComboBox ddlTemplateRepo;
        private ComboBox ddlTargetRepo;
        private GroupBox logGroupBox;
        private RichTextBox richTextBox1;
        private Label label1;
        private Panel panel1;
        private Label label5;
        private MaterialSkin.Controls.MaterialButton BtnLogin;
        private MaterialSkin.Controls.MaterialButton btnApplyTemplate;
        private MaterialSkin.Controls.MaterialButton btnNpmStart;
        private MaterialSkin.Controls.MaterialButton BtnRevealExplorer;
        private MaterialSkin.Controls.MaterialRadioButton rdbTrigger;
        private MaterialSkin.Controls.MaterialRadioButton rdbOtherProject;
        private MaterialSkin.Controls.MaterialRadioButton rdbService;
        private MaterialSkin.Controls.MaterialButton btnClear;
    }
}
