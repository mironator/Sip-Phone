namespace Phone
{
    partial class MainWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DirectCallTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnHangUpDirectCall = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMakeDirectCall = new System.Windows.Forms.Button();
            this.tbTargetIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTargetUserNameDirect = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAccountUser = new System.Windows.Forms.TextBox();
            this.TabsContainer = new System.Windows.Forms.TabControl();
            this.Item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.портыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DirectCallTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabsContainer.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectCallTab
            // 
            this.DirectCallTab.Controls.Add(this.groupBox3);
            this.DirectCallTab.Controls.Add(this.groupBox1);
            this.DirectCallTab.Location = new System.Drawing.Point(4, 25);
            this.DirectCallTab.Name = "DirectCallTab";
            this.DirectCallTab.Padding = new System.Windows.Forms.Padding(3);
            this.DirectCallTab.Size = new System.Drawing.Size(303, 353);
            this.DirectCallTab.TabIndex = 0;
            this.DirectCallTab.Text = "Звонок напрямую";
            this.DirectCallTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResume);
            this.groupBox3.Controls.Add(this.btnPause);
            this.groupBox3.Controls.Add(this.btnHangUpDirectCall);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnMakeDirectCall);
            this.groupBox3.Controls.Add(this.tbTargetIP);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbTargetUserNameDirect);
            this.groupBox3.Location = new System.Drawing.Point(6, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 187);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Свойства собеседника";
            // 
            // btnResume
            // 
            this.btnResume.Enabled = false;
            this.btnResume.Location = new System.Drawing.Point(6, 148);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(101, 23);
            this.btnResume.TabIndex = 9;
            this.btnResume.Text = "Продолжить";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(6, 119);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(101, 23);
            this.btnPause.TabIndex = 8;
            this.btnPause.Text = "Приостановить";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnHangUpDirectCall
            // 
            this.btnHangUpDirectCall.Enabled = false;
            this.btnHangUpDirectCall.Location = new System.Drawing.Point(206, 93);
            this.btnHangUpDirectCall.Name = "btnHangUpDirectCall";
            this.btnHangUpDirectCall.Size = new System.Drawing.Size(75, 49);
            this.btnHangUpDirectCall.TabIndex = 5;
            this.btnHangUpDirectCall.Text = "Повесить трубку";
            this.btnHangUpDirectCall.UseVisualStyleBackColor = true;
            this.btnHangUpDirectCall.Click += new System.EventHandler(this.btnHangUpDirectCall_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Его адрес:";
            // 
            // btnMakeDirectCall
            // 
            this.btnMakeDirectCall.Enabled = false;
            this.btnMakeDirectCall.Location = new System.Drawing.Point(206, 39);
            this.btnMakeDirectCall.Name = "btnMakeDirectCall";
            this.btnMakeDirectCall.Size = new System.Drawing.Size(75, 48);
            this.btnMakeDirectCall.TabIndex = 4;
            this.btnMakeDirectCall.Text = "Звонить";
            this.btnMakeDirectCall.UseVisualStyleBackColor = true;
            this.btnMakeDirectCall.Click += new System.EventHandler(this.btnMakeDirectCall_Click);
            // 
            // tbTargetIP
            // 
            this.tbTargetIP.Location = new System.Drawing.Point(6, 93);
            this.tbTargetIP.MaxLength = 500;
            this.tbTargetIP.Name = "tbTargetIP";
            this.tbTargetIP.Size = new System.Drawing.Size(137, 20);
            this.tbTargetIP.TabIndex = 4;
            this.tbTargetIP.Text = "192.168.1.101";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Имя пользователя:";
            // 
            // tbTargetUserNameDirect
            // 
            this.tbTargetUserNameDirect.Location = new System.Drawing.Point(6, 39);
            this.tbTargetUserNameDirect.Name = "tbTargetUserNameDirect";
            this.tbTargetUserNameDirect.Size = new System.Drawing.Size(137, 20);
            this.tbTargetUserNameDirect.TabIndex = 1;
            this.tbTargetUserNameDirect.Text = "USER2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogOut);
            this.groupBox1.Controls.Add(this.btnLogIn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbAccountUser);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 145);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ваш аккаунт";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(31, 104);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Выйти";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(31, 65);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "Зайти";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя пользователя:";
            // 
            // tbAccountUser
            // 
            this.tbAccountUser.Location = new System.Drawing.Point(6, 39);
            this.tbAccountUser.Name = "tbAccountUser";
            this.tbAccountUser.Size = new System.Drawing.Size(100, 20);
            this.tbAccountUser.TabIndex = 0;
            this.tbAccountUser.Text = "USER1";
            // 
            // TabsContainer
            // 
            this.TabsContainer.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabsContainer.Controls.Add(this.DirectCallTab);
            this.TabsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabsContainer.Location = new System.Drawing.Point(0, 24);
            this.TabsContainer.Name = "TabsContainer";
            this.TabsContainer.SelectedIndex = 0;
            this.TabsContainer.Size = new System.Drawing.Size(311, 382);
            this.TabsContainer.TabIndex = 0;
            // 
            // Item1
            // 
            this.Item1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиToolStripMenuItem});
            this.Item1.Name = "Item1";
            this.Item1.Size = new System.Drawing.Size(61, 20);
            this.Item1.Text = "Главное";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Item1,
            this.настройкиToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(311, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.портыToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // портыToolStripMenuItem
            // 
            this.портыToolStripMenuItem.Name = "портыToolStripMenuItem";
            this.портыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.портыToolStripMenuItem.Text = "Порты";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 406);
            this.Controls.Add(this.TabsContainer);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Основное окно";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.DirectCallTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TabsContainer.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage DirectCallTab;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnHangUpDirectCall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMakeDirectCall;
        private System.Windows.Forms.TextBox tbTargetIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTargetUserNameDirect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAccountUser;
        private System.Windows.Forms.TabControl TabsContainer;
        private System.Windows.Forms.ToolStripMenuItem Item1;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem портыToolStripMenuItem;

    }
}

