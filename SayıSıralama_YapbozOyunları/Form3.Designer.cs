namespace SayıSıralama_YapbozOyunları
{
    partial class SayıKutularıOyunu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BaslaButonu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(100, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 400);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // BaslaButonu
            // 
            this.BaslaButonu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BaslaButonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BaslaButonu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BaslaButonu.Location = new System.Drawing.Point(216, 474);
            this.BaslaButonu.Name = "BaslaButonu";
            this.BaslaButonu.Size = new System.Drawing.Size(150, 75);
            this.BaslaButonu.TabIndex = 2;
            this.BaslaButonu.Text = "Başla";
            this.BaslaButonu.UseVisualStyleBackColor = false;
            this.BaslaButonu.Click += new System.EventHandler(this.BaslaButonu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(216, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hareket Sayısı: ";
            // 
            // SayıKutularıOyunu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaslaButonu);
            this.Controls.Add(this.groupBox1);
            this.Name = "SayıKutularıOyunu";
            this.Text = "Sayı Kutuları Sıralama Oyunu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SayıKutularıOyunu_FormClosing);
            this.Load += new System.EventHandler(this.SayıKutularıOyunu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BaslaButonu;
        private System.Windows.Forms.Label label1;
    }
}