using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
namespace sample
{
    public partial class form_map : Form
    {
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("30.10.21.37"), 9999);// Server baglanti ip
        public form_map()
        {
            InitializeComponent();
        }
        GMapRoute route;//Ham verinin rotasi 
        GMapRoute reduct_route;//İndirgenmis verinin rotasi
        GMapOverlay line_overlay;
        GMapOverlay query_line;
        GMapOverlay marker_overlay;
        GMapOverlay query_overlay;
        GMapMarker query_marker;
        GMapMarker marker;
        List<Point> raw_data_coordinates = new List<Point>();
        List<Point> reduced_data = new List<Point>();
        bool clicked = true;
        double maxlat, minlat, maxlong, minlong;
        public class reduction_json_data  // indirgenmiş veri için json formati
        {
            public List<Point> data;
            public int service_ID;
            public reduction_json_data(List<Point> data, int service_ID)
            {
                this.data = data;
                this.service_ID = service_ID;
            }
        }
        public class received_reduction_data// 
        {
            public List<Point> Data;
            public double Ratio;
            public double Elapsed_time;
            received_reduction_data() { }
            received_reduction_data(List<Point> data, double ratio, double elapsed_time)
            {
                Data = data;
                Ratio = ratio;
                Elapsed_time = elapsed_time;
            }
        }
        public class received_query_data
        {
            public List<Point> data;// sorgu sonucunda gelen noktalar
            public List<int> Index;
            received_query_data() { }
            received_query_data(List<Point> query_result, List<int> index)
            {
                data =query_result ;
                Index = index;
            }
        }
        public class query_data
        {
            public List<Point> Data;
            public Point max_point;
            public Point min_point;
            int service_ID = 1;
        }
        
