namespace CryptoExchangeRateProvider
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblBinance;
        private System.Windows.Forms.Label lblBybit;
        private System.Windows.Forms.Label lblKucoin;
        private System.Windows.Forms.Label lblBitget;
        private System.Windows.Forms.ComboBox cmbPair;
        private System.Windows.Forms.ComboBox cmbExchange;

        private void InitializeComponent()
        {
            this.timer = new System.Windows.Forms.Timer();
            this.lblBinance = new System.Windows.Forms.Label();
            this.lblBybit = new System.Windows.Forms.Label();
            this.lblKucoin = new System.Windows.Forms.Label();
            this.lblBitget = new System.Windows.Forms.Label();
            this.cmbPair = new System.Windows.Forms.ComboBox();

            this.SuspendLayout();

            // 
            // lblBinance
            // 
            this.lblBinance.AutoSize = true;
            this.lblBinance.Location = new System.Drawing.Point(13, 45);
            this.lblBinance.Name = "Binance";
            this.lblBinance.Size = new System.Drawing.Size(67, 13);
            this.lblBinance.TabIndex = 0;
            this.lblBinance.Text = "Binance: N/A";
            // 
            // lblBybit
            // 
            this.lblBybit.AutoSize = true;
            this.lblBybit.Location = new System.Drawing.Point(13, 68);
            this.lblBybit.Name = "Bybit";
            this.lblBybit.Size = new System.Drawing.Size(54, 13);
            this.lblBybit.TabIndex = 1;
            this.lblBybit.Text = "Bybit: N/A";
            // 
            // lblKucoin
            // 
            this.lblKucoin.AutoSize = true;
            this.lblKucoin.Location = new System.Drawing.Point(13, 91);
            this.lblKucoin.Name = "Kucoin";
            this.lblKucoin.Size = new System.Drawing.Size(63, 13);
            this.lblKucoin.TabIndex = 2;
            this.lblKucoin.Text = "Kucoin: N/A";
            // 
            // lblBitget
            // 
            this.lblBitget.AutoSize = true;
            this.lblBitget.Location = new System.Drawing.Point(13, 114);
            this.lblBitget.Name = "Bitget";
            this.lblBitget.Size = new System.Drawing.Size(56, 13);
            this.lblBitget.TabIndex = 3;
            this.lblBitget.Text = "Bitget: N/A";
            // 
            // cmbPair
            // 
            this.cmbPair.FormattingEnabled = true;
            this.cmbPair.Items.AddRange(new object[] {
                "BTCUSDT",
                "ETHUSDT",
                "BNBUSDT"
            });
            this.cmbPair.Location = new System.Drawing.Point(13, 150);
            this.cmbPair.Name = "cmbPair";
            this.cmbPair.Size = new System.Drawing.Size(121, 21);
            this.cmbPair.TabIndex = 4;

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmbPair);
            this.Controls.Add(this.lblBitget);
            this.Controls.Add(this.lblKucoin);
            this.Controls.Add(this.lblBybit);
            this.Controls.Add(this.lblBinance);
            this.Name = "MainForm";
            this.Text = "Crypto Rates";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.cmbPair.SelectedIndexChanged += new System.EventHandler(this.cmbPair_SelectedIndexChanged);
        }

        #endregion
    }
}
