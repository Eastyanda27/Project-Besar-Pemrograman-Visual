
namespace Tugas_Besar
{
    partial class FormDataProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataProduk));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.gambar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_jual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah_jual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.txtboxCariProduk = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(147)))), ((int)(((byte)(241)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 23);
            this.panel3.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(147)))), ((int)(((byte)(241)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.foto,
            this.gambar,
            this.no_produk,
            this.no_barcode,
            this.jenis_produk,
            this.nama_produk,
            this.harga_jual,
            this.jumlah_produk,
            this.jumlah_jual,
            this.hapus});
            this.dataGridView1.Location = new System.Drawing.Point(81, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 60;
            this.dataGridView1.Size = new System.Drawing.Size(643, 272);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // foto
            // 
            this.foto.HeaderText = "Foto";
            this.foto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.foto.Name = "foto";
            this.foto.ReadOnly = true;
            this.foto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.foto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gambar
            // 
            this.gambar.DataPropertyName = "gambar";
            this.gambar.HeaderText = "Gambar";
            this.gambar.Name = "gambar";
            this.gambar.ReadOnly = true;
            // 
            // no_produk
            // 
            this.no_produk.DataPropertyName = "no_produk";
            this.no_produk.HeaderText = "No Produk";
            this.no_produk.Name = "no_produk";
            this.no_produk.ReadOnly = true;
            // 
            // no_barcode
            // 
            this.no_barcode.DataPropertyName = "no_barcode";
            this.no_barcode.HeaderText = "No Barcode";
            this.no_barcode.Name = "no_barcode";
            this.no_barcode.ReadOnly = true;
            // 
            // jenis_produk
            // 
            this.jenis_produk.DataPropertyName = "jenis_produk";
            this.jenis_produk.HeaderText = "Jenis Produk";
            this.jenis_produk.Name = "jenis_produk";
            this.jenis_produk.ReadOnly = true;
            // 
            // nama_produk
            // 
            this.nama_produk.DataPropertyName = "nama_produk";
            this.nama_produk.HeaderText = "Nama Produk";
            this.nama_produk.Name = "nama_produk";
            this.nama_produk.ReadOnly = true;
            // 
            // harga_jual
            // 
            this.harga_jual.DataPropertyName = "harga_jual";
            this.harga_jual.HeaderText = "Harga Produk";
            this.harga_jual.Name = "harga_jual";
            this.harga_jual.ReadOnly = true;
            // 
            // jumlah_produk
            // 
            this.jumlah_produk.DataPropertyName = "jumlah_produk";
            this.jumlah_produk.HeaderText = "Jumlah Produk";
            this.jumlah_produk.Name = "jumlah_produk";
            this.jumlah_produk.ReadOnly = true;
            // 
            // jumlah_jual
            // 
            this.jumlah_jual.DataPropertyName = "jumlah_jual";
            this.jumlah_jual.HeaderText = "Jumlah Terjual";
            this.jumlah_jual.Name = "jumlah_jual";
            this.jumlah_jual.ReadOnly = true;
            // 
            // hapus
            // 
            this.hapus.DataPropertyName = "hapus";
            this.hapus.HeaderText = "Hapus";
            this.hapus.Name = "hapus";
            this.hapus.ReadOnly = true;
            this.hapus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hapus.Text = "Hapus";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(289, 85);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(30, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 38;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(253, 85);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 37;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // txtboxCariProduk
            // 
            this.txtboxCariProduk.Location = new System.Drawing.Point(81, 90);
            this.txtboxCariProduk.Name = "txtboxCariProduk";
            this.txtboxCariProduk.Size = new System.Drawing.Size(165, 20);
            this.txtboxCariProduk.TabIndex = 36;
            this.txtboxCariProduk.Text = "Cari Produk...";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(649, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "KEMBALI";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(147)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 74);
            this.panel2.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "Pegawai";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "Keuangan";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(705, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 19);
            this.label7.TabIndex = 36;
            this.label7.Text = "Laporan";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(592, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "Transaksi";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Profil";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(137)))), ((int)(((byte)(199)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(280, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 68);
            this.panel1.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Produk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.MaximumSize = new System.Drawing.Size(0, 68);
            this.label3.MinimumSize = new System.Drawing.Size(180, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 69);
            this.label3.TabIndex = 4;
            this.label3.Text = "CATAT YUK";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(147)))), ((int)(((byte)(241)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(568, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "EDIT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(487, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 62;
            this.button3.Text = "CETAK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormDataProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(221)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.txtboxCariProduk);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.Name = "FormDataProduk";
            this.Text = "View Produk";
            this.Load += new System.EventHandler(this.FormDataProduk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TextBox txtboxCariProduk;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewImageColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gambar;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_jual;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah_jual;
        private System.Windows.Forms.DataGridViewButtonColumn hapus;
        private System.Windows.Forms.Button button3;
    }
}