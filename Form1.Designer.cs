
namespace Assignment2
{
    partial class Assign2Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assign2Form));
            this.Label1 = new System.Windows.Forms.Label();
            this.GuildBox = new System.Windows.Forms.ListBox();
            this.PlayerBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.GuildNameBox = new System.Windows.Forms.TextBox();
            this.GuildTypeBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Servercombo = new System.Windows.Forms.ComboBox();
            this.AddGuild = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ClassBox = new System.Windows.Forms.ComboBox();
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RaceBox = new System.Windows.Forms.ComboBox();
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.AddPlayer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.JoinGuild = new System.Windows.Forms.Button();
            this.ApplySearchCriteria = new System.Windows.Forms.Button();
            this.LeaveGuild = new System.Windows.Forms.Button();
            this.DisbandGuild = new System.Windows.Forms.Button();
            this.PrintGuildRoster = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(796, 71);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 32);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Guilds";
            // 
            // GuildBox
            // 
            this.GuildBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GuildBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuildBox.FormattingEnabled = true;
            this.GuildBox.ItemHeight = 16;
            this.GuildBox.Location = new System.Drawing.Point(796, 106);
            this.GuildBox.Name = "GuildBox";
            this.GuildBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GuildBox.Size = new System.Drawing.Size(334, 452);
            this.GuildBox.Sorted = true;
            this.GuildBox.TabIndex = 3;
            // 
            // PlayerBox
            // 
            this.PlayerBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PlayerBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerBox.FormattingEnabled = true;
            this.PlayerBox.ItemHeight = 16;
            this.PlayerBox.Location = new System.Drawing.Point(500, 106);
            this.PlayerBox.Name = "PlayerBox";
            this.PlayerBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PlayerBox.Size = new System.Drawing.Size(265, 452);
            this.PlayerBox.Sorted = true;
            this.PlayerBox.TabIndex = 4;
            this.PlayerBox.SelectedIndexChanged += new System.EventHandler(this.PlayerBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(500, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Players";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 579);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.GuildNameBox);
            this.groupBox1.Controls.Add(this.GuildTypeBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Servercombo);
            this.groupBox1.Controls.Add(this.AddGuild);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(437, 131);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create New Guild";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 18);
            this.label15.TabIndex = 29;
            this.label15.Text = "Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(164, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "Server";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 18);
            this.label13.TabIndex = 28;
            this.label13.Text = "Guild Name";
            // 
            // GuildNameBox
            // 
            this.GuildNameBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GuildNameBox.Location = new System.Drawing.Point(15, 35);
            this.GuildNameBox.Name = "GuildNameBox";
            this.GuildNameBox.Size = new System.Drawing.Size(131, 25);
            this.GuildNameBox.TabIndex = 17;
            // 
            // GuildTypeBox
            // 
            this.GuildTypeBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GuildTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GuildTypeBox.FormattingEnabled = true;
            this.GuildTypeBox.Location = new System.Drawing.Point(15, 84);
            this.GuildTypeBox.Name = "GuildTypeBox";
            this.GuildTypeBox.Size = new System.Drawing.Size(131, 26);
            this.GuildTypeBox.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "label9";
            // 
            // Servercombo
            // 
            this.Servercombo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Servercombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Servercombo.FormattingEnabled = true;
            this.Servercombo.Location = new System.Drawing.Point(167, 34);
            this.Servercombo.MaxDropDownItems = 20;
            this.Servercombo.Name = "Servercombo";
            this.Servercombo.Size = new System.Drawing.Size(131, 26);
            this.Servercombo.Sorted = true;
            this.Servercombo.TabIndex = 22;
            // 
            // AddGuild
            // 
            this.AddGuild.Location = new System.Drawing.Point(316, 32);
            this.AddGuild.Name = "AddGuild";
            this.AddGuild.Size = new System.Drawing.Size(105, 23);
            this.AddGuild.TabIndex = 16;
            this.AddGuild.Text = "Add Guild";
            this.AddGuild.UseVisualStyleBackColor = true;
            this.AddGuild.Click += new System.EventHandler(this.AddGuild_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.ClassBox);
            this.groupBox2.Controls.Add(this.RoleBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.RaceBox);
            this.groupBox2.Controls.Add(this.PlayerNameBox);
            this.groupBox2.Controls.Add(this.AddPlayer);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(437, 137);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create New Player";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "Class";
            // 
            // ClassBox
            // 
            this.ClassBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClassBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassBox.FormattingEnabled = true;
            this.ClassBox.Location = new System.Drawing.Point(15, 94);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(131, 26);
            this.ClassBox.TabIndex = 25;
            this.ClassBox.SelectedIndexChanged += new System.EventHandler(this.ClassBox_SelectedIndexChanged);
            // 
            // RoleBox
            // 
            this.RoleBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.RoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(167, 94);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(131, 26);
            this.RoleBox.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(162, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 18);
            this.label12.TabIndex = 27;
            this.label12.Text = "Race";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Role";
            // 
            // RaceBox
            // 
            this.RaceBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.RaceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RaceBox.FormattingEnabled = true;
            this.RaceBox.Location = new System.Drawing.Point(165, 42);
            this.RaceBox.Name = "RaceBox";
            this.RaceBox.Size = new System.Drawing.Size(131, 26);
            this.RaceBox.TabIndex = 20;
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PlayerNameBox.Location = new System.Drawing.Point(15, 45);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(131, 25);
            this.PlayerNameBox.TabIndex = 16;
            // 
            // AddPlayer
            // 
            this.AddPlayer.Location = new System.Drawing.Point(316, 38);
            this.AddPlayer.Name = "AddPlayer";
            this.AddPlayer.Size = new System.Drawing.Size(105, 23);
            this.AddPlayer.TabIndex = 15;
            this.AddPlayer.Text = "Add Player";
            this.AddPlayer.UseVisualStyleBackColor = true;
            this.AddPlayer.Click += new System.EventHandler(this.AddPlayer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Player Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.JoinGuild);
            this.groupBox3.Controls.Add(this.ApplySearchCriteria);
            this.groupBox3.Controls.Add(this.LeaveGuild);
            this.groupBox3.Controls.Add(this.DisbandGuild);
            this.groupBox3.Controls.Add(this.PrintGuildRoster);
            this.groupBox3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(23, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(437, 182);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Management Functions";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "Search Guild (by Server)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Search Player (by Name)";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox3.Location = new System.Drawing.Point(216, 120);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(131, 25);
            this.textBox3.TabIndex = 18;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox4.Location = new System.Drawing.Point(216, 60);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(131, 25);
            this.textBox4.TabIndex = 19;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // JoinGuild
            // 
            this.JoinGuild.Location = new System.Drawing.Point(15, 84);
            this.JoinGuild.Name = "JoinGuild";
            this.JoinGuild.Size = new System.Drawing.Size(151, 25);
            this.JoinGuild.TabIndex = 12;
            this.JoinGuild.Text = "Join Guild";
            this.JoinGuild.UseVisualStyleBackColor = true;
            this.JoinGuild.Click += new System.EventHandler(this.JoinGuild_Click);
            // 
            // ApplySearchCriteria
            // 
            this.ApplySearchCriteria.Location = new System.Drawing.Point(15, 142);
            this.ApplySearchCriteria.Name = "ApplySearchCriteria";
            this.ApplySearchCriteria.Size = new System.Drawing.Size(151, 23);
            this.ApplySearchCriteria.TabIndex = 14;
            this.ApplySearchCriteria.Text = "Apply Search Criteria";
            this.ApplySearchCriteria.UseVisualStyleBackColor = true;
            this.ApplySearchCriteria.Click += new System.EventHandler(this.ApplySearchCriteria_Click);
            // 
            // LeaveGuild
            // 
            this.LeaveGuild.Location = new System.Drawing.Point(15, 113);
            this.LeaveGuild.Name = "LeaveGuild";
            this.LeaveGuild.Size = new System.Drawing.Size(151, 23);
            this.LeaveGuild.TabIndex = 13;
            this.LeaveGuild.Text = "Leave Guild";
            this.LeaveGuild.UseVisualStyleBackColor = true;
            this.LeaveGuild.Click += new System.EventHandler(this.LeaveGuild_Click);
            // 
            // DisbandGuild
            // 
            this.DisbandGuild.Location = new System.Drawing.Point(15, 55);
            this.DisbandGuild.Name = "DisbandGuild";
            this.DisbandGuild.Size = new System.Drawing.Size(151, 23);
            this.DisbandGuild.TabIndex = 11;
            this.DisbandGuild.Text = "Disband Guild";
            this.DisbandGuild.UseVisualStyleBackColor = true;
            this.DisbandGuild.Click += new System.EventHandler(this.DisbandGuild_Click);
            // 
            // PrintGuildRoster
            // 
            this.PrintGuildRoster.Location = new System.Drawing.Point(15, 26);
            this.PrintGuildRoster.Name = "PrintGuildRoster";
            this.PrintGuildRoster.Size = new System.Drawing.Size(151, 23);
            this.PrintGuildRoster.TabIndex = 10;
            this.PrintGuildRoster.Text = "Print Guild Roster";
            this.PrintGuildRoster.UseVisualStyleBackColor = true;
            this.PrintGuildRoster.Click += new System.EventHandler(this.PrintGuildRoster_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(565, 47);
            this.label4.TabIndex = 0;
            this.label4.Text = "Player/Guild Management System";
            // 
            // OutputBox
            // 
            this.OutputBox.AllowDrop = true;
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.OutputBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.FormattingEnabled = true;
            this.OutputBox.ItemHeight = 14;
            this.OutputBox.Location = new System.Drawing.Point(41, 632);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OutputBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.OutputBox.Size = new System.Drawing.Size(1089, 172);
            this.OutputBox.TabIndex = 6;
            // 
            // Assign2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1159, 826);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayerBox);
            this.Controls.Add(this.GuildBox);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Assign2Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "World of ConflictCraft";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ListBox GuildBox;
        private System.Windows.Forms.ListBox PlayerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox GuildNameBox;
        private System.Windows.Forms.ComboBox GuildTypeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Servercombo;
        private System.Windows.Forms.Button AddGuild;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ClassBox;
        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox RaceBox;
        private System.Windows.Forms.TextBox PlayerNameBox;
        private System.Windows.Forms.Button AddPlayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button JoinGuild;
        private System.Windows.Forms.Button ApplySearchCriteria;
        private System.Windows.Forms.Button LeaveGuild;
        private System.Windows.Forms.Button DisbandGuild;
        private System.Windows.Forms.Button PrintGuildRoster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox OutputBox;
    }
}
