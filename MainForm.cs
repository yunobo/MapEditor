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
    enum ViewMode {all, below };
    public partial class MainForm : Form
    {
        private const int init_map_size_x = 16;
        private const int init_map_size_y = 16;

        static Map map = null;
        static MapBrush mapBrush = MapBrush.pencil;
        static int layer;
        static private string projectPath;
        static BindingList<Map> mapList = new BindingList<Map>();
        static string[] tileset_name = { "001-Grassland01", "002-Woods01", "003-Forest01", "004-Mountain01", "005-Beach01", "006-Desert01", "007-Swamp01", "008-Snowfield01", "009-CastleTown01", "010-CastleTown02", "011-PortTown01", "012-PortTown02", "013-PostTown01", "014-PostTown02", "015-ForestTown01", "016-ForestTown02", "017-MineTown01", "018-MineTown02", "019-DesertTown01", "020-DesertTown02", "021-SnowTown01", "022-SnowTown02", "023-FarmVillage01", "024-FarmVillage02", "025-Castle01", "026-Castle02", "027-Castle03", "028-Church01", "029-Church02", "030-Ship01", "031-Ship02", "032-Heaven01", "033-Heaven02", "034-Bridge01", "035-Ruins01", "036-Shop01", "037-Fort01", "038-Fort02", "039-Tower01", "040-Tower02", "041-EvilCastle01", "042-EvilCastle02", "043-Cave01", "044-Cave02", "045-Cave03", "046-Cave04", "047-Mine01", "048-Sewer01", "049-InnerBody01", "050-DarkSpace01" };
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
            var toolStripMenuItem_delete_map = new ToolStripMenuItem { Text = "Delete Map" };
            var toolStripMenuItem_duplicate_map = new ToolStripMenuItem { Text = "Duplicate Map" };
            toolStripMenuItem_new_map.Click +=  toolStripMenuItem_new_map_click;
            toolStripMenuItem_delete_map.Click += toolStripMenuItem_delete_map_click;
            toolStripMenuItem_map_properties.Click += toolStripMenuItem_map_properties_click;
            toolStripMenuItem_duplicate_map.Click += toolStripMenuItem_duplicate_map_click;
            //toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            mapsContextMenuStrip = new ContextMenuStrip();
            mapsContextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_map_properties, new ToolStripSeparator(), toolStripMenuItem_new_map, new ToolStripSeparator(), toolStripMenuItem_delete_map, toolStripMenuItem_duplicate_map });
            listBox_maps.MouseDown += listBox_maps_MouseDown;


        }

        private void toolStripMenuItem_duplicate_map_click(object sender, EventArgs e)
        {
            int newID = -1;
            foreach (var map in mapList)
            {
                if (map.ID >= newID)
                    newID = map.ID + 1;
            }
            Map newMap = new Map(map, string.Format("Map {0:000}", newID), newID);
            
            mapList.Add(newMap);
            map = newMap;
            listBox_maps.SelectedItem = map;
            map.UpdateGraphics(layer);
        }

        private void toolStripMenuItem_map_properties_click(object sender, EventArgs e)
        {
            MapPropertiesForm form = new MapPropertiesForm(tileset_name, OnPropertyChange, map.Name, map.Tileset_id, map.Map_tile_count_x, map.Map_tile_count_y);
            form.Show();
        }

        public void OnPropertyChange(string name, int tile_id, int map_tile_count_x, int map_tile_count_y)
        {
            map.UpdateProperties(name, tile_id, map_tile_count_x, map_tile_count_y);
            map.UpdateGraphics(layer);
            listBox_maps.DataSource = null;
            listBox_maps.DataSource = mapList;
            //UpdateToString(listBox_maps);
        }

        private void toolStripMenuItem_delete_map_click(object sender, EventArgs e)
        {
            File.SetAttributes(projectPath + "\\" + map.filename + ".mapinfo", FileAttributes.Normal);
            if (mapList.Count == 0) return;
            else if(mapList.Count == 1)
            {
                File.Delete(projectPath + "\\" + map.filename + ".mapinfo");
                mapList.Remove(map);
                map = null;
            }
            else
            {
                File.Delete(projectPath + "\\" + map.filename + ".mapinfo");
                mapList.Remove(map);
                map = mapList[0];
                listBox_maps.SelectedIndex = 0;
            }
            map.UpdateGraphics(layer);
        }

        private void toolStripMenuItem_new_map_click(object sender, EventArgs e)
        {
            int newID = -1;
            foreach(var map in mapList)
            {
                if (map.ID >= newID)
                    newID = map.ID + 1;
            }
            Map newMap = new MapEditor.Map(string.Format("Map {0:000}", newID), newID, init_map_size_x, init_map_size_y, 0, projectPath, string.Format("Map {0:000}", newID) + newID, ref pictureBox_tile, ref pictureBox_map);
            mapList.Add(newMap);
            map = newMap;
            listBox_maps.SelectedItem = map;
            //Map newMap = new Map()
        }

        private void listBox_maps_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox_maps.IndexFromPoint(e.Location) >= 0)
            {
                listBox_maps.SelectedIndex = listBox_maps.IndexFromPoint(e.Location);
                map = (Map)listBox_maps.SelectedItem;
                map.UpdateGraphics(layer);
            }

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
            mapList.Add(new Map("Map 000", 0, 16, 16, 1, projectPath, "Map 0000", ref pictureBox_tile, ref pictureBox_map));
            listBox_maps.SelectedItem = mapList[0];
            map = mapList[0];
        }

        private void pictureBox_map_MouseLeave(object sender, EventArgs e)
        {
            if (map != null)
                map.ClearMapOverlay();
        }

        private void pictureBox_map_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if(map!=null)
                if (mapBrush == MapBrush.pencil) map.DrawTiles(e.Location, mapBrush);
        }

        private void pictureBox_map_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if (map != null)
            {
                if (mapBrush == MapBrush.pencil) map.DrawTiles(e.Location, mapBrush);
                else if (mapBrush == MapBrush.rectangle) map.DrawMapOverlayPencil(e.Location, mapBrush);
            }
        }

        private void pictureBox_map_MouseMove(object sender, MouseEventArgs e)
        {
            if (map != null)
            {
                if(mapBrush == MapBrush.pencil) map.DrawMapOverlayPencil(e.Location, mapBrush);

                if (isMouseDown)
                {
                    if (mapBrush == MapBrush.pencil) map.DrawTiles(e.Location, mapBrush);
                    else if (mapBrush == MapBrush.rectangle) map.DrawMapOverlayPencil(e.Location, mapBrush);
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
            if (mapBrush == MapBrush.fill && map != null)
            {
                map.FillEverything();
            }
        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            panel1.ClientSize = new Size(panel1.Width, tableLayoutPanel1.Height - 23);
        }


        private void toolStripButton_new_Click(object sender, EventArgs e)
        {
            NewProjectForm npf = new NewProjectForm(new PathPassDelegate(OnNewProject));
            npf.Show();
            
        }

        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            if (map != null)
                map.SaveToFile();
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
                        map.SaveToFile();
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
                        string[] maps = Directory.GetFiles(projectPath, "*.mapinfo");
                        foreach(string filepath in maps)
                        {
                            mapList.Add(new Map(projectPath, Path.GetFileNameWithoutExtension(filepath), ref pictureBox_tile, ref pictureBox_map));
                        }
                        map = mapList[mapList.Count - 1];
                        listBox_maps.SelectedItem = map;
                        map.SetLayer(layer);
                    }
                    catch (IOException)
                    {

                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_new_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_open_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_save_Click(sender, e);
        }

        private void layer1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_layer1_Click(sender, e);
        }

        private void layer2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_layer2_Click(sender, e);
        }

        private void layer3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_layer3_Click(sender, e);
        }

        private void pencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_pencil_Click(sender, e);
        }

        private void allLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentLayerAndBelowToolStripMenuItem.Checked = false;
            allLayersToolStripMenuItem.Checked = true;
            if(map!=null)
            {
                map.ViewModeSetting = ViewMode.all;
            }
        }

        private void currentLayerAndBelowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentLayerAndBelowToolStripMenuItem.Checked = true;
            allLayersToolStripMenuItem.Checked = false;
            if (map != null)
            {
                map.ViewModeSetting = ViewMode.below;
            }
        }

        private void dimOtherLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dimOtherLayersToolStripMenuItem.Checked = !dimOtherLayersToolStripMenuItem.Checked;
            if (map != null)
            {
                map.Dim = dimOtherLayersToolStripMenuItem.Checked;
            }
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton_fill_Click(sender, e);
        }
        private void UpdateToString(ListBox listBox)
        {
            int count = listBox.Items.Count;
            listBox.SuspendLayout();
            for (int i = 0; i < count; i++)
            {
                listBox.Items[i] = listBox.Items[i];
            }
            listBox.ResumeLayout();
        }
    }
}