        public string Get_json_data(List<Point> points, int service_ID)
        {
            return JsonConvert.SerializeObject(new reduction_json_data(points, service_ID));
        } 
        public void initmap()
        {
            map_raw.Visible = true;
            map_raw.MapProvider = GMapProviders.GoogleMap;
            map_raw.MinZoom = 0;
            map_raw.MaxZoom = 100;
            map_raw.Zoom = 10;
            route = new GMapRoute("single_line");
            route.Stroke = new Pen(Brushes.Tomato, 2);
            line_overlay = new GMapOverlay("single_line");
            map_raw.Position = new PointLatLng(raw_data_coordinates[0].X, raw_data_coordinates[0].Y);
            marker_overlay = new GMapOverlay("markers");
        }
        public void show_map()
        {
            for (int i = 0; i < raw_data_coordinates.Count; i++)
            {
                route.Points.Add(new PointLatLng(raw_data_coordinates[i].X, raw_data_coordinates[i].Y));
                marker = new GMarkerGoogle(new PointLatLng(raw_data_coordinates[i].X, raw_data_coordinates[i].Y), GMarkerGoogleType.red_small);
                marker.ToolTipText = "P" + i.ToString();
                marker.ToolTip.Fill = Brushes.Tomato;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.TextPadding = new Size(4, 4);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker_overlay.Markers.Add(marker);
                map_raw.Overlays.Add(marker_overlay);
            }
            line_overlay.Routes.Add(route);
            map_raw.Overlays.Add(line_overlay);
            map_raw.UpdateRouteLocalPosition(route);
            map_raw.ReloadMap();
        }
        public void reduced_initmap()
        {
            reduct_map.Visible = true;
            reduct_map.MapProvider = GMapProviders.GoogleMap;
            reduct_map.MinZoom = 0;
            reduct_map.MaxZoom = 100;
            reduct_map.Zoom = 10;
            route = new GMapRoute("single_line");
            route.Stroke = new Pen(Brushes.Tomato, 2);
            line_overlay = new GMapOverlay("single_line");
            reduct_map.Position = new PointLatLng(reduced_data[0].X, reduced_data[0].Y);
            marker_overlay = new GMapOverlay("markers");
        }
        public void reduced_show_map()
        {
            for (int i = 0; i < reduced_data.Count; i++)
            {
                route.Points.Add(new PointLatLng(reduced_data[i].X, reduced_data[i].Y));
                marker = new GMarkerGoogle(new PointLatLng(reduced_data[i].X, reduced_data[i].Y), GMarkerGoogleType.red_small);
                marker.ToolTipText = "P" + i.ToString();
                marker.ToolTip.Fill = Brushes.Tomato;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.TextPadding = new Size(4, 4);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker_overlay.Markers.Add(marker);
                reduct_map.Overlays.Add(marker_overlay);
            }
            line_overlay.Routes.Add(route);
            reduct_map.Overlays.Add(line_overlay);
            reduct_map.UpdateRouteLocalPosition(route);
            reduct_map.ReloadMap();
        }
        public void raw_query_marker(received_query_data obj)
        {
            map_raw.Overlays.Remove(query_overlay);
            query_overlay = new GMapOverlay("markers");
            for (int i = 0; i <obj.data.Count; i++)
            {
                query_marker = new GMarkerGoogle(new PointLatLng(obj.data[i].X, obj.data[i].Y), GMarkerGoogleType.yellow_small);
                query_marker.ToolTipText = "P" + obj.Index[i].ToString();
                query_marker.ToolTip.Fill = Brushes.Tomato;
                query_marker.ToolTip.Foreground = Brushes.White;
                query_marker.ToolTip.TextPadding = new Size(4, 4);
                query_marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                query_overlay.Markers.Add(query_marker);
                map_raw.Overlays.Add(query_overlay);
            }
            map_raw.ReloadMap();
        }
        public void reduce_query_marker(received_query_data obj)
        {
            reduct_map.Overlays.Remove(query_overlay);
            query_overlay = new GMapOverlay("markers");
            for (int i = 0; i < obj.data.Count; i++)
            {
                query_marker = new GMarkerGoogle(new PointLatLng(obj.data[i].X, obj.data[i].Y), GMarkerGoogleType.yellow_small);
                query_marker.ToolTipText = "P" + obj.Index[i].ToString();
                query_marker.ToolTip.Fill = Brushes.Tomato;
                query_marker.ToolTip.Foreground = Brushes.White;
                query_marker.ToolTip.TextPadding = new Size(4, 4);
                query_marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                query_overlay.Markers.Add(query_marker);
                reduct_map.Overlays.Add(query_overlay);
            }
            reduct_map.ReloadMap();
        }
        public void raw_draw_polygon()
        {
            map_raw.Overlays.Remove(query_line);
            route = new GMapRoute("single_line");
            route.Stroke = new Pen(Brushes.Black, 2);
            query_line = new GMapOverlay("single_line");
            route.Points.Add(new PointLatLng(minlat, minlong));
            route.Points.Add(new PointLatLng(maxlat, minlong));
            route.Points.Add(new PointLatLng(maxlat, maxlong));
            route.Points.Add(new PointLatLng(minlat, maxlong));
            route.Points.Add(new PointLatLng(minlat, minlong));
            query_line.Routes.Add(route);
            map_raw.Overlays.Add(query_line);
            map_raw.UpdateRouteLocalPosition(route);
            map_raw.ReloadMap();
        }
        public void reduce_draw_polygon()
        {
            reduct_map.Overlays.Remove(query_line);
            route = new GMapRoute("single_line");
            route.Stroke = new Pen(Brushes.Black, 2);
            query_line = new GMapOverlay("single_line");
            route.Points.Add(new PointLatLng(minlat, minlong));
            route.Points.Add(new PointLatLng(maxlat, minlong));
            route.Points.Add(new PointLatLng(maxlat, maxlong));
            route.Points.Add(new PointLatLng(minlat, maxlong));
            route.Points.Add(new PointLatLng(minlat, minlong));
            query_line.Routes.Add(route);
            reduct_map.Overlays.Add(query_line);
            reduct_map.UpdateRouteLocalPosition(route);
            reduct_map.ReloadMap();
        }
        public void query(List<Point> send_data, int index)
        {
            query_data query = new query_data();
            query.Data = send_data;
            query.max_point = new Point(maxlat, maxlong);
            query.min_point = new Point(minlat, minlong);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ip);

