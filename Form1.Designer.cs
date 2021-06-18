
namespace AppEleicoes
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
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.barraProgresso = new System.Windows.Forms.ProgressBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileSend = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblFilesToSend = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Enabled = false;
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnEnviar.Location = new System.Drawing.Point(676, 406);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(85, 32);
            this.BtnEnviar.TabIndex = 0;
            this.BtnEnviar.Text = "&Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // barraProgresso
            // 
            this.barraProgresso.Location = new System.Drawing.Point(12, 406);
            this.barraProgresso.Name = "barraProgresso";
            this.barraProgresso.Size = new System.Drawing.Size(290, 32);
            this.barraProgresso.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(12, 93);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(749, 292);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(749, 73);
            this.label1.TabIndex = 4;
            this.label1.Text = "App Eleições";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFileSend
            // 
            this.lblFileSend.BackColor = System.Drawing.Color.DarkCyan;
            this.lblFileSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFileSend.ForeColor = System.Drawing.Color.Azure;
            this.lblFileSend.Location = new System.Drawing.Point(604, 406);
            this.lblFileSend.Name = "lblFileSend";
            this.lblFileSend.Size = new System.Drawing.Size(66, 32);
            this.lblFileSend.TabIndex = 5;
            this.lblFileSend.Text = "0%";
            this.lblFileSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(380, 406);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 32);
            this.progressBar1.TabIndex = 6;
            // 
            // lblFilesToSend
            // 
            this.lblFilesToSend.BackColor = System.Drawing.Color.Azure;
            this.lblFilesToSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFilesToSend.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFilesToSend.Location = new System.Drawing.Point(308, 406);
            this.lblFilesToSend.Name = "lblFilesToSend";
            this.lblFilesToSend.Size = new System.Drawing.Size(66, 32);
            this.lblFilesToSend.TabIndex = 7;
            this.lblFilesToSend.Text = "0%";
            this.lblFilesToSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 451);
            this.Controls.Add(this.lblFilesToSend);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblFileSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.barraProgresso);
            this.Controls.Add(this.BtnEnviar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App Eleições";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.ProgressBar barraProgresso;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileSend;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblFilesToSend;
    }
}

