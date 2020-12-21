namespace Snake_Game
{
    partial class GamePlay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePlay));
            this.Label_Score_P1 = new System.Windows.Forms.Label();
            this.P1_Score = new System.Windows.Forms.Label();
            this.End = new System.Windows.Forms.Label();
            this.Game_Timer = new System.Windows.Forms.Timer(this.components);
            this.P2_Score = new System.Windows.Forms.Label();
            this.Label_Score_P2 = new System.Windows.Forms.Label();
            this.Label_Target = new System.Windows.Forms.Label();
            this.Target_Score = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.Food_music = new AxWMPLib.AxWindowsMediaPlayer();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Food_music)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Score_P1
            // 
            this.Label_Score_P1.AutoSize = true;
            this.Label_Score_P1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Score_P1.Location = new System.Drawing.Point(633, 140);
            this.Label_Score_P1.Name = "Label_Score_P1";
            this.Label_Score_P1.Size = new System.Drawing.Size(95, 27);
            this.Label_Score_P1.TabIndex = 1;
            this.Label_Score_P1.Text = "P1 Score";
            // 
            // P1_Score
            // 
            this.P1_Score.AutoSize = true;
            this.P1_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1_Score.Location = new System.Drawing.Point(734, 140);
            this.P1_Score.Name = "P1_Score";
            this.P1_Score.Size = new System.Drawing.Size(46, 31);
            this.P1_Score.TabIndex = 2;
            this.P1_Score.Text = "00";
            // 
            // End
            // 
            this.End.AutoSize = true;
            this.End.BackColor = System.Drawing.Color.Silver;
            this.End.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.End.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.End.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.End.ForeColor = System.Drawing.Color.Teal;
            this.End.Location = new System.Drawing.Point(160, 298);
            this.End.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.End.Name = "End";
            this.End.Padding = new System.Windows.Forms.Padding(10);
            this.End.Size = new System.Drawing.Size(117, 46);
            this.End.TabIndex = 3;
            this.End.Text = "End Text";
            // 
            // P2_Score
            // 
            this.P2_Score.AutoSize = true;
            this.P2_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2_Score.Location = new System.Drawing.Point(734, 202);
            this.P2_Score.Name = "P2_Score";
            this.P2_Score.Size = new System.Drawing.Size(46, 31);
            this.P2_Score.TabIndex = 5;
            this.P2_Score.Text = "00";
            // 
            // Label_Score_P2
            // 
            this.Label_Score_P2.AutoSize = true;
            this.Label_Score_P2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Score_P2.Location = new System.Drawing.Point(633, 202);
            this.Label_Score_P2.Name = "Label_Score_P2";
            this.Label_Score_P2.Size = new System.Drawing.Size(95, 27);
            this.Label_Score_P2.TabIndex = 4;
            this.Label_Score_P2.Text = "P2 Score";
            // 
            // Label_Target
            // 
            this.Label_Target.AutoSize = true;
            this.Label_Target.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Target.Location = new System.Drawing.Point(650, 47);
            this.Label_Target.Name = "Label_Target";
            this.Label_Target.Size = new System.Drawing.Size(130, 38);
            this.Label_Target.TabIndex = 6;
            this.Label_Target.Text = "Target :";
            // 
            // Target_Score
            // 
            this.Target_Score.AutoSize = true;
            this.Target_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Target_Score.Location = new System.Drawing.Point(786, 47);
            this.Target_Score.Name = "Target_Score";
            this.Target_Score.Size = new System.Drawing.Size(57, 39);
            this.Target_Score.TabIndex = 7;
            this.Target_Score.Text = "00";
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(631, 315);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(96, 38);
            this.Result.TabIndex = 8;
            this.Result.Text = "Result";
            // 
            // Play
            // 
            this.Play.AutoSize = true;
            this.Play.Font = new System.Drawing.Font("Comic Sans MS", 30.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.Location = new System.Drawing.Point(150, 258);
            this.Play.Name = "Play";
            this.Play.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.Play.Size = new System.Drawing.Size(136, 78);
            this.Play.TabIndex = 9;
            this.Play.Text = "Play";
            this.Play.Visible = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            this.Play.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Clicked);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(783, 333);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(85, 32);
            this.axWindowsMediaPlayer1.TabIndex = 10;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // Food_music
            // 
            this.Food_music.Enabled = true;
            this.Food_music.Location = new System.Drawing.Point(783, 281);
            this.Food_music.Name = "Food_music";
            this.Food_music.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Food_music.OcxState")));
            this.Food_music.Size = new System.Drawing.Size(85, 30);
            this.Food_music.TabIndex = 11;
            this.Food_music.Visible = false;
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.pbCanvas.BackgroundImage = global::Snake_Game.Properties.Resources.background4_0;
            this.pbCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbCanvas.Enabled = false;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(579, 632);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Update_Graphics);
            // 
            // GamePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 632);
            this.Controls.Add(this.Food_music);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Target_Score);
            this.Controls.Add(this.Label_Target);
            this.Controls.Add(this.P2_Score);
            this.Controls.Add(this.Label_Score_P2);
            this.Controls.Add(this.End);
            this.Controls.Add(this.P1_Score);
            this.Controls.Add(this.Label_Score_P1);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.pbCanvas);
            this.Enabled = false;
            this.Name = "GamePlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.TransparencyKey = System.Drawing.SystemColors.Window;
            this.Load += new System.EventHandler(this.Snake_GameLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Food_music)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label Label_Score_P1;
        private System.Windows.Forms.Label P1_Score;
        private System.Windows.Forms.Label End;
        private System.Windows.Forms.Timer Game_Timer;
        private System.Windows.Forms.Label P2_Score;
        private System.Windows.Forms.Label Label_Score_P2;
        private System.Windows.Forms.Label Label_Target;
        private System.Windows.Forms.Label Target_Score;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label Play;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxWMPLib.AxWindowsMediaPlayer Food_music;
    }
}

