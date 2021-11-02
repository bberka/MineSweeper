
namespace MineSweeper
{
    partial class Game
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
            this.gameBoard = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboBoard = new System.Windows.Forms.ComboBox();
            this.BoardLabel = new System.Windows.Forms.Label();
            this.LabelP = new System.Windows.Forms.Label();
            this.panelControl = new System.Windows.Forms.Panel();
            this.PointLabel = new System.Windows.Forms.Label();
            this.checkShowBomb = new System.Windows.Forms.CheckBox();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameBoard
            // 
            this.gameBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameBoard.Location = new System.Drawing.Point(156, 12);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(6, 365);
            this.gameBoard.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonStart.Location = new System.Drawing.Point(7, 121);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(125, 32);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboDifficulty
            // 
            this.comboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboDifficulty.FormattingEnabled = true;
            this.comboDifficulty.Items.AddRange(new object[] {
            "EASY",
            "MEDIUM",
            "HARD"});
            this.comboDifficulty.Location = new System.Drawing.Point(7, 23);
            this.comboDifficulty.Name = "comboDifficulty";
            this.comboDifficulty.Size = new System.Drawing.Size(121, 24);
            this.comboDifficulty.TabIndex = 3;
            this.comboDifficulty.TabStop = false;
            this.comboDifficulty.SelectedIndexChanged += new System.EventHandler(this.comboDifficulty_SelectedIndexChanged);
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DifficultyLabel.Location = new System.Drawing.Point(3, 0);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(118, 20);
            this.DifficultyLabel.TabIndex = 4;
            this.DifficultyLabel.Text = "Select Difficulty";
            // 
            // buttonReset
            // 
            this.buttonReset.Enabled = false;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonReset.Location = new System.Drawing.Point(7, 173);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(125, 32);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.TabStop = false;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // comboBoard
            // 
            this.comboBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoard.Enabled = false;
            this.comboBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoard.FormattingEnabled = true;
            this.comboBoard.Items.AddRange(new object[] {
            "10x10",
            "15x15",
            "20x20"});
            this.comboBoard.Location = new System.Drawing.Point(7, 82);
            this.comboBoard.Name = "comboBoard";
            this.comboBoard.Size = new System.Drawing.Size(121, 24);
            this.comboBoard.TabIndex = 5;
            this.comboBoard.TabStop = false;
            this.comboBoard.SelectedIndexChanged += new System.EventHandler(this.comboBoard_SelectedIndexChanged);
            // 
            // BoardLabel
            // 
            this.BoardLabel.AutoSize = true;
            this.BoardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BoardLabel.Location = new System.Drawing.Point(3, 59);
            this.BoardLabel.Name = "BoardLabel";
            this.BoardLabel.Size = new System.Drawing.Size(101, 20);
            this.BoardLabel.TabIndex = 6;
            this.BoardLabel.Text = "Select Board";
            // 
            // LabelP
            // 
            this.LabelP.AutoSize = true;
            this.LabelP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelP.Location = new System.Drawing.Point(4, 223);
            this.LabelP.Name = "LabelP";
            this.LabelP.Size = new System.Drawing.Size(61, 20);
            this.LabelP.TabIndex = 7;
            this.LabelP.Text = "Points: ";
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.PointLabel);
            this.panelControl.Controls.Add(this.checkShowBomb);
            this.panelControl.Controls.Add(this.DifficultyLabel);
            this.panelControl.Controls.Add(this.LabelP);
            this.panelControl.Controls.Add(this.buttonStart);
            this.panelControl.Controls.Add(this.BoardLabel);
            this.panelControl.Controls.Add(this.comboDifficulty);
            this.panelControl.Controls.Add(this.comboBoard);
            this.panelControl.Controls.Add(this.buttonReset);
            this.panelControl.Location = new System.Drawing.Point(12, 12);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(138, 285);
            this.panelControl.TabIndex = 8;
            // 
            // PointLabel
            // 
            this.PointLabel.AutoSize = true;
            this.PointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PointLabel.ForeColor = System.Drawing.Color.Red;
            this.PointLabel.Location = new System.Drawing.Point(70, 217);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.Size = new System.Drawing.Size(27, 29);
            this.PointLabel.TabIndex = 11;
            this.PointLabel.Text = "0";
            // 
            // checkShowBomb
            // 
            this.checkShowBomb.AutoSize = true;
            this.checkShowBomb.Enabled = false;
            this.checkShowBomb.Location = new System.Drawing.Point(7, 259);
            this.checkShowBomb.Name = "checkShowBomb";
            this.checkShowBomb.Size = new System.Drawing.Size(88, 17);
            this.checkShowBomb.TabIndex = 9;
            this.checkShowBomb.Text = "Show Bombs";
            this.checkShowBomb.UseVisualStyleBackColor = true;
            this.checkShowBomb.CheckedChanged += new System.EventHandler(this.checkShowBomb_CheckedChanged);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(160, 381);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.gameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.ShowIcon = false;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gameBoard;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ComboBox comboBoard;
        private System.Windows.Forms.Label BoardLabel;
        private System.Windows.Forms.Label LabelP;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.CheckBox checkShowBomb;
        private System.Windows.Forms.Label PointLabel;
    }
}

