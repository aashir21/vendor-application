﻿namespace Vendor_App
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
            this.product = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // product
            // 
            this.product.Location = new System.Drawing.Point(0, 0);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(137, 62);
            this.product.TabIndex = 0;
            this.product.Text = "Products";
            this.product.UseVisualStyleBackColor = true;
            this.product.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reviews";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.CausesValidation = false;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(653, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 62);
            this.button4.TabIndex = 4;
            this.button4.Text = "Manage - Settings";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hello";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(134, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 62);
            this.button5.TabIndex = 6;
            this.button5.Text = "Vendors";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Upload Files For A Vendor";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(263, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 62);
            this.button3.TabIndex = 2;
            this.button3.Text = "Client\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(17, 287);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 47);
            this.button6.TabIndex = 8;
            this.button6.Text = "Upload File";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 229);
            this.textBox1.MinimumSize = new System.Drawing.Size(309, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 35);
            this.textBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(16, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "For file uploading, please provide a Vendor ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 517);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.product);
            this.Name = "Form1";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button product;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}