            NetworkStream stream = new NetworkStream(server);
            byte[] data_to_send = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(query));
            stream.Write(data_to_send, 0, data_to_send.Length);
            Thread.Sleep(2000);
            byte[] received_data = new byte[8000];
            server.Receive(received_data, SocketFlags.None);
            server.Close();
            received_query_data res = JsonConvert.DeserializeObject<received_query_data>(Encoding.ASCII.GetString(received_data));
            if (index == 0)
            {
                initmap();
                show_map();
                raw_draw_polygon();
                raw_query_marker(res);
            }
            else
            {
                reduced_initmap();
                reduced_show_map();
                reduce_draw_polygon();
                reduce_query_marker(res);
            }
        }
        private void btn_hamveri_sec_Click(object sender, EventArgs e)// Veriler dosyadan okunur, raw_data_coordinates listinde tutulur.
        {
            pb_image.Visible = false;
            grpbx_sorgu.Visible = true;
            WindowState = FormWindowState.Maximized;
            map_raw.Overlays.Clear();
            map_raw.Controls.Clear();
            reduct_map.Controls.Clear();
            string file_path = "";//
            raw_data_coordinates.Clear();
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                file_path = open_file.FileName;//Dosya yolunu alir
            }
            string[] filelines = File.ReadAllLines(file_path);//dosyayi satir satir okur
            for (int i = 0; i < filelines.Length; i++)
            {
                Point coordinate = new Point(Convert.ToDouble(filelines[i].Split(',')[0]), Convert.ToDouble(filelines[i].Split(',')[1]));
                raw_data_coordinates.Add(coordinate);
            }
            initmap();
            show_map();
        }
      
        private void btn_veri_indirge_Click(object sender, EventArgs e)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ip);
            NetworkStream stream = new NetworkStream(server);
            byte[] data_to_send = Encoding.ASCII.GetBytes(Get_json_data(raw_data_coordinates, 0));
            stream.Write(data_to_send, 0, data_to_send.Length);
            Thread.Sleep(3000);
            byte[] received_data = new byte[8048];
            server.Receive(received_data, SocketFlags.None);
            server.Close();
            received_reduction_data res = JsonConvert.DeserializeObject<received_reduction_data>(Encoding.ASCII.GetString(received_data));
            lbl_ratio.Text = "İndirgeme Oranı\n" + res.Ratio.ToString();
            lbl_time.Text ="İndirgeme Süresi\n"+ res.Elapsed_time.ToString() + "msn";
            for (int i = 0; i < res.Data.Count; i++)
            {
                reduced_data.Add(new Point(res.Data[i].X, res.Data[i].Y));
            }
            reduced_initmap();
            reduced_show_map();
        }
       
        private void map_raw_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clicked == true)
                {
                    maxlat = map_raw.FromLocalToLatLng(e.X, e.Y).Lat;
                    minlong = map_raw.FromLocalToLatLng(e.X, e.Y).Lng;
                    clicked = false;
                }
                else
                {
                    minlat = map_raw.FromLocalToLatLng(e.X, e.Y).Lat;
                    maxlong = map_raw.FromLocalToLatLng(e.X, e.Y).Lng;
                    clicked = true;
                    Thread.Sleep(1000);
                    query(raw_data_coordinates, 0);
                }
            }
        }
        private void reduct_map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clicked == true)
                {
                    maxlat = reduct_map.FromLocalToLatLng(e.X, e.Y).Lat;
                    minlong = reduct_map.FromLocalToLatLng(e.X, e.Y).Lng;
                    clicked = false;
                }
                else
                {
                    minlat = reduct_map.FromLocalToLatLng(e.X, e.Y).Lat;
                    maxlong = reduct_map.FromLocalToLatLng(e.X, e.Y).Lng;
                    clicked = true;
                    query(reduced_data,1);
                }
            }
        }
        private void btn_sorgu_Click(object sender, EventArgs e)
        {
            maxlat = Convert.ToDouble(max_lat.Text);
            maxlong = Convert.ToDouble(max_long.Text);
            minlat = Convert.ToDouble(min_lat.Text);
            minlong = Convert.ToDouble(min_long.Text);
            if (rb_raw.Checked == true)
            {
                raw_draw_polygon();
                query(raw_data_coordinates, 0);
            }
            if (rb_reduct.Checked == true)
            {
                reduce_draw_polygon();
                query(reduced_data, 1);
            }
        }
        private void map_raw_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_raw_coordinate.Visible = true;
            double lat = map_raw.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = map_raw.FromLocalToLatLng(e.X, e.Y).Lng;
            lbl_raw_coordinate.Text = "Lat:"+lat+"          "+"Long:"+lng;
        }
        private void reduct_map_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_reduce_coordinate.Visible = true;
            double lat = reduct_map.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = reduct_map.FromLocalToLatLng(e.X, e.Y).Lng;
            lbl_reduce_coordinate.Text = "Lat:" + lat + "          " + "Long:" + lng;
        }
    }
}
