namespace sample
{
    partial class form_map
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_map));
            this.map_raw = new GMap.NET.WindowsForms.GMapControl();
            this.btn_hamveri_sec = new System.Windows.Forms.Button();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.btn_veri_indirge = new System.Windows.Forms.Button();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.reduct_map = new GMap.NET.WindowsForms.GMapControl();
            this.lbl_ratio = new System.Windows.Forms.Label();
            this.btn_sorgu = new System.Windows.Forms.Button();
            this.max_lat = new System.Windows.Forms.TextBox();
            this.max_long = new System.Windows.Forms.TextBox();
            this.grpbx_sorgu = new System.Windows.Forms.GroupBox();
            this.rb_reduct = new System.Windows.Forms.RadioButton();
            this.rb_raw = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.min_long = new System.Windows.Forms.TextBox();
            this.min_lat = new System.Windows.Forms.TextBox();
            this.lbl_raw_coordinate = new System.Windows.Forms.Label();
            this.lbl_reduce_coordinate = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.grpbx_sorgu.SuspendLayout();
            this.SuspendLayout();
            // 
            // map_raw
            // 
            this.map_raw.AutoSize = true;
            this.map_raw.Bearing = 0F;
            this.map_raw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map_raw.CanDragMap = true;
            this.map_raw.EmptyTileColor = System.Drawing.Color.Navy;
            this.map_raw.GrayScaleMode = true;
            this.map_raw.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map_raw.LevelsKeepInMemmory = 5;
            this.map_raw.Location = new System.Drawing.Point(12, 127);
            this.map_raw.MarkersEnabled = true;
            this.map_raw.MaxZoom = 100;
            this.map_raw.MinZoom = 5;
            this.map_raw.MouseWheelZoomEnabled = true;
            this.map_raw.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.ViewCenter;
            this.map_raw.Name = "map_raw";
            this.map_raw.NegativeMode = true;
            this.map_raw.PolygonsEnabled = true;
            this.map_raw.RetryLoadTile = 0;
            this.map_raw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.map_raw.RoutesEnabled = true;
            this.map_raw.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map_raw.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map_raw.ShowTileGridLines = false;
            this.map_raw.Size = new System.Drawing.Size(540, 480);
            this.map_raw.TabIndex = 0;
            this.map_raw.Visible = false;
            this.map_raw.Zoom = 25D;
            this.map_raw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_raw_MouseClick);
            this.map_raw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_raw_MouseMove);
            // 
            // btn_hamveri_sec
            // 
            this.btn_hamveri_sec.Location = new System.Drawing.Point(12, 23);
            this.btn_hamveri_sec.Name = "btn_hamveri_sec";
            this.btn_hamveri_sec.Size = new System.Drawing.Size(118, 25);
            this.btn_hamveri_sec.TabIndex = 1;
            this.btn_hamveri_sec.Text = "Ham Veri";
            this.btn_hamveri_sec.UseVisualStyleBackColor = true;
            this.btn_hamveri_sec.Click += new System.EventHandler(this.btn_hamveri_sec_Click);
            // 
            // open_file
            // 
            this.open_file.FileName = "openFileDialog1";
            // 
            // btn_veri_indirge
            // 
            this.btn_veri_indirge.Location = new System.Drawing.Point(171, 23);
            this.btn_veri_indirge.Name = "btn_veri_indirge";
            this.btn_veri_indirge.Size = new System.Drawing.Size(151, 23);
            this.btn_veri_indirge.TabIndex = 2;
            this.btn_veri_indirge.Text = "Verileri İndirge";
            this.btn_veri_indirge.UseVisualStyleBackColor = true;
            this.btn_veri_indirge.Click += new System.EventHandler(this.btn_veri_indirge_Click);
            // 
            // pb_image
            // 
            this.pb_image.Image = ((System.Drawing.Image)(resources.GetObject("pb_image.Image")));
            this.pb_image.Location = new System.Drawing.Point(12, 52);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(540, 330);
            this.pb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_image.TabIndex = 3;
            this.pb_image.TabStop = false;
            // 
            // reduct_map
            // 
            this.reduct_map.AutoSize = true;
            this.reduct_map.Bearing = 0F;
            this.reduct_map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reduct_map.CanDragMap = true;
            this.reduct_map.EmptyTileColor = System.Drawing.Color.Navy;
            this.reduct_map.GrayScaleMode = true;
            this.reduct_map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.reduct_map.LevelsKeepInMemmory = 5;
            this.reduct_map.Location = new System.Drawing.Point(558, 127);
            this.reduct_map.MarkersEnabled = true;
            this.reduct_map.MaxZoom = 100;
            this.reduct_map.MinZoom = 5;
            this.reduct_map.MouseWheelZoomEnabled = true;
            this.reduct_map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.reduct_map.Name = "reduct_map";
            this.reduct_map.NegativeMode = false;
            this.reduct_map.PolygonsEnabled = true;
            this.reduct_map.RetryLoadTile = 0;
            this.reduct_map.RoutesEnabled = true;
            this.reduct_map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.reduct_map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.reduct_map.ShowTileGridLines = false;
            this.reduct_map.Size = new System.Drawing.Size(540, 480);
            this.reduct_map.TabIndex = 4;
            this.reduct_map.Visible = false;
            this.reduct_map.Zoom = 25D;
            this.reduct_map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.reduct_map_MouseClick);
            this.reduct_map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.reduct_map_MouseMove);
            // 
            // lbl_ratio
            // 
            this.lbl_ratio.AutoSize = true;
            this.lbl_ratio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ratio.Location = new System.Drawing.Point(334, 23);
            this.lbl_ratio.Name = "lbl_ratio";
            this.lbl_ratio.Size = new System.Drawing.Size(0, 15);
            this.lbl_ratio.TabIndex = 5;
            // 
            // btn_sorgu
            // 
            this.btn_sorgu.Location = new System.Drawing.Point(204, 63);
            this.btn_sorgu.Name = "btn_sorgu";
            this.btn_sorgu.Size = new System.Drawing.Size(75, 23);
            this.btn_sorgu.TabIndex = 6;
            this.btn_sorgu.Text = "Sorgu Yap";
            this.btn_sorgu.UseVisualStyleBackColor = true;
            this.btn_sorgu.Click += new System.EventHandler(this.btn_sorgu_Click);
            // 
            // max_lat
            // 
            this.max_lat.Location = new System.Drawing.Point(41, 19);
            this.max_lat.Name = "max_lat";
            this.max_lat.Size = new System.Drawing.Size(60, 20);
            this.max_lat.TabIndex = 7;
            // 
            // max_long
            // 
            this.max_long.Location = new System.Drawing.Point(41, 56);
            this.max_long.Name = "max_long";
            this.max_long.Size = new System.Drawing.Size(60, 20);
            this.max_long.TabIndex = 8;
            // 
            // grpbx_sorgu
            // 
            this.grpbx_sorgu.Controls.Add(this.rb_reduct);
            this.grpbx_sorgu.Controls.Add(this.rb_raw);
            this.grpbx_sorgu.Controls.Add(this.label4);
            this.grpbx_sorgu.Controls.Add(this.btn_sorgu);
            this.grpbx_sorgu.Controls.Add(this.label3);
            this.grpbx_sorgu.Controls.Add(this.label2);
            this.grpbx_sorgu.Controls.Add(this.label1);
            this.grpbx_sorgu.Controls.Add(this.min_long);
            this.grpbx_sorgu.Controls.Add(this.min_lat);
            this.grpbx_sorgu.Controls.Add(this.max_lat);
            this.grpbx_sorgu.Controls.Add(this.max_long);
            this.grpbx_sorgu.Location = new System.Drawing.Point(628, 12);
            this.grpbx_sorgu.Name = "grpbx_sorgu";
            this.grpbx_sorgu.Size = new System.Drawing.Size(313, 90);
            this.grpbx_sorgu.TabIndex = 9;
            this.grpbx_sorgu.TabStop = false;
            this.grpbx_sorgu.Visible = false;
            // 
            // rb_reduct
            // 
            this.rb_reduct.AutoSize = true;
            this.rb_reduct.Location = new System.Drawing.Point(204, 42);
            this.rb_reduct.Name = "rb_reduct";
            this.rb_reduct.Size = new System.Drawing.Size(99, 17);
            this.rb_reduct.TabIndex = 18;
            this.rb_reduct.TabStop = true;
            this.rb_reduct.Text = "İndirgenmiş Veri";
            this.rb_reduct.UseVisualStyleBackColor = true;
            // 
            // rb_raw
            // 
            this.rb_raw.AutoSize = true;
            this.rb_raw.Location = new System.Drawing.Point(204, 19);
            this.rb_raw.Name = "rb_raw";
            this.rb_raw.Size = new System.Drawing.Size(68, 17);
            this.rb_raw.TabIndex = 17;
            this.rb_raw.TabStop = true;
            this.rb_raw.Text = "Ham Veri";
            this.rb_raw.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Minimum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Maximum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Boylam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enlem";
            // 
            // min_long
            // 
            this.min_long.Location = new System.Drawing.Point(121, 56);
            this.min_long.Name = "min_long";
            this.min_long.Size = new System.Drawing.Size(60, 20);
            this.min_long.TabIndex = 10;
            // 
            // min_lat
            // 
            this.min_lat.Location = new System.Drawing.Point(121, 19);
            this.min_lat.Name = "min_lat";
            this.min_lat.Size = new System.Drawing.Size(60, 20);
            this.min_lat.TabIndex = 9;
            // 
            // lbl_raw_coordinate
            // 
            this.lbl_raw_coordinate.AutoSize = true;
            this.lbl_raw_coordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_raw_coordinate.Location = new System.Drawing.Point(13, 614);
            this.lbl_raw_coordinate.Name = "lbl_raw_coordinate";
            this.lbl_raw_coordinate.Size = new System.Drawing.Size(0, 15);
            this.lbl_raw_coordinate.TabIndex = 10;
            this.lbl_raw_coordinate.Visible = false;
            // 
            // lbl_reduce_coordinate
            // 
            this.lbl_reduce_coordinate.AutoSize = true;
            this.lbl_reduce_coordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reduce_coordinate.Location = new System.Drawing.Point(555, 614);
            this.lbl_reduce_coordinate.Name = "lbl_reduce_coordinate";
            this.lbl_reduce_coordinate.Size = new System.Drawing.Size(0, 15);
            this.lbl_reduce_coordinate.TabIndex = 11;
            this.lbl_reduce_coordinate.Visible = false;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(508, 23);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(0, 15);
            this.lbl_time.TabIndex = 12;
            // 
            // form_map
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1003, 716);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_reduce_coordinate);
            this.Controls.Add(this.lbl_raw_coordinate);
            this.Controls.Add(this.grpbx_sorgu);
            this.Controls.Add(this.lbl_ratio);
            this.Controls.Add(this.reduct_map);
            this.Controls.Add(this.pb_image);
            this.Controls.Add(this.btn_veri_indirge);
            this.Controls.Add(this.btn_hamveri_sec);
            this.Controls.Add(this.map_raw);
            this.Name = "form_map";
            this.Text = "Gezinge Verisi İşleme";
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.grpbx_sorgu.ResumeLayout(false);
            this.grpbx_sorgu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl map_raw;
        private System.Windows.Forms.Button btn_hamveri_sec;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.Button btn_veri_indirge;
        private System.Windows.Forms.PictureBox pb_image;
        private GMap.NET.WindowsForms.GMapControl reduct_map;
        private System.Windows.Forms.Label lbl_ratio;
        private System.Windows.Forms.Button btn_sorgu;
        private System.Windows.Forms.TextBox max_lat;
        private System.Windows.Forms.TextBox max_long;
        private System.Windows.Forms.GroupBox grpbx_sorgu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox min_long;
        private System.Windows.Forms.TextBox min_lat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_reduct;
        private System.Windows.Forms.RadioButton rb_raw;
        private System.Windows.Forms.Label lbl_raw_coordinate;
        private System.Windows.Forms.Label lbl_reduce_coordinate;
        private System.Windows.Forms.Label lbl_time;
    }
}

