//using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFBatch_main
{
    public partial class Form1 : Form
    {

        private int min_ff = 25;
        private Boolean fatal_parallel = false;
        private String fatal_parallel_msg = "";
        private ListViewColumnSorter lvwColumnSorter_Full;
        public string language = FFBatch_UPM.Properties.Settings.Default.app_lang;
        public int enc_q = FFBatch_UPM.Properties.Settings.Default.enc_q;

        ListView lv_size = new ListView();
        Boolean pop_invalids = false;
        Boolean cancel_cache = false;
        WebClient wc = new WebClient();
        Boolean cached = false;
        public long file_size_prog = 0;
        private Boolean cancelados_paralelos = false;
        private Boolean cancel_queue = false;
        private Boolean working = false;
        private int tiempo_apaga = 120;
        private Double durat_n = 0;
        private String validate_duration;
        private Boolean valid_prog = false;
        //private String def_mux_video_enc = "copy";
        //private String def_mux_audio_enc = "copy";
        //private String def_mux_subs_enc = "copy";
        private String def_lang_und_tracks = "und";
        //private Boolean Extract_img = false;
        //private Boolean select_mp4 = false;
        private int time_n_tasks = 0;
        private Boolean total_time = false;
        private Boolean recording_scr = false;
        //private Boolean hard_sub = false;
        private String add_suffix = "";
        private int capture_handle;
        //private Boolean Enable_txt_hard_Subs = false;
        private long tot_size = 0;
        private Boolean add_subfs = false;
        private Boolean warn_no_intros = false;

        //Boolean empty_text = false;
        private String n_th_suffix = String.Empty;

        private String n_th_source_ext = String.Empty;
        private int pending_dur = 0;
        private Boolean canceled_add = false;
        private Boolean dur_ok = false;
        private Boolean canceled_file_adding = false;
        private ListView list_pending_dur = new ListView();
        private ListView list_adding = new ListView();
        private ListView list_global_proc = new ListView();
        private List<string> files_to_add = new List<string>();
        private Boolean change_tab_1 = false;
        private Boolean change_tab_2 = false;
        private Boolean list_not_empty = false;
        private Process process_glob = new Process();
        private Process probe_urls = new Process();
        private Label was_started = new Label();
        private Boolean avoid_overwriting = false;

        private Boolean multi_running = false;
        private Dictionary<string, Process> procs = new Dictionary<string, Process>();
        private Dictionary<string, Point> points = new Dictionary<string, Point>();
        private Dictionary<string, Size> sizes = new Dictionary<string, Size>();

        private Boolean aborted_url = false;
        private int capture_count = 0;
        private Boolean tried_ok = false;
        private String textbox_params = String.Empty;
        private Boolean aborted = false;
        private Double total_duration = 0;
        private Double total_multi_duration = 0;
        private Double start_total_time = 0;


        private int time_est_size = 0;
        private Form frm_log = new Form();

        private RichTextBox Rtxt = new RichTextBox();
        private Boolean skipped = false;
        private List<string> tried_params = new List<string>();

        private Boolean paused = false;
        private ComboBox CB1_o = new ComboBox();
        private String audio_capture_device = String.Empty;
        private String prev_dev_audio = String.Empty;
        private Boolean abort_capture = false;
        private Boolean hw_decoders = false;
        private String hw_decode_glob = String.Empty;

        private String shut_type = "Power off";
        private Boolean fade_ok = true;
        private String multi_pr1 = String.Empty;
        private String multi_pr2 = String.Empty;
        private String multi_pr3 = String.Empty;
        private String multi_pr1_ext = String.Empty;
        private String multi_pr2_ext = String.Empty;
        private String multi_pr3_ext = String.Empty;
        private int n_multi_presets = 0;
        private String multi_two_pr1 = String.Empty;
        private String multi_two_ext = String.Empty;
        private String multi_1st_pass = String.Empty;
        private Boolean ren_multi = false;
        private Boolean runnin_n_presets = false;
        private TextBox path_txt = new TextBox();
        private ListBox LB1_o_try = new ListBox();
        private ToolTip toolTip01 = new ToolTip();
        private ToolTip toolTip_settings = new ToolTip();
        private Boolean back_ff = true;
        private Boolean just_started = true;
        private Boolean just_started5 = true;
        private int current_prio;
        private Boolean save_path_state = false;
        private Boolean save_preset_state = false;
        private List<string> decoders = new List<string>();
        private Boolean big_res = false;
        private int ff_ver_proc = 0;
        private Form frm_output2 = new Form();

        private Boolean is_ff_ok = false;
        private Boolean first_concat = true;
        private ListView LB1_kf = new ListView();
        
        OpenFileDialog file_dialog_ffq = new OpenFileDialog();
        SaveFileDialog save_ffq = new SaveFileDialog();
        Boolean send_par_consol = true;
        Boolean warn_success_items = true;
        Boolean no_save_logs = false;
        Boolean no_save_cache = false;
        Boolean os_save_cache = false;
        ListView unfilter_lv1 = new ListView();
        ListView filtered_lv1 = new ListView();
        ToolTip tool_undo_filter = new ToolTip();
        Boolean size_sorted = false;
        int initial_tab = 0;
        PictureBox pic_pause = new PictureBox();
        Boolean two_try_fail = false;
        public Boolean cancel_two = false;
        int invalids = 0;
        String file_to_copy = String.Empty;
        Boolean ask_cache_net = false;
        Boolean select_intro = false;
        Boolean select_credits = false;
        String duracion_intro = String.Empty;
        String duracion_salida = String.Empty;
        public int q_enc = 18;
        public ToolTip toolTip17 = new ToolTip();
        public ToolTip toolTip42 = new ToolTip();
        public ToolTip toolTip40 = new ToolTip();
        public ToolTip toolTip32 = new ToolTip();
        public ToolTip toolTip31 = new ToolTip();
        public ToolTip toolTip30 = new ToolTip();
        public ToolTip toolTip15 = new ToolTip();
        public ToolTip toolTip12 = new ToolTip();
        public ToolTip toolTip10_2 = new ToolTip();
        public ToolTip toolTip10 = new ToolTip();
        public ToolTip toolTip6_2 = new ToolTip();
        public ToolTip toolTip6 = new ToolTip();
        public ToolTip toolTip4 = new ToolTip();
        public ToolTip toolTip1 = new ToolTip();
        public ToolTip toolTip04 = new ToolTip();
        public ToolTip toolTip033 = new ToolTip();
        public ToolTip toolTip02 = new ToolTip();
        public ToolTip toolTipaA7 = new ToolTip();
        public ToolTip chkpaA7 = new ToolTip();
        public ToolTip chkpaA7z = new ToolTip();
        public ToolTip chkpaA8z = new ToolTip();
        public ToolTip chkpaA9z = new ToolTip();
        public ToolTip chkpaB0z = new ToolTip();

        public String pr1_string_main
        {
            get { return multi_pr1; }
            set { multi_pr1 = value; }
        }

        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter_Full = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter_Full;
            WebClient webClient1 = new WebClient();

        }

        public TextBox pr_default = new TextBox();
        public void prog_copy()
        {
            //pg_adding.Value = 
        }

        private void avoid_overw()
        {
            avoid_overwriting = false;
            if (listView1.Items.Count < 2) return;
            int i = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                if (Path.GetDirectoryName(item.Text) != Path.GetDirectoryName(listView1.Items[0].Text))
                {
                    avoid_overwriting = true;
                    return;
                }
                i = i + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was not found. Restart or reinstall application.", "Executable error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            openFileDialog1.Filter = "Audio and video |*.mp4; *.mkv; *.ts; *.mp3; *.wav; *.flac; *.m4a; *.avi; *.mts; *.flv; *.alac; *.aac; *.mpg; *.mp2; *.mpe; *.ogv; *.webm; *.aiff; *.vob; *.wma; *.wmv; *.mov; *.mka; *.m2ts; *.ac3; *.ogg|All files(*.*) | *.*";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileNames[0]);
            initial_tab = tabControl1.SelectedIndex;
            change_tab_1 = false;
            change_tab_2 = false;

            if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 0;
                change_tab_1 = true;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                tabControl1.SelectedIndex = 0;
                change_tab_2 = true;
            }

            string[] file_drop = (string[])openFileDialog1.FileNames;

            List<string> files2 = new List<string>();

            int num_drop = 0;
            foreach (String dropped in file_drop)
            {
                if (File.Exists(dropped))
                {
                    files2.Add(dropped);
                }

                num_drop = files2.Count();

                if (num_drop >= 10000)
                {
                    var a = MessageBox.Show("Adding " + num_drop + " files can take some time. Continue?", "Adding many files", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (a == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            files_to_add = files2;
            canceled_file_adding = false;
            btn_cancel_add.Enabled = true;
            btn_cancel_add.Visible = true;
            btn_cancel_add.Refresh();
            BG_Files.RunWorkerAsync();
        }

        private void check_back_updates()
        {
            return;
            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                String current_ver = btn_update.Text;

                String content2 = String.Empty;
                try
                {

                    WebClient client = new WebClientWithTimeout();
                    Stream stream = client.OpenRead("https://drive.upm.es/index.php/s/qx2KzwVy77y7pL3/download");
                    StreamReader reader = new StreamReader(stream);
                    String content = reader.ReadToEnd();
                    content2 = content;

                }
                catch
                {
                    try
                    {
                        //Backup server
                        WebClient client = new WebClientWithTimeout();
                        Stream stream = client.OpenRead("http://www.blasdelezoinvictus.es/config/current_ffb.txt");
                        StreamReader reader = new StreamReader(stream);
                        String content = reader.ReadToEnd();
                        content2 = content;
                    }
                    catch
                    {
                        //this.InvokeEx(f => f.lbl_updates.Text = "Update connection error");
                        this.InvokeEx(f => f.btn_update.Text = current_ver);
                        return;
                    }
                }

                try
                {
                    if (Convert.ToInt16(content2.Replace(".", String.Empty).Substring(0, 3)) > Convert.ToInt16(Application.ProductVersion.Replace(".", String.Empty)))
                    {
                        //this.InvokeEx(f => f.lbl_updates.Text = "Version " + content2.Substring(0, 5) + "  available!");
                    }
                }
                catch (Exception excpt)
                {
                    MessageBox.Show("There was an error checking for updates." + Environment.NewLine + Environment.NewLine + excpt.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.InvokeEx(f => f.btn_update.Text = current_ver);

            }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            pic_pause.Image = btn_pause.Image;

            if (FFBatch_UPM.Properties.Settings.Default.app_lang == "es")
            {
                combo_lang.SelectedIndex = 0;
            }
            if (FFBatch_UPM.Properties.Settings.Default.app_lang == "en")
            {
                combo_lang.SelectedIndex = 1;

            }
            else combo_lang.SelectedIndex = 0;

            if (!Directory.Exists(Path.Combine(Path.GetTempPath(), "FFBatch_test")))
            {
                try
                {
                    Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "FFBatch_test"));
                    watch_other_instance.Path = Path.Combine(Path.GetTempPath(), "FFBatch_test");
                }
                catch
                {

                }
            }
            else
            {
                watch_other_instance.Path = Path.Combine(Path.GetTempPath(), "FFBatch_test");
            }

            this.Cursor = Cursors.WaitCursor;
           

            String f_prio = String.Empty;

            f_prio = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_priority.ini";
                        

            this.Cursor = Cursors.Arrow;
        }

        private void read_saved_path()
        {
            String path_s = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_path.ini";

            if (File.Exists(path_s))
            {
                String saved_path = File.ReadAllText(path_s);

                if (saved_path != String.Empty)
                {
                    if (Directory.Exists(saved_path) == true)
                    {
                        txt_path.Text = saved_path;
                        txt_path.BackColor = Color.White;
                    }

                    else
                    {
                        if (saved_path.Contains("..\\"))
                        {
                            txt_path.Text = saved_path;                          
                        }
                        txt_path.BackColor = this.BackColor;
                    }
                }
                else

                {
                    File.Delete(path_s);
                    txt_path.BackColor = this.BackColor;
                }

            }

            //End read saved path
        }

        private void read_main_config()
        {
            //Read configuration

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);      



            //Check ffbatch.ini if not found
            String path = String.Empty;

            path = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.ini";


            //Read main legacy config

            int linea = 0;            

            foreach (string line in File.ReadLines(path))
            {
                linea = linea + 1;

                if (line == "yes")

                {
                   
                }

                if (line == "no")
                {
                   
                }

                if (linea == 4)
                {
                    if (line == "Vn")
                    {
                       
                    }
                    else
                    {
                    
                    }
                }

                if (line == "grid_yes")
                {
                    this.InvokeEx(f => f.listView1.GridLines = true);

                }
                if (line == "grid_no")
                {
                    this.InvokeEx(f => f.listView1.GridLines = false);

                }

                if (line == "keep_yes")
                {
                 
                }
                if (line == "keep_no")
                {
                  
                }

                if (line == "subf_yes")
                {
                    this.InvokeEx(f => f.chk_subfolders.CheckState = CheckState.Checked);
                    add_subfs = true;
                }
                if (line == "subf_no")
                {
                    this.InvokeEx(f => f.chk_subfolders.CheckState = CheckState.Unchecked);
                    add_subfs = false;
                }
                

                if (linea == 1)
                {
                   
                }

                if (linea == 2)
                {
             
                }

                if (line.Contains("PR: "))
                {
                    
                }
            }

            //End read configuration            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            lbl_size.Text = "";
            LB_Wait.Visible = false;
            txt_remain.Text = "Tiempo restante:   00h:00m:00s";
            listView1.Items.Clear();
            txt_video_intro.Text = String.Empty;
            txt_video_salida.Text = String.Empty;

            lbl_items.Text = "";
            lbl_dur_list.Text = "";
            Pg1.Value = 0;
            //pg_current.Value = 0;
            //textBox4.Text = "0%";
            txt_pg1_prog.Text = "0%";
        }

        private void cti1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                String fullPath = listView1.SelectedItems[0].Text;
                String destino = Path.GetDirectoryName(fullPath);

                if (Directory.Exists(destino))
                {
                    Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "explorer.exe";
                    process.StartInfo.Arguments = "\u0022" + destino + "\u0022";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                else
                {
                    MessageBox.Show("Path was not found", "Folder not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cti2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                String fullPath = listView1.SelectedItems[0].Text;
                if (File.Exists(fullPath))
                {
                    System.Diagnostics.Process.Start(fullPath);
                }
                else
                {
                    MessageBox.Show("File was not found", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ctm1_Opening(object sender, CancelEventArgs e)
        {
            if (language == "en")
            {
                ctm1.Items[0].Text = "Add videos";
                ctm1.Items[1].Text = "Add folder";
                ctm1.Items[3].Text = "Play video";
                ctm1.Items[4].Text = "Browse video path";
                ctm1.Items[5].Text = "Browse destination path";
                ctm1.Items[7].Text = "Remove from list";
                ctm1.Items[8].Text = "Reset status";
                ctm1.Items[9].Text = "Move item to top";
                ctm1.Items[10].Text = "Move item to bottom";


                ctm1.Items[12].Text = "Multimedia information";
                ctm1.Items[13].Text = "Total video frames/seconds";
                ctm1.Items[15].Text = "Show/hide grid";
                ctm1.Items[16].Text = "Stop task";
            }
            if (language == "es")
            {
                ctm1.Items[0].Text = "Añadir vídeos";
                ctm1.Items[1].Text = "Añadir carpeta";
                ctm1.Items[3].Text = "Reproducir video";
                ctm1.Items[4].Text = "Examinar ruta del vídeo";
                ctm1.Items[5].Text = "Examinar ruta de destino";
                ctm1.Items[7].Text = "Eliminar de la lista";
                ctm1.Items[8].Text = "Reiniciar estado del elemento";
                ctm1.Items[9].Text = "Mover elemento al principio";
                ctm1.Items[10].Text = "Mover elemento al final";


                ctm1.Items[12].Text = "Mostrar informatión multimedia";
                ctm1.Items[13].Text = "Total de fotogramas/segundos";
                ctm1.Items[15].Text = "Mostrar/ocultar rejilla";
                ctm1.Items[16].Text = "Abortar codificación";
            }
            cti6.Visible = false;
            if (runnin_n_presets == true) e.Cancel = true;

            ctm1_queue.Enabled = false;

            if (working == true)
            {
                cti1.Enabled = false;
                cti2.Enabled = false;
                cti3.Enabled = false;
                cti4.Enabled = false;

                ctdel.Enabled = false;
                ct1_total_frames.Enabled = false;

                ctm1_queue.Enabled = false;
                ctm_add_files.Enabled = false;
                ctm_add_folder.Enabled = false;

                if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[4].Text != "Aborted" && listView1.SelectedItems[0].SubItems[4].Text != "Queued" && listView1.SelectedItems[0].SubItems[4].Text != "Aborting" && listView1.SelectedItems[0].SubItems[4].Text != "Success")
                {
                    cti6.Visible = true;
                    if (language == "es") cti6.Text = "Abortar " + "\u0022" + Path.GetFileName(listView1.SelectedItems[0].Text) + "\u0022";
                    if (language == "en") cti6.Text = "Abort " + "\u0022" + Path.GetFileName(listView1.SelectedItems[0].Text) + "\u0022";
                }

                if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[4].Text == "Queued" && multi_running == false)
                {
                    ctdel.Enabled = true;
                }
            }
            else
            {

                if (listView1.SelectedItems.Count > 0)
                {
                    cti1.Enabled = true;
                    cti2.Enabled = true;

                    String fullPath = listView1.SelectedItems[0].Text;
                    String destino = "";
                    if (txt_path.Text.Contains("..\\"))
                    {
                        destino = fullPath.Substring(0, fullPath.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty);
                    }
                    else
                    {
                        destino = txt_path.Text;
                    }

                    if (Directory.Exists(destino))
                    {
                        cti3.Enabled = true;
                    }
                    else
                    {
                        cti3.Enabled = false;
                    }

                    cti4.Enabled = true;

                    ctdel.Enabled = true;
                    ct1_total_frames.Enabled = true;
                    ctm_add_files.Visible = false;
                    ctm_add_folder.Visible = false;
                    toolStripSeparator2.Visible = false;
                    ctm1_queue.Enabled = false;
                    ct_move_down.Enabled = true;
                    ct_move_up.Enabled = true;
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        if (item.SubItems[4].Text != "Queued")
                        {
                            ctm1_queue.Enabled = true;
                            break;
                        }
                    }
                }
                else
                {
                    e.Cancel = false;
                    ctm_add_files.Visible = true;
                    ctm_add_folder.Visible = true;
                    ctm1_queue.Enabled = false;
                    toolStripSeparator2.Visible = true;
                    cti1.Enabled = false;
                    cti2.Enabled = false;
                    cti3.Enabled = false;
                    cti4.Enabled = false;
                    ctdel.Enabled = false;
                    ct_move_down.Enabled = false;
                    ct_move_up.Enabled = false;
                    ct1_total_frames.Enabled = false;
                    toolStripSeparator2.Visible = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Double weight = 0;
            Double dg_multi_prog = 0;
            start_total_time = start_total_time + 1;

            TimeSpan t9 = TimeSpan.FromSeconds(start_total_time);
            String tx_elapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                t9.Hours,
                t9.Minutes,
                t9.Seconds);
            if (language == "es") lbl_elapsed.Text = "Tiempo actual: " + tx_elapsed;
            if (language == "en") lbl_elapsed.Text = "Elapsed time: " + tx_elapsed;

            foreach (ListViewItem item_p in listView1.Items)
            {
                try
                {
                    weight = TimeSpan.Parse(item_p.SubItems[2].Text).TotalSeconds / total_multi_duration;
                    if (item_p.SubItems[4].Text.Contains("%") == true && cancelados_paralelos == false)
                    {
                        dg_multi_prog = dg_multi_prog + (Convert.ToDouble(item_p.SubItems[4].Text.Replace("%", "")) * weight) * listView1.Items.Count;
                    }
                }
                catch
                {

                }

                if (item_p.SubItems[4].Text == "Success" || item_p.SubItems[4].Text == "Failed" || item_p.SubItems[4].Text == "Aborted" || item_p.SubItems[4].Text == "Aborting" || item_p.SubItems[4].Text == "Skipped" || item_p.SubItems[4].Text == "Replaced" || item_p.SubItems[4].Text == "Not replaced")
                {
                    dg_multi_prog = dg_multi_prog + (100 * weight * listView1.Items.Count);
                }
            }

            if (time_n_tasks > 1)
            {
                Pg1.Value = Convert.ToInt32(dg_multi_prog);
                if (Math.Round(dg_multi_prog / list_global_proc.Items.Count, 1).ToString().Contains(".") || Math.Round(dg_multi_prog / list_global_proc.Items.Count, 1).ToString().Contains(","))
                {
                    this.InvokeEx(f => f.txt_pg1_prog.Text = Math.Round(dg_multi_prog / list_global_proc.Items.Count, 1).ToString() + "%");
                }
                else
                {
                    this.InvokeEx(f => f.txt_pg1_prog.Text = Math.Round(dg_multi_prog / list_global_proc.Items.Count, 1).ToString() + ".0" + "%");
                }
                //textBox5.Text = (dg_multi_prog / list_global_proc.Items.Count).ToString() + "%";
                TaskbarProgress.SetValue(this.Handle, Convert.ToInt32(dg_multi_prog), Pg1.Maximum);
                txt_pg1_prog.Refresh();
            }
            else
            {
                Pg1.Value = 0;
                txt_pg1_prog.Text = "0%";
                txt_pg1_prog.Refresh();
            }

            if (Pg1.Value / listView1.Items.Count > 0 && start_total_time > 4)
            {
                Double remain_secs = time_n_tasks * 100 / (Pg1.Value / listView1.Items.Count) - start_total_time;
                String remain_string = String.Empty;

                TimeSpan t = TimeSpan.FromSeconds(remain_secs);
                remain_string = string.Format("{0:D2}h:{1:D2}",
                t.Hours,
                t.Minutes);

                if (remain_secs >= 43200)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: " + Math.Round(remain_secs / 3600).ToString() + " hours";
                    if (language == "en") txt_remain.Text = "Remaining time: " + Math.Round(remain_secs / 3600).ToString() + " hours";
                }

                if (remain_secs >= 3600 && remain_secs < 43200)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: " + remain_string + " min";
                    if (language == "en") txt_remain.Text = "Remaining time: " + remain_string + " min";
                }

                if (remain_secs < 3600 && remain_secs >= 600)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: " + remain_string.Substring(remain_string.LastIndexOf(":") + 1, 2) + " minutes";
                    if (language == "en") txt_remain.Text = "Remaining time: " + remain_string.Substring(remain_string.LastIndexOf(":") + 1, 2) + " minutes";
                }
                if (remain_secs < 600 && remain_secs >= 120)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: " + remain_string.Substring(remain_string.LastIndexOf(":") + 2, 1) + " minutes";
                    if (language == "en") txt_remain.Text = "Remaining time: " + remain_string.Substring(remain_string.LastIndexOf(":") + 2, 1) + " minutes";
                }

                if (remain_secs < 120 && remain_secs > 59)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: " + "1 minuto";
                    if (language == "en") txt_remain.Text = "Remaining time: " + "About a minute";
                }

                if (remain_secs <= 59)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: < 1 minuto";
                    if (language == "en") txt_remain.Text = "Remaining time: < 1 minute";
                }
                if (remain_secs <= 0)
                {
                    if (language == "es") txt_remain.Text = "Tiempo restante: Terminando";
                    if (language == "en") txt_remain.Text = "Remaining time: About to finish";
                }
                txt_remain.Refresh();
            }
            else
            {
                if (language == "es") txt_remain.Text = "Tiempo restante: Calculando...";
                txt_remain.Refresh();
            }
            if (cancelados_paralelos == true)
            {
                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
            }
        }

        private void cti3_Click(object sender, EventArgs e)
        {
            String fullPath = listView1.SelectedItems[0].Text;
            String destino = "";
            if (txt_path.Text.Contains("..\\"))
            {
                destino = fullPath.Substring(0, fullPath.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty);
            }
            else
            {
                destino = txt_path.Text;
            }

            if (Directory.Exists(destino))
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "explorer.exe";
                process.StartInfo.Arguments = "\u0022" + destino + "\u0022";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            else
            {
                MessageBox.Show("Folder was not found", "Folder not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cti4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 1) listView1.Items[0].Selected = true;

            String ffm = System.IO.Path.Combine(Application.StartupPath, "mediainfo.exe");
            if (!File.Exists(ffm))
            {
                MessageBox.Show("Error obtaining file information. You may have to reinstall application.", "Mediainfo not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listView1.SelectedItems.Count == 1)
            {
                String file1 = System.IO.Path.Combine(Application.StartupPath + "\\", "mediainfo.exe");
                String fullPath = "\u0022" + listView1.SelectedItems[0].Text + "\u0022";
                String testPath = listView1.SelectedItems[0].Text;

                if (!File.Exists(testPath))
                {
                    MessageBox.Show("File was not found", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;

                String salida = "";

                Form frmInfo = new Form();
                frmInfo.Name = "Multimedia information";
                frmInfo.Text = "FFmpeg Batch AV Converter";
                frmInfo.Icon = this.Icon;
                frmInfo.Height = 724;
                frmInfo.Width = 496;
                frmInfo.FormBorderStyle = FormBorderStyle.Fixed3D;
                frmInfo.MaximizeBox = false;
                frmInfo.MinimizeBox = false;
                frmInfo.BackColor = this.BackColor;

                var fuente_list = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular);

                ListView LB1 = new ListView();
                LB1.Parent = frmInfo;
                LB1.ShowItemToolTips = true;
                LB1.Left = 14;
                LB1.Top = 56;
                LB1.Height = 591;
                LB1.Width = 447;
                LB1.SmallImageList = img_streams;
                LB1.View = View.Details;
                LB1.FullRowSelect = true;
                LB1.GridLines = true;
                LB1.Columns.Add("", 130);
                LB1.Columns.Add("", 295);
                LB1.HeaderStyle = ColumnHeaderStyle.None;
                LB1.Refresh();

                TextBox titulo = new TextBox();
                titulo.Parent = frmInfo;
                titulo.Top = 6;
                titulo.Left = 14;
                titulo.Width = 448;
                titulo.TabIndex = 0;
                var fuente = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                titulo.BackColor = this.BackColor;

                titulo.Font = fuente;
                titulo.BorderStyle = BorderStyle.Fixed3D;
                titulo.TextAlign = HorizontalAlignment.Center;
                titulo.ReadOnly = true;

                titulo.Text = "MULTIMEDIA INFORMATION (SUMMARY)";

                Button boton_ok = new Button();
                boton_ok.Parent = frmInfo;
                boton_ok.Left = 73;
                boton_ok.Top = 650;
                boton_ok.Width = 330;
                boton_ok.Height = 27;
                boton_ok.Text = "Close window";
                boton_ok.Click += new EventHandler(boton_ok_Click);
                frmInfo.CancelButton = boton_ok;

                Button btn_next = new Button();
                btn_next.Parent = frmInfo;
                btn_next.Left = 404;
                btn_next.Top = 650;
                btn_next.Width = 59;
                btn_next.Height = 27;
                btn_next.Text = "Next  -->";
                btn_next.Click += new EventHandler(btn_next_Click);

                Button btn_prev = new Button();
                btn_prev.Parent = frmInfo;
                btn_prev.Left = 14;
                btn_prev.Top = 650;
                btn_prev.Width = 59;
                btn_prev.Height = 27;
                btn_prev.Text = "<-- Prev ";
                btn_prev.Click += new EventHandler(btn_prev_Click);

                String fichero = Path.GetFileName(listView1.SelectedItems[0].Text);
                TextBox titulo2 = new TextBox();
                titulo2.Parent = frmInfo;
                titulo2.Top = 34;
                titulo2.Left = 14;
                titulo2.Width = 440;
                titulo2.BackColor = this.BackColor;

                titulo2.BorderStyle = BorderStyle.None;
                titulo2.TextAlign = HorizontalAlignment.Center;
                titulo2.ReadOnly = true;

                titulo2.Text = (fichero);
                int indx = 0;
                List<string> salida1 = new List<string>();
                var font_item = new System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Bold);

                String[] fields_mi = new string[] { "Format  ", "Bit depth", "General", "Bit rate", "bit rate", "Duration", "Audio", "Frame rate  ", "Width", "Height", "Color space", "Chroma subsampling", "Channel(s)", "Channel positions", "Sampling rate ", "Maximum bit rate", "File size", "Format profile", "Display aspect ratio", "Stream size", "Text", "Language", "Recorded date", "Performer", "Album", "Genre", "Track name" };

                var process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = file1;
                process.StartInfo.Arguments = fullPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    salida = process.StandardOutput.ReadLine();
                    salida1.Add(salida);
                }
                process.WaitForExit();
                LB1.BeginUpdate();

                foreach (String salida2 in salida1)
                {
                    Boolean match = false;
                    foreach (String str in fields_mi)
                    {
                        if (salida2.Contains(str) == true)
                        {
                            match = true;
                            break;
                        }
                    }

                    if (salida2 == "" || salida2 == "Video" || match == true)

                    {
                        int derecha = 0;

                        if (!salida2.Contains("  : "))
                        {
                            LB1.Items.Add(salida2.ToUpper());
                            LB1.Items[indx].Font = font_item;
                            LB1.Items[indx].ForeColor = Color.DarkBlue;
                            if (salida2 != String.Empty)
                            {
                                LB1.Items[indx].SubItems[0].BackColor = Color.FromArgb(255, 220, 238, 255);
                                if (salida2.Contains("Video")) LB1.Items[indx].ImageIndex = 0;
                                if (salida2.Contains("Audio")) LB1.Items[indx].ImageIndex = 1;
                                if (salida2.Contains("Text")) LB1.Items[indx].ImageIndex = 2;
                                if (salida2.Contains("General"))
                                {
                                    LB1.Items[indx].ImageIndex = 5;
                                    LB1.Items[indx].SubItems[0].BackColor = Color.FromArgb(255, 255, 248, 220);
                                }
                            }

                            indx = indx + 1;
                        }
                        else

                        {
                            if (!salida2.Contains("SPF"))
                            {
                                LB1.Items.Add(salida2.Substring(0, salida2.LastIndexOf("  : ")).Replace("  ", ""));
                                derecha = salida2.Length - (salida2.LastIndexOf("  :"));
                                LB1.Items[indx].SubItems.Add(salida2.Substring(salida2.LastIndexOf("  :") + 4, derecha - 4).Replace("kb", "Kb"));
                                indx = indx + 1;
                            }
                        }
                    }
                }

                for (int x = 0; x < 2; x++)
                {
                    LB1.Items.RemoveAt(LB1.Items.Count - 1);
                }

                int duraciones = 0;
                String elemento = "";
                for (int i = 0; i < LB1.Items.Count; i++)
                {
                    elemento = LB1.Items[i].Text;

                    if (elemento.Contains("Duration"))
                    {
                        duraciones = duraciones + 1;

                        if (duraciones > 1)
                        {
                            LB1.Items.RemoveAt(i);
                        }
                    }
                }

                foreach (ListViewItem item in LB1.Items)
                {
                    if (item.Text == String.Empty)
                    {
                        item.Remove();
                    }
                }
                LB1.EndUpdate();
                frmInfo.StartPosition = FormStartPosition.CenterParent;
                this.Cursor = Cursors.Arrow;
                frmInfo.ShowDialog();
            }
            else

            {
                MessageBox.Show("No item was selected", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was not found. Restart or reinstall application.", "Executable error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (language == "es") folderBrowserDialog1.Description = "Incluir subcarpetas no habilitado";
            if (language == "en") folderBrowserDialog1.Description = "Include subfolders disabled";
            if (add_subfs == true)
            {
                if (language == "es") folderBrowserDialog1.Description = "Incluir subcarpetas habilitado";
                if (language == "en") folderBrowserDialog1.Description = "Include subfolders enabled";
            }

            folderBrowserDialog1.ShowNewFolderButton = false;

            change_tab_1 = false;
            change_tab_2 = false;

            if (listView1.Items.Count == 0)
            {
                list_not_empty = false;
            }
            else
            {
                list_not_empty = true;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                change_tab_1 = true;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                change_tab_2 = true;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> files2 = new List<string>();

                foreach (string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    if (!File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                    {
                        files2.Add(file);
                    }
                }

                int num_drop = files2.Count();

                if (add_subfs == true)
                {
                    string[] dirs = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);

                    foreach (string ds in dirs)
                    {
                        try
                        {
                            foreach (string f in Directory.GetFiles(ds, "*.*", System.IO.SearchOption.AllDirectories))
                            {
                                if (!File.GetAttributes(f).HasFlag(FileAttributes.Hidden))
                                {
                                    files2.Add(f);
                                    num_drop = num_drop + 1;
                                }
                            }
                        }
                        catch (System.Exception excpt)
                        {
                            var a = MessageBox.Show("Error: " + excpt.Message + " Continue?", "Access error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            if (a == DialogResult.Cancel) return;
                        }
                    }
                }

                if (num_drop == 0)
                {
                    var a = MessageBox.Show("Folder is empty", "Folder empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (num_drop >= 10000)
                {
                    var a = MessageBox.Show("Adding " + num_drop + " files can take some time. Continue?", "Adding many files", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (a == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                files_to_add = files2;
                canceled_file_adding = false;
                btn_cancel_add.Enabled = true;
                btn_cancel_add.Visible = true;
                btn_cancel_add.Refresh();
                BG_Files.RunWorkerAsync();
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void ctdel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.BeginUpdate();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    if (working == false)
                    {
                        listView1.Items.Remove(item);
                    }
                    else
                    {
                        if (item.SubItems[4].Text == "Queued")
                        {
                            listView1.Items.RemoveAt(item.Index);
                        }
                    }
                }

                listView1.EndUpdate();
                if (language == "es") lbl_items.Text = listView1.Items.Count + " fichero(s)";
                if (language == "en") lbl_items.Text = listView1.Items.Count + " file(s)";

                calc_total_dur();
                calc_list_size();

                if (working == true && multi_running == false)
                {
                    total_duration = 0;

                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[2].Text != "N/A" && item.SubItems[2].Text != "0:00:00" && item.SubItems[2].Text != "00:00:00" && item.SubItems[2].Text != "Pending")
                        {
                            total_duration = total_duration + TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds;
                        }
                        else
                        {
                            total_duration = total_duration + 0;
                        }
                    }
                }
            }
        }

        private void ctm_add_files_Click(object sender, EventArgs e)
        {
            this.btn_add_files.PerformClick();
        }

        private void ctm_add_folder_Click(object sender, EventArgs e)
        {
            this.btn_add_folders.PerformClick();
        }
        

        private void boton_ok_Click(object sender, System.EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void btn_next_Click(object sender, System.EventArgs e)
        {
            Form.ActiveForm.Close();
            if (listView1.SelectedItems[0].Index < listView1.Items.Count - 1)
            {
                listView1.Items[listView1.SelectedIndices[0] + 1].Selected = true;
                listView1.Items[listView1.SelectedIndices[0]].Selected = false;
                listView1.Select();
                cti4.PerformClick();
            }
        }

        private void btn_prev_Click(object sender, System.EventArgs e)
        {
            Form.ActiveForm.Close();
            if (listView1.SelectedItems[0].Index > 0)
            {
                int selected_item = listView1.SelectedIndices[0];
                //listView1.Items[listView1.SelectedIndices[0] - 2].Selected = true;
                listView1.Items[selected_item].Selected = false;
                listView1.Items[selected_item - 1].Selected = true;
                listView1.Select();
                cti4.PerformClick();
            }
        }

        private void boton_ok_wave_Click(object sender, System.EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void boton_kill_Click(object sender, System.EventArgs e)
        {
            cancelados_paralelos = true;
            cancel_queue = true;

            Form.ActiveForm.Close();

            Process[] localByName = Process.GetProcessesByName("ffmpeg");
            foreach (Process p in localByName)
                p.Kill();
            System.Threading.Thread.Sleep(250);
            Process[] localByName2 = Process.GetProcessesByName("ffmpeg");
            foreach (Process p2 in localByName2)
                p2.Kill();
        }

        private void boton_ok_ff_Click(object sender, System.EventArgs e)
        {
            Form.ActiveForm.Close();
            this.InvokeEx(f => this.Enabled = true);

        }

        private void boton_copy_kf_Click(object sender, System.EventArgs e)
        {
            String lista = "Video keyframes" + Environment.NewLine;

            foreach (ListViewItem item in LB1_kf.Items)
            {
                try
                {
                    lista = lista + Environment.NewLine + item.Text + " --- " + item.SubItems[1].Text + " ---" + item.SubItems[2].Text;
                }
                catch
                {
                    continue;
                }
            }

            String temp_file = Path.Combine(Path.GetTempPath(), "temp_copy_kf.ff");
            if (File.Exists(temp_file))
            {
                try
                {
                    File.Delete(temp_file);
                }
                catch
                {
                    MessageBox.Show("Error copying to clipboard");
                    return;
                }
            }

            File.WriteAllText(Path.Combine(Path.GetTempPath(), "temp_copy_kf.ff"), lista);
            Process.Start("notepad.exe", Path.Combine(Path.GetTempPath(), "temp_copy_kf.ff"));
        }

        private void boton_copy_ff_Click(object sender, System.EventArgs e)
        {
            String lista = String.Empty;

            for (int i = 0; i < LB1_o_try.Items.Count; i++)
            {
                lista = lista + Environment.NewLine + LB1_o_try.Items[i].ToString();
            }

            String temp_file = Path.Combine(Path.GetTempPath(), "temp_copy_clp.ff");
            if (File.Exists(temp_file))
            {
                try
                {
                    File.Delete(temp_file);
                }
                catch
                {
                    MessageBox.Show("Error copying to clipboard");
                    return;
                }
            }

            File.WriteAllText(Path.Combine(Path.GetTempPath(), "temp_copy_clp.ff"), lista);
            Process.Start("notepad.exe", Path.Combine(Path.GetTempPath(), "temp_copy_clp.ff"));
        }

        private void LB1_o_Click(object sender, System.EventArgs e)
        {
            //Form.ActiveForm.Close();
        }


        private void Timer_apaga_Tick(object sender, EventArgs e)
        {
            tiempo_apaga = tiempo_apaga - 1;

            if (tiempo_apaga % 2 == 0)

            {                
                this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, 100, 100));
                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Paused));
            }
            else
            {                
                this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, 100, 100));
                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Error));
            }           
        }

        private void disable_abort_btn()
        {
            this.InvokeEx(f => f.btn_abort_all.Enabled = false);

            this.InvokeEx(f => f.tabControl1.Enabled = false);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Normal));
            this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, 0, 100));
            this.TopMost = false;
            Enable_Controls();
            btn_pause.Enabled = true;
            

            Timer_apaga.Stop();
            
            notifyIcon1.Visible = false;
            txt_remain.Text = "Time remaining";

            if (tiempo_apaga == 0)
            {
                Process no_apagar = new System.Diagnostics.Process();
                no_apagar.StartInfo.FileName = "shutdown.exe";
                no_apagar.StartInfo.Arguments = "-a";
                no_apagar.StartInfo.UseShellExecute = false;
                no_apagar.StartInfo.CreateNoWindow = true;
                no_apagar.Start();
            }
            tiempo_apaga = 120;
        }

        
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            change_tab_1 = false;
            change_tab_2 = false;

            string[] file_drop = (string[])e.Data.GetData(DataFormats.FileDrop);

            List<string> files2 = new List<string>();

            int num_drop = 0;

            //Load queue file

            if (file_drop.Count() == 1 && Path.GetExtension(file_drop[0]) == ".ffq")
            {
                int linea = 0;
                int not_found = 0;
               
                List<ListViewItem> itemsToAdd = new List<ListViewItem>();
                try
                {
                    foreach (string line in File.ReadLines(file_drop[0]))
                    {

                        if (linea == 0)
                        {
                           
                        }
                        if (linea == 1)
                        {
                          
                        }

                        if (linea == 2)
                        {
                         
                        }

                        if (linea == 3)
                        {
                           
                        }

                        if (linea == 4)
                        {
                            txt_path.Text = line;
                        }

                        if (linea > 4)
                        {

                            Boolean missing = false;
                            listView1.SmallImageList = imageList2;

                            itemsToAdd.Add(new ListViewItem(line.Substring(0, line.LastIndexOf(" --0 ")), 1));
                            //ListViewItem elemento = new ListViewItem(line.Substring(0, line.LastIndexOf(" --0 ")), 1);
                            //Begin get file icon
                            Icon iconForFile = SystemIcons.WinLogo;

                            // Check to see if the image collection contains an image
                            // for this extension, using the extension as a key.
                            if (File.Exists(line.Substring(0, line.LastIndexOf(" --0 "))))
                            {
                                if (!imageList2.Images.ContainsKey(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 ")))))
                                {
                                    // If not, add the image to the image list.
                                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(line.Substring(0, line.LastIndexOf(" --0 ")));
                                    imageList2.Images.Add(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 "))), iconForFile);
                                }

                                //listView1.Items.Add(elemento);
                                itemsToAdd[linea - 5].ImageKey = System.IO.Path.GetExtension(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 "))));
                            }
                            else
                            {
                                not_found = not_found + 1;
                                missing = true;
                            }

                            //listView1.Items.Add(line.Substring(0,line.LastIndexOf(" --0 ")));
                            String type = line.Substring(line.LastIndexOf(" --0 ") + 5, line.Length - (line.LastIndexOf(" --0") + 5));
                            type = type.Substring(0, type.LastIndexOf(" --1"));
                            String dur = line.Substring(line.LastIndexOf(" --1 ") + 5, line.Length - (line.LastIndexOf(" --1") + 5));
                            dur = dur.Substring(0, dur.LastIndexOf(" --2"));
                            String size = line.Substring(line.LastIndexOf(" --2 ") + 5, line.Length - (line.LastIndexOf(" --2") + 5));
                            size = size.Substring(0, size.LastIndexOf(" --3"));
                            String status = line.Substring(line.LastIndexOf(" --3 ") + 5, line.Length - (line.LastIndexOf(" --3") + 5));

                            itemsToAdd[linea - 5].SubItems.Add(type);
                            itemsToAdd[linea - 5].SubItems.Add(dur);
                            itemsToAdd[linea - 5].SubItems.Add(size);
                            if (missing == false) itemsToAdd[linea - 5].SubItems.Add(status);
                            else
                            {
                                itemsToAdd[linea - 5].SubItems.Add("File not found");
                                itemsToAdd[linea - 5].BackColor = Color.LightGoldenrodYellow;
                            }
                        }
                        linea = linea + 1;
                    }
                    listView1.Items.AddRange(itemsToAdd.ToArray());

                }
                catch (Exception excpt)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Error loading queue session. Unexpected file format." + Environment.NewLine + excpt.Message, "Queue file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                    read_saved_path();
                    return;
                }
                this.Cursor = Cursors.Arrow;

                if (tabControl1.SelectedIndex == 0)
                {
                    calc_list_size();
                    calc_total_dur();
                    lbl_items.Text = listView1.Items.Count.ToString() + " files";


                    if (not_found > 0)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("Ficheros añadidos con éxito. " + Environment.NewLine + not_found.ToString() + " fichero(s) no fueron encontrados. " + Environment.NewLine + Environment.NewLine + "Please sort and check file list for items marked with status " + '\u0022' + "File not found" + '\u0022' + ".", "Queue list loaded with missing files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }

            //End load queue file

            foreach (String dropped in file_drop)
            {
                if (File.Exists(dropped))
                {
                    files2.Add(dropped);
                    num_drop = files2.Count();
                }
                else
                {
                    if (Directory.Exists(dropped))
                    {
                        if (add_subfs == false)
                        {
                            foreach (String file in Directory.GetFiles(dropped))
                            {
                                if (!File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                                {
                                    files2.Add(file);
                                    num_drop = num_drop + 1;
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                foreach (string f in Directory.GetFiles(dropped, "*.*", System.IO.SearchOption.AllDirectories))
                                {
                                    if (!File.GetAttributes(f).HasFlag(FileAttributes.Hidden))
                                    {
                                        files2.Add(f);
                                        num_drop = num_drop + 1;
                                    }
                                }
                            }
                            catch (System.Exception excpt)
                            {
                                var a = MessageBox.Show("Error: " + excpt.Message, "Access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }

            if (num_drop >= 5000)
            {
                var a = MessageBox.Show("Adding " + num_drop + " files could take some time. Continue?", "Adding many files", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (a == DialogResult.Cancel)
                {
                    return;
                }
            }

            files_to_add = files2;
            canceled_file_adding = false;
            btn_cancel_add.Enabled = true;
            btn_cancel_add.Visible = true;
            btn_cancel_add.Refresh();
            BG_Files.RunWorkerAsync();
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;

            //   if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (multi_running == true) return;

            if (working == true)
            {
                Boolean remove = true;
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    if (item.SubItems[4].Text != "Queued")
                    {
                        remove = false;
                        break;
                    }
                }

                if (e.KeyCode == Keys.Delete && remove == true)
                {
                    ctdel.PerformClick();
                }
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                ctdel.PerformClick();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listView1.Sorting = SortOrder.Ascending;
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem n_a in listView1.Items)
            {
                if (n_a.BackColor == Color.LightGoldenrodYellow)
                {
                    n_a.Remove();
                }
            }
            lbl_items.Text = listView1.Items.Count + " fichero(s)";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            cti4.PerformClick();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView myListView = (ListView)sender;
            if (e.Column == 0 || e.Column == 1 || e.Column == 2 || e.Column == 4)
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvwColumnSorter_Full.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter_Full.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter_Full.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter_Full.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter_Full.SortColumn = e.Column;
                    lvwColumnSorter_Full.Order = SortOrder.Ascending;
                }
                myListView.Sort();
            }
            if (e.Column == 3)
            {
                lvwColumnSorter_Full.SortColumn = 3;
                if (size_sorted == false)
                {
                    size_sorted = true;
                    lvwColumnSorter_Full.Order = SortOrder.Descending;
                }
                else
                {
                    size_sorted = false;
                    lvwColumnSorter_Full.Order = SortOrder.Ascending;
                }

                if (listView1.Items.Count > 6000) this.Cursor = Cursors.WaitCursor;
                listView1.BeginUpdate();

                foreach (ListViewItem item in listView1.Items)
                {
                    if (File.Exists(item.Text))
                    {
                        FileInfo fi = new FileInfo(item.Text);
                        item.SubItems[3].Text = fi.Length.ToString("D13");
                    }
                    else
                    {
                        item.SubItems[3].Text = "0000000000000";
                    }
                }
                listView1.Sort();

                foreach (ListViewItem item in listView1.Items)
                {
                    //Format size view
                    var bytes = long.Parse(item.SubItems[3].Text);

                    var kilobytes = (double)bytes / 1024;
                    var megabytes = kilobytes / 1024;
                    var gigabytes = megabytes / 1024;

                    String size = "";

                    String separator = System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;

                    if (bytes > 1000000000)
                    {
                        String gigas = gigabytes.ToString();
                        if (gigas.Length >= 5)
                        {
                            gigas = gigas.Substring(0, gigas.LastIndexOf(separator) + 3);
                            size = (gigas + " GB");
                        }
                        else
                        {
                            size = (gigas + " GB");
                        }
                    }

                    if (bytes >= 1048576 && bytes <= 1000000000)
                    {

                        String megas = megabytes.ToString();
                        if (megas.Length > 5)
                        {
                            megas = megas.Substring(0, megas.LastIndexOf(separator) + 2);
                            size = (megas + " MB");
                        }
                        else
                        {
                            size = (megas + " MB");
                        }
                    }

                    if (bytes >= 1024 && bytes < 1048576)

                    {
                        String kbs = kilobytes.ToString();
                        if (kbs.Length >= 5)
                        {
                            kbs = kbs.Substring(0, kbs.LastIndexOf(separator));
                            size = (kbs + " KB");
                        }
                        else
                        {
                            size = (kbs + " KB");
                        }
                    }
                    if (bytes > -1 && bytes < 1024)
                    {
                        String bits = bytes.ToString();
                        size = (bits + " Bytes");
                    }
                    item.SubItems[3].Text = size;

                    //End Format size view
                }
                this.Cursor = Cursors.Arrow;
                listView1.EndUpdate();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Pg1.Focus();

            if (tabControl1.SelectedIndex == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                //Backup listview1
                ListViewItem[] itemsToAdd = new ListViewItem[listView1.Items.Count];
                ListView lv_clean = new ListView();
                listView1.BeginUpdate();
                lv_clean.Items.AddRange((from ListViewItem item in listView1.Items select (ListViewItem)item.Clone()).ToArray());

                foreach (ListViewItem n_a in lv_clean.Items)
                {
                    if (n_a.BackColor == Color.LightGoldenrodYellow || n_a.SubItems[2].Text == "N/A" || n_a.SubItems[2].Text == "0:00:00" || n_a.SubItems[2].Text == "00:00:00")
                    {
                        n_a.Remove();
                    }
                }
                listView1.Items.Clear();
                listView1.Items.AddRange((from ListViewItem item in lv_clean.Items select (ListViewItem)item.Clone()).ToArray());
                lbl_items.Text = listView1.Items.Count + " fichero(s)";
                calc_total_dur();
                calc_list_size();
                listView1.EndUpdate();
            }
            this.Cursor = Cursors.Arrow;
        }

        private void CopyAction(object sender, EventArgs e)
        {
            if (Rtxt.SelectedText != String.Empty) Clipboard.SetText(Rtxt.SelectedText);
        }

        private void Disable_Controls()
        {
            if (btn_save_path.Enabled == true) save_path_state = true;
            else save_path_state = false;                        

            foreach (Control p in this.Controls)
            {
                if (p.Name != tabControl1.Name && p.Name != groupBox10.Name)
                {
                    this.InvokeEx(f => p.Enabled = false);
                }
                this.InvokeEx(f => f.btn_pause.Enabled = true);
            }            

            this.InvokeEx(f => f.btn_pause.Enabled = true);

            this.InvokeEx(f => f.listView1.Enabled = true);
            this.InvokeEx(f => f.txt_remain.Enabled = true);
            this.InvokeEx(f => f.label11.Enabled = true);
            this.InvokeEx(f => f.txt_pg1_prog.Enabled = true);
            this.InvokeEx(f => f.Pg1.Enabled = true);
            //this.InvokeEx(f => f.pg_current.Enabled = true);
            total_time = false;
            this.InvokeEx(f => f.LB_Wait.Enabled = true);
            this.InvokeEx(f => f.pg_adding.Enabled = true);
            this.InvokeEx(f => f.txt_adding_p.Enabled = true);
            this.InvokeEx(f => f.item_up.Enabled = true);
            this.InvokeEx(f => f.item_down.Enabled = true);
            this.InvokeEx(f => f.btn_rel_path.Enabled = false);
            this.InvokeEx(f => f.btn_reset_path.Enabled = false);
            this.InvokeEx(f => f.btn_save_path.Enabled = false);
            this.InvokeEx(f => f.btn_browse.Enabled = false);

            if (runnin_n_presets == true)
            {
                this.InvokeEx(f => f.btn_add_files.Enabled = false);
                this.InvokeEx(f => f.btn_add_folders.Enabled = false);
                this.InvokeEx(f => f.chk_subfolders.Enabled = false);
            }
        }

        private void Enable_Controls()
        {
            foreach (Control p in this.Controls)
            {
                this.InvokeEx(f => p.Enabled = true);
            }            

            if (save_path_state == false)
            {
                this.InvokeEx(f => f.btn_save_path.Enabled = false);
            }

            if (save_preset_state == false)
            {
               
            }
            

            this.InvokeEx(f => f.btn_rel_path.Enabled = true);
            this.InvokeEx(f => f.btn_reset_path.Enabled = true);
            this.InvokeEx(f => f.btn_save_path.Enabled = true);
            this.InvokeEx(f => f.btn_browse.Enabled = true);

            this.InvokeEx(f => f.txt_remain.Text = "");


            timer_tasks.Stop();
            TimeSpan t = TimeSpan.FromSeconds(time_n_tasks);
            String tx_elapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                t.Hours,
                t.Minutes,
                t.Seconds);
            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: 00:00:00");
            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: 00:00:00");

            this.InvokeEx(f => f.pg_adding.Visible = false);
            this.InvokeEx(f => f.btn_abort_all.Enabled = true);
            this.InvokeEx(f => f.btn_abort_all.Text = "");
            if (chk_vid_cod.CheckState == CheckState.Checked) this.InvokeEx(f => f.cb_hw_enc.Enabled = true);
            else this.InvokeEx(f => f.cb_hw_enc.Enabled = false);

        }

        public void Create_Tooltips()
        {
            chkpaB0z.AutoPopDelay = 9000;
            chkpaB0z.InitialDelay = 750;
            chkpaB0z.ReshowDelay = 500;
            chkpaB0z.ShowAlways = true;
            if (language == "es") chkpaB0z.SetToolTip(this.btn_logs, "Ver log de la última sesión.");
            if (language == "en") chkpaB0z.SetToolTip(this.btn_logs, "Display last session log");

            chkpaA9z.AutoPopDelay = 9000;
            chkpaA9z.InitialDelay = 750;
            chkpaA9z.ReshowDelay = 500;
            chkpaA9z.ShowAlways = true;
            if (language == "es") chkpaA9z.SetToolTip(this.btn_one_one, "Añadir cabeceras individualmente a cada video de la lista");
            if (language == "en") chkpaA9z.SetToolTip(this.btn_one_one, "Concatenate every single video file with selected header/credits videos");

            chkpaA8z.AutoPopDelay = 9000;
            chkpaA8z.InitialDelay = 750;
            chkpaA8z.ReshowDelay = 500;
            chkpaA8z.ShowAlways = true;
            if (language == "es") chkpaA8z.SetToolTip(this.chk_compat, "Marque esta opción en caso de problemas al reproducir los vídeos generados");
            if (language == "en") chkpaA8z.SetToolTip(this.chk_compat, "Check this in case of issues playing output videos");

            chkpaA7z.AutoPopDelay = 9000;
            chkpaA7z.InitialDelay = 750;
            chkpaA7z.ReshowDelay = 500;
            chkpaA7z.ShowAlways = true;
            if (language == "es") chkpaA7z.SetToolTip(this.btn_silence, "Detectar silencios de más de 3 segundos");
            if (language == "en") chkpaA7z.SetToolTip(this.btn_silence, "Detect silence gaps longer than 3 seconds");


            chkpaA7.AutoPopDelay = 9000;
            chkpaA7.InitialDelay = 750;
            chkpaA7.ReshowDelay = 500;
            chkpaA7.ShowAlways = true;
            if (language == "es") chkpaA7.SetToolTip(this.chk_preset, "Codificar más rápido (vídeo de más tamaño)");
            if (language == "en") chkpaA7.SetToolTip(this.chk_preset, "Fast encoding (bigger video size)");

            toolTipaA7.AutoPopDelay = 9000;
            toolTipaA7.InitialDelay = 750;
            toolTipaA7.ReshowDelay = 500;
            toolTipaA7.ShowAlways = true;
            if (language == "es") toolTipaA7.SetToolTip(this.btn_abort_all, "Detener codificación");
            if (language == "en") toolTipaA7.SetToolTip(this.btn_abort_all, "Abort encoding");


            toolTip02.AutoPopDelay = 5000;
            toolTip02.InitialDelay = 750;
            toolTip02.ReshowDelay = 500;
            toolTip02.ShowAlways = true;
            if (language == "es") toolTip02.SetToolTip(this.item_up, "Mover elemento hacia arriba");
            if (language == "en") toolTip02.SetToolTip(this.item_up, "Move queued item up");

            toolTip033.AutoPopDelay = 5000;
            toolTip033.InitialDelay = 750;
            toolTip033.ReshowDelay = 500;
            toolTip033.ShowAlways = true;
            if (language == "es") toolTip033.SetToolTip(this.item_down, "Mover elemento hacia abajo");
            if (language == "en") toolTip033.SetToolTip(this.item_down, "Move queued item down");

            toolTip04.AutoPopDelay = 5000;
            toolTip04.InitialDelay = 750;
            toolTip04.ReshowDelay = 500;
            toolTip04.ShowAlways = true;
            if (language == "es") toolTip04.SetToolTip(this.requeue, "Resetear status de los elementos");
            if (language == "en") toolTip04.SetToolTip(this.requeue, "Reset files status");


            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 750;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            if (language == "en") toolTip1.SetToolTip(this.listView1, "Drag and drop files or folders here");
            if (language == "es") toolTip1.SetToolTip(this.listView1, "Arrastre y suelte sus ficheros aquí");

            toolTip4.AutoPopDelay = 5000;
            toolTip4.InitialDelay = 750;
            toolTip4.ReshowDelay = 500;
            toolTip4.ShowAlways = true;
            if (language == "es") toolTip4.SetToolTip(this.button12, "Eliminar elementos no válidos de la lista");
            if (language == "en") toolTip4.SetToolTip(this.button12, "Remove invalid a/v files");

            toolTip6.AutoPopDelay = 5000;
            toolTip6.InitialDelay = 500;
            toolTip6.ReshowDelay = 500;
            toolTip6.ShowAlways = true;
            if (language == "es") toolTip6.SetToolTip(this.txt_path, "Reinicializar a ruta de salida por defecto");
            if (language == "en") toolTip6.SetToolTip(this.txt_path, "Reset to default output directory");

            toolTip6_2.AutoPopDelay = 5000;
            toolTip6_2.InitialDelay = 500;
            toolTip6_2.ReshowDelay = 500;
            toolTip6_2.ShowAlways = true;
            if (language == "es") toolTip6_2.SetToolTip(this.btn_reset_path, "Reinicializar a ruta de salida por defecto");
            if (language == "en") toolTip6_2.SetToolTip(this.btn_reset_path, "Reset to default output directory");

            toolTip10.AutoPopDelay = 5000;
            toolTip10.InitialDelay = 750;
            toolTip10.ReshowDelay = 500;
            toolTip10.ShowAlways = true;
            if (language == "en") toolTip10.SetToolTip(this.btn_concat_2, "Concatenate videos re-encoding source files");
            if (language == "es") toolTip10.SetToolTip(this.btn_concat_2, "Concatenar vídeos recodificando los ficheros");

            toolTip10_2.AutoPopDelay = 5000;
            toolTip10_2.InitialDelay = 750;
            toolTip10_2.ReshowDelay = 500;
            toolTip10_2.ShowAlways = true;
            if (language == "en") toolTip10.SetToolTip(this.btn_concat, "Concatenate videos without re-encoding source files");
            if (language == "es") toolTip10.SetToolTip(this.btn_concat, "Concatenar vídeos sin recodificar los ficheros");

            toolTip15.AutoPopDelay = 1500;
            toolTip15.InitialDelay = 750;
            toolTip15.ReshowDelay = 500;
            toolTip15.ShowAlways = true;
            if (language == "en") toolTip15.SetToolTip(this.label13, "Double-click to set default output folder");
            if (language == "en") toolTip15.SetToolTip(this.label13, "Doble click para usar directorio de salida por defecto");


            toolTip30.AutoPopDelay = 3500;
            toolTip30.InitialDelay = 750;
            toolTip30.ReshowDelay = 500;
            toolTip30.ShowAlways = true;
            if (language == "es") toolTip30.SetToolTip(this.chk_subfolders, "Incluir ficheros en subdirectorios");
            if (language == "en") toolTip30.SetToolTip(this.chk_subfolders, "Include files in subfolders");

            toolTip31.AutoPopDelay = 3500;
            toolTip31.InitialDelay = 750;
            toolTip31.ReshowDelay = 500;
            toolTip31.ShowAlways = true;
            if (language == "es") toolTip31.SetToolTip(this.btn_add_folders, "Seleccionar ruta");
            if (language == "en") toolTip31.SetToolTip(this.btn_add_folders, "Select path");

            toolTip32.AutoPopDelay = 3500;
            toolTip32.InitialDelay = 750;
            toolTip32.ReshowDelay = 500;
            toolTip32.ShowAlways = true;
            if (language == "es") toolTip32.SetToolTip(this.btn_refresh, "Actualizar lista");
            if (language == "en") toolTip32.SetToolTip(this.btn_refresh, "Refresh list");

            toolTip40.AutoPopDelay = 3500;
            toolTip40.InitialDelay = 750;
            toolTip40.ReshowDelay = 500;
            toolTip40.ShowAlways = true;
            if (language == "en") toolTip40.SetToolTip(this.btn_save_path, "Save this path as default");
            if (language == "es") toolTip40.SetToolTip(this.btn_save_path, "Guardar como ruta por defecto");

            toolTip42.AutoPopDelay = 3500;
            toolTip42.InitialDelay = 750;
            toolTip42.ReshowDelay = 500;
            toolTip42.ShowAlways = true;
            if (language == "es") toolTip42.SetToolTip(this.btn_pause, "Pausar codificación");
            if (language == "en") toolTip42.SetToolTip(this.btn_pause, "Pause encoding");

            toolTip17.AutoPopDelay = 3500;
            toolTip17.InitialDelay = 750;
            toolTip17.ReshowDelay = 500;
            toolTip17.ShowAlways = true;
            if (language == "en") toolTip17.SetToolTip(this.btn_help, "Open quick guide");
            if (language == "es") toolTip17.SetToolTip(this.btn_help, "Mostrar guía rápida");
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = folderBrowserDialog1.SelectedPath;               
                btn_save_path.Enabled = true;
                if (listView1.Items.Count == 0) return;

                try
                {
                    File.WriteAllText(folderBrowserDialog1.SelectedPath + "\\" + "FFBatch_test.txt", "FFBatch_test");
                    System.Threading.Thread.Sleep(10);
                    File.Delete(folderBrowserDialog1.SelectedPath + "\\" + "FFBatch_test.txt");
                }
                catch (System.Exception excpt)
                {
                    MessageBox.Show("Access error. Path may not be writable: " + Environment.NewLine + excpt.Message, "Access denied to folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.InvokeEx(f => this.Cursor = Cursors.Arrow);
                    return;
                }
            }
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            txt_path.Text = "..\\Unidos";
            txt_path.BackColor = this.BackColor;

            btn_save_path.Enabled = true;
        }
        
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            String destino_test = Path.GetTempPath() + "\\" + "FFBatch_test";

            if (Directory.Exists(destino_test) && Directory.GetFiles(destino_test).Length > 0)
            {
                foreach (String file in Directory.GetFiles(destino_test))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                    }
                }
            }

            if (Directory.Exists(destino_test))
            {
                if (Directory.GetFiles(destino_test).Length == 0)
                {
                    System.IO.Directory.Delete(destino_test);
                }
            }

            //End clean ffbatch_test

            //Clean file blank lines

            String path3 = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.ini";
            if (File.Exists(path3))
            {
                String path_temp = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch_temp.txt";

                int i2 = 0;

                foreach (string line in File.ReadLines(path3))
                {
                    i2 = i2 + 1;

                    if (line != String.Empty)
                    {
                        if (i2 < File.ReadAllLines(path3).Count())
                        {
                            File.AppendAllText(path_temp, line + Environment.NewLine);
                        }
                        else
                        {
                            File.AppendAllText(path_temp, line);
                        }
                    }
                }
                File.Delete(path3);
                File.Copy(System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch_temp.txt", path3);
                File.Delete(System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch_temp.txt");
            }

            if (working == true)
            {
                if (paused == false)
                {
                    MessageBox.Show("Queue processing is in progress. Please abort queue before exiting application", "Encoding in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;

                }
                else
                {
                    DialogResult a = MessageBox.Show("Queue processing is in pause mode. Do you want to abort queue and exit application?", "Abort paused enconding", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (a == DialogResult.No || a == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {

                        btn_pause.PerformClick();
                        this.Cursor = Cursors.WaitCursor;
                        Thread.Sleep(750);
                        //Abort
                        if (recording_scr == true)
                        {
                            Enable_Controls();
                            working = false;
                            recording_scr = false;

                            StreamWriter write_q = process_glob.StandardInput;
                            write_q.Write("q");
                            this.Cursor = Cursors.Arrow;
                            return;
                        }

                        if (multi_running == true)
                        {
                            working = false;
                            multi_running = false;
                            aborted = true;
                            cancelados_paralelos = true;

                            foreach (ListViewItem item in listView1.Items)
                            {
                                if (item.SubItems[4].Text != "Success" && item.SubItems[4].Text != "Ready" && item.SubItems[4].Text != "Queued")
                                {
                                    item.SubItems[4].Text = "Aborting";
                                }
                            }

                            foreach (Process proc in procs.Values)
                            {
                                cancelados_paralelos = true;
                                if (proc.StartInfo.Arguments != String.Empty)

                                {
                                    try
                                    {
                                        StreamWriter write_q = proc.StandardInput;
                                        write_q.Write("q");
                                    }
                                    catch (Exception exc)
                                    {
                                        MessageBox.Show("Error: " + exc.Message + " Some processes already finished or could not be aborted. Press Ok to retry.", "Queue abortion incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            return;
                        }

                        if (process_glob.StartInfo.Arguments != String.Empty)
                        {
                            try
                            {
                                process_glob.Kill();
                                working = false;
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            int num1 = 0;
                            Process[] localByName1 = Process.GetProcessesByName("ffmpeg");
                            num1 = localByName1.Length;
                            if (num1 == 1 && localByName1[0].Id == ff_ver_proc) return;

                            if (num1 > 0)
                            {
                                this.Cursor = Cursors.Arrow;
                                MessageBox.Show("FFmpeg processes still running were detected.", "FFmpeg processes warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        cancel_queue = true;
                        cancelados_paralelos = true;

                        if (process_glob.StartInfo.Arguments != String.Empty)
                        {
                            StreamWriter write_q = process_glob.StandardInput;
                            write_q.Write("q");
                            this.Cursor = Cursors.Arrow;
                            return;
                        }
                        //End abort
                    }
                }
                this.Cursor = Cursors.Arrow;
            }

            if (notifyIcon1 != null)
            {
                notifyIcon1.Visible = false;
            }

            int num = 0;
            Process[] localByName = Process.GetProcessesByName("ffmpeg");
            num = localByName.Length;
            if (num == 1 && localByName[0].Id == ff_ver_proc) return;

            if (num > 0)
            {
                MessageBox.Show("FFmpeg processes still running were detected.", "FFmpeg processes warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            notifyIcon1.Dispose();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
            this.BringToFront();
            this.Focus();
            notifyIcon1.Visible = false;
        }

        private void label13_DoubleClick(object sender, EventArgs e)
        {
            txt_path.Text = "..\\Unidos";
            txt_path.BackColor = Control.DefaultBackColor;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            txt_path.Text = "..\\Unidos";
            txt_path.BackColor = Control.DefaultBackColor;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {

                lbl_size.Visible = true;
                lbl_dur_list.Visible = true;
                lbl_items.Visible = true;                                          

                button12.Visible = true;
                label13.Visible = true;
                txt_path.Visible = true;
                btn_browse.Visible = true;                
                btn_pause.Visible = true;               
               
                return;
            }
        }        

        private void openFileDialog2_FileOk_1(object sender, CancelEventArgs e)
        {

        }
                
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
            this.BringToFront();
            this.Focus();
            notifyIcon1.Visible = false;
        }

        
        private void timer_tasks_Tick(object sender, EventArgs e)
        {
            if (paused == true) return;

            time_n_tasks = time_n_tasks + 1;

            TimeSpan t9 = TimeSpan.FromSeconds(time_n_tasks);
            String tx_elapsed1 = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                t9.Hours,
                t9.Minutes,
                t9.Seconds);
            if (language == "es") lbl_elapsed.Text = "Tiempo actual: " + tx_elapsed1;
            if (language == "en") lbl_elapsed.Text = "Elapsed time: " + tx_elapsed1;

            if (total_time == true)
            {
                TimeSpan t = TimeSpan.FromSeconds(time_n_tasks);
                String tx_elapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                    t.Hours,
                    t.Minutes,
                    t.Seconds);
                if (language == "es") txt_remain.Text = "Tiempo actual: " + tx_elapsed;
                if (language == "en") txt_remain.Text = "Elapsed time: " + tx_elapsed;
            }
        }

        private void calc_list_size()

        {
            tot_size = 0;

            foreach (ListViewItem file in listView1.Items)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.Text);
                if (File.Exists(file.Text))
                    tot_size = tot_size + fileInfo.Length;
            }

            var bytes = tot_size;
            var kilobytes = (double)bytes / 1024;
            var megabytes = kilobytes / 1024;
            var gigabytes = megabytes / 1024;

            //Format size view

            //Get separator
            String separator = ".";

            if (bytes > 1000000000)
            {
                if (gigabytes.ToString().Contains("."))
                {
                    separator = ".";
                }
                else
                {
                    separator = ",";
                }

                String gigas = gigabytes.ToString();
                if (gigas.Length >= 5)
                {
                    gigas = gigas.Substring(0, gigas.LastIndexOf(separator) + 3);
                    this.InvokeEx(f => f.lbl_size.Text = gigas + " GB");
                }
                else
                {
                    this.InvokeEx(f => f.lbl_size.Text = gigas + " GB");
                }
            }

            if (bytes >= 1048576 && bytes < 1000000000)
            {
                if (megabytes.ToString().Contains("."))
                {
                    separator = ".";
                }
                else
                {
                    separator = ",";
                }
                String megas = megabytes.ToString();
                if (megas.Length > 5)
                {
                    megas = megas.Substring(0, megas.LastIndexOf(separator));
                    this.InvokeEx(f => f.lbl_size.Text = megas + " MB");
                }
                else
                {
                    this.InvokeEx(f => f.lbl_size.Text = megas + " MB");
                }
            }

            if (bytes >= 1024 && bytes < 1048576)
            {
                if (kilobytes.ToString().Contains("."))
                {
                    separator = ".";
                }
                else
                {
                    separator = ",";
                }
                String kbs = kilobytes.ToString();
                if (kbs.Length >= 5)
                {
                    kbs = kbs.Substring(0, kbs.LastIndexOf(separator));
                    this.InvokeEx(f => f.lbl_size.Text = kbs + " KB");
                }
                else
                {
                    this.InvokeEx(f => f.lbl_size.Text = kbs + " KB");
                }
            }
            if (bytes > -1 && bytes < 1024)
            {
                String bits = bytes.ToString();
                this.InvokeEx(f => f.lbl_size.Text = bits + " Bytes");
            }

            //End Format size view
        }

        private void calc_list_dur()

        {
            //Show total duration
            Double Total_dur = 0;


            foreach (ListViewItem item in listView1.Items)
                if (item.SubItems[2].Text != "0:00:00" && item.SubItems[2].Text != "N/A" && item.SubItems[2].Text != "Pending" && item.SubItems[2].Text != "00:00:00")
                {
                    Total_dur = Total_dur + TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds;
                }


            TimeSpan t = TimeSpan.FromSeconds(Total_dur);
            String dur = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                     (int)t.TotalHours,
                     t.Minutes,
                     t.Seconds,
                     t.Milliseconds);
            lbl_dur_list.Text = dur.Substring(0, 11);

            //End show total duration
        }

        
        private void boton_show_rec_Click(object sender, EventArgs e)
        {
            Process.Start("control", "mmsys.cpl,,1");
        }

        private void boton_refresh_audio_Click(object sender, EventArgs e)
        {
            Process consola = new Process();

            consola.StartInfo.FileName = "ffmpeg.exe";
            consola.StartInfo.Arguments = " -list_devices true -f dshow -i dummy";

            consola.StartInfo.RedirectStandardOutput = true;
            consola.StartInfo.RedirectStandardError = true;
            consola.StartInfo.UseShellExecute = false;
            consola.StartInfo.CreateNoWindow = true;
            consola.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            consola.EnableRaisingEvents = true;

            consola.Start();

            CB1_o.Items.Clear();
            CB1_o.Items.Add("No audio");
            String out_ff = String.Empty;
            Boolean start_audio_sources = false;
            while (!consola.StandardError.EndOfStream)
            {
                out_ff = consola.StandardError.ReadLine();
                if (out_ff.Contains("DirectShow audio devices"))
                {
                    start_audio_sources = true;
                }

                if (start_audio_sources == true)
                {
                    if (out_ff.Substring(out_ff.Length - 2, 2) != "}" + "\u0022" && out_ff.Contains("DirectShow audio devices") == false && out_ff.Contains("Alternative name") == false && out_ff.Contains("dummy") == false)
                    {
                        //if (out_ff.Contains("Ã³")) out_ff = out_ff.Replace("Ã³", "ó");
                        int trim1 = out_ff.IndexOf("\u0022") + "\u0022".Length;
                        int trim2 = out_ff.LastIndexOf("\u0022");
                        if (trim2 - trim1 > 0) this.InvokeEx(f => CB1_o.Items.Add(out_ff.Substring(trim1, trim2 - trim1)));
                    }
                }
                //}

                //if (out_ff.Substring(out_ff.Length-1,1) == "\u0022")
                //{
                //this.InvokeEx(f => CB1_o.Items.Add(consola.StandardError.ReadLine()));
            }
            CB1_o.Refresh();
            CB1_o.SelectedIndex = 0;
            if (CB1_o.Items.Count > 1)
            {
                CB1_o.Enabled = true;
                CB1_o.DroppedDown = true;
            }
            else
            {
                CB1_o.Enabled = false;
            }

            consola.StartInfo.Arguments = String.Empty;
            this.Cursor = Cursors.Arrow;
        }

        private void boton_cancel_path_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void boton_cancel_audio_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }


        private void ct4_conv_Click(object sender, EventArgs e)
        {

        }

        private void refresh_full()

        {
            List<string> files2 = new List<string>();
            int num_drop = 0;


            foreach (ListViewItem item in listView1.Items)
            {
                if (File.Exists(item.Text))
                {
                    files2.Add(item.Text);
                }
            }


            num_drop = files2.Count();

            files_to_add = files2;
            listView1.Items.Clear();

            canceled_file_adding = false;

            btn_cancel_add.Enabled = true;
            btn_cancel_add.Visible = true;
            btn_cancel_add.Refresh();

            BG_Files.RunWorkerAsync();
        }


        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Pg1.Focus();

            if (listView1.Items.Count == 0)
            {
                return;
            }

            refresh_full();

            calc_list_dur();
            lbl_items.Text = listView1.Items.Count + " fichero(s)";

            if (tabControl1.SelectedIndex == 0)
            {                
                button12.Visible = true;
                label13.Visible = true;
                txt_path.Visible = true;
                btn_browse.Visible = true;               
                return;
            }
        }        

        private void chk_subfolders_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_subfolders.Checked == true)
            {
                add_subfs = true;
            }
            else
            {
                add_subfs = false;
            }

            Boolean prev_state = false;
            if (chk_subfolders.CheckState == CheckState.Checked) prev_state = false;
            if (chk_subfolders.CheckState == CheckState.Unchecked) prev_state = true;

            String path = String.Empty;

            path = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.ini";

            int linea = 0;

            foreach (string line in File.ReadLines(path))
            {
                linea = linea + 1;

                if (linea == 7)
                {
                    if (line == "subf_yes")
                    {
                        
                    }

                    if (line == "subf_no")
                    {
                        if (prev_state == true)
                        {
                        
                        }
                        else
                        {
                        
                        }
                    }
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
           
        }       

        private void btn_cancel_add_Click(object sender, EventArgs e)
        {
            canceled_add = true;
            canceled_file_adding = true;
            btn_cancel_add.Visible = false;
            dur_ok = false;            

            if (working == true)
            {
                wc.CancelAsync();
                cancel_cache = true;
            }
        }

        private void BG_Dur_DoWork(object sender, DoWorkEventArgs e)
        {
            dur_ok = false;
            canceled_add = false;
            this.InvokeEx(f => f.listView1.BeginUpdate());
            this.InvokeEx(f => f.Disable_Controls());
            this.InvokeEx(f => f.btn_abort_all.Enabled = false);
            this.InvokeEx(f => f.btn_cancel_add.Enabled = true);
            this.InvokeEx(f => f.btn_cancel_add.Visible = true);
            this.InvokeEx(f => f.btn_cancel_add.Refresh());
            this.InvokeEx(f => f.LB_Wait.Visible = true);
            this.InvokeEx(f => f.LB_Wait.Text = "Analyzing...");
            this.InvokeEx(f => f.LB_Wait.Refresh());
            this.InvokeEx(f => f.pg_adding.Visible = true);
            this.InvokeEx(f => f.pg_adding.Value = 0);
            this.InvokeEx(f => f.txt_adding_p.Visible = true);
            this.InvokeEx(f => f.txt_adding_p.Refresh());
            this.InvokeEx(f => f.pg_adding.Maximum = list_pending_dur.Items.Count);
            int invalids = 0;

            procs.Clear();

            for (int ii = 0; ii < list_pending_dur.Items.Count; ii++)
            {
                procs.Add("proc_urls_" + ii.ToString(), new Process());
            }

            ParallelOptions par_op = new ParallelOptions();
            CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
            par_op.CancellationToken = cts.Token;
            par_op.MaxDegreeOfParallelism = 2;
            fatal_parallel = false;

            IEnumerable<int> items_lv = Enumerable.Range(0, list_pending_dur.Items.Count);

            ParallelLoopResult result = new ParallelLoopResult();
            try
            {
                result = Parallel.ForEach(items_lv.AsParallel().AsOrdered(), par_op, (i) =>
                {
                    Task
                        .Factory
                        .StartNew(() =>
                        {
                            this.InvokeEx(f => f.pg_adding.Value = pg_adding.Value + 1);
                            this.InvokeEx(f => f.txt_adding_p.Text = (pg_adding.Value * 100 / list_pending_dur.Items.Count + "%"));
                            this.InvokeEx(f => f.txt_adding_p.Refresh());
                            var tmp = procs["proc_urls_" + i.ToString()];

                            if (canceled_add == false)
                            {
                                if (list_pending_dur.Items[i].SubItems[3].Text == "Pendiente")
                                {
                                    tmp.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "MediaInfo.exe");
                                    String ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration/String3%" + '\u0022';
                                    tmp.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + list_pending_dur.Items[i].SubItems[1].Text + "\\" + list_pending_dur.Items[i].Text + '\u0022';

                                    tmp.StartInfo.RedirectStandardOutput = true;
                                    tmp.StartInfo.UseShellExecute = false;
                                    tmp.StartInfo.CreateNoWindow = true;
                                    tmp.EnableRaisingEvents = true;
                                    tmp.Start();

                                    String duracion = tmp.StandardOutput.ReadToEnd();
                                    tmp.WaitForExit();

                                    if (duracion != null)
                                    {
                                        TimeSpan time = new TimeSpan();
                                        if (TimeSpan.TryParse(duracion, out time))
                                        {
                                            this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = duracion.Substring(0, 12));

                                            if (duracion.Length >= 12)
                                            {
                                                if (duracion.Substring(0, 11) == "0:00:00.000" || duracion.Substring(0, 12) == "00:00:00.000")
                                                {
                                                    invalids = invalids + 1;
                                                    this.InvokeEx(f => f.listView1.Items[i].BackColor = Color.LightGoldenrodYellow);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = "N/A");
                                            invalids = invalids + 1;
                                            this.InvokeEx(f => f.listView1.Items[i].BackColor = Color.LightGoldenrodYellow);
                                        }
                                    }
                                    else
                                    {
                                        this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = "N/A");
                                        invalids = invalids + 1;
                                        this.InvokeEx(f => f.listView1.Items[i].BackColor = Color.LightGoldenrodYellow);
                                    }
                                }
                            }
                            else { cts.Cancel(); }
                        }).Wait();
                    i++;
                });
            }
            catch (Exception exc)
            {
                fatal_parallel_msg = exc.Message;
                fatal_parallel = true;
            }

            if (result.IsCompleted == true) fatal_parallel = false;
            else if (cts.IsCancellationRequested == false) fatal_parallel = true;
            else fatal_parallel = false;
            //End parallel
            if (invalids > 0)
            {

            }

            dur_ok = !canceled_add;
        }

        private void BG_Dur_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_items.Text = listView1.Items.Count + " " + "Ficheros";
            LB_Wait.Text = "";
            txt_adding_p.Visible = false;
            listView1.EndUpdate();
            Enable_Controls();            
            btn_pause.Enabled = true;
            btn_cancel_add.Visible = false;
            txt_adding_p.Text = "";
            txt_adding_p.Visible = false;
            lbl_items.Visible = true;
            lbl_dur_list.Visible = true;
            lbl_size.Visible = true;
            pg_adding.Visible = false;
            LB_Wait.Visible = false;
            tabControl1.Enabled = true;

            tried_params.Clear();
            btn_cancel_add.Visible = false;
            if (canceled_add == true)
            {
                //MessageBox.Show(FFBatch.Properties.Strings.dur_comp, FFBatch.Properties.Strings.pars_inc, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
            else
            {
                //if (tabControl1.SelectedIndex == 0)
                //{
                //    if (was_started.Text == btn_seq.Text)
                //    {
                //        btn_seq.PerformClick();
                //    }
                //    else if (was_started.Text == btn_multiple_presets.Text)
                //    {
                //        start_multiple();
                //    }
                //    else if (was_started.Text == btn_multi_m.Text)
                //    {
                //        btn_multi_m.PerformClick();
                //    }
                //    else if (was_started.Text == btn_concat.Text)
                //    {
                //        btn_concat.PerformClick();
                //    }
                //    else if (was_started.Text == btn_trim.Text)
                //    {
                //        btn_trim.PerformClick();
                //    }
                //}
                //else if (tabControl1.SelectedIndex == 1)
                //{
                //    btn_mux.PerformClick();
                //}
                //else if (tabControl1.SelectedIndex == 2)
                //{
                //    btn_sub_mux.PerformClick();
                //}
            }
        }

        private void BG_Files_DoWork(object sender, DoWorkEventArgs e)
        {
            //Adding files/folders thread           

            this.InvokeEx(f => f.listView1.SmallImageList = imageList2);

            Disable_Controls();            
            this.InvokeEx(f => f.btn_pause.Enabled = false);
            this.InvokeEx(f => f.tabControl1.Enabled = false);
            this.InvokeEx(f => f.LB_Wait.Visible = true);
            this.InvokeEx(f => f.btn_cancel_add.Enabled = true);

            Type ts = Type.GetTypeFromProgID("Shell.Application");
            dynamic shell = Activator.CreateInstance(ts);

            //Es carpeta

            int i = 0;
            invalids = 0;
            pending_dur = 0;

            this.InvokeEx(f => f.pg_adding.Value = 0);
            this.InvokeEx(f => f.pg_adding.Maximum = files_to_add.Count);
            this.InvokeEx(f => f.pg_adding.Visible = true);
            this.InvokeEx(f => f.txt_adding_p.Visible = true);
            this.InvokeEx(f => f.txt_adding_p.Refresh());
            this.InvokeEx(f => f.lbl_items.Visible = false);
            this.InvokeEx(f => f.lbl_items.Refresh());
            this.InvokeEx(f => f.lbl_dur_list.Visible = false);
            this.InvokeEx(f => f.lbl_dur_list.Refresh());
            this.InvokeEx(f => f.lbl_size.Visible = false);
            this.InvokeEx(f => f.lbl_size.Refresh());

            this.InvokeEx(f => f.LB_Wait.Text = "Añadiendo " + files_to_add.Count + " ficheros");
            this.InvokeEx(f => f.LB_Wait.Refresh());

            this.InvokeEx(f => f.listView1.BeginUpdate());

            ListViewItem[] itemsToAdd = new ListViewItem[files_to_add.Count];
            String[] ext_nodur = new string[] { ".jpg", ".gif", ".bmp", ".png", ".tif", ".psd", ".txt", ".ini", ".zip", ".htm", ".html", ".css", ".js", ".rar", ".doc", ".docx", ".xls", ".xlsx", ".dll", ".exe", ".ico", ".pdf", ".log", ".cat", "mui", ".xml", String.Empty };

            for (int n = 0; n < files_to_add.Count; n++)
            {
                if (canceled_file_adding == false)
                {
                    i = i + 1;

                    this.InvokeEx(f => f.pg_adding.Value = i);
                    this.InvokeEx(f => f.txt_adding_p.Text = (i * 100 / files_to_add.Count).ToString() + "%");

                    //ListViewItem elemento = new ListViewItem(file2, 1);

                    Icon iconForFile = SystemIcons.WinLogo;

                    if (!files_to_add[n].Contains("\\\\"))
                    {
                        if (!imageList2.Images.ContainsKey(System.IO.Path.GetExtension(files_to_add[n])))
                        {
                            iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(files_to_add[n]);
                            this.InvokeEx(f => f.imageList2.Images.Add(System.IO.Path.GetExtension(files_to_add[n]), iconForFile));
                        }
                    }

                    itemsToAdd[n] = new ListViewItem(files_to_add[n]);
                    if (!files_to_add[n].Contains("\\\\"))
                    {
                        itemsToAdd[n].ImageKey = System.IO.Path.GetExtension(files_to_add[n]);
                    }
                    else
                    {
                        itemsToAdd[n].ImageIndex = 0;
                    }

                    Boolean no_av = false;
                    String videosLength = String.Empty;

                    Folder rFolder = shell.NameSpace(Path.GetDirectoryName(files_to_add[n]));
                    FolderItem rFiles = rFolder.ParseName(System.IO.Path.GetFileName(files_to_add[n]));
                    String videostype = rFolder.GetDetailsOf(rFiles, 2).Trim();
                    String videoSize = rFolder.GetDetailsOf(rFiles, 1).Trim();
                    itemsToAdd[n].SubItems.Add(videostype);
                    String f_ext = Path.GetExtension(files_to_add[n]).ToLower();
                    foreach (String no_ext in ext_nodur)
                    {
                        if (f_ext == no_ext)
                        {
                            itemsToAdd[n].SubItems.Add("00:00:00");
                            itemsToAdd[n].BackColor = Color.LightGoldenrodYellow;
                            no_av = true;
                            invalids = invalids + 1;
                            break;
                        }
                    }

                    if (no_av == false)
                    {
                        DateTime time;
                        videosLength = rFolder.GetDetailsOf(rFiles, 27).Trim();

                        if ((!DateTime.TryParse(videosLength, out time)))
                        {
                            itemsToAdd[n].SubItems.Add("Pending");
                            pending_dur = pending_dur + 1;
                        }
                        else
                        {
                            itemsToAdd[n].SubItems.Add(videosLength);
                        }
                    }

                    //End testing

                    itemsToAdd[n].SubItems.Add(videoSize);
                    itemsToAdd[n].SubItems.Add("Queued");

                }
            }

            if (canceled_file_adding == true)
            {
                this.InvokeEx(f => f.pg_adding.Value = 0);
                this.InvokeEx(f => f.pg_adding.Maximum = i);
                this.InvokeEx(f => f.LB_Wait.Text = "Canceling...");
                ListViewItem[] itemsToAdd2 = new ListViewItem[i];
                for (int n2 = 0; n2 < i; n2++)
                {
                    this.InvokeEx(f => f.pg_adding.Value = n2);
                    itemsToAdd2[n2] = itemsToAdd[n2];
                }
                this.InvokeEx(f => f.listView1.Items.AddRange(itemsToAdd2));

            }
            else
            {
                this.InvokeEx(f => f.listView1.Items.AddRange(itemsToAdd.ToArray()));
            }
        }

        private void BG_Files_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            calc_list_size();
            calc_total_dur();

            String other_file = Path.Combine(Path.GetTempPath(), "FFBatch_test") + "\\" + "Other_instance.fftmp";
            if (File.Exists(other_file))
            {
                try
                {
                    File.Delete(other_file);
                }
                catch { }
            }

            //Remove duplicates
            LB_Wait.Text = "Buscando duplicados";
            LB_Wait.Refresh();
            pg_adding.Value = 0;

            var tags = new HashSet<string>();
            var duplicates = new List<ListViewItem>();

            txt_adding_p.Text = "";

            foreach (ListViewItem item in listView1.Items)
            {
                // HashSet.Add() returns false if it already contains the key.
                if (!tags.Add(item.Text))
                    duplicates.Add(item);
            }
            if (duplicates.Count != 0)
            {
                MessageBox.Show("Ficheros duplicados fueron encontrados y serán eliminados de la lista.", "Ficheros duplicados encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pg_adding.Maximum = duplicates.Count();

            foreach (ListViewItem item in duplicates)
            {
                item.Remove();
                pg_adding.Value = pg_adding.Value + 1;
                txt_adding_p.Text = (pg_adding.Value * 100 / duplicates.Count).ToString() + "%";
                txt_adding_p.Refresh();
            }
            //End remove duplicates


            calc_total_dur();
            calc_list_size();
            
            btn_cancel_add.Enabled = true;
            btn_cancel_add.Visible = true;
            btn_cancel_add.Refresh();

            if (canceled_file_adding == false)
            {
                canceled_add = false;
                if (change_tab_1 == true)
                {
                    change_tab_1 = false;
                    tabControl1.SelectedIndex = 0;
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                canceled_add = true;

                if (change_tab_1 == true)
                {
                    change_tab_1 = false;
                    tabControl1.SelectedIndex = 0;
                }
            }

            list_global_proc.Items.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                list_global_proc.Items.Add((ListViewItem)item.Clone());
            }

            BG_P_Dur.RunWorkerAsync();
            listView1.EndUpdate();

        }

        private void change_tab()
        {
            if (change_tab_1 == true)
            {
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedIndex = 1;
            }
            if (change_tab_2 == true)
            {
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedIndex = 2;
            }
        }

        private void calc_total_dur()
        {
            Double Total_dur = 0;
            foreach (ListViewItem item in listView1.Items)

                if (item.SubItems[2].Text != "0:00:00" && item.SubItems[2].Text != "N/A" && item.SubItems[2].Text != "00:00:00" && item.SubItems[2].Text != "Pending")
                {
                    try
                    {
                        Total_dur = Total_dur + TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds;
                    }
                    catch (System.Exception)
                    {
                        item.SubItems[2].Text = "N/A";
                        item.BackColor = Color.LightGoldenrodYellow;
                    }
                }

            TimeSpan t = TimeSpan.FromSeconds(Total_dur);
            String dur = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                     (int)t.TotalHours,
                     t.Minutes,
                     t.Seconds,
                     t.Milliseconds);
            lbl_dur_list.Text = dur.Substring(0, 11);
        }

        private void BG_P_Dur_DoWork(object sender, DoWorkEventArgs e)
        {
            //PAUSE while parsing

            if (working == true)
            {
                paused = true;
                int tab = 0;
                tabControl1.Invoke(new MethodInvoker(delegate
                {
                    tab = tabControl1.SelectedIndex;
                }));

                if (tab == 0)
                {
                    listView1.Invoke(new MethodInvoker(delegate
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (working == true && multi_running == false)
                            {
                                process_glob.Suspend();
                            }
                        }
                    }));

                    if (working == true && multi_running == true)
                    {
                        foreach (Process proc in procs.Values)
                        {
                            try
                            {
                                proc.Suspend();
                            }
                            catch
                            {
                            }
                        }
                    }
                }


                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Paused));
            }

            //END PAUSE ENCODING, PENDING RESUME
            tried_params.Clear();
            if (listView1.Items.Count == 0)
            {
                list_not_empty = false;
            }
            else
            {
                list_not_empty = true;
            }

            if (list_not_empty == true)
            {
                pending_dur = 0;
                listView1.Invoke(new MethodInvoker(delegate
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[2].Text == "Pending")
                        {
                            pending_dur = pending_dur + 1;
                        }
                    }
                }));
            }

            this.InvokeEx(f => f.pg_adding.Value = 0);
            if (language == "es") this.InvokeEx(f => f.LB_Wait.Text = "Analizando " + pending_dur + " fichero");
            if (language == "en") this.InvokeEx(f => f.LB_Wait.Text = "Analysing " + pending_dur + " file");
            this.InvokeEx(f => f.LB_Wait.Refresh());
            this.InvokeEx(f => f.pg_adding.Maximum = pending_dur);
            Process probe = new Process();

            this.InvokeEx(f => f.listView1.BeginUpdate());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (canceled_add == false)
                {
                    listView1.Invoke(new MethodInvoker(delegate
                    {
                        if (listView1.Items[i].SubItems[2].Text == "Pending")
                        {
                            this.InvokeEx(f => f.pg_adding.Value = pg_adding.Value + 1);
                            this.InvokeEx(f => f.txt_adding_p.Text = (pg_adding.Value * 100 / pending_dur + "%"));
                            this.InvokeEx(f => f.txt_adding_p.Refresh());
                            probe.StartInfo.RedirectStandardOutput = true;
                            probe.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "MediaInfo.exe");
                            String ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration/String3%" + '\u0022';
                            probe.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + listView1.Items[i].Text + '\u0022';
                            probe.StartInfo.UseShellExecute = false;
                            probe.StartInfo.CreateNoWindow = true;
                            probe.EnableRaisingEvents = true;
                            probe.Start();

                            String duracion = probe.StandardOutput.ReadLine();
                            probe.WaitForExit();

                            if (duracion != null)
                            {
                                TimeSpan time = new TimeSpan();
                                if (TimeSpan.TryParse(duracion, out time))
                                {
                                    this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = duracion.Substring(0, 12));

                                    if (duracion.Length >= 12)
                                    {
                                        if (duracion.Substring(0, 11) == "0:00:00.000" || duracion.Substring(0, 12) == "00:00:00.000")
                                        {
                                            invalids = invalids + 1;
                                            listView1.Items[i].BackColor = Color.LightGoldenrodYellow;
                                        }
                                    }
                                }
                                else
                                {
                                    invalids = invalids + 1;
                                    listView1.Items[i].SubItems[2].Text = "N/A";
                                    listView1.Items[i].BackColor = Color.LightGoldenrodYellow;
                                }
                            }
                            else
                            {
                                invalids = invalids + 1;
                                listView1.Items[i].SubItems[3].Text = "N/A";
                                listView1.Items[i].BackColor = Color.LightGoldenrodYellow;
                            }
                        }
                        //    if (tbit_col != 0)
                        //    {
                        //        Double bytes = 0;
                        //        try
                        //        {
                        //            FileInfo fi = new FileInfo(listView1.Items[i].SubItems[1].Text + "\\" + listView1.Items[i].Text);
                        //            Double size = fi.Length;
                        //            Double dur = 0;

                        //            TimeSpan time;
                        //            if (TimeSpan.TryParse(listView1.Items[i].SubItems[3].Text, out time))
                        //            {
                        //                dur = TimeSpan.Parse(listView1.Items[i].SubItems[3].Text).TotalSeconds;
                        //                if (dur > 0) bytes = Math.Round((size / dur * 8 / 1000), 0);
                        //                else bytes = 0;
                        //            }

                        //            String subit = "";
                        //            if (bytes >= 1000000) subit = (bytes / 1000000).ToString("#,##0.0") + " " + "Gb/s";
                        //            else if (bytes >= 10000 && bytes < 1000000)
                        //                subit = (bytes / 1000).ToString("#,##0.0") + " " + "Mb/s";
                        //            else if (bytes < 10000) subit = bytes.ToString("#,##0") + " " + "Kb/s";
                        //            else if (bytes == 0 || bytes > 100000000000000) subit = "0 Kb/s";
                        //            listView1.Items[i].SubItems[tbit_col].Text = subit;
                        //        }
                        //        catch { listView1.Items[i].SubItems[tbit_col].Text = "0 Kb/s"; }
                        //    }

                    }));
                }
            }
            this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
            Boolean is_LV1 = false;
            tabControl1.Invoke(new MethodInvoker(delegate
            {
                if (tabControl1.SelectedIndex == 0) is_LV1 = true;
            }));

            dur_ok = !canceled_add;

            this.InvokeEx(f => f.lbl_items.Text = listView1.Items.Count + " " + "Ficheros");
            this.InvokeEx(f => f.LB_Wait.Text = "");
            this.InvokeEx(f => f.txt_adding_p.Visible = false);

            this.InvokeEx(f => f.lbl_dur_list.Refresh());

            this.InvokeEx(f => f.listView1.EndUpdate());
            this.InvokeEx(f => f.Enable_Controls());
            this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante" + " " + "00h:00m:00s");            
            this.InvokeEx(f => f.btn_pause.Enabled = true);
            this.InvokeEx(f => f.btn_pause.Enabled = true);
            this.InvokeEx(f => f.btn_abort_all.Enabled = true);
            this.InvokeEx(f => f.txt_adding_p.Text = "");
            this.InvokeEx(f => f.txt_adding_p.Visible = false);
            this.InvokeEx(f => f.lbl_items.Visible = true);
            this.InvokeEx(f => f.lbl_dur_list.Visible = true);
            this.InvokeEx(f => f.lbl_size.Visible = true);
            this.InvokeEx(f => f.pg_adding.Visible = false);
            this.InvokeEx(f => f.LB_Wait.Visible = false);

            this.InvokeEx(f => f.tabControl1.Enabled = true);
            this.InvokeEx(f => f.listView1.EndUpdate());
            pop_invalids = false;
            if (invalids > 0 && is_LV1 == true && initial_tab != 2)
            {
                pop_invalids = true;
            }
        }

        private void BG_P_Dur_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //RESUME
            btn_cancel_add.Visible = false;

            int tab = 0;
            tabControl1.Invoke(new MethodInvoker(delegate
            {
                tab = tabControl1.SelectedIndex;
            }));

            paused = false;
            if (tab == 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (working == true && multi_running == false)
                    {
                        process_glob.Resume();
                    }
                }
                if (working == true && multi_running == true)
                {
                    foreach (Process proc in procs.Values)
                    {
                        try
                        {
                            proc.Resume();
                        }
                        catch
                        {

                        }
                    }
                }
            }

            this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Normal));

            //END RESUME
            calc_total_dur();
            this.InvokeEx(f => this.Cursor = Cursors.Arrow);
            lvwColumnSorter_Full.SortColumn = 0;
            lvwColumnSorter_Full.Order = SortOrder.Ascending;

            listView1.Sort();

            if (pop_invalids == true) MessageBox.Show(listView1.Items.Count + " fichero(s) añadidos a la lista." + Environment.NewLine + invalids + " fichero(s) no pudieron ser analizados (duración = 0 ó N/A)." + Environment.NewLine + Environment.NewLine + "Puede eliminarlos con el botón para eliminar elementos no válidos", "Ficheros no válidos en la lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (working == true)
            {
                Disable_Controls();
                timer_tasks.Start();
                btn_add_files.Enabled = true;
                btn_add_folders.Enabled = true;

                chk_subfolders.Enabled = true;

                if (runnin_n_presets == true)
                {
                    btn_add_files.Enabled = true;
                    btn_add_folders.Enabled = true;

                }
                
                total_duration = 0;

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[2].Text != "N/A" && item.SubItems[2].Text != "0:00:00" && item.SubItems[2].Text != "00:00:00" && item.SubItems[2].Text != "Pending")
                    {
                        total_duration = total_duration + TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds;
                    }
                    else
                    {
                        total_duration = total_duration + 0;
                    }
                }
            }

        }

        private void BG_Validate_URLs_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void ct_validate_url_Click(object sender, EventArgs e)
        {

        }

        private void ct_paste_m3u_Click(object sender, EventArgs e)
        {

        }

        private void BG_Validate_URLs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

      
        private void ctm_m3u_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ct_play_vlc_Click(object sender, EventArgs e)
        {

        }
        private void ct_show_urls_Click(object sender, EventArgs e)
        {

        }       

        private void ctm_stop_url_Click(object sender, EventArgs e)
        {

        }

        private void cti6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1 && listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text != "Success" && listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text != "Queued" && listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text != "Aborted")
            {
                if (multi_running == false)
                {
                    StreamWriter write_q = process_glob.StandardInput;
                    write_q.Write("q");
                    aborted_url = true;
                    listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text = "Aborting";
                    return;
                }
                else
                {
                    StreamWriter write_q = procs["proc_urls_" + listView1.Items[listView1.SelectedIndices[0]].Index.ToString()].StandardInput;
                    write_q.Write("q");
                    aborted_url = true;
                    listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text = "Aborting";
                    return;
                }
            }
        }

        private void btn_reset_path_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            txt_path.Text = "..\\Unidos";
           
            String path_s = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_path.ini";
            if (File.Exists(path_s))
            {
                File.Delete(path_s);
                btn_save_path.Enabled = true;
            }
            else
            {
                btn_save_path.Enabled = false;
            }
        }

        public class WebClientWithTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest wr = base.GetWebRequest(address);
                wr.Timeout = 5000; // timeout in milliseconds (ms)
                return wr;
            }
        }


        private void btn_update_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            FFBatch.Form2 frm2 = new FFBatch.Form2();
            frm2.StartPosition = FormStartPosition.CenterParent;
            frm2.ShowDialog();
            return;
            //lbl_updates.Text = String.Empty;
            String current_ver = btn_update.Text;
            btn_update.Refresh();
            String content1 = String.Empty;


            try
            {

                WebClient client = new WebClientWithTimeout();
                Stream stream = client.OpenRead("https://drive.upm.es/index.php/s/qx2KzwVy77y7pL3/download");
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();
                content1 = content;



            }
            catch
            {
                try
                {
                    //Backup server
                    WebClient client = new WebClientWithTimeout();
                    Stream stream = client.OpenRead("http://www.blasdelezoinvictus.es/config/current_ffb.txt");
                    StreamReader reader = new StreamReader(stream);
                    String content = reader.ReadToEnd();
                    content1 = content;
                }
                catch (Exception excpt)
                {
                    MessageBox.Show("There was an error connecting to updates server." + Environment.NewLine + Environment.NewLine + excpt.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_update.Text = current_ver;
                    return;
                }
            }

            try
            {
                if (Convert.ToInt16(content1.Replace(".", String.Empty).Substring(0, 3)) > Convert.ToInt16(Application.ProductVersion.Replace(".", String.Empty)))
                {
                    var a = MessageBox.Show("A new version is available: " + content1.Substring(0, 5) + Environment.NewLine + content1.Substring(6, content1.Length - 6) + Environment.NewLine + Environment.NewLine + "Do you want to download it?", "New version found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (a == DialogResult.Yes)
                    {
                        Process.Start("https://sourceforge.net/p/ffmpeg-batch/wiki");
                    }
                }
                else
                {
                    MessageBox.Show("You are using the latest version.", "No update available", MessageBoxButtons.OK);
                }
            }
            catch (Exception excpt)
            {
                MessageBox.Show("There was an error checking for updates." + Environment.NewLine + Environment.NewLine + excpt.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_update.Text = current_ver;

        }      

        private void btn_save_path_Click(object sender, EventArgs e)
        {
            String path = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_path.ini";
            String path_to_save = String.Empty;
            path_to_save = txt_path.Text;
            File.WriteAllText(path, path_to_save);
            btn_save_path.Enabled = false;
        }
        private void btn_pause_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (working == false) return;
            if (btn_pause.Image.Size == pic_pause.Image.Size)
            {
                paused = true;

                if (tabControl1.SelectedIndex == 0)
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (working == true && multi_running == false)
                        {
                            process_glob.Suspend();
                        }
                    }

                    if (working == true && multi_running == true)
                    {
                        foreach (Process proc in procs.Values)
                        {
                            try
                            {
                                proc.Suspend();
                            }
                            catch
                            {

                            }
                        }
                    }
                }

                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Paused));
                this.InvokeEx(f => f.btn_abort_all.Enabled = false);
                this.InvokeEx(f => f.btn_pause.Image = pic_resume.Image);
                
                if (language == "es") MessageBox.Show("Codificación en pausa.", "Pausa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("Encoding is now paused.", "Paused", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Paused));

                paused = false;
                if (tabControl1.SelectedIndex == 0)
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (working == true && multi_running == false)
                        {
                            process_glob.Resume();
                        }
                    }
                    if (working == true && multi_running == true)
                    {
                        foreach (Process proc in procs.Values)
                        {
                            try
                            {
                                proc.Resume();
                            }
                            catch
                            {

                            }
                        }
                    }
                }

                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Normal));
                this.InvokeEx(f => f.btn_abort_all.Enabled = true);

                this.InvokeEx(f => f.btn_pause.Image = pic_pause.Image);
                //this.InvokeEx(f => f.btn_pause.Text = "Pause encoding");                
            }
        }

        private void timer_est_size_Tick(object sender, EventArgs e)
        {
            time_est_size = time_est_size + 1;
        }

      
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (language == "es") MessageBox.Show("Este programa permite unir dos o más vídeos grabados por partes con el Plató SAGA." + Environment.NewLine + Environment.NewLine + "Si queremos unir varias partes grabadas en un solo vídeo, usaremos la opción de Unir vídeos SIN cabeceras (rápido, no requiere recodificación.)" + Environment.NewLine + Environment.NewLine + "Si deseamos añadir cabecera y/o créditos al vídeo, usaremos la opción de Unir vídeos CON cabeceras (más lento, requiere recodificación.)", "Ayuda de la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (language == "en") MessageBox.Show("Application allows to concatenate two or more videos recorded with SAGA Studio." + Environment.NewLine + Environment.NewLine + "To join some parts as a single output video, we can use button to Join  without header/credit videos (quick, no encoding required.)" + Environment.NewLine + Environment.NewLine + "To add header/credit videos to output file, we will use the button to Join with headers (slower, encoding required.)", "Application help", MessageBoxButtons.OK, MessageBoxIcon.Question);           
        }


        private void boton_ok_path_Click(object sender, EventArgs e)
        {
            if (path_txt.Text == String.Empty)
            {
                MessageBox.Show("Path field is empty");
                return;
            }
            if (path_txt.Text.Substring(0, 1) == "\\")
            {
                MessageBox.Show("Please do not start with \\ characters");
                return;
            }

            if (path_txt.Text.Contains("¿") || path_txt.Text.Contains("?") || path_txt.Text.Contains(":") || path_txt.Text.Contains(".") || path_txt.Text.Contains("/") || path_txt.Text.Contains(">") || path_txt.Text.Contains(">") || path_txt.Text.Contains(",") || path_txt.Text.Contains("{") || path_txt.Text.Contains("}") || path_txt.Text.Contains("&") || path_txt.Text.Contains("%"))
            {
                MessageBox.Show("Invalid characters detected. Dots are not a valid character in this field");
                return;
            }

            txt_path.Text = "..\\" + path_txt.Text;
        
            path_txt.Text = String.Empty;
            btn_save_path.Enabled = true;
            ActiveForm.Close();
        }

        private void path_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (path_txt.Text == String.Empty)
                {
                    return;
                }
                if (path_txt.Text.Substring(0, 1) == "\\")
                {
                    MessageBox.Show("Please do not start with \\ characters");
                    return;
                }

                if (path_txt.Text.Contains("¿") || path_txt.Text.Contains("?") || path_txt.Text.Contains(":") || path_txt.Text.Contains(".") || path_txt.Text.Contains("/") || path_txt.Text.Contains(">") || path_txt.Text.Contains(">") || path_txt.Text.Contains(",") || path_txt.Text.Contains("{") || path_txt.Text.Contains("}") || path_txt.Text.Contains("&") || path_txt.Text.Contains("%"))
                {
                    MessageBox.Show("Invalid characters detected. Dots are not a valid character in this field");
                    return;
                }

                txt_path.Text = "..\\" + path_txt.Text;
    
                path_txt.Text = String.Empty;
                btn_save_path.Enabled = true;
                ActiveForm.Close();
            }
        }
        

        private void BG_refresh_dur_DoWork(object sender, DoWorkEventArgs e)
        {
            canceled_file_adding = false;
            this.InvokeEx(f => f.listView1.BeginUpdate());
            this.InvokeEx(f => f.Disable_Controls());
            this.InvokeEx(f => f.btn_abort_all.Enabled = false);            
            this.InvokeEx(f => f.btn_cancel_add.Enabled = true);
            this.InvokeEx(f => f.btn_cancel_add.Visible = true);
            this.InvokeEx(f => f.btn_cancel_add.Refresh());
            this.InvokeEx(f => f.LB_Wait.Visible = true);
            this.InvokeEx(f => f.LB_Wait.Text = "Refreshing duration");
            this.InvokeEx(f => f.LB_Wait.Refresh());
            this.InvokeEx(f => f.pg_adding.Visible = true);
            this.InvokeEx(f => f.pg_adding.Value = 0);
            this.InvokeEx(f => f.txt_adding_p.Visible = true);
            this.InvokeEx(f => f.txt_adding_p.Refresh());
            this.InvokeEx(f => f.pg_adding.Maximum = listView1.Items.Count);

            Process probe = new Process();

            for (int i = 0; i < list_global_proc.Items.Count; i++)
            {
                if (canceled_file_adding == true) continue;

                this.InvokeEx(f => f.pg_adding.Value = pg_adding.Value + 1);
                this.InvokeEx(f => f.txt_adding_p.Text = (pg_adding.Value * 100 / list_global_proc.Items.Count + "%"));
                this.InvokeEx(f => f.txt_adding_p.Refresh());

                if (list_global_proc.Items[i].SubItems[2].Text == "Pending" || list_global_proc.Items[i].SubItems[2].Text == "N/A")
                {
                    probe.StartInfo.FileName = Path.Combine(Application.StartupPath, "MediaInfo.exe");
                    String ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration/String3%" + '\u0022';
                    probe.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + list_global_proc.Items[i].Text + '\u0022';
                    probe.StartInfo.RedirectStandardOutput = true;
                    probe.StartInfo.UseShellExecute = false;
                    probe.StartInfo.CreateNoWindow = true;
                    probe.EnableRaisingEvents = true;
                    probe.Start();

                    String duracion = probe.StandardOutput.ReadLine();
                    probe.WaitForExit();

                    if (duracion != null)
                    {
                        TimeSpan time = new TimeSpan();
                        if (TimeSpan.TryParse(duracion, out time))
                        {
                            this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = duracion.Substring(0, 12));

                            if (duracion.Length >= 12)
                            {
                                if (duracion.Substring(0, 11) == "0:00:00.000" || duracion.Substring(0, 12) == "00:00:00.000")
                                {
                                    invalids = invalids + 1;
                                    this.InvokeEx(f => f.listView1.Items[i].BackColor = Color.LightGoldenrodYellow);
                                }
                            }
                        }
                        else
                        {
                            this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = "N/A");
                            invalids = invalids + 1;
                            this.InvokeEx(f => f.listView1.Items[i].BackColor = Color.LightGoldenrodYellow);
                        }
                    }
                    else
                    {
                        this.InvokeEx(f => f.listView1.Items[i].SubItems[2].Text = "N/A");
                        invalids = invalids + 1;
                        this.InvokeEx(f => f.listView1.Items[i].BackColor = Color.LightGoldenrodYellow);
                    }
                }
            }

            this.InvokeEx(f => f.lbl_items.Text = listView1.Items.Count + " fichero(s)");
            this.InvokeEx(f => f.LB_Wait.Text = "");
            this.InvokeEx(f => f.txt_adding_p.Visible = false);
            this.InvokeEx(f => f.listView1.EndUpdate());
            this.InvokeEx(f => f.Enable_Controls());
            this.InvokeEx(f => f.btn_pause.Enabled = true);
            this.InvokeEx(f => f.btn_cancel_add.Visible = false);
            this.InvokeEx(f => f.txt_adding_p.Text = "");
            this.InvokeEx(f => f.txt_adding_p.Visible = false);
            this.InvokeEx(f => f.lbl_items.Visible = true);
            this.InvokeEx(f => f.lbl_dur_list.Visible = true);
            this.InvokeEx(f => f.lbl_size.Visible = true);
            this.InvokeEx(f => f.pg_adding.Visible = false);
            this.InvokeEx(f => f.LB_Wait.Visible = false);
            this.InvokeEx(f => f.tabControl1.Enabled = true);
        }

        private void btn_edit_config_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            return;
        }
        private void btn_concat_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was not found. Restart or reinstall application.", "Executable error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            was_started.Text = btn_concat.Text;
            foreach (ListViewItem file in listView1.Items)
            {
                if (!File.Exists(file.Text))
                {
                    MessageBox.Show("File was not found: " + file.Text, "One file in the queue list was not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (listView1.Items.Count == 0)
            {
                if (language == "es") MessageBox.Show("La lista de vídeos está vacía", "No hay ficheros para unir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("File list is empty.", "No video files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listView1.Items.Count == 1 && txt_video_intro.Text == String.Empty)
            {
                if (language == "es") MessageBox.Show("Agregue más vídeos a la lista para concatenar, o agrege un vídeo de cabecera y salida.", "No hay vídeos suficientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("Add more video files to join, or add a header and credits videos.", "Not enough videos added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (check_sizes() == true) return;
            if (check_ffrate() == true)
            {
                if (language == "es") MessageBox.Show("Atención: En modo sin cabeceras no es posible forzar la tasa de fotogramas. Solo ase admiten videos con las mismas características.");
                if (language == "en") MessageBox.Show("Warning: In this mode it is not possible to force framerate. Only videos with the same qualities are supported.");
                return;
            }

            if (warn_no_intros == false)
            {
                if (txt_video_intro.Text != String.Empty || txt_video_salida.Text != String.Empty)
                {
                    DialogResult a = DialogResult.Yes;
                    if (language == "es") a = MessageBox.Show("Si agrega vídeos de cabecera o créditos se recomienda usar la opción CON Cabeceras. Si los vídeos a unir no tienen exactamente las mismas características el vídeo resultante puede ser defectuoso. ¿Desea continuar?", "Confirmar acción", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (language == "en") a = MessageBox.Show("If you add header or credit videos it is recommended to use the encoding choice WITH header. If video files to be joined are not video quality equals the resulting video could be defective. Do you want to continue?", "Confirm action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (a != DialogResult.Yes) return;
                    else warn_no_intros = true;
                }
            }

            //Check path is writable
            String destino1 = String.Empty;
            Boolean rel_path = false;
            if (txt_path.Text.Contains("..\\"))
            {
                destino1 = listView1.Items[0].Text.Substring(0, listView1.Items[0].Text.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty);
                rel_path = true;
            }
            else
            {               
                    destino1 = txt_path.Text;               
            }

            try
            {
                if (rel_path == true)
                {
                    Directory.CreateDirectory(destino1);
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    File.WriteAllText(destino1 + "\\" + "FFBatch_test.txt", "FFBatch_test");
                    System.Threading.Thread.Sleep(10);
                    File.Delete(destino1 + "\\" + "FFBatch_test.txt");
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show("Write error: " + excpt.Message, "Error writing to destination folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //End path is writable

            //Pending duration

            if (dur_ok == false)
            {
                list_pending_dur.Items.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    list_pending_dur.Items.Add((ListViewItem)item.Clone());
                }
                BG_Dur.RunWorkerAsync();
                return;
            }

            Disable_Controls();
            if (language == "es") txt_remain.Text = "Tiempo restante: 00:00:00";
            if (language == "en") txt_remain.Text = "Remaining time: 00:00:00";
            time_n_tasks = 0;
            timer_tasks.Start();
            cancel_queue = false;
            Pg1.Value = 0;
            //pg_current.Value = 0;
            txt_pg1_prog.Text = "0%";
            txt_pg1_prog.Visible = true;
            notifyIcon1.Visible = true;

            working = true;

            String ffm = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe");

            Pg1.Value = 0;

            String primero_lista = listView1.Items[0].Text;

            String destino = "";
            if (txt_path.Text.Contains("..\\"))
            {
                destino = primero_lista.Substring(0, primero_lista.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty); ;
            }
            else
            {
                destino = txt_path.Text;
            }

            if (!Directory.Exists(destino))
            {
                try
                {
                    Directory.CreateDirectory(destino);
                }
                catch (System.Exception excpt)
                {
                    MessageBox.Show("Error: " + excpt.Message, "Error writing to folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Arrow;
                    Enable_Controls();
                    working = false;
                    return;
                }
            }

            int list_concat_number = listView1.Items.Count;
            if (txt_video_intro.Text != String.Empty) list_concat_number = list_concat_number + 1;
            if (txt_video_salida.Text != String.Empty) list_concat_number = list_concat_number + 1;
            var lista_concat = new String[list_concat_number];
            int i = 0;
            ListView list_proc = new ListView();
            foreach (ListViewItem item in listView1.Items)
            {
                list_proc.Items.Add(item.Text);
                item.BackColor = Color.White;
            }

            listView1.SelectedIndices.Clear();
            Double total_duration = 0;
            int i_dur = 0;

            //Get total duration of files
            foreach (ListViewItem item in listView1.Items)
            {
                if (listView1.Items[i_dur].SubItems[2].Text != "N/A" && listView1.Items[i_dur].SubItems[2].Text != "0:00:00" && listView1.Items[i_dur].SubItems[2].Text != "00:00:00" && listView1.Items[i_dur].SubItems[2].Text != "Pending")
                {
                    total_duration = total_duration + TimeSpan.Parse(listView1.Items[i_dur].SubItems[2].Text).TotalSeconds;
                }
                else
                {
                    total_duration = total_duration + 0;
                }

                i_dur = i_dur + 1;
            }

            if (txt_video_intro.Text != String.Empty)
            {
                total_duration = total_duration + TimeSpan.Parse(duracion_intro).TotalSeconds;
                i_dur = i_dur + 1;
            }

            if (txt_video_salida.Text != String.Empty)
            {
                total_duration = total_duration + TimeSpan.Parse(duracion_salida).TotalSeconds;
                i_dur = i_dur + 1;
            }

            //End get total duration of files

            Pg1.Maximum = 100;
            foreach (ListViewItem item in listView1.Items)
            {
                if (language == "es") item.SubItems[4].Text = "Procesando";
                if (language == "en") item.SubItems[4].Text = "Processing";
            }

            //End total duration

            List<string> list_lines = new List<string>();
            process_glob.StartInfo.Arguments = String.Empty;
            String concat_name = Path.GetFileNameWithoutExtension(listView1.Items[0].Text);

            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;

                String remain_time = "";

                String path = String.Empty;
                String inputs = String.Empty;

                if (txt_video_intro.Text != String.Empty)
                {
                    lista_concat[i] = "file " + "'" + txt_video_intro.Text + "'";
                    i = i + 1;
                }

                foreach (ListViewItem file in list_proc.Items)
                {
                    //Aborted requested
                    if (cancel_queue == true)
                    {
                        working = false;
                        this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                        this.InvokeEx(f => f.Pg1.Value = 0);
                        //this.InvokeEx(f => f.pg_current.Value = 0);
                        Enable_Controls();
                        MessageBox.Show("Queue processing aborted", "Tasks aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (file.Text.Contains(" "))
                    {
                        lista_concat[i] = "file " + "'" + file.Text + "'";
                        i = i + 1;
                    }
                    else
                    {
                        lista_concat[i] = "file " + "'" + file.Text.Replace("\\", "\\\\") + "'";
                        i = i + 1;
                    }
                    path = System.IO.Path.Combine(Path.GetTempPath(), "concat.txt");
                    try
                    {
                        File.WriteAllLines(path, lista_concat);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Hubo un error al crear el fichero intermedio de concatenación." + Environment.NewLine + Environment.NewLine + exc.Message);
                        working = false;
                        Enable_Controls();
                        return;
                    }
                }
                if (txt_video_salida.Text != String.Empty)
                {
                    path = System.IO.Path.Combine(Path.GetTempPath(), "concat.txt");
                    lista_concat[i] = "file " + "'" + txt_video_salida.Text + "'";
                    File.WriteAllLines(path, lista_concat);
                }


                //Change Volume
                String change_vol = "";                
                //End change volume
                String AppParam = String.Empty;
                AppParam = " -f concat -safe 0 -i " + '\u0022' + path + '\u0022' +  " -c copy" + " -y " + '\u0022' + destino + "\\" + concat_name + "_unido" + ".mp4" + '\u0022';
                process_glob.StartInfo.FileName = ffm;
                process_glob.StartInfo.Arguments = AppParam;                
                process_glob.StartInfo.RedirectStandardOutput = true;
                process_glob.StartInfo.RedirectStandardError = true;
                process_glob.StartInfo.RedirectStandardInput = true;
                process_glob.StartInfo.UseShellExecute = false;
                process_glob.StartInfo.CreateNoWindow = true;
                process_glob.EnableRaisingEvents = true;

                valid_prog = false;

                //this.InvokeEx(f => f.pg_current.Value = 0);

                process_glob.Start();
                System.Threading.Thread.Sleep(50);
                
                String err_txt = "";

                while (!process_glob.StandardError.EndOfStream)
                {
                    err_txt = process_glob.StandardError.ReadLine();
                    list_lines.Add(err_txt);

                    if (err_txt.Contains("time=") && err_txt.Contains("time=-") == false)
                    {
                        int start_time_index = err_txt.IndexOf("time=") + 5;
                        Double sec_prog = TimeSpan.Parse(err_txt.Substring(start_time_index, 8)).TotalSeconds;
                        Double percent = (sec_prog * 100 / total_duration);
                        int percent2 = Convert.ToInt32(percent);

                        if (percent2 <= 100)
                        {
                            this.InvokeEx(f => f.txt_pg1_prog.Text = (percent2).ToString() + "%");
                            this.InvokeEx(f => f.txt_pg1_prog.Refresh());
                            this.InvokeEx(f => f.Pg1.Value = percent2);
                            this.InvokeEx(f => f.Pg1.Refresh());
                            this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, percent2, Pg1.Maximum));
                        }
                        //Estimated remaining time

                        remain_time = err_txt.Substring(err_txt.LastIndexOf("speed=") + 6, err_txt.Length - err_txt.LastIndexOf("speed=") - 6);
                        remain_time = remain_time.Replace("x", String.Empty);
                        Double timing1 = 0;

                        if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                        {
                            timing1 = Math.Round(Double.Parse(remain_time.Replace(".", ",")), 2);
                        }
                        else
                        {
                            timing1 = Math.Round(Double.Parse(remain_time), 2);
                        }
                        Decimal timing = (decimal)timing1;
                        Decimal total_dur_dec = Convert.ToDecimal(total_duration);
                        Decimal total_prog_dec = Convert.ToDecimal(sec_prog);
                        Decimal remain_secs = 0;
                        if (timing > 0)
                        {
                            remain_secs = (decimal)(total_dur_dec - total_prog_dec) / timing;
                        }

                        if (remain_secs > 60)
                        {
                            remain_secs = remain_secs + 60;
                        }
                        String remain_from_secs = "";

                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(remain_secs));
                        remain_from_secs = string.Format("{0:D2}h:{1:D2}",
                           t.Hours,
                          t.Minutes);

                        if (remain_secs >= 3600)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs + " min");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs + " min");
                        }

                        if (remain_secs < 3600 && remain_secs >= 600)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutos");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutes");
                        }
                        if (remain_secs < 600 && remain_secs >= 120)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutos");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutes");
                        }

                        if (remain_secs <= 59)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + Convert.ToInt16(remain_secs) + " segundo(s)");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + Convert.ToInt16(remain_secs) + " second(s)");
                        }
                        this.InvokeEx(f => f.txt_remain.Refresh());

                        //End remaining time
                    }

                    //Read output, get progress
                }
                process_glob.WaitForExit();
                process_glob.StartInfo.Arguments = String.Empty;
                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                list_lines.Add("");

                if (process_glob.ExitCode == 0)
                {
                    foreach (ListViewItem item in list_proc.Items)
                    {
                        this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Success");
                    }
                    working = false;
                    Enable_Controls();
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    if (Form.ActiveForm == null)
                    {
                        if (language == "es")
                        {
                            notifyIcon1.BalloonTipText = "Concatenación de vídeos completada con éxito";
                            notifyIcon1.BalloonTipTitle = "Concatenación completada";
                        }
                        if (language == "en")
                        {
                            notifyIcon1.BalloonTipText = "Concatenation successfully complete";
                            notifyIcon1.BalloonTipTitle = "Concatenation complete";
                        }
                        notifyIcon1.ShowBalloonTip(0);
                    }

                        if (Directory.GetFiles(destino).Length != 0)
                        {
                            Process open_processed = new Process();
                            open_processed.StartInfo.FileName = "explorer.exe";
                            open_processed.StartInfo.Arguments = '\u0022' + destino + '\u0022';
                            open_processed.Start();
                        }                     
                }
                else
                {
                    working = false;
                    Enable_Controls();
                    if (Directory.GetFiles(destino).Length == 0)
                    {
                        if (Directory.Exists(destino))
                        {
                            System.IO.Directory.Delete(destino);
                        }
                    }
                    if (cancel_queue == true)
                    {
                        foreach (ListViewItem item in list_proc.Items)
                        {
                            this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Aborted");
                        }
                        if (language == "en") MessageBox.Show("Concatenation aborted by user", "Concatenation Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (language == "es") MessageBox.Show("Concatenación abortada por el usuario", "Concatenación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        foreach (ListViewItem item in list_proc.Items)
                        {
                            this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Error");
                        }

                        if (language == "en") MessageBox.Show("Concatenation failed. Check output error below. Some characters in filenames can also cause errors." + Environment.NewLine + Environment.NewLine + '\u0022' + list_lines[list_lines.Count - 2] + '\u0022', "Concatenation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (language == "es") MessageBox.Show("Hubo un error durante la concatenación de ficheros. Revise los mensajes a continuación." + Environment.NewLine + Environment.NewLine + '\u0022' + list_lines[list_lines.Count - 2] + '\u0022', "La concatenación falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Save log
                string[] array_err = list_lines.ToArray();
                String path_l = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.log";

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path_l);
                SaveFile.WriteLine("FFmpeg log session: " + System.DateTime.Now);
                SaveFile.WriteLine("-------------------------------");
                foreach (String item in array_err)
                {
                    SaveFile.WriteLine(item);
                }
                SaveFile.Close();

                File.AppendAllText(path_l, "-----------------------");
                File.AppendAllText(path_l, Environment.NewLine + "END OF LOG FILE" + Environment.NewLine);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path_l);

                var bytes = fileInfo.Length;

                var kilobytes = (double)bytes / 1024;
                var megabytes = kilobytes / 1024;
                var gigabytes = megabytes / 1024;

                //Format size view
                String size = "";
                String separator = ".";

                if (bytes > 1000000000)
                {
                    if (gigabytes.ToString().Contains("."))
                    {
                        separator = ".";
                    }
                    else
                    {
                        separator = ",";
                    }

                    String gigas = gigabytes.ToString();
                    if (gigas.Length >= 5)
                    {
                        gigas = gigas.Substring(0, gigas.LastIndexOf(separator) + 3);
                        size = (gigas + " GB");
                    }
                    else
                    {
                        size = (gigas + " GB");
                    }
                }

                if (bytes >= 1048576 && bytes <= 1000000000)
                {
                    if (megabytes.ToString().Contains("."))
                    {
                        separator = ".";
                    }
                    else
                    {
                        separator = ",";
                    }
                    String megas = megabytes.ToString();
                    if (megas.Length > 5)
                    {
                        megas = megas.Substring(0, megas.LastIndexOf(separator));
                        size = (megas + " MB");
                    }
                    else
                    {
                        size = (megas + " MB");
                    }
                }

                if (bytes >= 1024 && bytes < 1048576)

                {
                    if (kilobytes.ToString().Contains("."))
                    {
                        separator = ".";
                    }
                    else
                    {
                        separator = ",";
                    }

                    String kbs = kilobytes.ToString();
                    if (kbs.Length >= 5)
                    {
                        kbs = kbs.Substring(0, kbs.LastIndexOf(separator));
                        size = (kbs + " KB");
                    }
                    else
                    {
                        size = (kbs + " KB");
                    }
                }
                if (bytes > -1 && bytes < 1024)
                {
                    String bits = bytes.ToString();
                    size = (bits + " Bytes");
                }

                //End Format size view
                File.AppendAllText(path_l, Environment.NewLine + "LOG SIZE: " + size);

                //End save log


                if (File.Exists(System.IO.Path.Combine(Application.StartupPath, "concat.txt")))
                {
                    File.Delete(System.IO.Path.Combine(Application.StartupPath, "concat.txt"));
                }

                Enable_Controls();
            }).Start();
        }

        private void Timer_idle_Tick(object sender, EventArgs e)
        {
            NativeMethods.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            Pg1.Focus();
            Form frm_custom_path = new Form();
            frm_custom_path.Icon = this.Icon;

            frm_custom_path.Height = 141;
            frm_custom_path.Width = 418;
            frm_custom_path.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm_custom_path.MaximizeBox = false;
            frm_custom_path.MinimizeBox = false;
            String st1 = "";
            if (language == "es") st1 = "Ruta relativa personalizada";
            if (language == "en") st1 = "Custom relative path";
            frm_custom_path.Text = st1;

            Label texto = new Label();
            texto.Top = 10;
            texto.Left = 15;
            texto.Width = 220;
            texto.Parent = frm_custom_path;
            String st2 = "";
            if (language == "es") st2 = "Escriba la ruta relativa personalizada";
            if (language == "en") st2 = "Write down your custom relative output path";
            texto.Text = st2;

            path_txt.Parent = frm_custom_path;
            path_txt.Top = 35;
            path_txt.Left = 15;
            path_txt.Width = 368;
            path_txt.Focus();
            path_txt.TabIndex = 0;
            path_txt.KeyDown += new KeyEventHandler(path_txt_KeyDown);

            Button boton_user_source_path = new Button();
            boton_user_source_path.Parent = frm_custom_path;
            boton_user_source_path.Left = 15;
            boton_user_source_path.Top = 63;
            boton_user_source_path.Width = 135;
            boton_user_source_path.Height = 25;
            String st3 = "";
            if (language == "es") st3 = "Usar ruta del fichero";
            if (language == "en") st3 = "Use file path";
            boton_user_source_path.Text = st3;
            boton_user_source_path.TabIndex = 0;
            boton_user_source_path.Click += new EventHandler(boton_user_source_path_Click);

            Button boton_ok_path = new Button();
            boton_ok_path.Parent = frm_custom_path;
            boton_ok_path.Left = 315;
            boton_ok_path.Top = 63;
            boton_ok_path.Width = 70;
            boton_ok_path.Height = 25;
            boton_ok_path.Text = "OK";
            boton_ok_path.TabIndex = 0;
            boton_ok_path.Click += new EventHandler(boton_ok_path_Click);

            Button boton_cancel_path = new Button();
            boton_cancel_path.Parent = frm_custom_path;
            boton_cancel_path.Left = 243;
            boton_cancel_path.Top = 63;
            boton_cancel_path.Width = 70;
            boton_cancel_path.Height = 25;
            String st4 = "";
            if (language == "es") st4 = "Cancelar";
            if (language == "en") st4 = "Cancel";
            boton_cancel_path.Text = st4;

            boton_cancel_path.Click += new EventHandler(boton_cancel_path_Click);

            frm_custom_path.StartPosition = FormStartPosition.CenterParent;
            frm_custom_path.ShowDialog();
        }

        private void boton_user_source_path_Click(object sender, EventArgs e)
        {
            if (txt_path.Text == "..\\" && btn_save_path.Enabled == false) btn_save_path.Enabled = true;
            if (txt_path.Text != "..\\") btn_save_path.Enabled = true;
            txt_path.Text = "..\\";
            ActiveForm.Close();
        }

        private void item_up_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            foreach (ListViewItem item in listView1.Items)
            {
                item.SubItems[4].Text = "Queued";
            }

            if (tabControl1.SelectedIndex == 0)
            {
                if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[4].Text == "Queued")
                {
                    lvwColumnSorter_Full.Order = SortOrder.None;
                    var currentIndex = listView1.SelectedItems[0].Index;
                    var item = listView1.Items[listView1.SelectedIndices[0]];
                    if (currentIndex > 0 && listView1.Items[currentIndex - 1].SubItems[4].Text == "Queued")
                    {
                        listView1.Items.RemoveAt(currentIndex);
                        listView1.Items.Insert(currentIndex - 1, item);
                    }
                }
            }
        }

        private void item_down_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (tabControl1.SelectedIndex == 0)
            {
                if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[4].Text == "Queued")
                {
                    lvwColumnSorter_Full.Order = SortOrder.None;
                    var currentIndex = listView1.SelectedItems[0].Index;
                    var item = listView1.Items[listView1.SelectedIndices[0]];
                    if (currentIndex > -1 && currentIndex < listView1.Items.Count - 1)
                    {
                        listView1.Items.RemoveAt(currentIndex);
                        listView1.Items.Insert(currentIndex + 1, item);
                    }
                }
            }
        }

        private void requeue_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (tabControl1.SelectedIndex == 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.SubItems[4].Text = "Queued";
                    item.BackColor = Color.White;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {            
            //Read saved path

            String path_s = String.Empty;

            path_s = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_path.ini";


            if (File.Exists(path_s))
            {
                String saved_path = File.ReadAllText(path_s);

                if (saved_path != String.Empty)
                {
                    if (Directory.Exists(saved_path) == true)
                    {
                        txt_path.Text = saved_path;
                        txt_path.BackColor = Color.White;
                    }

                    else
                    {
                        if (saved_path.Contains("..\\"))
                        {
                            txt_path.Text = saved_path;
                       
                        }
                        txt_path.BackColor = this.BackColor;
                    }
                }
                else

                {
                    File.Delete(path_s);
                    txt_path.BackColor = this.BackColor;
                }

            }

            //End read saved path

            read_main_config();
            cb_q.SelectedIndex = FFBatch_UPM.Properties.Settings.Default.enc_q;
            chk_vid_cod.Checked = FFBatch_UPM.Properties.Settings.Default.hw_enc_en;
            cb_hw_enc.SelectedIndex = FFBatch_UPM.Properties.Settings.Default.hw_enc;
            chk_preset.Checked = FFBatch_UPM.Properties.Settings.Default.quick_mode;
            chk_compat.Checked = FFBatch_UPM.Properties.Settings.Default.compt_mode;

            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;

                this.InvokeEx(f => f.chk_subfolders.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 225, 235, 251));                

                this.InvokeEx(f => f.notifyIcon1.Visible = false);
                this.InvokeEx(f => f.listView1.LabelWrap = true);                
                
            }).Start();

            Create_Tooltips();

            is_ff_ok = true;
            String ffm = Path.Combine(Application.StartupPath, "ffmpeg.exe");
            if (!File.Exists(ffm))
            {
                this.Enabled = false;
                var a = MessageBox.Show("FFmpeg.exe was not found in application path. Do you want to find it and copy it to application folder?", "FFmpeg.exe not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.No)
                {
                    Application.Exit();
                    return;
                }
                if (a == DialogResult.Yes)
                {

                    if (is_ff_ok == false)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        is_ff_ok = true;
                        this.Enabled = true;
                    }
                }
            }

            String ffm3 = System.IO.Path.Combine(Application.StartupPath, "mediainfo.exe");
            if (!File.Exists(ffm3))
            {
                this.Enabled = false;
                var a = MessageBox.Show("Mediainfo.exe was not found in application path. Do you want to find it and copy it to application folder?", "Mediainfo.exe not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.No) Application.Exit();
                if (a == DialogResult.Yes)
                {

                    if (is_ff_ok == false)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        is_ff_ok = true;
                        this.Enabled = true;
                    }
                }
            }

            watch_ff.Path = Application.StartupPath;

            //Automatic update

            String f_updates = String.Empty;

            f_updates = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_updates.ini";

            if (!File.Exists(f_updates))
            {
                chk_auto_updates.Checked = true;
                check_back_updates();
            }
            else
            {
                chk_auto_updates.Checked = false;
            }
            Pg1.Focus();
            //End automatic updates

            String save_path_queue = Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch") + "\\" + "saved_queue_temp.ffq";
            if (File.Exists(save_path_queue))
            {
                var a = MessageBox.Show("Program was interrupted during file encoding. Do you want to load the last saved queue state file?", "A queue temporary session file was found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.No)
                {
                    try
                    {
                        File.Delete(save_path_queue);
                    }
                    catch
                    {

                    }
                }
                if (a == DialogResult.Yes)
                {

                    int linea = 0;
                    int not_found = 0;                   
                    this.Cursor = Cursors.WaitCursor;
                    List<ListViewItem> itemsToAdd = new List<ListViewItem>();
                    try
                    {
                        foreach (string line in File.ReadLines(save_path_queue))
                        {

                            if (linea == 0)
                            {
                          
                            }
                            if (linea == 1)
                            {
                              
                            }

                            if (linea == 2)
                            {
                              
                            }

                            if (linea == 3)
                            {                                

                            }

                            if (linea == 4)
                            {
                                txt_path.Text = line;
                            }

                            if (linea > 4)
                            {

                                Boolean missing = false;
                                listView1.SmallImageList = imageList2;

                                itemsToAdd.Add(new ListViewItem(line.Substring(0, line.LastIndexOf(" --0 ")), 1));
                                //ListViewItem elemento = new ListViewItem(line.Substring(0, line.LastIndexOf(" --0 ")), 1);
                                //Begin get file icon
                                Icon iconForFile = SystemIcons.WinLogo;

                                // Check to see if the image collection contains an image
                                // for this extension, using the extension as a key.
                                if (File.Exists(line.Substring(0, line.LastIndexOf(" --0 "))))
                                {
                                    if (!imageList2.Images.ContainsKey(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 ")))))
                                    {
                                        // If not, add the image to the image list.
                                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(line.Substring(0, line.LastIndexOf(" --0 ")));
                                        imageList2.Images.Add(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 "))), iconForFile);
                                    }

                                    //listView1.Items.Add(elemento);
                                    itemsToAdd[linea - 5].ImageKey = System.IO.Path.GetExtension(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 "))));
                                }
                                else
                                {
                                    not_found = not_found + 1;
                                    missing = true;
                                }

                                //listView1.Items.Add(line.Substring(0,line.LastIndexOf(" --0 ")));
                                String type = line.Substring(line.LastIndexOf(" --0 ") + 5, line.Length - (line.LastIndexOf(" --0") + 5));
                                type = type.Substring(0, type.LastIndexOf(" --1"));
                                String dur = line.Substring(line.LastIndexOf(" --1 ") + 5, line.Length - (line.LastIndexOf(" --1") + 5));
                                dur = dur.Substring(0, dur.LastIndexOf(" --2"));
                                String size = line.Substring(line.LastIndexOf(" --2 ") + 5, line.Length - (line.LastIndexOf(" --2") + 5));
                                size = size.Substring(0, size.LastIndexOf(" --3"));
                                String status = line.Substring(line.LastIndexOf(" --3 ") + 5, line.Length - (line.LastIndexOf(" --3") + 5));

                                itemsToAdd[linea - 5].SubItems.Add(type);
                                itemsToAdd[linea - 5].SubItems.Add(dur);
                                itemsToAdd[linea - 5].SubItems.Add(size);
                                if (missing == false) itemsToAdd[linea - 5].SubItems.Add(status);
                                else
                                {
                                    itemsToAdd[linea - 5].SubItems.Add("File not found");
                                    itemsToAdd[linea - 5].BackColor = Color.LightGoldenrodYellow;
                                }
                            }
                            linea = linea + 1;
                        }
                        listView1.Items.AddRange(itemsToAdd.ToArray());

                    }
                    catch (Exception excpt)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("Error loading queue session. Unexpected file format." + Environment.NewLine + excpt.Message, "Queue file error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                        read_saved_path();
                        return;
                    }
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[4].Text == "Error") item.BackColor = Color.Orange;
                    }

                    this.Cursor = Cursors.Arrow;

                    calc_list_size();
                    calc_total_dur();
                    lbl_items.Text = listView1.Items.Count.ToString() + " files";


                    if (not_found > 0)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("Queue list loaded successfully. " + Environment.NewLine + not_found.ToString() + " queue fichero(s) were not found. " + Environment.NewLine + Environment.NewLine + "Please sort and check file list for items marked with status " + '\u0022' + "File not found" + '\u0022' + ".", "Queue list loaded with missing files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;

                }
            }
            //End program crashed

            //Sendto parameters

            String[] arguments = Environment.GetCommandLineArgs();
            String[] file_drop = arguments.Skip(1).ToArray();

            if (file_drop.Count() != 0)
            {
                change_tab_1 = false;
                change_tab_2 = false;

                this.Cursor = Cursors.WaitCursor;

                List<string> files2 = new List<string>();

                int num_drop = 0;
                if (file_drop.Count() == 1 && Path.GetExtension(file_drop[0]) == ".ffq")
                //Load queue file
                {
                    int linea = 0;
                    int not_found = 0;
                   
                    List<ListViewItem> itemsToAdd = new List<ListViewItem>();
                    try
                    {
                        foreach (string line in File.ReadLines(file_drop[0]))
                        {

                            if (linea == 0)
                            {
                             
                            }
                            if (linea == 1)
                            {
                              
                            }

                            if (linea == 2)
                            {
                               
                            }

                            if (linea == 3)
                            {                                

                            }

                            if (linea == 4)
                            {
                                txt_path.Text = line;
                            }

                            if (linea > 4)
                            {

                                Boolean missing = false;
                                listView1.SmallImageList = imageList2;

                                itemsToAdd.Add(new ListViewItem(line.Substring(0, line.LastIndexOf(" --0 ")), 1));
                                //ListViewItem elemento = new ListViewItem(line.Substring(0, line.LastIndexOf(" --0 ")), 1);
                                //Begin get file icon
                                Icon iconForFile = SystemIcons.WinLogo;

                                // Check to see if the image collection contains an image
                                // for this extension, using the extension as a key.
                                if (File.Exists(line.Substring(0, line.LastIndexOf(" --0 "))))
                                {
                                    if (!imageList2.Images.ContainsKey(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 ")))))
                                    {
                                        // If not, add the image to the image list.
                                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(line.Substring(0, line.LastIndexOf(" --0 ")));
                                        imageList2.Images.Add(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 "))), iconForFile);
                                    }

                                    //listView1.Items.Add(elemento);
                                    itemsToAdd[linea - 5].ImageKey = System.IO.Path.GetExtension(System.IO.Path.GetExtension(line.Substring(0, line.LastIndexOf(" --0 "))));
                                }
                                else
                                {
                                    not_found = not_found + 1;
                                    missing = true;
                                }

                                //listView1.Items.Add(line.Substring(0,line.LastIndexOf(" --0 ")));
                                String type = line.Substring(line.LastIndexOf(" --0 ") + 5, line.Length - (line.LastIndexOf(" --0") + 5));
                                type = type.Substring(0, type.LastIndexOf(" --1"));
                                String dur = line.Substring(line.LastIndexOf(" --1 ") + 5, line.Length - (line.LastIndexOf(" --1") + 5));
                                dur = dur.Substring(0, dur.LastIndexOf(" --2"));
                                String size = line.Substring(line.LastIndexOf(" --2 ") + 5, line.Length - (line.LastIndexOf(" --2") + 5));
                                size = size.Substring(0, size.LastIndexOf(" --3"));
                                String status = line.Substring(line.LastIndexOf(" --3 ") + 5, line.Length - (line.LastIndexOf(" --3") + 5));

                                itemsToAdd[linea - 5].SubItems.Add(type);
                                itemsToAdd[linea - 5].SubItems.Add(dur);
                                itemsToAdd[linea - 5].SubItems.Add(size);
                                if (missing == false) itemsToAdd[linea - 5].SubItems.Add(status);
                                else
                                {
                                    itemsToAdd[linea - 5].SubItems.Add("File not found");
                                    itemsToAdd[linea - 5].BackColor = Color.LightGoldenrodYellow;
                                }
                            }
                            linea = linea + 1;
                        }
                        listView1.Items.AddRange(itemsToAdd.ToArray());

                    }
                    catch (Exception excpt)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("Error loading queue session. Unexpected file format." + Environment.NewLine + excpt.Message, "Queue file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        read_saved_path();
                        return;
                    }

                    this.Cursor = Cursors.Arrow;
                    calc_list_size();
                    calc_total_dur();
                    lbl_items.Text = listView1.Items.Count.ToString() + " files";

                    if (not_found > 0)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("Queue list loaded successfully. " + Environment.NewLine + not_found.ToString() + " queue fichero(s) were not found. " + Environment.NewLine + Environment.NewLine + "Please sort and check file list for items marked with status " + '\u0022' + "File not found" + '\u0022' + ".", "Queue list loaded with missing files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;

                }

                //End load queue file

                foreach (String dropped in file_drop)
                {
                    if (File.Exists(dropped))
                    {
                        files2.Add(dropped);
                        num_drop = files2.Count();
                    }
                    else
                    {
                        if (Directory.Exists(dropped))
                        {
                            if (add_subfs == false)
                            {
                                foreach (String file in Directory.GetFiles(dropped))
                                {
                                    if (!File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                                    {
                                        files2.Add(file);
                                        num_drop = num_drop + 1;
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    foreach (string f in Directory.GetFiles(dropped, "*.*", System.IO.SearchOption.AllDirectories))
                                    {
                                        if (!File.GetAttributes(f).HasFlag(FileAttributes.Hidden))
                                        {
                                            files2.Add(f);
                                            num_drop = num_drop + 1;
                                        }
                                    }
                                }
                                catch (System.Exception excpt)
                                {
                                    var a = MessageBox.Show("Error: " + excpt.Message, "Access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }

                if (num_drop >= 5000)
                {
                    var a = MessageBox.Show("Adding " + num_drop + " files could take some time. Continue?", "Adding many files", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (a == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                files_to_add = files2;
                canceled_file_adding = false;
                btn_cancel_add.Enabled = true;
                btn_cancel_add.Visible = true;
                btn_cancel_add.Refresh();
                BG_Files.RunWorkerAsync();
                this.Cursor = Cursors.Arrow;

                //End Sendto files
            }
            this.Cursor = Cursors.Arrow;
        }        


        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void combo_prio_Click(object sender, EventArgs e)
        {
            //Load priority

            String f_prio = String.Empty;

            f_prio = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_priority.ini";

            if (File.Exists(f_prio))
            {
                String saved_prio = File.ReadAllText(f_prio);
                if (saved_prio != String.Empty)
                {
                    current_prio = Convert.ToInt16(saved_prio);
                }
            }
            else
            {
                current_prio = 2;
            }

            //End load priority
        }        

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            Pg1.Focus();
        }

        private void cti4_2_Click(object sender, EventArgs e)
        {
            listView1.GridLines = !listView1.GridLines;

            Boolean prev_state = false;
            if (listView1.GridLines == true) prev_state = false;
            if (listView1.GridLines == false) prev_state = true;

            String path = String.Empty;

            path = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.ini";

            int linea = 0;

            foreach (string line in File.ReadLines(path))
            {
                linea = linea + 1;

                if (linea == 5)
                {
                    if (line == "grid_yes")
                    {
                        
                    }

                    if (line == "grid_no")
                    {
                        
                    }
                }
            }
        }


        private void watch_ff_Deleted(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was deleted. Application will not work.", "FFmpeg Batch error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                //End FFmpeg version
            }
        }

        private void watch_ff_Renamed(object sender, RenamedEventArgs e)
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was renamed. Application will not work.", "FFmpeg Batch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void watch_ff_Created(object sender, FileSystemEventArgs e)
        {

        }

        private void check_concat_CheckedChanged(object sender, EventArgs e)
        {
            String f_concat = String.Empty;

            f_concat = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_concat.ini";

            if (check_concat.Checked == false)
            {
                if (File.Exists(f_concat))
                {
                    try
                    {
                        File.Delete(f_concat);


                    }
                    catch
                    {
                        MessageBox.Show("An error occurred while trying to set concat option", "Error saving option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (!File.Exists(f_concat))
                {
                    try
                    {
                        File.WriteAllText(f_concat, String.Empty);


                    }
                    catch
                    {
                        MessageBox.Show("An error occurred while trying to set concat option", "Error saving option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void chk_auto_updates_CheckedChanged(object sender, EventArgs e)
        {

            String f_updates = String.Empty;

            f_updates = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_updates.ini";


            if (chk_auto_updates.CheckState == CheckState.Checked)
            {
                if (File.Exists(f_updates))
                {
                    try
                    {
                        File.Delete(f_updates);
                    }
                    catch
                    {
                        MessageBox.Show("An error occurred while trying to set automatic updates option", "Error saving option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (!File.Exists(f_updates))
                {
                    try
                    {
                        File.WriteAllText(f_updates, String.Empty);
                    }
                    catch
                    {
                        MessageBox.Show("An error occurred while trying to set automatic updates option", "Error saving option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void main_f_1_Click(object sender, EventArgs e)
        {
            btn_clear_list.PerformClick();
        }

        private void main_f_2_Click(object sender, EventArgs e)
        {
            btn_add_files.PerformClick();
        }

                private void ctm1_queue_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    item.SubItems[4].Text = "Queued";
                }
            }
        }


        private void timer_adding_Tick(object sender, EventArgs e)
        {
            start_total_time = start_total_time + 1;
            time_n_tasks = time_n_tasks + 1;
            if (language == "es") this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante:");
            if (language == "en") this.InvokeEx(f => f.txt_add_remain.Text = "Remaining time:");
            this.InvokeEx(f => f.txt_add_remain.Refresh());

            if (Convert.ToUInt16(txt_adding_p.Text.Replace("%", "")) > 1 || start_total_time > 9)
            {
                this.InvokeEx(f => f.txt_add_remain.Visible = true);
                Double remain_secs = time_n_tasks * 100 / Convert.ToUInt16(txt_adding_p.Text.Replace("%", "")) - start_total_time;
                //Double remain_secs = start_total_time;
                String remain_string = String.Empty;


                TimeSpan t = TimeSpan.FromSeconds(remain_secs);
                remain_string = string.Format("{0:D2}h:{1:D2}",
                t.Hours,
                t.Minutes);

                if (remain_secs >= 43200)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: " + Math.Round(remain_secs / 3600).ToString() + " hours");
                }

                if (remain_secs >= 3600 && remain_secs < 43200)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: " + remain_string + " min");
                }

                if (remain_secs < 3600 && remain_secs >= 600)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: " + remain_string.Substring(remain_string.LastIndexOf(":") + 1, 2) + " minutes");
                }
                if (remain_secs < 600 && remain_secs >= 120)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: " + remain_string.Substring(remain_string.LastIndexOf(":") + 2, 1) + " minutes");
                }

                if (remain_secs < 120 && remain_secs > 59)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: " + "About 1 minute");
                }

                if (remain_secs <= 59)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: < 1 minute");
                }
                if (remain_secs <= 0)
                {
                    this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: Almost done");
                }
                this.InvokeEx(f => f.txt_remain.Refresh());
            }
            else
            {
                this.InvokeEx(f => f.txt_add_remain.Text = "Tiempo restante: Calculating...");
                this.InvokeEx(f => f.txt_add_remain.Refresh());
            }
            this.InvokeEx(f => f.txt_add_remain.Refresh());
        }

        private void ct1_total_frames_Click(object sender, EventArgs e)
        {
            String file = listView1.SelectedItems[0].Text;
            String ff_frames = String.Empty;
            String ff_rate = String.Empty;
            String ff_dur = String.Empty;
            Decimal tot_frames = 0;
            Decimal ff_rate_dec = 0;
            Decimal ff_dur_dec = 0;
            this.Cursor = Cursors.WaitCursor;
            Task t = Task.Run(() =>
            {

                Process get_frames = new Process();
                get_frames.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "MediaInfo.exe");
                String ffprobe_frames = " " + '\u0022' + "--Inform=Video;%FrameCount%,%FrameRate%" + '\u0022';
                get_frames.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + file + '\u0022';
                get_frames.StartInfo.RedirectStandardOutput = true;
                get_frames.StartInfo.RedirectStandardError = true;
                get_frames.StartInfo.UseShellExecute = false;
                get_frames.StartInfo.CreateNoWindow = true;
                get_frames.EnableRaisingEvents = true;
                get_frames.Start();

                while (!get_frames.StandardOutput.EndOfStream)
                {
                    ff_frames = get_frames.StandardOutput.ReadLine();
                }
                get_frames.WaitForExit();

                try
                {
                    int ff_rate_1 = ff_frames.IndexOf(",");
                    ff_rate = ff_frames.Substring(ff_frames.IndexOf(",") + 1, ff_frames.Length - ff_rate_1 - 1);
                    ff_frames = ff_frames.Substring(0, ff_frames.IndexOf(","));
                }
                catch
                {
                    ff_frames = null;
                    ff_rate = null;
                }

                if (get_frames.ExitCode == 0)
                {
                    if (ff_frames != null)
                    {
                        try
                        {
                            tot_frames = decimal.Parse(ff_frames) / 1000;

                        }
                        catch
                        {
                            tot_frames = 0;
                            ff_rate_dec = 0;
                        }

                    }
                    else
                    {
                        tot_frames = 0;
                        ff_rate_dec = 0;
                    }
                    if (ff_rate != null)
                    {
                        try
                        {
                            ff_rate_dec = decimal.Parse(ff_rate);
                        }
                        catch
                        {
                            tot_frames = 0;
                            ff_rate_dec = 0;
                        }

                    }
                    else
                    {
                        tot_frames = 0;
                        ff_rate_dec = 0;
                    }
                }
                else
                {
                    tot_frames = 0;
                    ff_rate_dec = 0;
                    ff_dur_dec = 0;
                }

                Process get_frames2 = new Process();
                get_frames2.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "MediaInfo.exe");
                ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration%" + '\u0022';
                get_frames2.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + file + '\u0022';
                get_frames2.StartInfo.RedirectStandardOutput = true;
                get_frames2.StartInfo.RedirectStandardError = true;
                get_frames2.StartInfo.UseShellExecute = false;
                get_frames2.StartInfo.CreateNoWindow = true;
                get_frames2.EnableRaisingEvents = true;
                get_frames2.Start();

                ff_dur = get_frames2.StandardOutput.ReadLine();

                get_frames2.WaitForExit();

                if (get_frames2.ExitCode == 0)
                {
                    if (ff_dur != null)
                    {
                        try
                        {
                            ff_dur_dec = decimal.Parse(ff_dur) / 1000;

                        }
                        catch
                        {
                            ff_dur_dec = 0;
                        }

                    }
                    else
                    {
                        ff_dur_dec = 0;
                    }
                }
            });

            if (!t.Wait(10000))
            {
                this.Cursor = Cursors.Arrow;
                return;
            }

            this.Cursor = Cursors.Arrow;
            Form frmInfo = new Form();
            frmInfo.Name = "Multimedia file statistics";
            frmInfo.Text = "Multimedia file statistics";
            frmInfo.Icon = this.Icon;
            frmInfo.Height = 228;
            frmInfo.Width = 336;
            frmInfo.FormBorderStyle = FormBorderStyle.Fixed3D;
            frmInfo.MaximizeBox = false;
            frmInfo.MinimizeBox = false;
            frmInfo.BackColor = this.BackColor;

            TextBox titulo2 = new TextBox();
            titulo2.Parent = frmInfo;
            titulo2.Top = 12;
            titulo2.Left = 9;
            titulo2.Width = 293;
            titulo2.BackColor = this.BackColor;
            titulo2.BorderStyle = BorderStyle.None;
            titulo2.TextAlign = HorizontalAlignment.Center;
            titulo2.ReadOnly = true;
            titulo2.TabIndex = 2;
            titulo2.Text = Path.GetFileName(listView1.SelectedItems[0].Text);

            Label line = new Label();
            line.Parent = frmInfo;
            line.Left = 0;
            line.Top = 41;
            line.Height = 2;
            line.BorderStyle = BorderStyle.Fixed3D;
            line.Width = 336;

            Label line2 = new Label();
            line2.Parent = frmInfo;
            line2.Left = 0;
            line2.Top = 136;
            line2.Height = 2;
            line2.BorderStyle = BorderStyle.Fixed3D;
            line2.Width = 336;

            Button boton_ok_st = new Button();
            boton_ok_st.Parent = frmInfo;
            boton_ok_st.Left = 85;
            boton_ok_st.Top = 148;
            boton_ok_st.Width = 145;
            boton_ok_st.Height = 27;
            boton_ok_st.Text = "Close";
            boton_ok_st.TabIndex = 0;
            boton_ok_st.Click += new EventHandler(boton_ok_st_Click);
            frmInfo.CancelButton = boton_ok_st;

            Label lbl_frm_rate = new Label();
            lbl_frm_rate.Parent = frmInfo;
            lbl_frm_rate.Left = 20;
            lbl_frm_rate.Top = 55;
            lbl_frm_rate.Width = 90;
            lbl_frm_rate.Text = "Framerate:";

            Label lbl_frm_rate2 = new Label();
            lbl_frm_rate2.Parent = frmInfo;
            lbl_frm_rate2.Left = 123;
            lbl_frm_rate2.Top = 55;
            lbl_frm_rate2.Width = 110;
            if (ff_rate_dec != 0) lbl_frm_rate2.Text = ff_rate + " fps.";
            else lbl_frm_rate2.Text = "-";

            Label lbl_seconds = new Label();
            lbl_seconds.Parent = frmInfo;
            lbl_seconds.Left = 20;
            lbl_seconds.Top = 81;
            lbl_seconds.Width = 90;
            lbl_seconds.Text = "Total seconds:";

            Label lbl_seconds2 = new Label();
            lbl_seconds2.Parent = frmInfo;
            lbl_seconds2.Left = 123;
            lbl_seconds2.Top = 81;
            lbl_seconds2.Width = 110;
            if (ff_dur_dec != 0) lbl_seconds2.Text = ff_dur_dec.ToString() + " seconds.";
            else lbl_seconds2.Text = "-";

            Label lbl_fr_count = new Label();
            lbl_fr_count.Parent = frmInfo;
            lbl_fr_count.Left = 20;
            lbl_fr_count.Top = 107;
            lbl_fr_count.Width = 90;
            lbl_fr_count.Text = "Total frame count:";

            Label lbl_fr_count2 = new Label();
            lbl_fr_count2.Parent = frmInfo;
            lbl_fr_count2.Left = 123;
            lbl_fr_count2.Top = 107;
            lbl_fr_count2.Width = 110;
            if (tot_frames != 0) lbl_fr_count2.Text = tot_frames.ToString().TrimStart('0').Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, String.Empty) + " frames.";
            else lbl_fr_count2.Text = "-";
            frmInfo.StartPosition = FormStartPosition.CenterParent;
            frmInfo.ShowDialog();
        }

        private void boton_ok_st_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }


        private void watch_other_instance_Created(object sender, FileSystemEventArgs e)
        {
            String other_file = Path.Combine(Path.GetTempPath(), "FFBatch_test") + "\\" + "Other_instance.fftmp";
            if (File.Exists(other_file) && working == false)
            {
                List<string> files2 = new List<string>();
                int num_drop = 0;
                this.BringToFront();
                foreach (String dropped in File.ReadLines(other_file))
                {
                    if (File.Exists(dropped))
                    {
                        files2.Add(dropped);
                        num_drop = files2.Count();
                    }
                    else
                    {
                        if (Directory.Exists(dropped))
                        {
                            if (add_subfs == false)
                            {
                                foreach (String file in Directory.GetFiles(dropped))
                                {
                                    if (!File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                                    {
                                        files2.Add(file);
                                        num_drop = num_drop + 1;
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    foreach (string f in Directory.GetFiles(dropped, "*.*", System.IO.SearchOption.AllDirectories))
                                    {
                                        if (!File.GetAttributes(f).HasFlag(FileAttributes.Hidden))
                                        {
                                            files2.Add(f);
                                            num_drop = num_drop + 1;
                                        }
                                    }
                                }
                                catch (System.Exception excpt)
                                {
                                    var a = MessageBox.Show("Error: " + excpt.Message, "Access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }

                if (num_drop >= 5000)
                {
                    var a = MessageBox.Show("Adding " + num_drop + " files could take some time. Continue?", "Adding many files", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (a == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                files_to_add = files2;
                canceled_file_adding = false;
                btn_cancel_add.Enabled = true;
                btn_cancel_add.Visible = true;
                btn_cancel_add.Refresh();
                BG_Files.RunWorkerAsync();

                try
                {
                    File.Delete(other_file);
                }
                catch { }
            }
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
        }
                
        private void button20_Click_1(object sender, EventArgs e)
        {
            Pg1.Focus();
            this.Text = "FFmpeg Batch AV Converter";
            if (working == false)
            {
                int num = 0;
                Process[] localByName = Process.GetProcessesByName("ffmpeg");
                num = localByName.Length;
                if (num > 0 && localByName[0].Id == ff_ver_proc) return;

                if (num > 0)
                {
                    var a = MessageBox.Show("FFmpeg processes still running were detected on the system. Do you want to terminate them?", "FFmpeg processes running", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (a == DialogResult.Yes)
                    {
                        foreach (Process p in localByName)
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch
                            {
                                MessageBox.Show("Error closing process. ID " + p.Id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                cancelados_paralelos = true;
                return;
            }
            else aborted = true;
            working = false;
            btn_abort_all.Enabled = false;
            //button20.Text = "Aborting queue";
        
            runnin_n_presets = false;

            if (recording_scr == true)
            {
                Enable_Controls();
                working = false;
                recording_scr = false;

                StreamWriter write_q = process_glob.StandardInput;
                write_q.Write("q");
                return;
            }

            if (multi_running == true)
            {
                working = false;
                multi_running = false;
                aborted = true;
                cancelados_paralelos = true;

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[4].Text != "Success" && item.SubItems[4].Text != "Ready" && item.SubItems[4].Text != "Queued")
                    {
                        item.SubItems[4].Text = "Aborting";
                    }
                }

                foreach (Process proc in procs.Values)
                {
                    cancelados_paralelos = true;
                    if (proc.StartInfo.Arguments != String.Empty)

                    {
                        try
                        {
                            StreamWriter write_q = proc.StandardInput;
                            write_q.Write("q");
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Error: " + exc.Message + " Some processes already finished or could not be aborted. Press Ok to retry.", "Queue abortion incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                return;
            }

            if (process_glob.StartInfo.Arguments != String.Empty)
            {
                try
                {
                    process_glob.Kill();
                    working = false;
                }
                catch
                {
                }
            }
            else
            {
                MessageBox.Show("Some processes could not be aborted. Press Ok to retry.", "Queue abortion incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cancel_queue = true;
            cancelados_paralelos = true;

            if (process_glob.StartInfo.Arguments != String.Empty)
            {
                StreamWriter write_q = process_glob.StandardInput;
                write_q.Write("q");
                return;
            }
        }

        private void btn_concat_2_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was not found. Restart or reinstall application.", "Executable error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            was_started.Text = btn_concat.Text;
            foreach (ListViewItem file in listView1.Items)
            {
                if (!File.Exists(file.Text))
                {
                    MessageBox.Show("File was not found: " + file.Text, "One file in the queue list was not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (listView1.Items.Count == 0)
            {
                if (language == "es") MessageBox.Show("La lista de vídeos está vacía", "No hay ficheros para unir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("File list is empty.", "No video files", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (listView1.Items.Count == 1 && txt_video_intro.Text == String.Empty)
            {
                if (language == "es") MessageBox.Show("Agregue más vídeos a la lista para concatenar, o agrege un vídeo de cabecera y salida.", "No hay vídeos suficientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("Add more video files to join, or add a header and credits videos.", "No hay vídeos suficientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listView1.Items.Count > 1 && txt_video_intro.Text == String.Empty)
            {
                DialogResult a = new DialogResult();
                if (language == "es") a = MessageBox.Show("No ha agregado una cortinilla de entrada. ¿Desea continuar uniendo los vídeos de la lista de ficheros?", "No se agregó cortinilla de entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (language == "en") a = MessageBox.Show("No header video was selected. Do you want to continue joning videos on file list?", "No header video was selected", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.No) return;
            }            

            if (check_sizes() == true) return;
            if (chk_forceff.Checked == false) if (check_ffrate() == true) return;

            //Check path is writable
            String destino1 = String.Empty;
            Boolean rel_path = false;
            if (txt_path.Text.Contains("..\\"))
            {
                destino1 = listView1.Items[0].Text.Substring(0, listView1.Items[0].Text.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty);
                rel_path = true;
            }
            else
            {                
               destino1 = txt_path.Text;             
            }

            try
            {
                if (rel_path == true)
                {
                    Directory.CreateDirectory(destino1);
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    File.WriteAllText(destino1 + "\\" + "FFBatch_test.txt", "FFBatch_test");
                    System.Threading.Thread.Sleep(10);
                    File.Delete(destino1 + "\\" + "FFBatch_test.txt");
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show("Write error: " + excpt.Message, "Error writing to destination folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //End path is writable

            //Pending duration

            if (dur_ok == false)
            {
                list_pending_dur.Items.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    list_pending_dur.Items.Add((ListViewItem)item.Clone());
                }
                BG_Dur.RunWorkerAsync();
                return;
            }

            Disable_Controls();
            txt_remain.Text = "Tiempo restante: 00:00:00";
            time_n_tasks = 0;
            timer_tasks.Start();
            cancel_queue = false;
            Pg1.Value = 0;
            //pg_current.Value = 0;
            txt_pg1_prog.Text = "0%";
            txt_pg1_prog.Visible = true;
            notifyIcon1.Visible = true;

            working = true;

            String ffm = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe");

            Pg1.Value = 0;

            String primero_lista = listView1.Items[0].Text;

            String destino = "";
            if (txt_path.Text.Contains("..\\"))
            {
                destino = primero_lista.Substring(0, primero_lista.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty); ;
            }
            else
            {
                destino = txt_path.Text;
            }
            if (!Directory.Exists(destino))
            {
                try
                {
                    Directory.CreateDirectory(destino);
                }
                catch (System.Exception excpt)
                {
                    MessageBox.Show("Error: " + excpt.Message, "Error writing to folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Arrow;
                    Enable_Controls();
                    working = false;
                    return;
                }
            }

            var lista_concat = new String[listView1.Items.Count];
            int i = 0;
            ListView list_proc = new ListView();
            foreach (ListViewItem item in listView1.Items)
            {
                list_proc.Items.Add(item.Text);
                item.BackColor = Color.White;
            }

            listView1.SelectedIndices.Clear();
            Double total_duration = 0;
            int i_dur = 0;

            //Get total duration of files
            foreach (ListViewItem item in listView1.Items)
            {
                if (listView1.Items[i_dur].SubItems[2].Text != "N/A" && listView1.Items[i_dur].SubItems[2].Text != "0:00:00" && listView1.Items[i_dur].SubItems[2].Text != "00:00:00" && listView1.Items[i_dur].SubItems[2].Text != "Pending")
                {
                    total_duration = total_duration + TimeSpan.Parse(listView1.Items[i_dur].SubItems[2].Text).TotalSeconds;
                }
                else
                {
                    total_duration = total_duration + 0;
                }

                i_dur = i_dur + 1;
            }
            if (txt_video_intro.Text != String.Empty)
            {
                total_duration = total_duration + TimeSpan.Parse(duracion_intro).TotalSeconds;
                i_dur = i_dur + 1;
            }

            if (txt_video_salida.Text != String.Empty)
            {
                total_duration = total_duration + TimeSpan.Parse(duracion_salida).TotalSeconds;
                i_dur = i_dur + 1;
            }

            //End get total duration of files

            Pg1.Maximum = 100;
            foreach (ListViewItem item in listView1.Items)
            {
                if (language == "es") item.SubItems[4].Text = "Procesando";
                if (language == "en") item.SubItems[4].Text = "Processing";
            }

            //End total duration

            List<string> list_lines = new List<string>();
            process_glob.StartInfo.Arguments = String.Empty;
            String concat_name = Path.GetFileNameWithoutExtension(listView1.Items[0].Text);

            if (cb_q.SelectedIndex == 0) q_enc = 18;
            if (cb_q.SelectedIndex == 1) q_enc = 21;
            if (cb_q.SelectedIndex == 2) q_enc = 24;
            if (cb_q.SelectedIndex == 3) q_enc = 28;

            String v_profile = " veryfast ";
            if (chk_preset.Checked == false) v_profile = " medium ";

            String enc_params_v = " -c:v libx264 -crf " + q_enc.ToString() + " -profile high -preset " + v_profile + " -pix_fmt yuv420p -r 30 ";
            String enc_params_a = " -c:a aac -ab 192K ";
            if (chk_vid_cod.Checked == true)
            {
                q_enc = q_enc + 2;
                if (cb_hw_enc.SelectedIndex == 0) enc_params_v = " -c:v h264_qsv -preset medium -profile:v high -global_quality " + q_enc.ToString() + " -look_ahead 1 -r 30 ";
                if (cb_hw_enc.SelectedIndex == 1) enc_params_v = " -c:v h264_nvenc -preset llhq -profile:v high -qp " + q_enc.ToString() + " -r 30 ";
                if (cb_hw_enc.SelectedIndex == 2) enc_params_v = " -c:v h264_amf -profile:v high -rc cqp -qp_p " + q_enc.ToString() + " " + "-qp_i " + q_enc.ToString() + " " + "-qp_b " + q_enc.ToString() + " -r 30 ";
            }

            Decimal est_bitrate = 0;
            Decimal est_size = 0;

            String force_ff = String.Empty;
            if (chk_forceff.Checked == true) force_ff = " -r " + min_ff.ToString();

            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;

                String remain_time = "";

                String path = String.Empty;
                String inputs = String.Empty;

                if (txt_video_intro.Text != String.Empty) inputs = " -i " + '\u0022' + txt_video_intro.Text + '\u0022';

                foreach (ListViewItem file in list_proc.Items)
                {
                    //Aborted requested
                    if (cancel_queue == true)
                    {
                        working = false;
                        this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                        this.InvokeEx(f => f.Pg1.Value = 0);
                        //this.InvokeEx(f => f.pg_current.Value = 0);
                        Enable_Controls();
                        MessageBox.Show("Queue processing aborted", "Tasks aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    inputs = inputs + " -i " + '\u0022' + file.Text + '\u0022';
                }
                if (txt_video_salida.Text != String.Empty) inputs = inputs + " -i " + '\u0022' + txt_video_salida.Text + '\u0022';

                //Change Volume
                String change_vol = "";
                
                //End change volume
                String AppParam = String.Empty;
                int concat_number = list_proc.Items.Count;
                if (txt_video_intro.Text != String.Empty) concat_number = concat_number + 1;
                if (txt_video_salida.Text != String.Empty) concat_number = concat_number + 1;

                String suff = "_unido";
                if (language == "en") suff = "_joined";

                if (chk_compat.CheckState == CheckState.Checked)
                {
                    AppParam = inputs + " -filter_complex " + '\u0022' + "concat=n=" + concat_number + ":v=1:a=1[outv][outa]" + '\u0022' + " -map " + '\u0022' + "[outv]" + '\u0022' + " -map " + '\u0022' + "[outa]" + '\u0022' + force_ff + " -y " + '\u0022' + destino + "\\" + concat_name + suff + "." + "mp4" + '\u0022';
                }
                else AppParam = inputs + " -filter_complex " + '\u0022' + "concat=n=" + concat_number + ":v=1:a=1[outv][outa]" + '\u0022' + " -map " + '\u0022' + "[outv]" + '\u0022' + " -map " + '\u0022' + "[outa]" + '\u0022' + enc_params_v + force_ff + " " + enc_params_a + " -y " + '\u0022' + destino + "\\" + concat_name + suff + "." + "mp4" + '\u0022';

                process_glob.StartInfo.FileName = ffm;
                process_glob.StartInfo.Arguments = AppParam;
                process_glob.StartInfo.RedirectStandardOutput = true;
                process_glob.StartInfo.RedirectStandardError = true;
                process_glob.StartInfo.RedirectStandardInput = true;
                process_glob.StartInfo.UseShellExecute = false;
                process_glob.StartInfo.CreateNoWindow = true;
                process_glob.EnableRaisingEvents = true;

                valid_prog = false;

                //this.InvokeEx(f => f.pg_current.Value = 0);

                process_glob.Start();                

                String err_txt = "";

                while (!process_glob.StandardError.EndOfStream)
                {
                    err_txt = process_glob.StandardError.ReadLine();
                    list_lines.Add(err_txt);

                    if (err_txt.Contains("time=") && err_txt.Contains("time=-") == false)
                    {
                        int start_time_index = err_txt.IndexOf("time=") + 5;
                        Double sec_prog = TimeSpan.Parse(err_txt.Substring(start_time_index, 8)).TotalSeconds;
                        Double percent = (sec_prog * 100 / total_duration);
                        int percent2 = Convert.ToInt32(percent);

                        if (percent2 <= 100)
                        {
                            this.InvokeEx(f => f.txt_pg1_prog.Text = (percent2).ToString() + "%");
                            this.InvokeEx(f => f.txt_pg1_prog.Refresh());
                            this.InvokeEx(f => f.Pg1.Value = percent2);
                            this.InvokeEx(f => f.Pg1.Refresh());
                            this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, percent2, Pg1.Maximum));
                        }
                        //Estimated remaining time

                        remain_time = err_txt.Substring(err_txt.LastIndexOf("speed=") + 6, err_txt.Length - err_txt.LastIndexOf("speed=") - 6);
                        remain_time = remain_time.Replace("x", String.Empty);
                        Double timing1 = 0;

                        if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                        {
                            timing1 = Math.Round(Double.Parse(remain_time.Replace(".", ",")), 2);
                        }
                        else
                        {
                            timing1 = Math.Round(Double.Parse(remain_time), 2);
                        }
                        Decimal timing = (decimal)timing1;
                        Decimal total_dur_dec = Convert.ToDecimal(total_duration);
                        Decimal total_prog_dec = Convert.ToDecimal(sec_prog);
                        Decimal remain_secs = 0;
                        if (timing > 0)
                        {
                            remain_secs = (decimal)(total_dur_dec - total_prog_dec) / timing;
                        }

                        if (remain_secs > 60)
                        {
                            remain_secs = remain_secs + 60;
                        }
                        String remain_from_secs = "";

                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(remain_secs));
                        remain_from_secs = string.Format("{0:D2}h:{1:D2}",
                           t.Hours,
                          t.Minutes);

                        if (remain_secs >= 3600)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs + " min");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs + " min");
                        }

                        if (remain_secs < 3600 && remain_secs >= 600)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutos");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutes");
                        }
                        if (remain_secs < 600 && remain_secs >= 120)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutos");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutes");
                        }

                        if (remain_secs <= 59)
                        {
                            if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + Convert.ToInt16(remain_secs) + " segundo(s)");
                            if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + Convert.ToInt16(remain_secs) + " second(s)");
                        }
                        this.InvokeEx(f => f.txt_remain.Refresh());

                        //End remaining time

                        //Estimated size and bitrate

                        String read_size = String.Empty;
                        if (err_txt.Contains("size=") && (time_est_size % 3 == 0))
                        {
                            int size_index = err_txt.IndexOf("size=") + 5;
                            read_size = err_txt.Substring(size_index, 8);
                            if (Convert.ToDecimal(sec_prog) != 0)
                            {
                                est_bitrate = (Math.Round(Convert.ToDecimal(read_size) * 8 / Convert.ToDecimal(sec_prog), 0));
                            }
                            else
                            {
                                est_bitrate = 0;
                            }

                            if (Convert.ToDecimal(read_size) > 1 && time_n_tasks > 1)
                            {
                                if (est_bitrate < 9999)
                                {
                                    if (est_bitrate > 48)
                                    {
                                        this.InvokeEx(f => f.lbl_bitrate.Text = "Avg. bitrate: " + est_bitrate + " Kb/s");
                                    }
                                    else
                                    {
                                        this.InvokeEx(f => f.lbl_bitrate.Text = "Avg. bitrate: ");
                                    }
                                }
                                else
                                {
                                    this.InvokeEx(f => f.lbl_bitrate.Text = "Avg. bitrate: " + (Math.Round(est_bitrate / 1000, 0)) + " Mb/s");
                                }
                                //Estimated size

                                est_size = Convert.ToDecimal(total_duration) * est_bitrate / 8;
                                //MessageBox.Show(est_size.ToString());

                                if (est_size > 1000000)
                                {
                                    this.InvokeEx(f => f.lbl_est_size.Text = "Estimated size: " + (Math.Round(est_size / 1000000, 1)).ToString() + " GB");
                                }
                                else
                                {
                                    if (Math.Round(est_size / 1000, 0) > 0)
                                    {
                                        this.InvokeEx(f => f.lbl_est_size.Text = "Estimated size: " + (Math.Round(est_size / 1000, 0)).ToString() + " MB");
                                    }
                                    else
                                    {
                                        this.InvokeEx(f => f.lbl_est_size.Text = "Estimated size: ");
                                    }
                                }
                            }
                            if (time_est_size % 3 == 0) this.InvokeEx(f => f.lbl_speed.Text = remain_time.Trim() + "x");
                            this.InvokeEx(f => f.lbl_est_size.Refresh());
                        }
                    }

                    //Read output, get progress
                }
                process_glob.WaitForExit();
                process_glob.StartInfo.Arguments = String.Empty;
                this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                this.InvokeEx(f => f.lbl_est_size.Text = "");
                this.InvokeEx(f => f.lbl_bitrate.Text = "");
                this.InvokeEx(f => f.lbl_speed.Text = "");

                list_lines.Add("");

                if (process_glob.ExitCode == 0)
                {
                    foreach (ListViewItem item in list_proc.Items)
                    {
                        this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Success");
                    }
                    working = false;
                    Enable_Controls();
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    if (Form.ActiveForm == null)
                    {
                        if (language == "es")
                        {
                            notifyIcon1.BalloonTipText = "Concatenación completada con éxito";
                            notifyIcon1.BalloonTipTitle = "Concatenation completada";
                        }
                        if (language == "en")
                        {
                            notifyIcon1.BalloonTipText = "Concatenation successfully completed";
                            notifyIcon1.BalloonTipTitle = "Concatenation complete";
                        }

                        notifyIcon1.ShowBalloonTip(0);
                    }

                        if (Directory.GetFiles(destino).Length != 0)
                        {
                            Process open_processed = new Process();
                            open_processed.StartInfo.FileName = "explorer.exe";
                            open_processed.StartInfo.Arguments = '\u0022' + destino + '\u0022';
                            open_processed.Start();
                        }                   
                }
                else
                {
                    working = false;
                    Enable_Controls();
                    if (Directory.GetFiles(destino).Length == 0)
                    {
                        if (Directory.Exists(destino))
                        {
                            System.IO.Directory.Delete(destino);
                        }
                    }
                    if (cancel_queue == true)
                    {
                        foreach (ListViewItem item in list_proc.Items)
                        {
                            this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Aborted");
                        }
                        if (language == "en") MessageBox.Show("Concatenation aborted by user", "Concatenation Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (language == "es") MessageBox.Show("Concatenación abortada por el usuario", "Concatenación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        foreach (ListViewItem item in list_proc.Items)
                        {
                            this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Error");
                        }

                        if (language == "en") MessageBox.Show("Concatenation failed. Check output error below. Some characters in filenames can also cause errors." + Environment.NewLine + Environment.NewLine + '\u0022' + list_lines[list_lines.Count - 2] + '\u0022', "Concatenation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (language == "es") MessageBox.Show("Hubo un error durante la concatenación de ficheros. Revise los mensajes a continuación." + Environment.NewLine + Environment.NewLine + '\u0022' + list_lines[list_lines.Count - 2] + '\u0022', "La concatenación falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Save log
                string[] array_err = list_lines.ToArray();
                String path_l = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.log";

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path_l);
                SaveFile.WriteLine("FFmpeg log session: " + System.DateTime.Now);
                SaveFile.WriteLine("-------------------------------");
                foreach (String item in array_err)
                {
                    SaveFile.WriteLine(item);
                }
                SaveFile.Close();

                File.AppendAllText(path_l, "-----------------------");
                File.AppendAllText(path_l, Environment.NewLine + "END OF LOG FILE" + Environment.NewLine);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path_l);

                var bytes = fileInfo.Length;

                var kilobytes = (double)bytes / 1024;
                var megabytes = kilobytes / 1024;
                var gigabytes = megabytes / 1024;

                //Format size view
                String size = "";
                String separator = ".";

                if (bytes > 1000000000)
                {
                    if (gigabytes.ToString().Contains("."))
                    {
                        separator = ".";
                    }
                    else
                    {
                        separator = ",";
                    }

                    String gigas = gigabytes.ToString();
                    if (gigas.Length >= 5)
                    {
                        gigas = gigas.Substring(0, gigas.LastIndexOf(separator) + 3);
                        size = (gigas + " GB");
                    }
                    else
                    {
                        size = (gigas + " GB");
                    }
                }

                if (bytes >= 1048576 && bytes <= 1000000000)
                {
                    if (megabytes.ToString().Contains("."))
                    {
                        separator = ".";
                    }
                    else
                    {
                        separator = ",";
                    }
                    String megas = megabytes.ToString();
                    if (megas.Length > 5)
                    {
                        megas = megas.Substring(0, megas.LastIndexOf(separator));
                        size = (megas + " MB");
                    }
                    else
                    {
                        size = (megas + " MB");
                    }
                }

                if (bytes >= 1024 && bytes < 1048576)

                {
                    if (kilobytes.ToString().Contains("."))
                    {
                        separator = ".";
                    }
                    else
                    {
                        separator = ",";
                    }

                    String kbs = kilobytes.ToString();
                    if (kbs.Length >= 5)
                    {
                        kbs = kbs.Substring(0, kbs.LastIndexOf(separator));
                        size = (kbs + " KB");
                    }
                    else
                    {
                        size = (kbs + " KB");
                    }
                }
                if (bytes > -1 && bytes < 1024)
                {
                    String bits = bytes.ToString();
                    size = (bits + " Bytes");
                }

                //End Format size view
                File.AppendAllText(path_l, Environment.NewLine + "LOG SIZE: " + size);

                //End save log


                if (File.Exists(System.IO.Path.Combine(Application.StartupPath, "concat.txt")))
                {
                    File.Delete(System.IO.Path.Combine(Application.StartupPath, "concat.txt"));
                }

                Enable_Controls();
            }).Start();
        }

        private void start_silence()
        {

            Pg1.Focus();
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was not found. Restart or reinstall application.", "Executable error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listView1.Items.Count == 0)
            {
                if (language == "es") MessageBox.Show("La lista de vídeos está vacía", "No hay ficheros para unir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("File list is empty.", "No video files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem file2 in listView1.Items)
            {
                if (!File.Exists(file2.Text))
                {
                    MessageBox.Show("No se encontró el fichero: " + file2.Text, "Nn fichero de la lista no existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            pg_adding.Visible = true;
            pg_adding.Value = 0;
            pg_adding.Maximum = listView1.Items.Count;
            LB_Wait.Visible = true;
            txt_adding_p.Visible = true;

            LB_Wait.Text = String.Empty;
            LB_Wait.Visible = false;
            pg_adding.Visible = false;
            txt_adding_p.Text = String.Empty;

            cancel_queue = false;
            notifyIcon1.Visible = true;
          
            //Validated list, start processing

            txt_remain.Text = "Tiempo restante: 00:00:00";

            if (listView1.SelectedIndices.Count == 0)
            {
                listView1.Items[0].Selected = true;
                listView1.Items[0].Focused = true;
                listView1.Focus();
            }

            //Remove test file/folder

            String file_prueba = "";
            String sel_test = listView1.SelectedItems[0].Text;
            file_prueba = sel_test;
            String destino = Path.Combine(Path.GetTempPath(), "\\" + "FFBatch_test");
            String borrar = destino + "\\" + System.IO.Path.GetFileNameWithoutExtension(file_prueba) + "." + "mp4";

            cancel_queue = false;
            Pg1.Value = 0;
            //pg_current.Value = 0;
            Disable_Controls();

            //btn_skip_main.Enabled = true;
            //textBox4.Text = "0%";
            working = true;
            runnin_n_presets = true;
            txt_pg1_prog.Visible = true;

            ListView list_proc = new ListView();
            foreach (ListViewItem item in listView1.Items)
            {
                list_proc.Items.Add((ListViewItem)item.Clone());
                item.SubItems[4].Text = "Queued";
                item.BackColor = Color.White;

            }

            //End save hw decoder


            Pg1.Maximum = listView1.Items.Count;
            listView1.SelectedIndices.Clear();

            total_duration = 0;
            Double total_prog = 0;

            //Get total duration of files

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[2].Text != "N/A" && item.SubItems[2].Text != "0:00:00" && item.SubItems[2].Text != "00:00:00" && item.SubItems[2].Text != "Pending")
                {
                    total_duration = total_duration + TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds;
                }
                else
                {
                    total_duration = total_duration + 0;
                }
            }


            Pg1.Minimum = 0;
            Pg1.Maximum = 100;
            String remain_time = "0";
            //End get total duration of files

            List<string> list_lines = new List<string>();
            process_glob.StartInfo.Arguments = String.Empty;

            time_n_tasks = 0;
            timer_tasks.Start();
            timer_est_size.Start();
            time_est_size = 0;
            String file = String.Empty;          
          
            
            Boolean silence_found = false;

            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;

                for (int list_index = 0; list_index < listView1.Items.Count; list_index++)
                {
                    System.Threading.Thread.Sleep(50); //Allow kill process to send cancel_queue

                    listView1.Invoke(new MethodInvoker(delegate
                    {
                        file = listView1.Items[list_index].Text;
                    }));

                    if (cancel_queue == true)
                    {
                        this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                        working = false;
                        time_est_size = 0;

                        Enable_Controls();
                        MessageBox.Show("Procesamiento abortado", "Abortado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.InvokeEx(f => timer_est_size.Start());

                    String ffm = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe");
                    String fullPath = file;

                    if (txt_path.Text.Contains("..\\"))
                    {
                        if (txt_path.Text != "..\\")
                            destino = file.Substring(0, fullPath.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty);
                        else
                        {
                            destino = Path.GetDirectoryName(file);
                        }
                    }
                    else
                    {
                        destino = txt_path.Text;                     
                    }

                    String pre_input_var = "";
                    
                    String pre_ss = "";                  

                    add_suffix = "";

                    //String output_file = output_file = '\u0022' + destino + "\\" + System.IO.Path.GetFileNameWithoutExtension(file) + add_suffix + add_pr_suffix + ext_output1 + '\u0022';
                    String silence_params = "-af silencedetect=n=-" + "60" + "dB" + ":d=" + "3" + " -f null -";
                    String AppParam = pre_input_var + " " + pre_ss + " -i " + "" + '\u0022' + file + '\u0022' + " " + silence_params + " -loglevel info -stats";

                    process_glob.StartInfo.FileName = ffm;
                    process_glob.StartInfo.Arguments = AppParam;

                    valid_prog = false;
                    this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = "Processing");
                    //this.InvokeEx(f => f.pg_current.Value = 0);
                    //this.InvokeEx(f => f.pg_current.Refresh());

                    process_glob.StartInfo.RedirectStandardOutput = true;
                    process_glob.StartInfo.RedirectStandardInput = true;
                    process_glob.StartInfo.RedirectStandardError = true;
                    process_glob.StartInfo.UseShellExecute = false;
                    process_glob.StartInfo.CreateNoWindow = true;
                    process_glob.EnableRaisingEvents = true;
                    process_glob.Start();


                    //Progress test
                    ProgressBarWithText pg_lv = new ProgressBarWithText();
                    this.InvokeEx(f => pg_lv.Top = listView1.Items[list_index].SubItems[4].Bounds.Top);
                    this.InvokeEx(f => pg_lv.Left = listView1.Items[list_index].SubItems[4].Bounds.Left);
                    this.InvokeEx(f => pg_lv.Width = listView1.Items[list_index].SubItems[4].Bounds.Width);
                    this.InvokeEx(f => pg_lv.Height = listView1.Items[list_index].SubItems[4].Bounds.Height);
                    this.InvokeEx(f => pg_lv.Minimum = 0);
                    this.InvokeEx(f => pg_lv.Maximum = 100);
                    this.InvokeEx(f => pg_lv.Parent = listView1);
                    this.InvokeEx(f => pg_lv.Text = "0" + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "0%");
                    this.InvokeEx(f => pg_lv.Show());
                    this.InvokeEx(f => pg_lv.Refresh());
                    //End Progress test

                    this.InvokeEx(f => validate_duration = listView1.Items[list_index].SubItems[2].Text);
                    if (validate_duration != "N/A" && validate_duration != "0:00:00" && validate_duration != "00:00:00" && validate_duration != "Pending")
                    {
                        valid_prog = true;
                    }

                    String err_txt = "";

                    String silence_duration = String.Empty;
                    String silence_start = String.Empty;
                    Double interval = 0;
                    this.InvokeEx(f => durat_n = TimeSpan.Parse(listView1.Items[list_index].SubItems[2].Text).TotalSeconds);

                    lbl_speed.Text = String.Empty;
                    Double sec_prog = 0;
                    Boolean silence_found_file = false;

                    while (!process_glob.StandardError.EndOfStream)
                    {
                        err_txt = process_glob.StandardError.ReadLine();

                        if (err_txt.ToLower().Contains("silence"))
                        {
                            silence_found_file = true;
                            silence_found = true;
                            list_lines.Add(err_txt);
                            try
                            {
                                if (err_txt.ToLower().Contains("silence_start:")) silence_start = err_txt.Substring(err_txt.LastIndexOf("silence_start:") + 15, 6);
                                if (err_txt.ToLower().Contains("silence_duration:")) silence_duration = err_txt.Substring(err_txt.LastIndexOf("silence_duration:") + 18, 6);
                            }
                            catch { }
                        }
                        if (err_txt.Contains("time=") && err_txt.Contains("time=-") == false)
                        {
                            if (valid_prog == true)
                            {
                                int start_time_index = err_txt.IndexOf("time=") + 5;
                                sec_prog = TimeSpan.Parse(err_txt.Substring(start_time_index, 8)).TotalSeconds;

                                Double percent = (sec_prog * 100 / durat_n);

                                total_prog = total_prog + (sec_prog - interval);
                                interval = sec_prog;
                                int percent2 = Convert.ToInt32(percent);

                                Double percent_tot = (total_prog * 100 / total_duration);
                                int percent_tot_2 = Convert.ToInt32(percent_tot);

                                if (percent_tot_2 <= 100)
                                {
                                    this.InvokeEx(f => f.Pg1.Value = percent_tot_2);
                                    this.InvokeEx(f => f.Pg1.Refresh());

                                    this.InvokeEx(f => f.txt_pg1_prog.Text = Math.Round(percent_tot, 1).ToString() + "%");

                                    this.InvokeEx(f => f.txt_pg1_prog.Refresh());

                                    this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, percent_tot, Pg1.Maximum));
                                }

                                if (percent2 <= 100)
                                {

                                    this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = percent2.ToString() + "%");

                                    this.InvokeEx(f => pg_lv.Value = Convert.ToInt16(percent2));
                                    this.InvokeEx(f => pg_lv.Refresh());
                                    if (Math.Round(percent, 1).ToString().Contains(".") || Math.Round(percent, 1).ToString().Contains(","))
                                        this.InvokeEx(f => pg_lv.Text = Math.Round(percent, 1).ToString() + "%");
                                    this.InvokeEx(f => pg_lv.Refresh());
                                }

                                if (cancel_queue == false)
                                {
                                    //Estimated remaining time

                                    remain_time = err_txt.Substring(err_txt.LastIndexOf("speed=") + 6, err_txt.Length - err_txt.LastIndexOf("speed=") - 6);
                                    if (time_est_size % 3 == 0) this.InvokeEx(f => f.lbl_speed.Text = "Velocidad: " + remain_time);
                                    remain_time = remain_time.Replace("x", String.Empty);
                                    Double timing1 = 0;

                                    if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                                    {
                                        timing1 = Math.Round(Double.Parse(remain_time.Replace(".", ",")), 2);
                                    }
                                    else
                                    {
                                        timing1 = Math.Round(Double.Parse(remain_time), 2);
                                    }

                                    Decimal timing = (decimal)timing1;
                                    Decimal total_dur_dec = Convert.ToDecimal(total_duration);
                                    Decimal total_prog_dec = Convert.ToDecimal(total_prog);
                                    Decimal remain_secs = 0;

                                    if (timing > 0)
                                    {
                                        remain_secs = (decimal)(total_dur_dec - total_prog_dec) / timing;
                                    }

                                    if (remain_secs > 60)
                                    {
                                        remain_secs = remain_secs + 60;
                                    }

                                    String remain_from_secs = String.Empty;

                                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(remain_secs));
                                    remain_from_secs = string.Format("{0:D2}h:{1:D2}", t.Hours, t.Minutes);
                                    String time_text = "";
                                    if (language == "es") time_text = "Tiempo restante: ";
                                    if (language == "en") time_text = "Remaining time: ";

                                    if (remain_secs >= 43200)
                                    {
                                        this.InvokeEx(f => f.txt_remain.Text = time_text + Math.Round(remain_secs / 3600).ToString() + " horas");
                                    }

                                    if (remain_secs >= 3600 && remain_secs < 43200)
                                    {
                                        this.InvokeEx(f => f.txt_remain.Text = time_text + remain_from_secs + " min");
                                    }

                                    if (remain_secs < 3600 && remain_secs >= 600)
                                    {
                                        this.InvokeEx(f => f.txt_remain.Text = time_text + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutos");
                                    }

                                    if (remain_secs < 600 && remain_secs >= 120)
                                    {
                                        this.InvokeEx(f => f.txt_remain.Text = time_text + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutos");
                                    }

                                    if (remain_secs <= 59 && remain_secs != 0)
                                    {
                                        this.InvokeEx(f => f.txt_remain.Text = time_text + Convert.ToInt16(remain_secs) + " segundo(s)");
                                    }

                                    if (remain_secs == 0)
                                    {
                                        this.InvokeEx(f => f.txt_remain.Text = time_text + "Finalizando...");
                                    }
                                }
                                //End remaining time
                            }
                        }
                    }
                    process_glob.WaitForExit();
                    process_glob.StartInfo.Arguments = String.Empty;
                    timer_est_size.Stop();
                    time_est_size = 0;
                    this.InvokeEx(f => lbl_speed.Text = String.Empty);
                    this.InvokeEx(f => pg_lv.Visible = false);
                    this.InvokeEx(f => pg_lv.Dispose());
                    this.InvokeEx(f => f.lbl_est_size.Text = String.Empty);
                    this.InvokeEx(f => f.lbl_bitrate.Text = String.Empty);

                    list_lines.Add("");
                    list_lines.Add("---------------------End of " + Path.GetFileName(file) + " log-------------------------------");
                    list_lines.Add("");

                    if (process_glob.ExitCode == 0)
                    {
                        if (skipped == false)
                        {
                            if (silence_found_file == false)
                            {
                                this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = "Success");
                                this.InvokeEx(f => f.listView1.Items[list_index].BackColor = listView1.BackColor);
                            }
                            else
                            {
                                String silence_text = "";
                                String dur_text = "";
                                if (language == "es")
                                {
                                    silence_text = "Silencio en ";
                                    dur_text = "Duración: ";
                                }
                                if (language == "en")
                                {
                                    silence_text = "Silence on ";
                                    dur_text = "Duration: ";
                                }

                                this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = silence_text + silence_start + ". " + dur_text + silence_duration);
                                this.InvokeEx(f => f.listView1.Items[list_index].BackColor = Color.LightGoldenrodYellow);
                            }
                        }
                        else
                        {
                            this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = "Skipped");
                            this.InvokeEx(f => f.listView1.Items[list_index].BackColor = Color.Beige);
                            total_prog = (total_prog + durat_n - sec_prog) / n_multi_presets;
                            skipped = false;
                        }
                        //this.InvokeEx(f => f.listView1.Items[list_index].EnsureVisible());
                    }
                    else
                    {
                        this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = "Error");
                        this.InvokeEx(f => f.listView1.Items[list_index].BackColor = Color.PaleGoldenrod);
                        total_prog = total_prog + durat_n - sec_prog;
                    }

                    if (list_index == listView1.Items.Count - 1)
                    {                    
                        runnin_n_presets = false;
                        list_index = listView1.Items.Count - 1;
                        this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                        this.InvokeEx(f => f.Pg1.Value = 100);
                        this.InvokeEx(f => f.txt_pg1_prog.Text = "100%");
                        working = false;
                        timer_est_size.Stop();
                        time_est_size = 0;

                        if (no_save_logs == false)
                        {
                            //Save log
                            string[] array_err = list_lines.ToArray();
                            String path = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.log";

                            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path);
                            SaveFile.WriteLine("Sesión: " + System.DateTime.Now);
                            SaveFile.WriteLine("-------------------------------");
                            foreach (String item in array_err)
                            {
                                SaveFile.WriteLine(item);
                            }
                            SaveFile.Close();

                            File.AppendAllText(path, "-----------------------");
                            File.AppendAllText(path, Environment.NewLine + "END OF LOG FILE" + Environment.NewLine);
                            File.AppendAllText(path, "-----------------------");
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);

                            var bytes = fileInfo.Length;

                            var kilobytes = (double)bytes / 1024;
                            var megabytes = kilobytes / 1024;
                            var gigabytes = megabytes / 1024;

                            //Format size view
                            String size = "";
                            String separator = ".";

                            if (bytes > 1000000000)
                            {
                                if (gigabytes.ToString().Contains("."))
                                {
                                    separator = ".";
                                }
                                else
                                {
                                    separator = ",";
                                }

                                String gigas = gigabytes.ToString();
                                if (gigas.Length >= 5)
                                {
                                    gigas = gigas.Substring(0, gigas.LastIndexOf(separator) + 3);
                                    size = (gigas + " GB");
                                }
                                else
                                {
                                    size = (gigas + " GB");
                                }
                            }

                            if (bytes >= 1048576 && bytes <= 1000000000)
                            {
                                if (megabytes.ToString().Contains("."))
                                {
                                    separator = ".";
                                }
                                else
                                {
                                    separator = ",";
                                }
                                String megas = megabytes.ToString();
                                if (megas.Length > 5)
                                {
                                    megas = megas.Substring(0, megas.LastIndexOf(separator));
                                    size = (megas + " MB");
                                }
                                else
                                {
                                    size = (megas + " MB");
                                }
                            }

                            if (bytes >= 1024 && bytes < 1048576)

                            {
                                if (kilobytes.ToString().Contains("."))
                                {
                                    separator = ".";
                                }
                                else
                                {
                                    separator = ",";
                                }

                                String kbs = kilobytes.ToString();
                                if (kbs.Length >= 5)
                                {
                                    kbs = kbs.Substring(0, kbs.LastIndexOf(separator));
                                    size = (kbs + " KB");
                                }
                                else
                                {
                                    size = (kbs + " KB");
                                }
                            }
                            if (bytes > -1 && bytes < 1024)
                            {
                                String bits = bytes.ToString();
                                size = (bits + " Bytes");
                            }

                            //End Format size view
                            timer_tasks.Stop();
                            TimeSpan t = TimeSpan.FromSeconds(time_n_tasks);
                            String tx_elapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                            File.AppendAllText(path, Environment.NewLine);
                            File.AppendAllText(path, Environment.NewLine + "Total time: " + tx_elapsed);
                            File.AppendAllText(path, Environment.NewLine + "Log size: " + size);
                            //End save log
                        }

                        //Automatic shutdown check
                        if (cancel_queue == false)
                        {  

                                if (Form.ActiveForm == null)
                                {
                                    String detect_ok = "";
                                    String detect_ok_comp = "";
                                    if (language == "es")
                                    {
                                        detect_ok = "Detección de silencios completada con éxito";
                                        detect_ok_comp = "Detección de silencios completada";
                                    }
                                    if (language == "en")
                                    {
                                        detect_ok = "Silence detection successfully completed";
                                        detect_ok_comp = "Silence detection complete";
                                    }
                                    notifyIcon1.BalloonTipText = detect_ok;
                                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                                    notifyIcon1.BalloonTipTitle = detect_ok_comp;
                                    notifyIcon1.ShowBalloonTip(0);
                                }

                            }

                            else
                            {
                                this.InvokeEx(f => f.txt_pg1_prog.Text = "100%");
                                if (language == "es") this.InvokeEx(f => MessageBox.Show("Procesamiento cancelado", "Detección abortada", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                if (language == "en") this.InvokeEx(f => MessageBox.Show("Processing was cancelled", "Detection aborted", MessageBoxButtons.OK, MessageBoxIcon.Error));
                            }
                        }
                    }                

                this.InvokeEx(f => this.Cursor = Cursors.Arrow);
                if (silence_found == true)
                {
                    Enable_Controls();
                    if (language == "es") this.InvokeEx(f => MessageBox.Show("Se detectaron silencios de 3 ó más segundos en alguno de los ficheros de la lista.", "Silencio encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    if (language == "en") this.InvokeEx(f => MessageBox.Show("Silence gaps longer than 3 seconds were detected on one or more files.", "Silence detected", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    log_silence();
                }
                Enable_Controls();

            }).Start();
        }

        private void btn_silence_Click(object sender, EventArgs e)
        {
            start_silence();
        }

        private void log_silence()
        {
            this.InvokeEx(f => f.Pg1.Focus());
            String path_log_file = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.log";
            if (!File.Exists(path_log_file))
            {
                //if (no_save_logs == true) MessageBox.Show("No log file was found. Log saving is disabled.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //else
                //if (no_save_logs == false) MessageBox.Show("No log file was found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long length = new System.IO.FileInfo(path_log_file).Length;
            if (length > 20000000)
            {
                var a = MessageBox.Show("Log size is " + (length / 1024).ToString() + " KB " + "and it could take some time to load. Continue?", "Log size warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.No) return;
            }

            //Form frm_output = new Form();
            frm_log.Name = "FFmpeg Batch UPM log";
            frm_log.Text = "FFmpeg Batch UPM";
            frm_log.Icon = this.Icon;

            frm_log.Height = 675;
            frm_log.Width = 977;
            frm_log.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm_log.MaximizeBox = false;
            frm_log.MinimizeBox = false;

            var fuente_list = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular);

            Rtxt.Parent = frm_log;
            Rtxt.Left = 20;
            Rtxt.Top = 65;
            Rtxt.Height = 525;
            Rtxt.Width = 920;
            Rtxt.Font = fuente_list;

            ContextMenu Rtxt_menu = new ContextMenu();
            Rtxt.ContextMenu = Rtxt_menu;
            MenuItem CopyItem = new MenuItem("Copy");
            Rtxt_menu.MenuItems.Add(CopyItem);
            CopyItem.Click += new EventHandler(CopyAction);

            TextBox titulo = new TextBox();
            titulo.Parent = frm_log;
            titulo.Top = 15;
            titulo.Left = 20;
            titulo.Width = 921;
            titulo.TabIndex = 0;
            var fuente = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            titulo.Font = fuente;
            titulo.BorderStyle = BorderStyle.Fixed3D;
            titulo.TextAlign = HorizontalAlignment.Center;
            titulo.ReadOnly = true;

            titulo.Text = "FFmpeg batch log";

            Button boton_ok_ff = new Button();
            boton_ok_ff.Parent = frm_log;
            boton_ok_ff.Left = 20;
            boton_ok_ff.Top = 595;
            boton_ok_ff.Width = 920;
            boton_ok_ff.Height = 27;
            boton_ok_ff.Text = "Opening log file...";
            boton_ok_ff.Click += new EventHandler(boton_ok_ff_Click);

            TextBox titulo2 = new TextBox();
            titulo2.Parent = frm_log;
            titulo2.Top = 42;
            titulo2.Left = 47;
            titulo2.Width = 867;

            var fuente2 = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            titulo2.Font = fuente2;
            titulo2.BorderStyle = BorderStyle.None;
            titulo2.TextAlign = HorizontalAlignment.Center;
            titulo2.ReadOnly = true;

            titulo2.Text = "ff_batch.log";

            frm_log.StartPosition = FormStartPosition.CenterScreen;
            Rtxt.Text = File.ReadAllText(path_log_file);
            boton_ok_ff.Text = "Cerrar ventana";
            frm_log.ShowDialog();
            frm_log.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFile_Heads.Filter = "Video |*.mp4; *.mkv; *.avi; *.ts; *.mts; *.flv; *.mpg; *.wmv; *.mov; *.mka; *.m2ts|All files(*.*) | *.*";
            select_intro = true;
            select_credits = false;
            openFile_Heads.ShowDialog();
        }

        private void openFile_Heads_FileOk(object sender, CancelEventArgs e)
        {
            Process probe = new Process();
            probe.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Mediainfo.exe");
            probe.StartInfo.RedirectStandardOutput = true;
            probe.StartInfo.UseShellExecute = false;
            probe.StartInfo.CreateNoWindow = true;
            probe.EnableRaisingEvents = true;

            if (select_intro == true)
            {
                txt_video_intro.Text = openFile_Heads.FileName;
                String ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration/String3%" + '\u0022';
                probe.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + txt_video_intro.Text + '\u0022';

                probe.Start();

                String duracion = probe.StandardOutput.ReadLine();
                probe.WaitForExit();

                if (duracion != null)
                {
                    if (duracion.Length >= 12)
                    {
                        if (duracion.Substring(0, 11) == "0:00:00.000" || duracion.Substring(0, 12) == "00:00:00.000")
                        {
                            duracion = "00:00:00";
                        }
                    }
                    else
                    {
                        duracion = "0";
                    }
                }
                else
                {
                    duracion = "0";
                }

                duracion_intro = duracion;

                ////Check size

                //Boolean has_streams = false;
                //Boolean has_video = false;
                //String ff_frames = String.Empty;
                //Process get_frames = new Process();
                //get_frames.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Mediainfo.exe");
                //String ffprobe_frames2 = "--Inform=Video;%Width%" + "x" + "%Height%";
                //get_frames.StartInfo.Arguments = ffprobe_frames2 + " " + '\u0022' + txt_video_intro.Text + '\u0022';
                //get_frames.StartInfo.RedirectStandardOutput = true;
                //get_frames.StartInfo.RedirectStandardError = true;
                //get_frames.StartInfo.UseShellExecute = false;
                //get_frames.StartInfo.CreateNoWindow = true;
                //get_frames.EnableRaisingEvents = true;
                //get_frames.Start();

                //ff_frames = get_frames.StandardOutput.ReadLine();
                //get_frames.WaitForExit();

                //if (get_frames.ExitCode == 0)
                //{
                //    if (ff_frames != null)
                //    {
                //        has_streams = true;
                //        if (ff_frames.ToLower().Contains("x"))
                //        {
                //            has_video = true;
                //        }
                //        else
                //        {

                //            has_video = false;
                //        }
                //    }
                //    else
                //    {
                //        ff_frames = String.Empty;
                //        has_streams = false;
                //    }
                //    if (has_video == true)
                //    {
                //        if (language == "es" && ff_frames != "1920x1080") MessageBox.Show("El vídeo seleccionado es de tamaño " + ff_frames + "." + Environment.NewLine + Environment.NewLine + "El tamaño debe ser 1920x1080 o pueden producirse errores al unir los vídeos.", "Tamaño de video incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        if (language == "en" && ff_frames != "1920x1080") MessageBox.Show("Selected video size is " + ff_frames + "." + Environment.NewLine + Environment.NewLine + "Required size is 1920x1080 or otherwise concatenation could fail.", "Incorrect video size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
                ////End check size
            }

            //Credits video

            if (select_credits == true)
            {
                txt_video_salida.Text = openFile_Heads.FileName;
                String ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration/String3%" + '\u0022';
                probe.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + txt_video_salida.Text + '\u0022';
                probe.Start();

                String duracion = probe.StandardOutput.ReadLine();
                probe.WaitForExit();

                if (duracion != null)
                {
                    if (duracion.Length >= 12)
                    {
                        if (duracion.Substring(0, 11) == "0:00:00.000" || duracion.Substring(0, 12) == "00:00:00.000")
                        {
                            duracion = "00:00:00";
                        }
                    }
                    else
                    {
                        duracion = "0";
                    }
                }
                else
                {
                    duracion = "0";
                }
                duracion_salida = duracion;

                ////Check size

                //Boolean has_streams = false;
                //Boolean has_video = false;
                //String ff_frames = String.Empty;
                //Process get_frames = new Process();
                //get_frames.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Mediainfo.exe");
                //String ffprobe_frames2 = "--Inform=Video;%Width%" + "x" + "%Height%";
                //get_frames.StartInfo.Arguments = ffprobe_frames2 + " " + '\u0022' + txt_video_salida.Text + '\u0022';
                //get_frames.StartInfo.RedirectStandardOutput = true;
                //get_frames.StartInfo.RedirectStandardError = true;
                //get_frames.StartInfo.UseShellExecute = false;
                //get_frames.StartInfo.CreateNoWindow = true;
                //get_frames.EnableRaisingEvents = true;
                //get_frames.Start();

                //ff_frames = get_frames.StandardOutput.ReadLine();
                //get_frames.WaitForExit();

                //if (get_frames.ExitCode == 0)
                //{
                //    if (ff_frames != null)
                //    {
                //        has_streams = true;
                //        if (ff_frames.ToLower().Contains("x"))
                //        {
                //            has_video = true;
                //        }
                //        else
                //        {

                //            has_video = false;
                //        }
                //    }
                //    else
                //    {
                //        ff_frames = String.Empty;
                //        has_streams = false;

                //    }
                //    if (has_video == true)
                //    {
                //        if (language == "es" && ff_frames != "1920x1080") MessageBox.Show("El vídeo seleccionado es de tamaño " + ff_frames + "." + Environment.NewLine + Environment.NewLine + "El tamaño debe ser 1920x1080 o pueden producirse errores al unir los vídeos.", "Tamaño de video incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        if (language == "en" && ff_frames != "1920x1080") MessageBox.Show("Selected video size is " + ff_frames + "." + Environment.NewLine + Environment.NewLine + "Required size is 1920x1080 or otherwise concatenation could fail.", "Incorrect video size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
                ////End check size
            }

            //End credits video

            if (select_intro == false && select_credits == false)
            {
                txt_video_salida.Text = openFile_Heads.FileName;
                probe.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Mediainfo.exe");
                String ffprobe_frames = " " + '\u0022' + "--Inform=General;%Duration/String3%" + '\u0022';
                probe.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + txt_video_salida.Text + '\u0022';
                probe.Start();

                String duracion = probe.StandardOutput.ReadLine();
                probe.WaitForExit();

                if (duracion != null)
                {
                    if (duracion.Length >= 12)
                    {
                        if (duracion.Substring(0, 11) == "0:00:00.000" || duracion.Substring(0, 12) == "00:00:00.000")
                        {
                            duracion = "00:00:00";
                        }
                    }
                    else
                    {
                        duracion = "0";
                    }
                }
                else
                {
                    duracion = "0";
                }
                duracion_salida = duracion;
            }
            select_intro = false;
            select_credits = false;
        }

        private Boolean check_sizes()
        {
            List<String> files = new List<String>();
            List<String> sizes = new List<String>();
            if (txt_video_intro.Text.Length > 0) files.Add(txt_video_intro.Text);
            if (txt_video_salida.Text.Length > 0) files.Add(txt_video_salida.Text);
            foreach (ListViewItem item in listView1.Items) files.Add(item.Text);

            foreach (String file in files)
            {
                //Check size

                Boolean has_streams = false;
                Boolean has_video = false;
                String ff_frames = String.Empty;
                Process get_frames = new Process();
                get_frames.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Mediainfo.exe");
                String ffprobe_frames2 = "--Inform=Video;%Width%" + "x" + "%Height%";
                get_frames.StartInfo.Arguments = ffprobe_frames2 + " " + '\u0022' + file + '\u0022';
                get_frames.StartInfo.RedirectStandardOutput = true;
                get_frames.StartInfo.RedirectStandardError = true;
                get_frames.StartInfo.UseShellExecute = false;
                get_frames.StartInfo.CreateNoWindow = true;
                get_frames.EnableRaisingEvents = true;
                get_frames.Start();

                ff_frames = get_frames.StandardOutput.ReadLine();
                get_frames.WaitForExit();

                if (get_frames.ExitCode == 0)
                {
                    if (ff_frames != null)
                    {
                        has_streams = true;
                        if (ff_frames.ToLower().Contains("x"))
                        {
                            has_video = true;
                        }
                        else
                        {

                            has_video = false;
                        }
                    }
                    else
                    {
                        ff_frames = String.Empty;
                        has_streams = false;
                    }                    
                }
                if (has_video == true) sizes.Add(ff_frames);
                //End check size
            }
            String size1 = sizes[0];
            int cur_size = 0;
            foreach (String size in sizes)
            {
                if (size != size1)
                {
                    if (language == "es") MessageBox.Show("Solo es posible concatenar ficheros de la misma resolución:" + Environment.NewLine + Environment.NewLine + Path.GetFileName(files[0]) + ": " + size1 + Environment.NewLine + Path.GetFileName(files[cur_size]) + ": " + size, "Resoluciones múltiples", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (language == "en") MessageBox.Show("Only videos with the same resolution can be concatenated:" + Environment.NewLine + Environment.NewLine + Path.GetFileName(files[0]) + ": " + size1 + Environment.NewLine + Path.GetFileName(files[cur_size]) + ": " + size, "Mixed resolutions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                cur_size++;
            }
            return false;
        }

        private Boolean check_ffrate()
        {
            List<String> files = new List<String>();
            List<String> sizes = new List<String>();
            List<int> sizes_int = new List<int>();
            if (txt_video_intro.Text.Length > 0) files.Add(txt_video_intro.Text);
            if (txt_video_salida.Text.Length > 0) files.Add(txt_video_salida.Text);
            foreach (ListViewItem item in listView1.Items) files.Add(item.Text);

            foreach (String file in files)
            {
                //Check framerate

                Boolean has_streams = false;
                Boolean has_video = false;
                String ff_frames = String.Empty;
                Process get_frames = new Process();
                get_frames.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "Mediainfo.exe");
                String ffprobe_frames = " " + '\u0022' + "--Inform=Video;%FrameRate%" + '\u0022';
                get_frames.StartInfo.Arguments = ffprobe_frames + " " + '\u0022' + file + '\u0022';
                get_frames.StartInfo.RedirectStandardOutput = true;
                get_frames.StartInfo.RedirectStandardError = true;
                get_frames.StartInfo.UseShellExecute = false;
                get_frames.StartInfo.CreateNoWindow = true;
                get_frames.EnableRaisingEvents = true;
                get_frames.Start();

                ff_frames = get_frames.StandardOutput.ReadLine();
                get_frames.WaitForExit();

                if (get_frames.ExitCode == 0)
                {
                    if (ff_frames != null)
                    {
                        ff_frames = (decimal.Parse(ff_frames) / 1000).ToString();
                        sizes.Add(ff_frames);
                        sizes_int.Add(Convert.ToInt32(ff_frames));
                    }
                    else sizes.Add("0");
                }
                get_frames.Dispose();
                
                //End check framerate
            }
            String size1 = sizes[0];
            int cur_size = 0;
            min_ff = sizes_int.Min();
            if (min_ff < 25) min_ff = 25;
            foreach (String size in sizes)
            {                
                if (size != size1)
                {
                    if (language == "es") MessageBox.Show("Solo es posible concatenar ficheros con la misma tasa de fotogramas por segundo:" + Environment.NewLine + Environment.NewLine + Path.GetFileName(files[0]) + ": " + size1 + " fps" + Environment.NewLine + Path.GetFileName(files[cur_size]) + ": " + size + " fps" + Environment.NewLine + Environment.NewLine + "Marque la opción de forzar tasa de fotogramas para evitar este error.", "Tasas de fotogramas múltiples", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (language == "en") MessageBox.Show("Only videos with the same framerate can be concatenated:" + Environment.NewLine + Environment.NewLine + Path.GetFileName(files[0]) + ": " + size1 + " fps" + Environment.NewLine + Path.GetFileName(files[cur_size]) + ": " + size + " fps" + Environment.NewLine + Environment.NewLine + "Enable Force framerate setting to avoid this error.", "Mixed framerates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                cur_size++;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFile_Heads.Filter = "Video |*.mp4; *.mkv; *.avi; *.ts; *.mts; *.flv; *.mpg; *.wmv; *.mov; *.mka; *.m2ts|All files(*.*) | *.*";
            select_credits = true;
            select_intro = false;
            openFile_Heads.ShowDialog();
        }

        private void txt_video_intro_DoubleClick(object sender, EventArgs e)
        {
            txt_video_intro.Text = String.Empty;
        }

        private void txt_video_salida_DoubleClick(object sender, EventArgs e)
        {
            txt_video_salida.Text = String.Empty;
        }

        private void btn_clear_intro_Click(object sender, EventArgs e)
        {
            txt_video_intro.Text = String.Empty;
        }

        private void btn_clear_credits_Click(object sender, EventArgs e)
        {
            txt_video_salida.Text = String.Empty;
        }

        private void btn_cl_list_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void RefreshResources(Control ctrl, ComponentResourceManager res)
        {
            ctrl.SuspendLayout();
            res.ApplyResources(ctrl, ctrl.Name, Thread.CurrentThread.CurrentUICulture);
            foreach (Control control in ctrl.Controls)
                RefreshResources(control, res); // recursion
            ctrl.ResumeLayout(false);
        }

        private void combo_lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_lang.SelectedIndex == 0)
            {
                FFBatch_UPM.Properties.Settings.Default.app_lang = "es";
                language = "es";
                cb_q.Items.Clear();
                cb_q.Items.Add("Muy alta");
                cb_q.Items.Add("Alta");
                cb_q.Items.Add("Media");
                cb_q.Items.Add("Baja");
                listView1.Columns[0].Text = "Fichero";
                listView1.Columns[1].Text = "Tipo de archivo";
                listView1.Columns[2].Text = "Duración";
                listView1.Columns[3].Text = "Tamaño";
                listView1.Columns[4].Text = "Estado";
            }
            if (combo_lang.SelectedIndex == 1)
            {
                FFBatch_UPM.Properties.Settings.Default.app_lang = "en";
                language = "en";
                cb_q.Items.Clear();
                cb_q.Items.Add("Very high");
                cb_q.Items.Add("High");
                cb_q.Items.Add("Medium");
                cb_q.Items.Add("Low");
                listView1.Columns[0].Text = "File";
                listView1.Columns[1].Text = "File type";
                listView1.Columns[2].Text = "Duration";
                listView1.Columns[3].Text = "Size";
                listView1.Columns[4].Text = "Status";

            }
            FFBatch_UPM.Properties.Settings.Default.Save();

            Create_Tooltips();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(FFBatch_UPM.Properties.Settings.Default.app_lang);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            RefreshResources(this, resources);
        }

        private void chk_vid_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_vid_cod.CheckState == CheckState.Checked) cb_hw_enc.Enabled = true;
            else cb_hw_enc.Enabled = false;
            FFBatch_UPM.Properties.Settings.Default.hw_enc_en = chk_vid_cod.Checked;
            FFBatch_UPM.Properties.Settings.Default.Save();
        }

        private void btn_one_one_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            if (!File.Exists(Path.Combine(Application.StartupPath, "ffmpeg.exe")))
            {
                MessageBox.Show("FFmpeg executable file was not found. Restart or reinstall application.", "Executable error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            was_started.Text = btn_concat.Text;
            foreach (ListViewItem file in listView1.Items)
            {
                if (!File.Exists(file.Text))
                {
                    if (language == "es") MessageBox.Show("El fichero no fue encontrado: " + file.Text, "Fichero de la lista no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (language == "en") MessageBox.Show("File was not found: " + file.Text, "One file in the queue list was not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (listView1.Items.Count == 0)
            {
                if (language == "es") MessageBox.Show("La lista de vídeos está vacía", "No hay ficheros para unir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("File list is empty.", "No video files", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (listView1.Items.Count == 1 && txt_video_intro.Text == String.Empty)
            {
                if (language == "es") MessageBox.Show("Agregue más vídeos a la lista para concatenar, o agrege un vídeo de cabecera y salida.", "No hay vídeos suficientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (language == "en") MessageBox.Show("Add more video files to join, or add a header and credits videos.", "No hay vídeos suficientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listView1.Items.Count > 1 && txt_video_intro.Text == String.Empty)
            {
                DialogResult a = new DialogResult();
                if (language == "es") a = MessageBox.Show("No ha agregado una cortinilla de entrada. ¿Desea continuar uniendo los vídeos de la lista de ficheros?", "No se agregó cortinilla de entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (language == "en") a = MessageBox.Show("No header video was selected. Do you want to continue joning videos on file list?", "No header video was selected", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.No) return;
            }
            
            if (check_sizes() == true) return;
            if (chk_forceff.Checked == false) if (check_ffrate() == true) return;

            
            //Check path is writable
            String destino1 = String.Empty;
            Boolean rel_path = false;
            if (txt_path.Text.Contains("..\\"))
            {
                destino1 = listView1.Items[0].Text.Substring(0, listView1.Items[0].Text.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty);
                rel_path = true;
            }
            else
            {                
               destino1 = txt_path.Text;               
            }

            try
            {
                if (rel_path == true)
                {
                    Directory.CreateDirectory(destino1);
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    File.WriteAllText(destino1 + "\\" + "FFBatch_test.txt", "FFBatch_test");
                    System.Threading.Thread.Sleep(10);
                    File.Delete(destino1 + "\\" + "FFBatch_test.txt");
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show("Write error: " + excpt.Message, "Error writing to destination folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //End path is writable

            //Pending duration

            if (dur_ok == false)
            {
                list_pending_dur.Items.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    list_pending_dur.Items.Add((ListViewItem)item.Clone());
                }
                BG_Dur.RunWorkerAsync();
                return;
            }

            Disable_Controls();
            txt_remain.Text = "Tiempo restante: 00:00:00";
            time_n_tasks = 0;
            timer_tasks.Start();
            cancel_queue = false;
            Pg1.Value = 0;
            //pg_current.Value = 0;
            txt_pg1_prog.Text = "0%";
            txt_pg1_prog.Visible = true;
            notifyIcon1.Visible = true;

            working = true;

            String ffm = System.IO.Path.Combine(Application.StartupPath, "ffmpeg.exe");

            Pg1.Value = 0;

            var lista_concat = new String[listView1.Items.Count];
            int i = 0;
            ListView list_proc = new ListView();
            foreach (ListViewItem item in listView1.Items)
            {
                list_proc.Items.Add(item.Text);
                item.BackColor = Color.White;
            }

            listView1.SelectedIndices.Clear();
            Double total_duration = 0;
            int i_dur = 0;

            //Get total duration of files
            List<Double> durs = new List<Double>();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[2].Text != "N/A" && item.SubItems[2].Text != "0:00:00" && item.SubItems[2].Text != "00:00:00" && item.SubItems[2].Text != "Pending")
                {
                    total_duration = total_duration + TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds;
                    durs.Add(TimeSpan.Parse(item.SubItems[2].Text).TotalSeconds);
                    if (txt_video_intro.Text != String.Empty)
                    {
                        total_duration = total_duration + TimeSpan.Parse(duracion_intro).TotalSeconds;

                    }

                    if (txt_video_salida.Text != String.Empty)
                    {
                        total_duration = total_duration + TimeSpan.Parse(duracion_salida).TotalSeconds;

                    }
                }
            }
            Double total_prog = 0;

            //End get total duration of files

            Pg1.Maximum = 100;
            aborted = false;

            foreach (ListViewItem item in listView1.Items)
            {
                if (language == "es") item.SubItems[4].Text = "Procesando";
                if (language == "en") item.SubItems[4].Text = "Processing";
            }

            //End total duration

            List<string> list_lines = new List<string>();
            process_glob.StartInfo.Arguments = String.Empty;

            String v_profile = " veryfast ";
            if (chk_preset.Checked == false) v_profile = " medium ";

            if (cb_q.SelectedIndex == 0) q_enc = 18;
            if (cb_q.SelectedIndex == 1) q_enc = 21;
            if (cb_q.SelectedIndex == 2) q_enc = 24;
            if (cb_q.SelectedIndex == 3) q_enc = 28;

            String enc_params_v = " -c:v libx264 -crf " + q_enc.ToString() + " -profile high -preset " + v_profile + " -pix_fmt yuv420p ";
            String enc_params_a = " -c:a aac -ab 192K ";
            if (chk_vid_cod.Checked == true)
            {
                q_enc = q_enc + 2;
                if (cb_hw_enc.SelectedIndex == 0) enc_params_v = " -c:v h264_qsv -preset medium -profile:v high -global_quality " + q_enc.ToString() + " -look_ahead 1 ";
                if (cb_hw_enc.SelectedIndex == 1) enc_params_v = " -c:v h264_nvenc -preset llhq -profile:v high -qp " + q_enc.ToString();
                if (cb_hw_enc.SelectedIndex == 2) enc_params_v = " -c:v h264_amf -profile:v high -rc cqp -qp_p " + q_enc.ToString() + " " + "-qp_i " + q_enc.ToString() + " " + "-qp_b " + q_enc.ToString();
            }

            String force_ff = String.Empty;
            if (chk_forceff.Checked == true) force_ff = " -r " + min_ff.ToString();

            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;

                String remain_time = "";
                String path = String.Empty;
                String inputs = String.Empty;
                int list_index = 0;
                int percent_elapsed = 0;
                Double item_duration = 0;
                int errors = 0;

                foreach (ListViewItem file in list_proc.Items)
                {
                    inputs = "";

                    String destino = "";
                    if (txt_path.Text.Contains("..\\"))
                    {
                        destino = file.Text.Substring(0, file.Text.LastIndexOf('\\')) + txt_path.Text.Replace(".", String.Empty); ;
                    }
                    else
                    {
                        destino = txt_path.Text;
                    }
                    if (!Directory.Exists(destino))
                    {
                        try
                        {
                            Directory.CreateDirectory(destino);
                        }
                        catch (System.Exception excpt)
                        {
                            MessageBox.Show("Error: " + excpt.Message, "Error writing to folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Arrow;
                            Enable_Controls();
                            working = false;
                            return;
                        }
                    }
                    String concat_name = Path.GetFileNameWithoutExtension(file.Text);

                    //Aborted requested
                    if (cancel_queue == true)
                    {
                        working = false;
                        this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                        this.InvokeEx(f => f.Pg1.Value = 0);
                        //this.InvokeEx(f => f.pg_current.Value = 0);
                        Enable_Controls();
                        MessageBox.Show("Queue processing aborted", "Tasks aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (txt_video_intro.Text != String.Empty)
                    {
                        inputs = inputs + " -i " + '\u0022' + txt_video_intro.Text + '\u0022';
                    }

                    inputs = inputs + " -i " + '\u0022' + file.Text + '\u0022';

                    if (txt_video_salida.Text != String.Empty)
                    {
                        inputs = inputs + " -i " + '\u0022' + txt_video_salida.Text + '\u0022';
                    }
                    int concat_number = 1;
                    if (txt_video_intro.Text != String.Empty)
                    {
                        concat_number = concat_number + 1;

                    }
                    else duracion_intro = "0";
                    if (txt_video_salida.Text != String.Empty)
                    {
                        concat_number = concat_number + 1;
                    }
                    else duracion_salida = "0";

                    //Change Volume
                    String change_vol = "";
                    
                    //End change volume
                    String AppParam = String.Empty;

                    String suff = "_unido";
                    if (language == "en") suff = "_joined";

                    if (concat_number == 2)
                    {
                        if (chk_compat.CheckState == CheckState.Checked)
                        {
                            AppParam = inputs + " -filter_complex " + '\u0022' + "[0:v:0][0:a:0][1:v:0][1:a:0]concat=n=" + concat_number.ToString() + ":v=1:a=1[outv] [outa]" + '\u0022' + " -map " + '\u0022' + "[outv]" + '\u0022' + " -map " + '\u0022' + "[outa]" + '\u0022' + force_ff + " -y " + '\u0022' + destino + "\\" + concat_name + suff + "." + "mp4" + '\u0022';
                        }
                        else AppParam = inputs + " -filter_complex " + '\u0022' + "[0:v:0][0:a:0][1:v:0][1:a:0]concat=n=" + concat_number.ToString() + ":v=1:a=1[outv][outa]" + '\u0022' + " -map " + '\u0022' + "[outv]" + '\u0022' + " -map " + '\u0022' + "[outa]" + '\u0022' + enc_params_v + force_ff +  " " + enc_params_a + " -y " + '\u0022' + destino + "\\" + concat_name + suff + "." + "mp4" + '\u0022';

                    }

                    if (concat_number == 3)
                    {
                        if (chk_compat.CheckState == CheckState.Checked)
                        {
                            AppParam = inputs + " -filter_complex " + '\u0022' + "[0:v:0][0:a:0][1:v:0][1:a:0][2:v:0][2:a:0]concat=n=" + concat_number.ToString() + ":v=1:a=1[outv] [outa]" + '\u0022' + " -map " + '\u0022' + "[outv]" + '\u0022' + " -map " + '\u0022' + "[outa]" + '\u0022' + force_ff + " -y " + '\u0022' + destino + "\\" + concat_name + suff + "." + "mp4" + '\u0022';
                        }
                        else AppParam = inputs + " -filter_complex " + '\u0022' + "[0:v:0][0:a:0][1:v:0][1:a:0][2:v:0][2:a:0]concat=n=" + concat_number.ToString() + ":v=1:a=1[outv][outa]" + '\u0022' + " -map " + '\u0022' + "[outv]" + '\u0022' + " -map " + '\u0022' + "[outa]" + '\u0022' + enc_params_v + force_ff + " " + enc_params_a + " -y " + '\u0022' + destino + "\\" + concat_name + suff + "." + "mp4" + '\u0022';

                    }
                    //Thread thread = new Thread(() => Clipboard.SetText(ffm + " " + AppParam));
                    //thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                    //thread.Start();
                    //thread.Join(); //Wait for the thread to end
                    
                    process_glob.StartInfo.FileName = ffm;
                    process_glob.StartInfo.Arguments = AppParam;                    
                    process_glob.StartInfo.RedirectStandardOutput = true;
                    process_glob.StartInfo.RedirectStandardError = true;
                    process_glob.StartInfo.RedirectStandardInput = true;
                    process_glob.StartInfo.UseShellExecute = false;
                    process_glob.StartInfo.CreateNoWindow = true;
                    process_glob.EnableRaisingEvents = true;

                    valid_prog = false;

                    process_glob.Start();
                    System.Threading.Thread.Sleep(50);                    

                    String err_txt = "";
                    Double sec_prog = 0;
                    Double interval = 0;
                    Decimal est_bitrate = 0;
                    Decimal est_size = 0;
                    lbl_bitrate.Text = "";
                    lbl_est_size.Text = "";

                    while (!process_glob.StandardError.EndOfStream)
                    {
                        err_txt = process_glob.StandardError.ReadLine();
                        list_lines.Add(err_txt);

                        if (err_txt.Contains("time=") && err_txt.Contains("time=-") == false)
                        {
                            this.InvokeEx(f => durat_n = TimeSpan.Parse(listView1.Items[list_index].SubItems[2].Text).TotalSeconds + TimeSpan.Parse(duracion_intro).TotalSeconds + TimeSpan.Parse(duracion_salida).TotalSeconds);
                            int start_time_index = err_txt.IndexOf("time=") + 5;
                            sec_prog = TimeSpan.Parse(err_txt.Substring(start_time_index, 8)).TotalSeconds;

                            Double percent = (sec_prog * 100 / durat_n);

                            total_prog = total_prog + (sec_prog - interval);
                            interval = sec_prog;
                            int percent2 = Convert.ToInt32(percent);

                            Double percent_tot = (total_prog * 100 / total_duration);
                            int percent_tot_2 = Convert.ToInt32(percent_tot);

                            if (percent_tot_2 <= 100)
                            {
                                this.InvokeEx(f => f.Pg1.Value = percent_tot_2);
                                this.InvokeEx(f => f.Pg1.Refresh());

                                if (Math.Round(percent_tot, 1).ToString().Contains(".") || Math.Round(percent_tot, 1).ToString().Contains(","))
                                {
                                    this.InvokeEx(f => f.txt_pg1_prog.Text = Math.Round(percent_tot, 1).ToString() + "%");
                                }
                                else
                                {
                                    this.InvokeEx(f => f.txt_pg1_prog.Text = Math.Round(percent_tot, 1).ToString() + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "0" + "%");
                                }

                                this.InvokeEx(f => TaskbarProgress.SetValue(this.Handle, percent_tot, Pg1.Maximum));
                            }

                            if (percent2 <= 100)
                            {
                                if (Math.Round(percent, 1).ToString().Contains(".") || Math.Round(percent, 1).ToString().Contains(","))
                                {
                                    this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = Math.Round(percent, 1).ToString() + "%");

                                }
                                else
                                {
                                    this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = Math.Round(percent, 1).ToString() + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "0" + "%");

                                }
                            }
                            //Estimated remaining time

                            remain_time = err_txt.Substring(err_txt.LastIndexOf("speed=") + 6, err_txt.Length - err_txt.LastIndexOf("speed=") - 6);
                            remain_time = remain_time.Replace("x", String.Empty);

                            Double timing1 = 0;

                            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                            {
                                timing1 = Math.Round(Double.Parse(remain_time.Replace(".", ",")), 2);
                            }
                            else
                            {
                                timing1 = Math.Round(Double.Parse(remain_time), 2);
                            }
                            Decimal timing = (decimal)timing1;
                            Decimal total_dur_dec = Convert.ToDecimal(total_duration);
                            Decimal total_prog_dec = Convert.ToDecimal(sec_prog);
                            Decimal remain_secs = 0;
                            if (timing > 0)
                            {
                                remain_secs = (decimal)(total_dur_dec - total_prog_dec) / timing;
                            }

                            if (remain_secs > 60)
                            {
                                remain_secs = remain_secs + 60;
                            }
                            String remain_from_secs = "";

                            TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(remain_secs));
                            remain_from_secs = string.Format("{0:D2}h:{1:D2}",
                               t.Hours,
                              t.Minutes);

                            if (remain_secs >= 3600)
                            {
                                if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs + " min");
                                if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs + " min");
                            }

                            if (remain_secs < 3600 && remain_secs >= 600)
                            {
                                if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutos");
                                if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 1, 2) + " minutes");
                            }
                            if (remain_secs < 600 && remain_secs >= 120)
                            {
                                if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutos");
                                if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + remain_from_secs.Substring(remain_from_secs.LastIndexOf(":") + 2, 1) + " minutes");
                            }

                            if (remain_secs <= 59)
                            {
                                if (language == "es") this.InvokeEx(f => f.txt_remain.Text = "Tiempo restante: " + Convert.ToInt16(remain_secs) + " segundo(s)");
                                if (language == "en") this.InvokeEx(f => f.txt_remain.Text = "Remaining time: " + Convert.ToInt16(remain_secs) + " second(s)");
                            }
                            this.InvokeEx(f => f.txt_remain.Refresh());

                            //End remaining time
                            //Estimated size and bitrate

                            String read_size = String.Empty;
                            if (err_txt.Contains("size=") && (time_est_size % 3 == 0))
                            {
                                int size_index = err_txt.IndexOf("size=") + 5;
                                read_size = err_txt.Substring(size_index, 8);
                                if (Convert.ToDecimal(sec_prog) != 0)
                                {
                                    est_bitrate = (Math.Round(Convert.ToDecimal(read_size) * 8 / Convert.ToDecimal(sec_prog), 0));
                                }
                                else
                                {
                                    est_bitrate = 0;
                                }

                                if (Convert.ToDecimal(read_size) > 1 && time_n_tasks > 1)
                                {
                                    if (est_bitrate < 9999)
                                    {
                                        if (est_bitrate > 48)
                                        {
                                            this.InvokeEx(f => f.lbl_bitrate.Text = "Avg. bitrate: " + est_bitrate + " Kb/s");
                                        }
                                        else
                                        {
                                            this.InvokeEx(f => f.lbl_bitrate.Text = "Avg. bitrate: ");
                                        }
                                    }
                                    else
                                    {
                                        this.InvokeEx(f => f.lbl_bitrate.Text = "Avg. bitrate: " + (Math.Round(est_bitrate / 1000, 0)) + " Mb/s");
                                    }
                                    //Estimated size
                                    est_size = Convert.ToDecimal(durat_n) * est_bitrate / 8;

                                    if (est_size > 1000000)
                                    {
                                        this.InvokeEx(f => f.lbl_est_size.Text = "Estimated size: " + (Math.Round(est_size / 1000000, 1)).ToString() + " GB");
                                    }
                                    else
                                    {
                                        if (Math.Round(est_size / 1000, 0) > 0)
                                        {
                                            this.InvokeEx(f => f.lbl_est_size.Text = "Estimated size: " + (Math.Round(est_size / 1000, 0)).ToString() + " MB");
                                        }
                                        else
                                        {
                                            this.InvokeEx(f => f.lbl_est_size.Text = "Estimated size: ");
                                        }
                                    }
                                }
                                if (time_est_size % 3 == 0) this.InvokeEx(f => f.lbl_speed.Text = remain_time.Trim() + "x");
                                this.InvokeEx(f => f.lbl_est_size.Refresh());
                            }
                        }

                    }
                    //While encoding
                    process_glob.WaitForExit();
                    process_glob.StartInfo.Arguments = String.Empty;
                    this.InvokeEx(f => TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress));
                    list_lines.Add("");

                    if (process_glob.ExitCode == 0)
                    {
                        this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = "Success");
                    }
                    else
                    {
                        errors = errors + 1;
                        this.InvokeEx(f => f.listView1.Items[list_index].SubItems[4].Text = "Error");
                    }
                    this.InvokeEx(f => f.lbl_bitrate.Text = "");
                    this.InvokeEx(f => f.lbl_est_size.Text = "");
                    this.InvokeEx(f => f.lbl_speed.Text = "");
                    list_index++;

                    if (list_index == list_proc.Items.Count)
                    {
                        working = false;
                        Enable_Controls();
                        this.InvokeEx(f => f.Pg1.Value = Pg1.Maximum);
                        this.InvokeEx(f => f.txt_pg1_prog.Text = "100" + "%");

                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                        if (Form.ActiveForm == null)
                        {
                            if (errors == 0)
                            {
                                if (language == "es")
                                {
                                    notifyIcon1.BalloonTipText = "Concatenación completada con éxito";
                                    notifyIcon1.BalloonTipTitle = "Concatenation completada";
                                }
                                if (language == "en")
                                {
                                    notifyIcon1.BalloonTipText = "Concatenation successfully completed";
                                    notifyIcon1.BalloonTipTitle = "Concatenation complete";
                                }
                                notifyIcon1.ShowBalloonTip(0);
                            }
                            else
                            {
                                if (language == "es")
                                {
                                    notifyIcon1.BalloonTipText = "Concatenación completada con errores";
                                    notifyIcon1.BalloonTipTitle = "Concatenation completada";
                                }
                                if (language == "en")
                                {
                                    notifyIcon1.BalloonTipText = "Concatenation completed with errors";
                                    notifyIcon1.BalloonTipTitle = "Concatenation complete";
                                }
                                notifyIcon1.ShowBalloonTip(1);
                            }
                        }
                        else
                        {
                            if (errors > 0 && aborted == false)
                            {
                                if (language == "es")
                                {
                                    MessageBox.Show("Se produjeron " + errors.ToString() + " error(es) durante la concatenación. Puede revisar el log para más información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                if (language == "en")
                                {
                                    MessageBox.Show("There were " + errors.ToString() + " error(s) during queue concatention. You can check log for more information.", "Errors found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                            if (Directory.GetFiles(destino).Length != 0)
                            {
                                Process open_processed = new Process();
                                open_processed.StartInfo.FileName = "explorer.exe";
                                open_processed.StartInfo.Arguments = '\u0022' + destino + '\u0022';
                                open_processed.Start();
                            }                         

                        working = false;
                        Enable_Controls();
                        if (Directory.GetFiles(destino).Length == 0)
                        {
                            if (Directory.Exists(destino))
                            {
                                System.IO.Directory.Delete(destino);
                            }
                        }
                        if (cancel_queue == true)
                        {
                            foreach (ListViewItem item in list_proc.Items)
                            {                                
                                this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Aborted");
                            }
                        }
                        else
                        {
                            foreach (ListViewItem item in list_proc.Items)
                            {
                             //   this.InvokeEx(f => f.listView1.Items[item.Index].SubItems[4].Text = "Error");
                            }

                        }
                        if (aborted == true)
                        {
                            if (language == "en") MessageBox.Show("Concatenation aborted by user", "Concatenation Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (language == "es") MessageBox.Show("Concatenación abortada por el usuario", "Concatenación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        //Save log
                        string[] array_err = list_lines.ToArray();
                        String path_l = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.log";

                        System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path_l);
                        SaveFile.WriteLine("FFmpeg log session: " + System.DateTime.Now);
                        SaveFile.WriteLine("-------------------------------");
                        foreach (String item in array_err)
                        {
                            SaveFile.WriteLine(item);
                        }
                        SaveFile.Close();

                        File.AppendAllText(path_l, "-----------------------");
                        File.AppendAllText(path_l, Environment.NewLine + "END OF LOG FILE" + Environment.NewLine);
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(path_l);

                        var bytes = fileInfo.Length;

                        var kilobytes = (double)bytes / 1024;
                        var megabytes = kilobytes / 1024;
                        var gigabytes = megabytes / 1024;

                        //Format size view
                        String size = "";
                        String separator = ".";

                        if (bytes > 1000000000)
                        {
                            if (gigabytes.ToString().Contains("."))
                            {
                                separator = ".";
                            }
                            else
                            {
                                separator = ",";
                            }

                            String gigas = gigabytes.ToString();
                            if (gigas.Length >= 5)
                            {
                                gigas = gigas.Substring(0, gigas.LastIndexOf(separator) + 3);
                                size = (gigas + " GB");
                            }
                            else
                            {
                                size = (gigas + " GB");
                            }
                        }

                        if (bytes >= 1048576 && bytes <= 1000000000)
                        {
                            if (megabytes.ToString().Contains("."))
                            {
                                separator = ".";
                            }
                            else
                            {
                                separator = ",";
                            }
                            String megas = megabytes.ToString();
                            if (megas.Length > 5)
                            {
                                megas = megas.Substring(0, megas.LastIndexOf(separator));
                                size = (megas + " MB");
                            }
                            else
                            {
                                size = (megas + " MB");
                            }
                        }

                        if (bytes >= 1024 && bytes < 1048576)

                        {
                            if (kilobytes.ToString().Contains("."))
                            {
                                separator = ".";
                            }
                            else
                            {
                                separator = ",";
                            }

                            String kbs = kilobytes.ToString();
                            if (kbs.Length >= 5)
                            {
                                kbs = kbs.Substring(0, kbs.LastIndexOf(separator));
                                size = (kbs + " KB");
                            }
                            else
                            {
                                size = (kbs + " KB");
                            }
                        }
                        if (bytes > -1 && bytes < 1024)
                        {
                            String bits = bytes.ToString();
                            size = (bits + " Bytes");
                        }

                        //End Format size view
                        File.AppendAllText(path_l, Environment.NewLine + "LOG SIZE: " + size);

                        //End save log


                        if (File.Exists(System.IO.Path.Combine(Application.StartupPath, "concat.txt")))
                        {
                            File.Delete(System.IO.Path.Combine(Application.StartupPath, "concat.txt"));
                        }

                        Enable_Controls();
                    }
                }

            }).Start();
        }

        private void btn_logs_Click(object sender, EventArgs e)
        {
            Pg1.Focus();
            String path_log_file = System.IO.Path.Combine(Environment.GetEnvironmentVariable("appdata"), "FFBatch_UPM") + "\\" + "ff_batch.log";
            if (!File.Exists(path_log_file))
            {
                if (no_save_logs == true) MessageBox.Show("No log file was found. Log saving is disabled.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                if (no_save_logs == false) MessageBox.Show("No log file was found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long length = new System.IO.FileInfo(path_log_file).Length;
            if (length > 20000000)
            {
                var a = MessageBox.Show("Log size is " + (length / 1024).ToString() + " KB " + "and it could take some time to load. Continue?", "Log size warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.No) return;
            }

            //Form frm_output = new Form();
            frm_log.Name = "Last session Batch log";
            frm_log.Text = "FFmpeg Batch AV Converter";
            frm_log.Icon = this.Icon;

            frm_log.Height = 675;
            frm_log.Width = 977;
            frm_log.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm_log.MaximizeBox = false;
            frm_log.MinimizeBox = false;

            var fuente_list = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular);

            Rtxt.Parent = frm_log;
            Rtxt.Left = 20;
            Rtxt.Top = 65;
            Rtxt.Height = 525;
            Rtxt.Width = 920;
            Rtxt.Font = fuente_list;

            ContextMenu Rtxt_menu = new ContextMenu();
            Rtxt.ContextMenu = Rtxt_menu;
            MenuItem CopyItem = new MenuItem("Copy");
            Rtxt_menu.MenuItems.Add(CopyItem);
            CopyItem.Click += new EventHandler(CopyAction);

            TextBox titulo = new TextBox();
            titulo.Parent = frm_log;
            titulo.Top = 15;
            titulo.Left = 20;
            titulo.Width = 921;
            titulo.TabIndex = 0;
            var fuente = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            titulo.Font = fuente;
            titulo.BorderStyle = BorderStyle.Fixed3D;
            titulo.TextAlign = HorizontalAlignment.Center;
            titulo.ReadOnly = true;

            titulo.Text = " Last batch log";

            Button boton_ok_ff = new Button();
            boton_ok_ff.Parent = frm_log;
            boton_ok_ff.Left = 20;
            boton_ok_ff.Top = 595;
            boton_ok_ff.Width = 920;
            boton_ok_ff.Height = 27;
            boton_ok_ff.Text = "Opening log file...";
            boton_ok_ff.Click += new EventHandler(boton_ok_ff_Click);

            TextBox titulo2 = new TextBox();
            titulo2.Parent = frm_log;
            titulo2.Top = 42;
            titulo2.Left = 47;
            titulo2.Width = 867;

            var fuente2 = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            titulo2.Font = fuente2;
            titulo2.BorderStyle = BorderStyle.None;
            titulo2.TextAlign = HorizontalAlignment.Center;
            titulo2.ReadOnly = true;

            titulo2.Text = "ff_batch.log";

            frm_log.StartPosition = FormStartPosition.CenterScreen;
            Rtxt.Text = File.ReadAllText(path_log_file);
            boton_ok_ff.Text = "Close window";
            frm_log.ShowDialog();
            frm_log.Refresh();
        }

        private void ct_move_up_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[4].Text == "Queued")
                {
                    lvwColumnSorter_Full.Order = SortOrder.None;
                    var currentIndex = listView1.SelectedItems[0].Index;
                    var item = listView1.Items[listView1.SelectedIndices[0]];
                    if (currentIndex > 0 && listView1.Items[currentIndex - 1].SubItems[4].Text == "Queued")
                    {
                        listView1.Items.RemoveAt(currentIndex);
                        listView1.Items.Insert(0, item);
                    }
                }
            }
        }

        private void ct_move_down_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[4].Text == "Queued")
            {
                lvwColumnSorter_Full.Order = SortOrder.None;
                var currentIndex = listView1.SelectedItems[0].Index;
                var item = listView1.Items[listView1.SelectedIndices[0]];
                if (currentIndex > -1 && currentIndex < listView1.Items.Count - 1)
                {
                    listView1.Items.RemoveAt(currentIndex);
                    listView1.Items.Insert(listView1.Items.Count, item);
                }
            }
        }
        private void cb_q_SelectedIndexChanged(object sender, EventArgs e)
        {
            FFBatch_UPM.Properties.Settings.Default.enc_q = cb_q.SelectedIndex;
            FFBatch_UPM.Properties.Settings.Default.Save();
        }

        private void cb_hw_enc_SelectedIndexChanged(object sender, EventArgs e)
        {
            FFBatch_UPM.Properties.Settings.Default.hw_enc = cb_hw_enc.SelectedIndex;
            FFBatch_UPM.Properties.Settings.Default.Save();
        }

        private void chk_preset_CheckedChanged_1(object sender, EventArgs e)
        {
            FFBatch_UPM.Properties.Settings.Default.quick_mode = chk_preset.Checked;
            FFBatch_UPM.Properties.Settings.Default.Save();
        }

        private void chk_compat_CheckedChanged(object sender, EventArgs e)
        {
            FFBatch_UPM.Properties.Settings.Default.compt_mode = chk_compat.Checked;
            FFBatch_UPM.Properties.Settings.Default.Save();
        }

        // End code
    } //Form Class


    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }

    //Pause code

    [Flags]
    public enum ThreadAccess : int
    {
        TERMINATE = (0x0001),
        SUSPEND_RESUME = (0x0002),
        GET_CONTEXT = (0x0008),
        SET_CONTEXT = (0x0010),
        SET_INFORMATION = (0x0020),
        QUERY_INFORMATION = (0x0040),
        SET_THREAD_TOKEN = (0x0080),
        IMPERSONATE = (0x0100),
        DIRECT_IMPERSONATION = (0x0200)
    }

    public enum EXECUTION_STATE : uint
    {
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001,
    }


    public static class NativeMethods
    {

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [DllImport("kernel32.dll")]
        private static extern uint SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        private static extern int ResumeThread(IntPtr hThread);


        public static void Suspend(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }
                SuspendThread(pOpenThread);
            }
        }

        public static void Resume(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }
                ResumeThread(pOpenThread);
            }
        }
    }

    //End pause code
    //Flickering progress bar text
    public class ProgressBarWithText : ProgressBar
    {
        private const int WmPaint = 15;
        private SizeF TextSize;
        private PointF TextPos;

        public ProgressBarWithText()
        {
            this.DoubleBuffered = true;
            this.TextChanged += ProgressBarWithText_TextChanged;
            this.SizeChanged += ProgressBarWithText_SizeChanged;
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void RecalcTextPos()
        {
            if (string.IsNullOrEmpty(base.Text))
                return;

            using (var graphics = Graphics.FromHwnd(this.Handle))
            {
                TextSize = graphics.MeasureString(base.Text, this.Font);
                TextPos.X = (this.Width / 2) - (TextSize.Width / 2) + 1;
                TextPos.Y = (this.Height / 2) - (TextSize.Height / 2) + 1;
            }
        }

        private void ProgressBarWithText_SizeChanged(object sender, EventArgs e)
        {
            RecalcTextPos();
        }

        private void ProgressBarWithText_TextChanged(object sender, EventArgs e)
        {
            RecalcTextPos();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WmPaint:
                    using (var graphics = Graphics.FromHwnd(Handle))
                        graphics.DrawString(base.Text, base.Font, Brushes.Black, TextPos.X, TextPos.Y);

                    break;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams result = base.CreateParams;
                result.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return result;
            }
        }
    }

    public static class TaskbarProgress
    {
        public enum TaskbarStates
        {
            NoProgress = 0,
            Indeterminate = 0x1,
            Normal = 0x2,
            Error = 0x4,
            Paused = 0x8
        }

        [ComImport()]
        [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ITaskbarList3
        {
            // ITaskbarList
            [PreserveSig]
            void HrInit();

            [PreserveSig]
            void AddTab(IntPtr hwnd);

            [PreserveSig]
            void DeleteTab(IntPtr hwnd);

            [PreserveSig]
            void ActivateTab(IntPtr hwnd);

            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);

            // ITaskbarList2
            [PreserveSig]
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            // ITaskbarList3
            [PreserveSig]
            void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);

            [PreserveSig]
            void SetProgressState(IntPtr hwnd, TaskbarStates state);
        }

        [ComImport()]
        [Guid("56fdf344-fd6d-11d0-958a-006097c9a090")]
        [ClassInterface(ClassInterfaceType.None)]
        private class TaskbarInstance
        {
        }

        private static ITaskbarList3 taskbarInstance = (ITaskbarList3)new TaskbarInstance();
        private static bool taskbarSupported = Environment.OSVersion.Version >= new Version(6, 1);

        public static void SetState(IntPtr windowHandle, TaskbarStates taskbarState)
        {
            if (taskbarSupported) taskbarInstance.SetProgressState(windowHandle, taskbarState);
        }

        public static void SetValue(IntPtr windowHandle, double progressValue, double progressMax)
        {
            if (taskbarSupported) taskbarInstance.SetProgressValue(windowHandle, (ulong)progressValue, (ulong)progressMax);
        }
    }

    //END APP
}