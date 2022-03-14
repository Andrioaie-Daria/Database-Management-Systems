namespace Lab2
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
            this.dgvCats = new System.Windows.Forms.DataGridView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBreed = new System.Windows.Forms.TextBox();
            this.txtCrazyLevel = new System.Windows.Forms.TextBox();
            this.txtColour = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgvSlaves = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlaves)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCats
            // 
            this.dgvCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCats.Location = new System.Drawing.Point(31, 40);
            this.dgvCats.Name = "dgvCats";
            this.dgvCats.RowHeadersWidth = 51;
            this.dgvCats.RowTemplate.Height = 24;
            this.dgvCats.Size = new System.Drawing.Size(757, 176);
            this.dgvCats.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(633, 381);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 42);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(31, 263);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 2;
            this.txtID.Text = "CatID";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(163, 263);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(113, 22);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "Name";
            // 
            // txtBreed
            // 
            this.txtBreed.Location = new System.Drawing.Point(305, 263);
            this.txtBreed.Name = "txtBreed";
            this.txtBreed.Size = new System.Drawing.Size(103, 22);
            this.txtBreed.TabIndex = 4;
            this.txtBreed.Text = "Breed";
            // 
            // txtCrazyLevel
            // 
            this.txtCrazyLevel.Location = new System.Drawing.Point(664, 263);
            this.txtCrazyLevel.Name = "txtCrazyLevel";
            this.txtCrazyLevel.Size = new System.Drawing.Size(124, 22);
            this.txtCrazyLevel.TabIndex = 5;
            this.txtCrazyLevel.Text = "Crazyness";
            // 
            // txtColour
            // 
            this.txtColour.Location = new System.Drawing.Point(554, 263);
            this.txtColour.Name = "txtColour";
            this.txtColour.Size = new System.Drawing.Size(100, 22);
            this.txtColour.TabIndex = 6;
            this.txtColour.Text = "Colour";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(429, 263);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 22);
            this.txtAge.TabIndex = 7;
            this.txtAge.Text = "Age";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(60, 306);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 45);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(228, 306);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(141, 45);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(396, 306);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(133, 45);
            this.btnLast.TabIndex = 10;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(564, 306);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(144, 45);
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(81, 381);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(126, 42);
            this.btnInsert.TabIndex = 12;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dgvSlaves
            // 
            this.dgvSlaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSlaves.Location = new System.Drawing.Point(22, 479);
            this.dgvSlaves.Name = "dgvSlaves";
            this.dgvSlaves.RowHeadersWidth = 51;
            this.dgvSlaves.RowTemplate.Height = 24;
            this.dgvSlaves.Size = new System.Drawing.Size(752, 150);
            this.dgvSlaves.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 683);
            this.Controls.Add(this.dgvSlaves);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtColour);
            this.Controls.Add(this.txtCrazyLevel);
            this.Controls.Add(this.txtBreed);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.dgvCats);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCats;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBreed;
        private System.Windows.Forms.TextBox txtCrazyLevel;
        private System.Windows.Forms.TextBox txtColour;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dgvSlaves;
    }
}

