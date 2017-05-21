using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace MapEditor
{
    class Map
    {
        private const int tile_count_x = 8;
        private const int tile_width = 32;
        private const int tile_height = 32;
        private const int tileset_width = 256;

        private string name;
        private int id;
        public int ID
        {
            get { return id; }
        }

        private PictureBox pictureBox_tileset;
        private PictureBox pictureBox_map;
        private Color BGColor = Color.Wheat;

        private int tile_count_y;
        private int tile_select_start_x = 0;
        private int tile_select_start_y = 0;
        private int tile_select_end_x = 0;
        private int tile_select_end_y = 0;
        private int tile_select_width_count = 1;
        private int tile_select_height_count = 1;
        private int tile_select_width = 32;
        private int tile_select_height = 32;
        private int tileset_id;

        private Image[,] tile;
        private Image tileset;
        private Image tileset_overlay;
        private Image tileset_output;

        private int map_width;
        private int map_height;
        private int map_tile_count_x;
        private int map_tile_count_y;
        private int map_cursor_pos_x_hover = 0;
        private int map_cursor_pos_y_hover = 0;
        private int map_cursor_pos_x_down = 0;
        private int map_cursor_pos_y_down = 0;
        private int map_layer_index = 1;

        private Image[] map_layer = new Image[3];
        private Image[] map_layer_opaque = new Image[3];
        private Image map_combined;
        private Image map_overlay;
        private Image map_output;
        private int[][] map_layer_tileinfo = new int[3][];

        private int gcCounter = 0;
        private bool newTileSelected = false;
        private bool layerChanged = false;
        static private Graphics graphics;


        public Map(string name, int id, int tile_count_x, int tile_count_y, int tileset_id, string project_path, ref PictureBox pb_tileset, ref PictureBox pb_map)
        {
            this.name = name;
            this.id = id;
            this.tileset_id = tileset_id;
            map_width = tile_count_x * tile_height;
            map_height = tile_count_y * tile_width;
            pictureBox_tileset = pb_tileset;
            pictureBox_map = pb_map;
            map_tile_count_y = tile_count_y;
            map_tile_count_x = tile_count_x;

            for (int i = 0; i < 3; i++)
            {
                map_layer_tileinfo[i] = new int[map_tile_count_x * map_tile_count_y];
                for (int j = 0; j < map_layer_tileinfo[i].Length; j++)
                {
                    map_layer_tileinfo[i][j] = -1;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                map_layer[i] = new Bitmap(map_width, map_height);
                graphics = Graphics.FromImage(map_layer[i]);
                graphics.Clear(Color.Transparent);
                graphics.Dispose();
            }
            for (int i = 0; i < 3; i++)
            {
                map_layer_opaque[i] = new Bitmap(map_width, map_height);
                graphics = Graphics.FromImage(map_layer_opaque[i]);
                graphics.Clear(Color.Transparent);
                graphics.Dispose();
            }
            map_overlay = new Bitmap(map_width, map_height);
            graphics = Graphics.FromImage(map_overlay);
            graphics.Clear(Color.Transparent);
            graphics.Dispose();
            map_output = new Bitmap(map_width, map_height);
            graphics = Graphics.FromImage(map_output);
            graphics.Clear(BGColor);
            graphics.Dispose();
            map_combined = new Bitmap(map_width, map_height);
            graphics = Graphics.FromImage(map_combined);
            graphics.Clear(Color.Transparent);
            graphics.Dispose();

            CombineMaskMapOutput(map_layer_index);
            CombineOverlayMapOutput();

            pictureBox_map.Width = map_width;
            pictureBox_map.Height = map_height;
            pictureBox_map.Image = map_output;
            LoadTileSet(project_path);
        }
        public Map(string projectpath, string filepath, ref PictureBox pb_tileset, ref PictureBox pb_map)
        {

            using (var fileStream = File.OpenRead(filepath))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.Unicode))
                {
                    string line;
                    int[] layer_start = new int[3];

                    for (int line_number = 0; (line = streamReader.ReadLine()) != null; line_number++)
                    {
                        if (line_number == 0)
                        {
                            id = int.Parse(line);
                        }
                        else if (line_number == 1)
                        {
                            name = line;
                        }
                        else if (line_number == 2)
                        {
                            tileset_id = int.Parse(line);
                        }
                        else if (line_number == 3)
                        {
                            map_tile_count_x = int.Parse(line);
                            map_width = map_tile_count_x * tile_width;
                        }
                        else if (line_number == 4)
                        {
                            map_tile_count_y = int.Parse(line);
                            map_height = map_tile_count_y * tile_height;
                            for (int i = 0; i < 3; i++)
                            {
                                map_layer_tileinfo[i] = new int[map_tile_count_x * map_tile_count_y];
                                for (int j = 0; j < map_layer_tileinfo[i].Length; j++)
                                {
                                    map_layer_tileinfo[i][j] = -1;
                                }
                            }

                            layer_start[0] = 5;
                            layer_start[1] = 5 + map_tile_count_x * map_tile_count_y;
                            layer_start[2] = layer_start[1] + map_tile_count_x * map_tile_count_y;
                        }
                        else if (line_number >= layer_start[0] && line_number < layer_start[1])
                        {
                            map_layer_tileinfo[0][line_number - layer_start[0]] = int.Parse(line);
                        }
                        else if (line_number >= layer_start[1] && line_number < layer_start[2])
                        {
                            map_layer_tileinfo[1][line_number - layer_start[1]] = int.Parse(line);
                        }
                        else if (line_number >= layer_start[2] && line_number < layer_start[2] + map_tile_count_x * map_tile_count_y)
                        {
                            map_layer_tileinfo[2][line_number - layer_start[2]] = int.Parse(line);
                        }
                    }
                    pictureBox_tileset = pb_tileset;
                    pictureBox_map = pb_map;
                    

                    for (int i = 0; i < 3; i++)
                    {
                        map_layer[i] = new Bitmap(map_width, map_height);
                        graphics = Graphics.FromImage(map_layer[i]);
                        graphics.Clear(Color.Transparent);
                        graphics.Dispose();
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        map_layer_opaque[i] = new Bitmap(map_width, map_height);
                        graphics = Graphics.FromImage(map_layer_opaque[i]);
                        graphics.Clear(Color.Transparent);
                        graphics.Dispose();
                    }
                    map_overlay = new Bitmap(map_width, map_height);
                    graphics = Graphics.FromImage(map_overlay);
                    graphics.Clear(Color.Transparent);
                    graphics.Dispose();
                    map_output = new Bitmap(map_width, map_height);
                    graphics = Graphics.FromImage(map_output);
                    graphics.Clear(BGColor);
                    graphics.Dispose();
                    map_combined = new Bitmap(map_width, map_height);
                    graphics = Graphics.FromImage(map_combined);
                    graphics.Clear(Color.Transparent);
                    graphics.Dispose();
                    pictureBox_map.Width = map_width;
                    pictureBox_map.Height = map_height;
                    
                    LoadTileSet(projectpath);
                    for (int layer = 1; layer <= 3; layer++)
                    {
                        graphics = Graphics.FromImage(map_layer[layer - 1]);
                        graphics.Clear(Color.Transparent);
                        for (int x = 0; x < map_tile_count_x; x++)
                        {
                            for (int y = 0; y < map_tile_count_y; y++)
                            {
                                if(map_layer_tileinfo[layer - 1][y * map_tile_count_x + x] != -1)
                                    graphics.DrawImage(tile[map_layer_tileinfo[layer - 1][y * map_tile_count_x + x] % tile_count_x, map_layer_tileinfo[layer - 1][y * map_tile_count_x + x] / tile_count_x], tile_width * x, tile_height * y);
                                
                            }

                        }
                        graphics.Dispose();
                    }
                    CombineMaskMapOutput(map_layer_index);
                    CombineOverlayMapOutput();
                    pictureBox_map.Image = map_output;
                }
            }
        }
        public void LoadTileSet(string project_path)
        {
            if(!File.Exists(project_path + "\\tiles\\" + tileset_id + ".tile"))
                ((Image)Properties.Resources.ResourceManager.GetObject("tileset_" + tileset_id)).Save(project_path + "\\tiles\\" + tileset_id + ".tile");

            tileset = Image.FromFile(project_path + "\\tiles\\" + tileset_id + ".tile");
            tileset_overlay = new Bitmap(tileset.Width, tileset.Height);
            tileset_output = new Bitmap(tileset.Width, tileset.Height); ;
            graphics = Graphics.FromImage(tileset_overlay);
            graphics.Clear(Color.Transparent);
            graphics.Dispose();

            if (tileset.Width != tileset_width)
            {
                tileset = null;
                return;
            }
            tile_count_y = tileset.Height / tile_height;
            tile = new Image[tile_count_x, tile_count_y];
            for (int x = 0; x < tile_count_x; x++)
            {
                for (int y = 0; y < tile_count_y; y++)
                {

                    tile[x, y] = new Bitmap(tile_width, tile_height);
                    graphics = Graphics.FromImage(tile[x, y]);
                    if (!(x == 0 && y == 1))
                    {
                        graphics.DrawImage(tileset, 0, 0, new Rectangle(x * tile_width, y * tile_height, tile_width, tile_height), GraphicsUnit.Pixel);
                    }

                    graphics.Dispose();
                }
            }

            SelectTilesStart(new Point(0, 0));
            SelectTilesEnd(new Point(0, 0));
            CombineTilesetOutput();
            pictureBox_tileset.ClientSize = new Size(tileset.Width, tileset.Height);
            pictureBox_tileset.Image = tileset_output;
            return;
        }

        public void SelectTilesStart(Point startPos)
        {
            tile_select_start_x = startPos.X / tile_width;
            tile_select_start_y = startPos.Y / tile_height;
            tile_select_end_x = tile_select_start_x;
            tile_select_end_y = tile_select_start_y;

            graphics = Graphics.FromImage(tileset_overlay);
            graphics.Clear(Color.Transparent);
            graphics.DrawRectangle(new Pen(Color.Red, 2.0f), new Rectangle(tile_select_start_x * tile_width + 1, tile_select_start_y * tile_height + 1, tile_width - 2, tile_height - 2));
            graphics.Dispose();
            CombineTilesetOutput();
            pictureBox_tileset.Image = tileset_output;
            newTileSelected = true;
            return;

        }
        public void SelectTilesEnd(Point endPos)
        {
            UpdateTiles(endPos);

            if (tile_select_end_x < tile_select_start_x)
            {
                int temp = tile_select_start_x;
                tile_select_start_x = tile_select_end_x;
                tile_select_end_x = temp;
            }
            if (tile_select_end_y < tile_select_start_y)
            {
                int temp = tile_select_start_y;
                tile_select_start_y = tile_select_end_y;
                tile_select_end_y = temp;
            }
        }

        public void SelectTilesMiddle(Point midPos)
        {
            if (tile_select_end_x == midPos.X / tile_width && tile_select_end_y == midPos.Y / tile_height)
            {
                return;
            }
            UpdateTiles(midPos);
            return;
        }



        public void DrawMapOverlay(Point pos, MapBrush brush)
        {
            int posx = pos.X / tile_width;
            int posy = pos.Y / tile_height;

            if (posx >= map_tile_count_x) posx = map_tile_count_x - 1;
            else if (posx < 0) posx = 0;

            if (posy >= map_tile_count_y) posy = map_tile_count_y - 1;
            else if (posy < 0) posy = 0;

            if (map_cursor_pos_x_hover == posx && map_cursor_pos_y_hover == posy) return;
            else
            {
                map_cursor_pos_x_hover = posx;
                map_cursor_pos_y_hover = posy;
            }

            if (brush == MapBrush.pencil)
            {
                graphics = Graphics.FromImage(map_overlay);
                graphics.Clear(Color.Transparent);
                graphics.DrawRectangle(new Pen(Color.Red, 2.0f), new Rectangle(posx * tile_width + 1, posy * tile_height + 1, tile_select_width - 2, tile_select_height - 2));
                graphics.Dispose();
                //CombineMaskMapOutput(map_layer_index);
                CombineOverlayMapOutput();
                pictureBox_map.Image = map_output;
            }
        }

        public void DrawTiles(Point pos, MapBrush brush)
        {
            if (map_layer_index == 0) return;

            int posx = pos.X / tile_width;
            int posy = pos.Y / tile_height;

            if (posx >= map_tile_count_x) posx = map_tile_count_x - 1;
            else if (posx < 0) posx = 0;

            if (posy >= map_tile_count_y) posy = map_tile_count_y - 1;
            else if (posy < 0) posy = 0;

            if (map_cursor_pos_x_down == posx && map_cursor_pos_y_down == posy && !newTileSelected && !layerChanged) return;
            else
            {
                map_cursor_pos_x_down = posx;
                map_cursor_pos_y_down = posy;
                newTileSelected = false;
                layerChanged = false;
            }

            if (brush == MapBrush.pencil)
            {
                graphics = Graphics.FromImage(map_layer[map_layer_index - 1]);
                for (int x = 0; x < tile_select_width_count; x++)
                {
                    for (int y = 0; y < tile_select_height_count; y++)
                    {
                        graphics.SetClip(new Rectangle(tile_width * (posx + x), tile_height * (posy + y), tile_width, tile_height), System.Drawing.Drawing2D.CombineMode.Replace);
                        graphics.Clear(Color.Transparent);
                        graphics.DrawImage(tile[tile_select_start_x + x, tile_select_start_y + y], tile_width * (posx + x), tile_height * (posy + y));
                        if (posx + x < map_tile_count_x && posy + y < map_tile_count_y)
                        {
                            map_layer_tileinfo[map_layer_index - 1][(posy + y) * map_tile_count_x + x + posx] = (tile_select_start_y + y) * tile_count_x + tile_select_start_x + x;
                            if (tile_select_start_x + x == 0 && tile_select_start_y + y == 1)
                            {
                                map_layer_tileinfo[map_layer_index - 1][(posy + y) * map_tile_count_x + posx + x] = -1;
                            } 
                        }
                        //Console.WriteLine("index: " + ((posy + y) * map_tile_count_x + posx + x) + "value: " + map_layer_tileinfo[layer - 1][(posy + y) * map_tile_count_x + x+posx]);
                    }
                }

                graphics.Dispose();
                CombineMaskMapOutput(map_layer_index);
                CombineOverlayMapOutput();
                pictureBox_map.Image = map_output;
            }
        }

        public void SetLayer(int layer)
        {
            map_layer_index = layer;
            layerChanged = true;
            if (layer == 0)
            {
                CombineAllMapOutput();
                pictureBox_map.Image = map_output;
            }
            for (int i = 0; i < 3; i++)
            {
                if (layer - 1 != i)
                {
                    graphics = Graphics.FromImage(map_layer_opaque[i]);
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(SetImageOpacity(map_layer[i], 0.3f), 0, 0);
                    graphics.Dispose();
                }
            }
            CombineLayersMapOutput(layer);
            CombineMaskMapOutput(layer);
            CombineOverlayMapOutput();
            pictureBox_map.Image = map_output;

        }

        public void ClearMapOverlay()
        {
            graphics = Graphics.FromImage(map_overlay);
            graphics.Clear(Color.Transparent);
            graphics.Dispose();
            CombineMaskMapOutput(map_layer_index);
            CombineOverlayMapOutput();
            pictureBox_map.Image = map_output;
        }

        public void SaveToFile(string project_path)
        {
            using (StreamWriter file = new StreamWriter(project_path + "\\" + name + id + ".mapinfo", false, Encoding.Unicode))
            {
                file.WriteLine(id);
                file.WriteLine(name);
                file.WriteLine(tileset_id);
                file.WriteLine(map_tile_count_x);
                file.WriteLine(map_tile_count_y);
                for (int i = 0; i < 3; i++)
                {
                    for (int y = 0; y < map_tile_count_y; y++)
                    {
                        for (int x = 0; x < map_tile_count_x; x++)
                        {
                            file.WriteLine(map_layer_tileinfo[i][y * map_tile_count_x + x]);
                        }
                    } 
                }
                file.Close();
            }
        }












        public override string ToString()
        {
            return name;
        }
        private void UpdateTiles(Point pos)
        {
            tile_select_end_x = pos.X / tile_width;
            tile_select_end_y = pos.Y / tile_height;
            if (tile_select_end_x < 0) tile_select_end_x = 0;
            else if (tile_select_end_x >= tile_count_x) tile_select_end_x = tile_count_x - 1;

            if (tile_select_end_y < 0) tile_select_end_y = 0;
            else if (tile_select_end_y >= tile_count_y) tile_select_end_y = tile_count_y - 1;

            tile_select_width_count = Math.Abs(tile_select_start_x - tile_select_end_x) + 1;
            tile_select_height_count = Math.Abs(tile_select_start_y - tile_select_end_y) + 1;

            int recx, recy;
            tile_select_width = tile_width * tile_select_width_count;
            tile_select_height = tile_height * tile_select_height_count;
            if (tile_select_end_x > tile_select_start_x) recx = tile_select_start_x * tile_width;
            else recx = tile_select_end_x * tile_width;

            if (tile_select_end_y > tile_select_start_y) recy = tile_select_start_y * tile_height;
            else recy = tile_select_end_y * tile_height;

            graphics = Graphics.FromImage(tileset_overlay);
            graphics.Clear(Color.Transparent);
            graphics.DrawRectangle(new Pen(Color.Red, 2.0f), new Rectangle(recx + 1, recy + 1, tile_select_width - 2, tile_select_height - 2));
            graphics.Dispose();
            CombineTilesetOutput();
            pictureBox_tileset.Image = tileset_output;
        }

        private void CombineTilesetOutput()
        {
            graphics = Graphics.FromImage(tileset_output);
            graphics.Clear(BGColor);
            graphics.DrawImageUnscaled(tileset, 0, 0);
            graphics.DrawImageUnscaled(tileset_overlay, 0, 0);
            graphics.Dispose();
        }

        private void CombineAllMapOutput()
        {
            graphics = Graphics.FromImage(map_output);
            graphics.Clear(BGColor);
            for (int i = 0; i < 3; i++)
            {
                graphics.DrawImageUnscaled(map_layer[i], 0, 0);
            }
            graphics.DrawImageUnscaled(map_overlay, 0, 0);
            graphics.Dispose();
        }
        private void CombineOverlayMapOutput()
        {
            if (map_layer_index == 0)
                return;

            graphics = Graphics.FromImage(map_output);
            graphics.Clear(BGColor);
            graphics.DrawImageUnscaled(map_combined, 0, 0);
            graphics.DrawImageUnscaled(map_overlay, 0, 0);
            graphics.Dispose();

        }
        private void CombineLayersMapOutput(int layer) // unused
        {
            graphics = Graphics.FromImage(map_combined);
            graphics.Clear(BGColor);
            for (int i = 0; i < layer; i++)
            {
                graphics.DrawImageUnscaled(map_layer[i], 0, 0);
            }
            graphics.Dispose();
        }

        private void CombineMaskMapOutput(int masklayer)
        {
            if (masklayer == 0)
                return;

            graphics = Graphics.FromImage(map_combined);
            graphics.Clear(BGColor);

            if (masklayer != 1) graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, 0, 0, 0)), 0, 0, map_width, map_height);
            for (int i = 0; i < 3; i++)
            {
                if (masklayer - 1 != i)
                {
                    graphics.DrawImageUnscaled(map_layer_opaque[i], 0, 0);
                }
            }
            graphics.DrawImage(map_layer[masklayer - 1], 0, 0);
            for (int i = masklayer - 1; i < 3; i++)
            {
                if (masklayer - 1 != i)
                {
                    graphics.DrawImageUnscaled(map_layer_opaque[i], 0, 0);
                }
            }
            graphics.Dispose();
        }

        private Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                    gfx.Dispose();
                    attributes.Dispose();
                    if (gcCounter < 10) { gcCounter++; }
                    else
                    {
                        gcCounter = 0;
                        GC.Collect();
                    }
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
