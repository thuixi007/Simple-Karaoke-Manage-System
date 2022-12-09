namespace Simple_Karaoke_Manage_System
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Panel_Welcome = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_Login = new Guna.UI2.WinForms.Guna2Panel();
            this.pass_input = new Guna.UI2.WinForms.Guna2TextBox();
            this.login_input = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_exit = new Guna.UI2.WinForms.Guna2Button();
            this.btn_login = new Guna.UI2.WinForms.Guna2Button();
            this.Pannel_Drag_drop = new Guna.UI2.WinForms.Guna2Panel();
            this.App_Name_label = new System.Windows.Forms.Label();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.Panel_Welcome.SuspendLayout();
            this.Panel_Login.SuspendLayout();
            this.Pannel_Drag_drop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // Panel_Welcome
            // 
            this.Panel_Welcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Panel_Welcome.Controls.Add(this.guna2PictureBox1);
            this.Panel_Welcome.Controls.Add(this.label2);
            this.Panel_Welcome.Controls.Add(this.label1);
            this.Panel_Welcome.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Welcome.Location = new System.Drawing.Point(0, 0);
            this.Panel_Welcome.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Welcome.Name = "Panel_Welcome";
            this.Panel_Welcome.Size = new System.Drawing.Size(296, 444);
            this.Panel_Welcome.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("iCiel Cadena", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(55, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vạn Sự Như Ý";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("iCiel Be Cool", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(23, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Back !";
            // 
            // Panel_Login
            // 
            this.Panel_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(251)))), ((int)(((byte)(246)))));
            this.Panel_Login.Controls.Add(this.pass_input);
            this.Panel_Login.Controls.Add(this.login_input);
            this.Panel_Login.Controls.Add(this.btn_exit);
            this.Panel_Login.Controls.Add(this.btn_login);
            this.Panel_Login.Controls.Add(this.Pannel_Drag_drop);
            this.Panel_Login.Controls.Add(this.guna2PictureBox2);
            this.Panel_Login.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_Login.Location = new System.Drawing.Point(292, 0);
            this.Panel_Login.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Login.Name = "Panel_Login";
            this.Panel_Login.Size = new System.Drawing.Size(487, 444);
            this.Panel_Login.TabIndex = 1;
            this.Panel_Login.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Login_Paint);
            // 
            // pass_input
            // 
            this.pass_input.Animated = true;
            this.pass_input.AutoRoundedCorners = true;
            this.pass_input.BorderColor = System.Drawing.Color.Black;
            this.pass_input.BorderRadius = 28;
            this.pass_input.BorderThickness = 2;
            this.pass_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pass_input.DefaultText = "";
            this.pass_input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pass_input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pass_input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pass_input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pass_input.FillColor = System.Drawing.Color.DimGray;
            this.pass_input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pass_input.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.pass_input.ForeColor = System.Drawing.Color.White;
            this.pass_input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pass_input.Location = new System.Drawing.Point(57, 247);
            this.pass_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pass_input.Name = "pass_input";
            this.pass_input.PasswordChar = '#';
            this.pass_input.PlaceholderForeColor = System.Drawing.Color.White;
            this.pass_input.PlaceholderText = "Mật khẩu";
            this.pass_input.SelectedText = "";
            this.pass_input.Size = new System.Drawing.Size(388, 59);
            this.pass_input.TabIndex = 4;
            // 
            // login_input
            // 
            this.login_input.Animated = true;
            this.login_input.AutoRoundedCorners = true;
            this.login_input.BorderColor = System.Drawing.Color.Black;
            this.login_input.BorderRadius = 28;
            this.login_input.BorderThickness = 2;
            this.login_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.login_input.DefaultText = "";
            this.login_input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.login_input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.login_input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.login_input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.login_input.FillColor = System.Drawing.Color.DimGray;
            this.login_input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.login_input.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.login_input.ForeColor = System.Drawing.Color.White;
            this.login_input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.login_input.Location = new System.Drawing.Point(57, 180);
            this.login_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.login_input.Name = "login_input";
            this.login_input.PasswordChar = '\0';
            this.login_input.PlaceholderForeColor = System.Drawing.Color.White;
            this.login_input.PlaceholderText = "Tên đăng nhập";
            this.login_input.SelectedText = "";
            this.login_input.Size = new System.Drawing.Size(388, 59);
            this.login_input.TabIndex = 3;
            // 
            // btn_exit
            // 
            this.btn_exit.Animated = true;
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_exit.FillColor = System.Drawing.Color.White;
            this.btn_exit.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.IndicateFocus = true;
            this.btn_exit.Location = new System.Drawing.Point(100, 377);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(310, 45);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_login
            // 
            this.btn_login.Animated = true;
            this.btn_login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_login.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btn_login.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.IndicateFocus = true;
            this.btn_login.Location = new System.Drawing.Point(100, 326);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(310, 45);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "Đăng nhập";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // Pannel_Drag_drop
            // 
            this.Pannel_Drag_drop.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Pannel_Drag_drop.Controls.Add(this.App_Name_label);
            this.Pannel_Drag_drop.Controls.Add(this.guna2ControlBox2);
            this.Pannel_Drag_drop.Controls.Add(this.guna2ControlBox1);
            this.Pannel_Drag_drop.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pannel_Drag_drop.Location = new System.Drawing.Point(0, 0);
            this.Pannel_Drag_drop.Margin = new System.Windows.Forms.Padding(4);
            this.Pannel_Drag_drop.Name = "Pannel_Drag_drop";
            this.Pannel_Drag_drop.Size = new System.Drawing.Size(487, 53);
            this.Pannel_Drag_drop.TabIndex = 0;
            // 
            // App_Name_label
            // 
            this.App_Name_label.AutoSize = true;
            this.App_Name_label.Font = new System.Drawing.Font("MinstrelPosterWHG", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.App_Name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.App_Name_label.Location = new System.Drawing.Point(0, 12);
            this.App_Name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.App_Name_label.Name = "App_Name_label";
            this.App_Name_label.Size = new System.Drawing.Size(339, 27);
            this.App_Name_label.TabIndex = 2;
            this.App_Name_label.Text = "Simple Karaoke Manage System";
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BorderRadius = 15;
            this.guna2ControlBox2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Gold;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(383, 4);
            this.guna2ControlBox2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(40, 37);
            this.guna2ControlBox2.TabIndex = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Coral;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(431, 4);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(40, 37);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.Pannel_Drag_drop;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.App_Name_label;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::Simple_Karaoke_Manage_System.Properties.Resources.Karaoke_logo_7D5E3FEDCB_seeklogo_com;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(100, 85);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(298, 63);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 5;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(17, 194);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(267, 246);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 444);
            this.Controls.Add(this.Panel_Login);
            this.Controls.Add(this.Panel_Welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Panel_Welcome.ResumeLayout(false);
            this.Panel_Welcome.PerformLayout();
            this.Panel_Login.ResumeLayout(false);
            this.Pannel_Drag_drop.ResumeLayout(false);
            this.Pannel_Drag_drop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel Panel_Login;
        private Guna.UI2.WinForms.Guna2Panel Pannel_Drag_drop;
        private Guna.UI2.WinForms.Guna2Panel Panel_Welcome;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label App_Name_label;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btn_exit;
        private Guna.UI2.WinForms.Guna2Button btn_login;
        private Guna.UI2.WinForms.Guna2TextBox pass_input;
        private Guna.UI2.WinForms.Guna2TextBox login_input;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}

