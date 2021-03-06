﻿namespace CharacterCreator
{
    partial class SpriteForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxSheets = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSheet = new System.Windows.Forms.Label();
            this.labelLayers = new System.Windows.Forms.Label();
            this.listViewTiles = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tilex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tiley = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(283, 290);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(362, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 1;
            // 
            // comboBoxSheets
            // 
            this.comboBoxSheets.FormattingEnabled = true;
            this.comboBoxSheets.Location = new System.Drawing.Point(362, 39);
            this.comboBoxSheets.Name = "comboBoxSheets";
            this.comboBoxSheets.Size = new System.Drawing.Size(263, 21);
            this.comboBoxSheets.TabIndex = 2;
            this.comboBoxSheets.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheets_SelectedValueChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(550, 279);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(467, 279);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(321, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name";
            // 
            // labelSheet
            // 
            this.labelSheet.AutoSize = true;
            this.labelSheet.Location = new System.Drawing.Point(321, 42);
            this.labelSheet.Name = "labelSheet";
            this.labelSheet.Size = new System.Drawing.Size(35, 13);
            this.labelSheet.TabIndex = 7;
            this.labelSheet.Text = "Sheet";
            // 
            // labelLayers
            // 
            this.labelLayers.AutoSize = true;
            this.labelLayers.Location = new System.Drawing.Point(321, 67);
            this.labelLayers.Name = "labelLayers";
            this.labelLayers.Size = new System.Drawing.Size(38, 13);
            this.labelLayers.TabIndex = 8;
            this.labelLayers.Text = "Layers";
            // 
            // listViewTiles
            // 
            this.listViewTiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.priority,
            this.tilex,
            this.tiley});
            this.listViewTiles.LabelEdit = true;
            this.listViewTiles.Location = new System.Drawing.Point(362, 66);
            this.listViewTiles.MultiSelect = false;
            this.listViewTiles.Name = "listViewTiles";
            this.listViewTiles.Size = new System.Drawing.Size(263, 206);
            this.listViewTiles.TabIndex = 9;
            this.listViewTiles.UseCompatibleStateImageBehavior = false;
            this.listViewTiles.View = System.Windows.Forms.View.Details;
            this.listViewTiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewTiles_AfterLabelEdit);
            this.listViewTiles.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Layer Name";
            this.name.Width = 73;
            // 
            // priority
            // 
            this.priority.Text = "Priority";
            // 
            // tilex
            // 
            this.tilex.Text = "Tile X";
            // 
            // tiley
            // 
            this.tiley.Text = "Tile Y";
            this.tiley.Width = 72;
            // 
            // SpriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 316);
            this.Controls.Add(this.listViewTiles);
            this.Controls.Add(this.labelLayers);
            this.Controls.Add(this.labelSheet);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.comboBoxSheets);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "SpriteForm";
            this.Text = "Sprite";
            this.Activated += new System.EventHandler(this.SpriteForm_Activated);
            this.Load += new System.EventHandler(this.SpriteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxSheets;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSheet;
        private System.Windows.Forms.Label labelLayers;
        private System.Windows.Forms.ListView listViewTiles;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader priority;
        private System.Windows.Forms.ColumnHeader tilex;
        private System.Windows.Forms.ColumnHeader tiley;
    }
}