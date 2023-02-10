namespace stdrecors
{
    partial class Form1
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
            this.dgvstd = new System.Windows.Forms.DataGridView();
            this.btnparse = new System.Windows.Forms.Button();
            this.txtfile_path = new System.Windows.Forms.TextBox();
            this.submit_click_Click = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvstd
            // 
            this.dgvstd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstd.Location = new System.Drawing.Point(58, 84);
            this.dgvstd.Name = "dgvstd";
            this.dgvstd.RowHeadersWidth = 62;
            this.dgvstd.RowTemplate.Height = 28;
            this.dgvstd.Size = new System.Drawing.Size(679, 234);
            this.dgvstd.TabIndex = 0;
            // 
            // btnparse
            // 
            this.btnparse.Location = new System.Drawing.Point(538, 27);
            this.btnparse.Name = "btnparse";
            this.btnparse.Size = new System.Drawing.Size(110, 32);
            this.btnparse.TabIndex = 1;
            this.btnparse.Text = "browse";
            this.btnparse.UseVisualStyleBackColor = true;
            this.btnparse.Click += new System.EventHandler(this.btnparse_Click);
            // 
            // txtfile_path
            // 
            this.txtfile_path.Location = new System.Drawing.Point(216, 25);
            this.txtfile_path.Name = "txtfile_path";
            this.txtfile_path.Size = new System.Drawing.Size(252, 26);
            this.txtfile_path.TabIndex = 2;
            // 
            // submit_click_Click
            // 
            this.submit_click_Click.Location = new System.Drawing.Point(124, 371);
            this.submit_click_Click.Name = "submit_click_Click";
            this.submit_click_Click.Size = new System.Drawing.Size(99, 44);
            this.submit_click_Click.TabIndex = 3;
            this.submit_click_Click.TabStop = false;
            this.submit_click_Click.Text = "Import";
            this.submit_click_Click.UseVisualStyleBackColor = true;
            this.submit_click_Click.Click += new System.EventHandler(this.submit_click_Click_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(301, 380);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 26);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.submit_click_Click);
            this.Controls.Add(this.txtfile_path);
            this.Controls.Add(this.btnparse);
            this.Controls.Add(this.dgvstd);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvstd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvstd;
        private System.Windows.Forms.Button btnparse;
        private System.Windows.Forms.TextBox txtfile_path;
        private System.Windows.Forms.Button submit_click_Click;
        private System.Windows.Forms.TextBox textBox1;
    }
}

