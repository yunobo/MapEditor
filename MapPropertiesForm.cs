using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public delegate void PropertiesPassDelegate(string name, int tile_id, int map_tile_count_x, int map_tile_count_y);
    

    public partial class MapPropertiesForm : Form
    {
        PropertiesPassDelegate onPropertySet;
        public MapPropertiesForm(string[] tileset_name, PropertiesPassDelegate func, string name, int tile_id, int map_tile_count_x, int map_tile_count_y)
        {
            InitializeComponent();
            onPropertySet = func;
            textBox_name.Text = name;
            comboBox_tileset.Items.AddRange(tileset_name);
            comboBox_tileset.SelectedIndex = tile_id;
            numericUpDown_width.Value = map_tile_count_x;
            numericUpDown_height.Value = map_tile_count_y;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            onPropertySet(textBox_name.Text, comboBox_tileset.SelectedIndex, (int)numericUpDown_width.Value, (int)numericUpDown_height.Value);
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
