namespace Lab1Enhanced
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
            this.dgvRoutes = new System.Windows.Forms.DataGridView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoutes
            // 
            this.dgvRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutes.Location = new System.Drawing.Point(595, 48);
            this.dgvRoutes.Name = "dgvRoutes";
            this.dgvRoutes.RowHeadersWidth = 51;
            this.dgvRoutes.RowTemplate.Height = 24;
            this.dgvRoutes.Size = new System.Drawing.Size(478, 338);
            this.dgvRoutes.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(938, 466);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(123, 53);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dgvStations
            // 
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Location = new System.Drawing.Point(65, 48);
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.RowHeadersWidth = 51;
            this.dgvStations.RowTemplate.Height = 24;
            this.dgvStations.Size = new System.Drawing.Size(485, 338);
            this.dgvStations.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(775, 466);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 53);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 556);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvStations);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.dgvRoutes);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoutes;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.Button btnUpdate;
    }
}

