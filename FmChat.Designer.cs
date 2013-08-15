namespace ChatChatBroadcast
{
    partial class FmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmChat));
            this.TxtDisplayMessage = new System.Windows.Forms.TextBox();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.BtnSendMessage = new System.Windows.Forms.Button();
            this.BtnClearDisplayMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtDisplayMessage
            // 
            this.TxtDisplayMessage.BackColor = System.Drawing.Color.White;
            this.TxtDisplayMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDisplayMessage.Location = new System.Drawing.Point(12, 12);
            this.TxtDisplayMessage.Multiline = true;
            this.TxtDisplayMessage.Name = "TxtDisplayMessage";
            this.TxtDisplayMessage.ReadOnly = true;
            this.TxtDisplayMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDisplayMessage.Size = new System.Drawing.Size(486, 245);
            this.TxtDisplayMessage.TabIndex = 1;
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(12, 265);
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(405, 20);
            this.TxtMessage.TabIndex = 0;
            this.TxtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // BtnSendMessage
            // 
            this.BtnSendMessage.Location = new System.Drawing.Point(423, 262);
            this.BtnSendMessage.Name = "BtnSendMessage";
            this.BtnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.BtnSendMessage.TabIndex = 2;
            this.BtnSendMessage.Text = "ส่งข้อความ";
            this.BtnSendMessage.UseVisualStyleBackColor = true;
            this.BtnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // BtnClearDisplayMessage
            // 
            this.BtnClearDisplayMessage.BackColor = System.Drawing.Color.White;
            this.BtnClearDisplayMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearDisplayMessage.Location = new System.Drawing.Point(444, 15);
            this.BtnClearDisplayMessage.Name = "BtnClearDisplayMessage";
            this.BtnClearDisplayMessage.Size = new System.Drawing.Size(33, 23);
            this.BtnClearDisplayMessage.TabIndex = 3;
            this.BtnClearDisplayMessage.Text = "ล้าง";
            this.BtnClearDisplayMessage.UseVisualStyleBackColor = false;
            this.BtnClearDisplayMessage.Click += new System.EventHandler(this.BtnClearDisplayMessage_Click);
            // 
            // FmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 294);
            this.Controls.Add(this.BtnClearDisplayMessage);
            this.Controls.Add(this.BtnSendMessage);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.TxtDisplayMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FmChat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmChat_FormClosing);
            this.Load += new System.EventHandler(this.FmChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtDisplayMessage;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnSendMessage;
        private System.Windows.Forms.Button BtnClearDisplayMessage;
    }
}