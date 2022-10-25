
namespace Annonsinlämmning
{
    partial class Form7
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShowAds = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnPwd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1078, 225);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnShowAds
            // 
            this.btnShowAds.Location = new System.Drawing.Point(907, 243);
            this.btnShowAds.Name = "btnShowAds";
            this.btnShowAds.Size = new System.Drawing.Size(183, 34);
            this.btnShowAds.TabIndex = 1;
            this.btnShowAds.Text = "Visa alla annonser";
            this.btnShowAds.UseVisualStyleBackColor = true;
            this.btnShowAds.Click += new System.EventHandler(this.btnShowAds_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(12, 499);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(256, 34);
            this.btnGoBack.TabIndex = 2;
            this.btnGoBack.Text = "Gå tillbaka till sök funktionen";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(700, 502);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(259, 31);
            this.txtPwd.TabIndex = 3;
            // 
            // btnPwd
            // 
            this.btnPwd.Location = new System.Drawing.Point(965, 499);
            this.btnPwd.Name = "btnPwd";
            this.btnPwd.Size = new System.Drawing.Size(125, 34);
            this.btnPwd.TabIndex = 4;
            this.btnPwd.Text = "Klar";
            this.btnPwd.UseVisualStyleBackColor = true;
            this.btnPwd.Click += new System.EventHandler(this.btnPwd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Skriv in ditt lösenord för att radera";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPwd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnShowAds);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form7";
            this.Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShowAds;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnPwd;
        private System.Windows.Forms.Label label1;
    }
}