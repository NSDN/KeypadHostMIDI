namespace KeypadHostMIDI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupMidi = new System.Windows.Forms.GroupBox();
            this.btnMidi = new System.Windows.Forms.Button();
            this.boxMidi = new System.Windows.Forms.ComboBox();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.groupSerial = new System.Windows.Forms.GroupBox();
            this.btnSerial = new System.Windows.Forms.Button();
            this.boxSerial = new System.Windows.Forms.ComboBox();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.spliter = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelTo = new System.Windows.Forms.Label();
            this.boxKey = new System.Windows.Forms.TextBox();
            this.boxNote = new System.Windows.Forms.TextBox();
            this.showState = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.Button();
            this.modeBox = new System.Windows.Forms.CheckBox();
            this.groupMidi.SuspendLayout();
            this.groupSerial.SuspendLayout();
            this.groupMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupMidi
            // 
            this.groupMidi.Controls.Add(this.btnMidi);
            this.groupMidi.Controls.Add(this.boxMidi);
            this.groupMidi.Location = new System.Drawing.Point(12, 12);
            this.groupMidi.Name = "groupMidi";
            this.groupMidi.Size = new System.Drawing.Size(219, 50);
            this.groupMidi.TabIndex = 0;
            this.groupMidi.TabStop = false;
            this.groupMidi.Text = "MIDI";
            // 
            // btnMidi
            // 
            this.btnMidi.Location = new System.Drawing.Point(133, 17);
            this.btnMidi.Name = "btnMidi";
            this.btnMidi.Size = new System.Drawing.Size(80, 24);
            this.btnMidi.TabIndex = 7;
            this.btnMidi.Text = "Refresh";
            this.btnMidi.UseVisualStyleBackColor = true;
            this.btnMidi.Click += new System.EventHandler(this.btnMidi_Click);
            // 
            // boxMidi
            // 
            this.boxMidi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMidi.FormattingEnabled = true;
            this.boxMidi.Location = new System.Drawing.Point(6, 19);
            this.boxMidi.Name = "boxMidi";
            this.boxMidi.Size = new System.Drawing.Size(121, 20);
            this.boxMidi.TabIndex = 6;
            // 
            // groupSerial
            // 
            this.groupSerial.Controls.Add(this.modeBox);
            this.groupSerial.Controls.Add(this.btnSerial);
            this.groupSerial.Controls.Add(this.boxSerial);
            this.groupSerial.Location = new System.Drawing.Point(12, 68);
            this.groupSerial.Name = "groupSerial";
            this.groupSerial.Size = new System.Drawing.Size(219, 50);
            this.groupSerial.TabIndex = 8;
            this.groupSerial.TabStop = false;
            this.groupSerial.Text = "Serial";
            // 
            // btnSerial
            // 
            this.btnSerial.Location = new System.Drawing.Point(133, 17);
            this.btnSerial.Name = "btnSerial";
            this.btnSerial.Size = new System.Drawing.Size(59, 24);
            this.btnSerial.TabIndex = 10;
            this.btnSerial.Text = "Refresh";
            this.btnSerial.UseVisualStyleBackColor = true;
            this.btnSerial.Click += new System.EventHandler(this.btnSerial_Click);
            // 
            // boxSerial
            // 
            this.boxSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSerial.FormattingEnabled = true;
            this.boxSerial.Location = new System.Drawing.Point(6, 19);
            this.boxSerial.Name = "boxSerial";
            this.boxSerial.Size = new System.Drawing.Size(121, 20);
            this.boxSerial.TabIndex = 8;
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.spliter);
            this.groupMain.Controls.Add(this.btnAdd);
            this.groupMain.Controls.Add(this.labelTo);
            this.groupMain.Controls.Add(this.boxKey);
            this.groupMain.Controls.Add(this.boxNote);
            this.groupMain.Controls.Add(this.showState);
            this.groupMain.Controls.Add(this.btnConnect);
            this.groupMain.Location = new System.Drawing.Point(12, 124);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(219, 100);
            this.groupMain.TabIndex = 9;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "Main";
            // 
            // spliter
            // 
            this.spliter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spliter.Location = new System.Drawing.Point(4, 47);
            this.spliter.Name = "spliter";
            this.spliter.Size = new System.Drawing.Size(209, 20);
            this.spliter.TabIndex = 14;
            this.spliter.Text = "--------------------------------";
            this.spliter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(133, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 24);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(60, 25);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(17, 12);
            this.labelTo.TabIndex = 12;
            this.labelTo.Text = "=>";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxKey
            // 
            this.boxKey.Location = new System.Drawing.Point(79, 21);
            this.boxKey.Name = "boxKey";
            this.boxKey.ReadOnly = true;
            this.boxKey.Size = new System.Drawing.Size(48, 21);
            this.boxKey.TabIndex = 11;
            this.boxKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxKey_KeyDown);
            // 
            // boxNote
            // 
            this.boxNote.Location = new System.Drawing.Point(6, 21);
            this.boxNote.Name = "boxNote";
            this.boxNote.ReadOnly = true;
            this.boxNote.Size = new System.Drawing.Size(48, 21);
            this.boxNote.TabIndex = 10;
            this.boxNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // showState
            // 
            this.showState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showState.AutoCheck = false;
            this.showState.AutoSize = true;
            this.showState.Location = new System.Drawing.Point(6, 74);
            this.showState.Name = "showState";
            this.showState.Size = new System.Drawing.Size(77, 16);
            this.showState.TabIndex = 9;
            this.showState.Text = "Connected";
            this.showState.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(133, 70);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 24);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // modeBox
            // 
            this.modeBox.AutoSize = true;
            this.modeBox.Checked = true;
            this.modeBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.modeBox.Location = new System.Drawing.Point(198, 22);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(15, 14);
            this.modeBox.TabIndex = 12;
            this.modeBox.UseVisualStyleBackColor = true;
            this.modeBox.CheckedChanged += new System.EventHandler(this.modeBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 236);
            this.Controls.Add(this.groupMain);
            this.Controls.Add(this.groupSerial);
            this.Controls.Add(this.groupMidi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "KeypadHost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupMidi.ResumeLayout(false);
            this.groupSerial.ResumeLayout(false);
            this.groupSerial.PerformLayout();
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupMidi;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Button btnMidi;
        private System.Windows.Forms.ComboBox boxMidi;
        private System.Windows.Forms.GroupBox groupSerial;
        private System.Windows.Forms.ComboBox boxSerial;
        private System.Windows.Forms.Button btnSerial;
        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.Label spliter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.TextBox boxKey;
        private System.Windows.Forms.TextBox boxNote;
        private System.Windows.Forms.RadioButton showState;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox modeBox;
    }
}

