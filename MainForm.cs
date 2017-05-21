using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    enum MapBrush {pencil, rectangle, ellipse, fill, select };
    public partial class MainForm : Form
    {
        static Map map = null;
        static MapBrush mapBrush = MapBrush.pencil;
        static int layer;
        static private string projectPath;
        static BindingList<Map> mapList = new BindingList<Map>();
        private bool isMouseDown = false;

        private string _selectedMenuItem;
        private readonly ContextMenuStrip mapsContextMenuStrip;
        public MainForm()
        {
            InitializeComponent();
            panel1.ClientSize = new Size(panel1.Width, tableLayoutPanel1.Height - 23);//TODO: fix this fuckin thing
            layer = 1;

            listBox_maps.DataSource = mapList;
            

            pictureBox_tile.MouseMove += new MouseEventHandler(pictureBox_tile_MouseMove);
            pictureBox_tile.MouseDown += new MouseEventHandler(pictureBox_tile_MouseDown);
            pictureBox_tile.MouseUp += new MouseEventHandler(pictureBox_tile_MouseUp);
            pictureBox_map.MouseMove += new MouseEventHandler(pictureBox_map_MouseMove);
            pictureBox_map.MouseDown += new MouseEventHandler(pictureBox_map_MouseDown);
            pictureBox_map.MouseUp += new MouseEventHandler(pictureBox_map_MouseUp);
            pictureBox_map.MouseLeave += new EventHandler(pictureBox_map_MouseLeave);

            var toolStripMenuItem_map_properties = new ToolStripMenuItem { Text = "Map Properties" };
            var toolStripMenuItem_new_map = new ToolStripMenuItem { Text = "New Map" };
            toolStripMenuItem_new_map.Click +=  toolStripMenuItem_new_map_click;

            //toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            mapsContextMenuStrip = new ContextMenuStrip();
            mapsContextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_map_properties, new ToolStripSeparator(), toolStripMenuItem_new_map });
            listBox_maps.MouseDown += listBox_maps_MouseDown;


        }

        private void toolStripMenuItem_new_map_click(object sender, EventArgs e)
        {

            //Map newMap = new Map()
        }

        private void listBox_maps_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = listBox_maps.IndexFromPoint(e.Location);
            mapsContextMenuStrip.Items[0].Enabled = true;
            if (index != ListBox.NoMatches)
            {
                _selectedMenuItem = listBox_maps.Items[index].ToString();
                mapsContextMenuStrip.Show(Cursor.Position);
                mapsContextMenuStrip.Visible = true;
            }
            else
            {
                if (listBox_maps.SelectedItem != null)
                {
                    _selectedMenuItem = listBox_maps.SelectedItem.ToString();
                }
                else
                {
                    mapsContextMenuStrip.Items[0].Enabled = false;
                }
                
                mapsContextMenuStrip.Show(Cursor.Position);
                mapsContextMenuStrip.Visible = true;
            }
        }

        public void OnNewProject(string path)
        {
            projectPath = path;
            if(!Directory.Exists(path+ "\\tiles"))
            {
                Directory.CreateDirectory(path + "\\tiles");
            }
            this.Text = "Map Editor  " + projectPath;
            mapList.Add(new Map("Map 000", 0, 16, 16, 1, projectPath, ref pictureBox_tile, ref pictureBox_map));
            listBox_maps.SelectedItem = mapList[mapList.Count - 1];
            map = mapList[mapList.Count-1];
        }

        private void pictureBox_map_MouseLeave(object sender, EventArgs e)
        {
            if (map != null)
                map.ClearMapOverlay();
        }

        private void pictureBox_map_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void pictureBox_map_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if (map != null)
                map.DrawTiles(e.Location, mapBrush);
        }

        private void pictureBox_map_MouseMove(object sender, MouseEventArgs e)
        {
            if (map != null)
            {
                map.DrawMapOverlay(e.Location, mapBrush);
                if (isMouseDown)
                {
                    map.DrawTiles(e.Location, mapBrush);
                }
            }
        }

        private void pictureBox_tile_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (map != null)
                    map.SelectTilesMiddle(e.Location);
            }
        }
        private void pictureBox_tile_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isMouseDown = true;
            if (map != null)
                map.SelectTilesStart(e.Location);
        }
        private void pictureBox_tile_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isMouseDown = false;
            if (map != null)
                map.SelectTilesEnd(e.Location);
        }




        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutbox = new AboutBox();
            aboutbox.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_layer1_Click(object sender, EventArgs e)
        {
            toolStripButton_layer1.Checked = true;
            toolStripButton_layer2.Checked = false;
            toolStripButton_layer3.Checked = false;
            toolStripButton_all.Checked = false;
            layer = 1;
            if (map != null)
                map.SetLayer(1);
        }

        private void toolStripButton_layer2_Click(object sender, EventArgs e)
        {
            toolStripButton_layer1.Checked = false;
            toolStripButton_layer2.Checked = true;
            toolStripButton_layer3.Checked = false;
            toolStripButton_all.Checked = false;
            layer = 2;
            if (map != null)
                map.SetLayer(2);
        }

        private void toolStripButton_layer3_Click(object sender, EventArgs e)
        {
            toolStripButton_layer1.Checked = false;
            toolStripButton_layer2.Checked = false;
            toolStripButton_layer3.Checked = true;
            toolStripButton_all.Checked = false;
            layer = 3;
            if (map != null)
                map.SetLayer(3);
        }

        private void toolStripButton_all_Click(object sender, EventArgs e)
        {
            toolStripButton_layer1.Checked = false;
            toolStripButton_layer2.Checked = false;
            toolStripButton_layer3.Checked = false;
            toolStripButton_all.Checked = true;
            layer = 0;
            if (map != null)
                map.SetLayer(0);
        }

        private void toolStripButton_pencil_Click(object sender, EventArgs e)
        {
            toolStripButton_pencil.Checked = true;
            toolStripButton_fill.Checked = false;
            toolStripButton_select.Checked = false;
            toolStripButton_rectangle.Checked = false;
            toolStripButton_ellipse.Checked = false;
            mapBrush = MapBrush.pencil;
        }

        private void toolStripButton_fill_Click(object sender, EventArgs e)
        {
            toolStripButton_pencil.Checked = false;
            toolStripButton_fill.Checked = true;
            toolStripButton_select.Checked = false;
            toolStripButton_rectangle.Checked = false;
            toolStripButton_ellipse.Checked = false;
            mapBrush = MapBrush.fill;
        }

        private void toolStripButton_select_Click(object sender, EventArgs e)
        {
            toolStripButton_pencil.Checked = false;
            toolStripButton_fill.Checked = false;
            toolStripButton_select.Checked = true;
            toolStripButton_rectangle.Checked = false;
            toolStripButton_ellipse.Checked = false;
            mapBrush = MapBrush.select;
        }

        private void toolStripButton_rectangle_Click(object sender, EventArgs e)
        {
            toolStripButton_pencil.Checked = false;
            toolStripButton_fill.Checked = false;
            toolStripButton_select.Checked = false;
            toolStripButton_rectangle.Checked = true;
            toolStripButton_ellipse.Checked = false;
            mapBrush = MapBrush.rectangle;


        }

        private void toolStripButton_ellipse_Click(object sender, EventArgs e)
        {
            toolStripButton_pencil.Checked = false;
            toolStripButton_fill.Checked = false;
            toolStripButton_select.Checked = false;
            toolStripButton_rectangle.Checked = false;
            toolStripButton_ellipse.Checked = true;
            mapBrush = MapBrush.ellipse;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_map_Click(object sender, EventArgs e)
        {

        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            panel1.ClientSize = new Size(panel1.Width, tableLayoutPanel1.Height - 23);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_new_Click(object sender, EventArgs e)
        {
            NewProjectForm npf = new NewProjectForm(new PathPassDelegate(OnNewProject));
            npf.Show();
            
        }

        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            if (map != null)
                map.SaveToFile(projectPath);
        }

        private void toolStripButton_open_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if(mapList.Count >0 )
                {
                    DialogResult dialogResult = MessageBox.Show("Save Project?", "Message", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        map.SaveToFile(projectPath);
                    }
                }
                mapList.Clear();
                fbd.Description = "Select Project Folder to Open.";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        if (!Directory.Exists(fbd.SelectedPath + "\\tiles"))
                        {
                            MessageBox.Show("No Project Detected.");
                            return;
                        }
                        projectPath = fbd.SelectedPath;
                        this.Text = "Map Editor  " + projectPath;
                        mapList.Add(new Map(projectPath, projectPath + "\\" + "Map 0000.mapinfo", ref pictureBox_tile, ref pictureBox_map));
                        map = mapList[mapList.Count - 1];
                        listBox_maps.SelectedItem = mapList[mapList.Count - 1];
                        map.SetLayer(layer);
                    }
                    catch (IOException)
                    {

                    }
                }
            }
        }
    }
}
