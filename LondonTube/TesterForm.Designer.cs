namespace LondonTube
{
    partial class TesterForm
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
            this._calculateButton = new System.Windows.Forms.Button();
            this._stations = new System.Windows.Forms.ComboBox();
            this._numberOfStops = new System.Windows.Forms.NumericUpDown();
            this._stationsFound = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this._numberOfStops)).BeginInit();
            this.SuspendLayout();
            // 
            // _calculateButton
            // 
            this._calculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._calculateButton.Location = new System.Drawing.Point(232, 255);
            this._calculateButton.Name = "_calculateButton";
            this._calculateButton.Size = new System.Drawing.Size(75, 23);
            this._calculateButton.TabIndex = 0;
            this._calculateButton.Text = "Calculate";
            this._calculateButton.UseVisualStyleBackColor = true;
            this._calculateButton.Click += new System.EventHandler(this._calculateButtonClick);
            // 
            // _stations
            // 
            this._stations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._stations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._stations.FormattingEnabled = true;
            this._stations.Location = new System.Drawing.Point(13, 13);
            this._stations.Name = "_stations";
            this._stations.Size = new System.Drawing.Size(198, 21);
            this._stations.Sorted = true;
            this._stations.TabIndex = 1;
            // 
            // _numberOfStops
            // 
            this._numberOfStops.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._numberOfStops.Location = new System.Drawing.Point(232, 12);
            this._numberOfStops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numberOfStops.Name = "_numberOfStops";
            this._numberOfStops.Size = new System.Drawing.Size(74, 20);
            this._numberOfStops.TabIndex = 3;
            this._numberOfStops.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._numberOfStops.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // _stationsFound
            // 
            this._stationsFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._stationsFound.FormattingEnabled = true;
            this._stationsFound.Location = new System.Drawing.Point(13, 41);
            this._stationsFound.Name = "_stationsFound";
            this._stationsFound.Size = new System.Drawing.Size(293, 199);
            this._stationsFound.TabIndex = 4;
            // 
            // TesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 290);
            this.Controls.Add(this._stationsFound);
            this.Controls.Add(this._numberOfStops);
            this.Controls.Add(this._stations);
            this.Controls.Add(this._calculateButton);
            this.Name = "TesterForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._numberOfStops)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _calculateButton;
        private System.Windows.Forms.ComboBox _stations;
        private System.Windows.Forms.NumericUpDown _numberOfStops;
        private System.Windows.Forms.ListBox _stationsFound;
    }
}

