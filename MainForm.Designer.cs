namespace MapEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentLayerAndBelowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.dimOtherLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_new = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_open = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_cut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_copy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_layer1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_layer2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_layer3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_all = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_pencil = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_rectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ellipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_fill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_select = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox_tile = new System.Windows.Forms.PictureBox();
            this.listBox_maps = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_map = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tile)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_map)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1029, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Add_File_48;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Open_Folder_48;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Save_48;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Cut_48;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Copy_48;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Paste_48;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Delete_48;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentLayerAndBelowToolStripMenuItem,
            this.allLayersToolStripMenuItem,
            this.toolStripSeparator6,
            this.dimOtherLayersToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // currentLayerAndBelowToolStripMenuItem
            // 
            this.currentLayerAndBelowToolStripMenuItem.Name = "currentLayerAndBelowToolStripMenuItem";
            this.currentLayerAndBelowToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.currentLayerAndBelowToolStripMenuItem.Text = "Current Layer and Below";
            // 
            // allLayersToolStripMenuItem
            // 
            this.allLayersToolStripMenuItem.Name = "allLayersToolStripMenuItem";
            this.allLayersToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.allLayersToolStripMenuItem.Text = "All Layers";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(203, 6);
            // 
            // dimOtherLayersToolStripMenuItem
            // 
            this.dimOtherLayersToolStripMenuItem.Name = "dimOtherLayersToolStripMenuItem";
            this.dimOtherLayersToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dimOtherLayersToolStripMenuItem.Text = "Dim Other Layers";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layer1ToolStripMenuItem,
            this.layer2ToolStripMenuItem,
            this.layer3ToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // layer1ToolStripMenuItem
            // 
            this.layer1ToolStripMenuItem.Image = global::MapEditor.Properties.Resources._1_48;
            this.layer1ToolStripMenuItem.Name = "layer1ToolStripMenuItem";
            this.layer1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.layer1ToolStripMenuItem.Text = "Layer1";
            // 
            // layer2ToolStripMenuItem
            // 
            this.layer2ToolStripMenuItem.Image = global::MapEditor.Properties.Resources._2_48;
            this.layer2ToolStripMenuItem.Name = "layer2ToolStripMenuItem";
            this.layer2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.layer2ToolStripMenuItem.Text = "Layer2";
            // 
            // layer3ToolStripMenuItem
            // 
            this.layer3ToolStripMenuItem.Image = global::MapEditor.Properties.Resources._3_48;
            this.layer3ToolStripMenuItem.Name = "layer3ToolStripMenuItem";
            this.layer3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.layer3ToolStripMenuItem.Text = "Layer3";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pencilToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.elipseToolStripMenuItem,
            this.floodFillToolStripMenuItem,
            this.selectToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Pencil_Tip_48;
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.pencilToolStripMenuItem.Text = "Pencil";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Rectangle_48;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            // 
            // elipseToolStripMenuItem
            // 
            this.elipseToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Ellipse_48;
            this.elipseToolStripMenuItem.Name = "elipseToolStripMenuItem";
            this.elipseToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.elipseToolStripMenuItem.Text = "Ellipse";
            this.elipseToolStripMenuItem.Click += new System.EventHandler(this.elipseToolStripMenuItem_Click);
            // 
            // floodFillToolStripMenuItem
            // 
            this.floodFillToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Fill_Color_48;
            this.floodFillToolStripMenuItem.Name = "floodFillToolStripMenuItem";
            this.floodFillToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.floodFillToolStripMenuItem.Text = "Flood Fill";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Cursor_48;
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_new,
            this.toolStripButton_open,
            this.toolStripButton_save,
            this.toolStripSeparator1,
            this.toolStripButton_cut,
            this.toolStripButton_copy,
            this.toolStripButton_paste,
            this.toolStripButton_delete,
            this.toolStripSeparator2,
            this.toolStripButton_layer1,
            this.toolStripButton_layer2,
            this.toolStripButton_layer3,
            this.toolStripButton_all,
            this.toolStripSeparator4,
            this.toolStripButton_pencil,
            this.toolStripButton_rectangle,
            this.toolStripButton_ellipse,
            this.toolStripButton_fill,
            this.toolStripButton_select});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1029, 36);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_new
            // 
            this.toolStripButton_new.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_new.Image = global::MapEditor.Properties.Resources.Add_File_48;
            this.toolStripButton_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_new.Name = "toolStripButton_new";
            this.toolStripButton_new.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_new.Text = "New Project";
            this.toolStripButton_new.Click += new System.EventHandler(this.toolStripButton_new_Click);
            // 
            // toolStripButton_open
            // 
            this.toolStripButton_open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_open.Image = global::MapEditor.Properties.Resources.Open_Folder_48;
            this.toolStripButton_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_open.Name = "toolStripButton_open";
            this.toolStripButton_open.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_open.Text = "Open Project";
            this.toolStripButton_open.ToolTipText = "Open Project";
            this.toolStripButton_open.Click += new System.EventHandler(this.toolStripButton_open_Click);
            // 
            // toolStripButton_save
            // 
            this.toolStripButton_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_save.Image = global::MapEditor.Properties.Resources.Save_48;
            this.toolStripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_save.Name = "toolStripButton_save";
            this.toolStripButton_save.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_save.Text = "Save Project";
            this.toolStripButton_save.ToolTipText = "Save Project";
            this.toolStripButton_save.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton_cut
            // 
            this.toolStripButton_cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_cut.Image = global::MapEditor.Properties.Resources.Cut_48;
            this.toolStripButton_cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_cut.Name = "toolStripButton_cut";
            this.toolStripButton_cut.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_cut.Text = "toolStripButton4";
            // 
            // toolStripButton_copy
            // 
            this.toolStripButton_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_copy.Image = global::MapEditor.Properties.Resources.Copy_48;
            this.toolStripButton_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_copy.Name = "toolStripButton_copy";
            this.toolStripButton_copy.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_copy.Text = "toolStripButton5";
            // 
            // toolStripButton_paste
            // 
            this.toolStripButton_paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_paste.Image = global::MapEditor.Properties.Resources.Paste_48;
            this.toolStripButton_paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_paste.Name = "toolStripButton_paste";
            this.toolStripButton_paste.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_paste.Text = "toolStripButton6";
            // 
            // toolStripButton_delete
            // 
            this.toolStripButton_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_delete.Image = global::MapEditor.Properties.Resources.Delete_48;
            this.toolStripButton_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_delete.Name = "toolStripButton_delete";
            this.toolStripButton_delete.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_delete.Text = "toolStripButton7";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton_layer1
            // 
            this.toolStripButton_layer1.Checked = true;
            this.toolStripButton_layer1.CheckOnClick = true;
            this.toolStripButton_layer1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton_layer1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_layer1.Image = global::MapEditor.Properties.Resources._1_48;
            this.toolStripButton_layer1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_layer1.Name = "toolStripButton_layer1";
            this.toolStripButton_layer1.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_layer1.Text = "Layer 1";
            this.toolStripButton_layer1.Click += new System.EventHandler(this.toolStripButton_layer1_Click);
            // 
            // toolStripButton_layer2
            // 
            this.toolStripButton_layer2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_layer2.Image = global::MapEditor.Properties.Resources._2_48;
            this.toolStripButton_layer2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_layer2.Name = "toolStripButton_layer2";
            this.toolStripButton_layer2.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_layer2.Text = "Layer 2";
            this.toolStripButton_layer2.Click += new System.EventHandler(this.toolStripButton_layer2_Click);
            // 
            // toolStripButton_layer3
            // 
            this.toolStripButton_layer3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton_layer3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_layer3.Image = global::MapEditor.Properties.Resources._3_48;
            this.toolStripButton_layer3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_layer3.Name = "toolStripButton_layer3";
            this.toolStripButton_layer3.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_layer3.Text = "Layer 3";
            this.toolStripButton_layer3.Click += new System.EventHandler(this.toolStripButton_layer3_Click);
            // 
            // toolStripButton_all
            // 
            this.toolStripButton_all.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_all.Image = global::MapEditor.Properties.Resources.Sugar_Cube_50;
            this.toolStripButton_all.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_all.Name = "toolStripButton_all";
            this.toolStripButton_all.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_all.Text = "Show All";
            this.toolStripButton_all.Click += new System.EventHandler(this.toolStripButton_all_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButton_pencil
            // 
            this.toolStripButton_pencil.Checked = true;
            this.toolStripButton_pencil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton_pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pencil.Image = global::MapEditor.Properties.Resources.Pencil_Tip_48;
            this.toolStripButton_pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pencil.Name = "toolStripButton_pencil";
            this.toolStripButton_pencil.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_pencil.Text = "Pencil";
            this.toolStripButton_pencil.Click += new System.EventHandler(this.toolStripButton_pencil_Click);
            // 
            // toolStripButton_rectangle
            // 
            this.toolStripButton_rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_rectangle.Image = global::MapEditor.Properties.Resources.Rectangle_48;
            this.toolStripButton_rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_rectangle.Name = "toolStripButton_rectangle";
            this.toolStripButton_rectangle.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_rectangle.Text = "Rectangle";
            this.toolStripButton_rectangle.Click += new System.EventHandler(this.toolStripButton_rectangle_Click);
            // 
            // toolStripButton_ellipse
            // 
            this.toolStripButton_ellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ellipse.Image = global::MapEditor.Properties.Resources.Ellipse_48;
            this.toolStripButton_ellipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ellipse.Name = "toolStripButton_ellipse";
            this.toolStripButton_ellipse.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_ellipse.Text = "Ellipse";
            this.toolStripButton_ellipse.ToolTipText = "Ellipse";
            this.toolStripButton_ellipse.Click += new System.EventHandler(this.toolStripButton_ellipse_Click);
            // 
            // toolStripButton_fill
            // 
            this.toolStripButton_fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_fill.Image = global::MapEditor.Properties.Resources.Fill_Color_48;
            this.toolStripButton_fill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_fill.Name = "toolStripButton_fill";
            this.toolStripButton_fill.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_fill.Text = "Flood Fill";
            this.toolStripButton_fill.ToolTipText = "Flood Fill";
            this.toolStripButton_fill.Click += new System.EventHandler(this.toolStripButton_fill_Click);
            // 
            // toolStripButton_select
            // 
            this.toolStripButton_select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_select.Image = global::MapEditor.Properties.Resources.Cursor_48;
            this.toolStripButton_select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_select.Name = "toolStripButton_select";
            this.toolStripButton_select.Size = new System.Drawing.Size(29, 33);
            this.toolStripButton_select.Text = "Select";
            this.toolStripButton_select.Click += new System.EventHandler(this.toolStripButton_select_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 561);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_tile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.listBox_maps);
            this.splitContainer1.Size = new System.Drawing.Size(275, 553);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // pictureBox_tile
            // 
            this.pictureBox_tile.BackColor = System.Drawing.Color.White;
            this.pictureBox_tile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_tile.InitialImage = null;
            this.pictureBox_tile.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_tile.Name = "pictureBox_tile";
            this.pictureBox_tile.Size = new System.Drawing.Size(258, 576);
            this.pictureBox_tile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_tile.TabIndex = 0;
            this.pictureBox_tile.TabStop = false;
            // 
            // listBox_maps
            // 
            this.listBox_maps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_maps.FormattingEnabled = true;
            this.listBox_maps.ItemHeight = 12;
            this.listBox_maps.Location = new System.Drawing.Point(0, 0);
            this.listBox_maps.Name = "listBox_maps";
            this.listBox_maps.Size = new System.Drawing.Size(275, 176);
            this.listBox_maps.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.pictureBox_map);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(283, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 519);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox_map
            // 
            this.pictureBox_map.BackColor = System.Drawing.Color.White;
            this.pictureBox_map.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_map.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_map.Name = "pictureBox_map";
            this.pictureBox_map.Size = new System.Drawing.Size(512, 446);
            this.pictureBox_map.TabIndex = 0;
            this.pictureBox_map.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1029, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 621);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Map Editor";
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tile)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_new;
        private System.Windows.Forms.ToolStripButton toolStripButton_open;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButton_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_cut;
        private System.Windows.Forms.ToolStripButton toolStripButton_copy;
        private System.Windows.Forms.ToolStripButton toolStripButton_paste;
        private System.Windows.Forms.ToolStripButton toolStripButton_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_layer1;
        private System.Windows.Forms.ToolStripButton toolStripButton_layer2;
        private System.Windows.Forms.ToolStripButton toolStripButton_layer3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_pencil;
        private System.Windows.Forms.ToolStripButton toolStripButton_rectangle;
        private System.Windows.Forms.ToolStripButton toolStripButton_select;
        private System.Windows.Forms.ToolStripMenuItem currentLayerAndBelowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem dimOtherLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox_tile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_map;
        private System.Windows.Forms.ToolStripButton toolStripButton_fill;
        private System.Windows.Forms.ToolStripButton toolStripButton_ellipse;
        private System.Windows.Forms.ToolStripButton toolStripButton_all;
        private System.Windows.Forms.ListBox listBox_maps;
    }
}

