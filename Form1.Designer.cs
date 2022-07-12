namespace FFBatch_main
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ctm1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctm_add_files = new System.Windows.Forms.ToolStripMenuItem();
            this.ctm_add_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cti2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cti1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cti3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ctdel = new System.Windows.Forms.ToolStripMenuItem();
            this.ctm1_queue = new System.Windows.Forms.ToolStripMenuItem();
            this.ct_move_up = new System.Windows.Forms.ToolStripMenuItem();
            this.ct_move_down = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cti4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ct1_total_frames = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.cti4_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cti6 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.img_list_4 = new System.Windows.Forms.ImageList(this.components);
            this.Timer_apaga = new System.Windows.Forms.Timer(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.img_tabc = new System.Windows.Forms.ImageList(this.components);
            this.img_streams = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.timer_tasks = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.BG_Dur = new System.ComponentModel.BackgroundWorker();
            this.BG_Files = new System.ComponentModel.BackgroundWorker();
            this.BG_P_Dur = new System.ComponentModel.BackgroundWorker();
            this.BG_Validate_URLs = new System.ComponentModel.BackgroundWorker();
            this.folderBrowser_m3u = new System.Windows.Forms.FolderBrowserDialog();
            this.timer_est_size = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.img_abort = new System.Windows.Forms.ImageList(this.components);
            this.BG_refresh_dur = new System.ComponentModel.BackgroundWorker();
            this.Timer_idle = new System.Windows.Forms.Timer(this.components);
            this.watch_ff = new System.IO.FileSystemWatcher();
            this.img_undo = new System.Windows.Forms.ImageList(this.components);
            this.BG_Vfilter = new System.ComponentModel.BackgroundWorker();
            this.BG_AFilter = new System.ComponentModel.BackgroundWorker();
            this.timer_adding = new System.Windows.Forms.Timer(this.components);
            this.BG_Video_Bitrate = new System.ComponentModel.BackgroundWorker();
            this.img_try = new System.Windows.Forms.ImageList(this.components);
            this.watch_other_instance = new System.IO.FileSystemWatcher();
            this.openFile_Heads = new System.Windows.Forms.OpenFileDialog();
            this.item_up = new System.Windows.Forms.Button();
            this.item_down = new System.Windows.Forms.Button();
            this.requeue = new System.Windows.Forms.Button();
            this.lbl_items = new System.Windows.Forms.Label();
            this.lbl_dur_list = new System.Windows.Forms.Label();
            this.lbl_size = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.txt_adding_p = new System.Windows.Forms.TextBox();
            this.LB_Wait = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.btn_cancel_add = new System.Windows.Forms.Button();
            this.pg_adding = new System.Windows.Forms.ProgressBar();
            this.txt_add_remain = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_cl_list = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_rel_path = new System.Windows.Forms.Button();
            this.btn_reset_path = new System.Windows.Forms.Button();
            this.btn_save_path = new System.Windows.Forms.Button();
            this.chk_preset = new System.Windows.Forms.CheckBox();
            this.chk_compat = new System.Windows.Forms.CheckBox();
            this.chk_vid_cod = new System.Windows.Forms.CheckBox();
            this.cb_hw_enc = new System.Windows.Forms.ComboBox();
            this.btn_logs = new System.Windows.Forms.Button();
            this.cb_q = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.chk_forceff = new System.Windows.Forms.CheckBox();
            this.btn_add_files = new System.Windows.Forms.Button();
            this.btn_clear_list = new System.Windows.Forms.Button();
            this.chk_subfolders = new System.Windows.Forms.CheckBox();
            this.btn_add_folders = new System.Windows.Forms.Button();
            this.btn_help = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_edit_config = new System.Windows.Forms.Button();
            this.chk_auto_updates = new System.Windows.Forms.CheckBox();
            this.check_concat = new System.Windows.Forms.CheckBox();
            this.btn_concat = new System.Windows.Forms.Button();
            this.btn_concat_2 = new System.Windows.Forms.Button();
            this.btn_silence = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.combo_lang = new System.Windows.Forms.ComboBox();
            this.lbl_lang = new System.Windows.Forms.Label();
            this.btn_one_one = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_video_intro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_video_salida = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_clear_intro = new System.Windows.Forms.Button();
            this.btn_clear_credits = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col1_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_pg1_prog = new System.Windows.Forms.TextBox();
            this.Pg1 = new System.Windows.Forms.ProgressBar();
            this.txt_remain = new System.Windows.Forms.Label();
            this.lbl_est_size = new System.Windows.Forms.Label();
            this.lbl_bitrate = new System.Windows.Forms.Label();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.lbl_elapsed = new System.Windows.Forms.Label();
            this.btn_abort_all = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.pic_resume = new System.Windows.Forms.PictureBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ctm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watch_ff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watch_other_instance)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_resume)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add-files.png");
            this.imageList1.Images.SetKeyName(1, "Reload_new.png");
            this.imageList1.Images.SetKeyName(2, "Save-icon.png");
            this.imageList1.Images.SetKeyName(3, "folder-add-icon.png");
            this.imageList1.Images.SetKeyName(4, "Actions-view-list-details-icon.png");
            this.imageList1.Images.SetKeyName(5, "minus - Red.png");
            this.imageList1.Images.SetKeyName(6, "default_save.png");
            this.imageList1.Images.SetKeyName(7, "add_39_3.png");
            this.imageList1.Images.SetKeyName(8, "url-sign-link-domain-512.png");
            this.imageList1.Images.SetKeyName(9, "Script-Console-icon.png");
            this.imageList1.Images.SetKeyName(10, "Script-Console-icon_Check.png");
            this.imageList1.Images.SetKeyName(11, "kill_process.png");
            this.imageList1.Images.SetKeyName(12, "Script-Console-icon_Check.png");
            this.imageList1.Images.SetKeyName(13, "clear_list.png");
            this.imageList1.Images.SetKeyName(14, "cut_file.png");
            this.imageList1.Images.SetKeyName(15, "Video_concatenar.png");
            this.imageList1.Images.SetKeyName(16, "concat2.png");
            this.imageList1.Images.SetKeyName(17, "concat.png");
            this.imageList1.Images.SetKeyName(18, "Screen_capture_39.png");
            this.imageList1.Images.SetKeyName(19, "Reset_39.png");
            this.imageList1.Images.SetKeyName(20, "default_save_V2.png");
            this.imageList1.Images.SetKeyName(21, "load_file_v2.png");
            this.imageList1.Images.SetKeyName(22, "stop_32.png");
            this.imageList1.Images.SetKeyName(23, "skip_39.png");
            this.imageList1.Images.SetKeyName(24, "Check_URLs_v2.png");
            this.imageList1.Images.SetKeyName(25, "clean_urls.png");
            this.imageList1.Images.SetKeyName(26, "delete-icon_18.png");
            this.imageList1.Images.SetKeyName(27, "Save_settings_39.png");
            this.imageList1.Images.SetKeyName(28, "skip_square2.png");
            this.imageList1.Images.SetKeyName(29, "skip_button_41.png");
            this.imageList1.Images.SetKeyName(30, "save_pending.png");
            this.imageList1.Images.SetKeyName(31, "Resume_encoding_38.png");
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ctm1
            // 
            this.ctm1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.ctm1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctm_add_files,
            this.ctm_add_folder,
            this.toolStripSeparator2,
            this.cti2,
            this.cti1,
            this.cti3,
            this.toolStripSeparator8,
            this.ctdel,
            this.ctm1_queue,
            this.ct_move_up,
            this.ct_move_down,
            this.toolStripSeparator1,
            this.cti4,
            this.ct1_total_frames,
            this.toolStripSeparator15,
            this.cti4_2,
            this.cti6});
            this.ctm1.Name = "ctm1";
            resources.ApplyResources(this.ctm1, "ctm1");
            this.ctm1.Opening += new System.ComponentModel.CancelEventHandler(this.ctm1_Opening);
            // 
            // ctm_add_files
            // 
            resources.ApplyResources(this.ctm_add_files, "ctm_add_files");
            this.ctm_add_files.Name = "ctm_add_files";
            this.ctm_add_files.Click += new System.EventHandler(this.ctm_add_files_Click);
            // 
            // ctm_add_folder
            // 
            resources.ApplyResources(this.ctm_add_folder, "ctm_add_folder");
            this.ctm_add_folder.Name = "ctm_add_folder";
            this.ctm_add_folder.Click += new System.EventHandler(this.ctm_add_folder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // cti2
            // 
            resources.ApplyResources(this.cti2, "cti2");
            this.cti2.Name = "cti2";
            this.cti2.Click += new System.EventHandler(this.cti2_Click);
            // 
            // cti1
            // 
            resources.ApplyResources(this.cti1, "cti1");
            this.cti1.Name = "cti1";
            this.cti1.Click += new System.EventHandler(this.cti1_Click);
            // 
            // cti3
            // 
            resources.ApplyResources(this.cti3, "cti3");
            this.cti3.Name = "cti3";
            this.cti3.Click += new System.EventHandler(this.cti3_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // ctdel
            // 
            resources.ApplyResources(this.ctdel, "ctdel");
            this.ctdel.Name = "ctdel";
            this.ctdel.Click += new System.EventHandler(this.ctdel_Click);
            // 
            // ctm1_queue
            // 
            resources.ApplyResources(this.ctm1_queue, "ctm1_queue");
            this.ctm1_queue.Name = "ctm1_queue";
            this.ctm1_queue.Click += new System.EventHandler(this.ctm1_queue_Click);
            // 
            // ct_move_up
            // 
            resources.ApplyResources(this.ct_move_up, "ct_move_up");
            this.ct_move_up.Name = "ct_move_up";
            this.ct_move_up.Click += new System.EventHandler(this.ct_move_up_Click);
            // 
            // ct_move_down
            // 
            resources.ApplyResources(this.ct_move_down, "ct_move_down");
            this.ct_move_down.Name = "ct_move_down";
            this.ct_move_down.Click += new System.EventHandler(this.ct_move_down_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // cti4
            // 
            resources.ApplyResources(this.cti4, "cti4");
            this.cti4.Name = "cti4";
            this.cti4.Click += new System.EventHandler(this.cti4_Click);
            // 
            // ct1_total_frames
            // 
            resources.ApplyResources(this.ct1_total_frames, "ct1_total_frames");
            this.ct1_total_frames.Name = "ct1_total_frames";
            this.ct1_total_frames.Click += new System.EventHandler(this.ct1_total_frames_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            // 
            // cti4_2
            // 
            resources.ApplyResources(this.cti4_2, "cti4_2");
            this.cti4_2.Name = "cti4_2";
            this.cti4_2.Click += new System.EventHandler(this.cti4_2_Click);
            // 
            // cti6
            // 
            resources.ApplyResources(this.cti6, "cti6");
            this.cti6.Name = "cti6";
            this.cti6.Click += new System.EventHandler(this.cti6_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // img_list_4
            // 
            this.img_list_4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_list_4.ImageStream")));
            this.img_list_4.TransparentColor = System.Drawing.Color.Transparent;
            this.img_list_4.Images.SetKeyName(0, "Shutdown-26_off.png");
            this.img_list_4.Images.SetKeyName(1, "Shutdown_26_on.png");
            this.img_list_4.Images.SetKeyName(2, "no_sleep_26_2.png");
            this.img_list_4.Images.SetKeyName(3, "no_sleep_26_1.png");
            // 
            // Timer_apaga
            // 
            this.Timer_apaga.Interval = 500;
            this.Timer_apaga.Tick += new System.EventHandler(this.Timer_apaga_Tick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "folder_network.png");
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Name = "label4";
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // img_tabc
            // 
            this.img_tabc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_tabc.ImageStream")));
            this.img_tabc.TransparentColor = System.Drawing.Color.Transparent;
            this.img_tabc.Images.SetKeyName(0, "FFbatch_logo_oct-2019.ico");
            this.img_tabc.Images.SetKeyName(1, "mux_icon.png");
            this.img_tabc.Images.SetKeyName(2, "subs_icon.png");
            this.img_tabc.Images.SetKeyName(3, "link_6.png");
            // 
            // img_streams
            // 
            this.img_streams.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_streams.ImageStream")));
            this.img_streams.TransparentColor = System.Drawing.Color.Transparent;
            this.img_streams.Images.SetKeyName(0, "claqueta_icon_16.png");
            this.img_streams.Images.SetKeyName(1, "audio_icon_16.png");
            this.img_streams.Images.SetKeyName(2, "subs_text_32.png");
            this.img_streams.Images.SetKeyName(3, "minus - Red.png");
            this.img_streams.Images.SetKeyName(4, "image_audio_17.png");
            this.img_streams.Images.SetKeyName(5, "Visualpharm-Must-Have-Text-Document.ico");
            // 
            // openFileDialog2
            // 
            resources.ApplyResources(this.openFileDialog2, "openFileDialog2");
            this.openFileDialog2.Multiselect = true;
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk_1);
            // 
            // timer_tasks
            // 
            this.timer_tasks.Interval = 1000;
            this.timer_tasks.Tick += new System.EventHandler(this.timer_tasks_Tick);
            // 
            // openFileDialog3
            // 
            resources.ApplyResources(this.openFileDialog3, "openFileDialog3");
            this.openFileDialog3.Multiselect = true;
            // 
            // BG_Dur
            // 
            this.BG_Dur.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_Dur_DoWork);
            this.BG_Dur.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BG_Dur_RunWorkerCompleted);
            // 
            // BG_Files
            // 
            this.BG_Files.WorkerSupportsCancellation = true;
            this.BG_Files.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_Files_DoWork);
            this.BG_Files.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BG_Files_RunWorkerCompleted);
            // 
            // BG_P_Dur
            // 
            this.BG_P_Dur.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_P_Dur_DoWork);
            this.BG_P_Dur.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BG_P_Dur_RunWorkerCompleted);
            // 
            // BG_Validate_URLs
            // 
            this.BG_Validate_URLs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_Validate_URLs_DoWork);
            this.BG_Validate_URLs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BG_Validate_URLs_RunWorkerCompleted);
            // 
            // timer_est_size
            // 
            this.timer_est_size.Interval = 1000;
            this.timer_est_size.Tick += new System.EventHandler(this.timer_est_size_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // img_abort
            // 
            this.img_abort.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_abort.ImageStream")));
            this.img_abort.TransparentColor = System.Drawing.Color.Transparent;
            this.img_abort.Images.SetKeyName(0, "Abort_20.png");
            this.img_abort.Images.SetKeyName(1, "audio-icon_20.png");
            this.img_abort.Images.SetKeyName(2, "Reset_Defaults_18.png");
            // 
            // BG_refresh_dur
            // 
            this.BG_refresh_dur.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_refresh_dur_DoWork);
            // 
            // Timer_idle
            // 
            this.Timer_idle.Interval = 30000;
            this.Timer_idle.Tick += new System.EventHandler(this.Timer_idle_Tick);
            // 
            // watch_ff
            // 
            this.watch_ff.EnableRaisingEvents = true;
            this.watch_ff.Filter = "ff*.exe";
            this.watch_ff.SynchronizingObject = this;
            this.watch_ff.Created += new System.IO.FileSystemEventHandler(this.watch_ff_Created);
            this.watch_ff.Deleted += new System.IO.FileSystemEventHandler(this.watch_ff_Deleted);
            this.watch_ff.Renamed += new System.IO.RenamedEventHandler(this.watch_ff_Renamed);
            // 
            // img_undo
            // 
            this.img_undo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_undo.ImageStream")));
            this.img_undo.TransparentColor = System.Drawing.Color.Transparent;
            this.img_undo.Images.SetKeyName(0, "undo_20.png");
            this.img_undo.Images.SetKeyName(1, "redo_20.png");
            // 
            // timer_adding
            // 
            this.timer_adding.Interval = 1000;
            this.timer_adding.Tick += new System.EventHandler(this.timer_adding_Tick);
            // 
            // img_try
            // 
            this.img_try.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_try.ImageStream")));
            this.img_try.TransparentColor = System.Drawing.Color.Transparent;
            this.img_try.Images.SetKeyName(0, "try_40_3.png");
            this.img_try.Images.SetKeyName(1, "try_ok_40.png");
            this.img_try.Images.SetKeyName(2, "try_fail_40.png");
            // 
            // watch_other_instance
            // 
            this.watch_other_instance.EnableRaisingEvents = true;
            this.watch_other_instance.Filter = "*.fftmp";
            this.watch_other_instance.SynchronizingObject = this;
            this.watch_other_instance.Created += new System.IO.FileSystemEventHandler(this.watch_other_instance_Created);
            // 
            // openFile_Heads
            // 
            this.openFile_Heads.RestoreDirectory = true;
            resources.ApplyResources(this.openFile_Heads, "openFile_Heads");
            this.openFile_Heads.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_Heads_FileOk);
            // 
            // item_up
            // 
            this.item_up.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.item_up, "item_up");
            this.item_up.Name = "item_up";
            this.item_up.UseVisualStyleBackColor = true;
            this.item_up.Click += new System.EventHandler(this.item_up_Click);
            // 
            // item_down
            // 
            this.item_down.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.item_down, "item_down");
            this.item_down.Name = "item_down";
            this.item_down.UseVisualStyleBackColor = true;
            this.item_down.Click += new System.EventHandler(this.item_down_Click);
            // 
            // requeue
            // 
            this.requeue.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.requeue, "requeue");
            this.requeue.Name = "requeue";
            this.requeue.UseVisualStyleBackColor = true;
            this.requeue.Click += new System.EventHandler(this.requeue_Click);
            // 
            // lbl_items
            // 
            resources.ApplyResources(this.lbl_items, "lbl_items");
            this.lbl_items.Name = "lbl_items";
            // 
            // lbl_dur_list
            // 
            resources.ApplyResources(this.lbl_dur_list, "lbl_dur_list");
            this.lbl_dur_list.Name = "lbl_dur_list";
            // 
            // lbl_size
            // 
            resources.ApplyResources(this.lbl_size, "lbl_size");
            this.lbl_size.Name = "lbl_size";
            // 
            // btn_refresh
            // 
            this.btn_refresh.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_refresh, "btn_refresh");
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // txt_adding_p
            // 
            this.txt_adding_p.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_adding_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txt_adding_p, "txt_adding_p");
            this.txt_adding_p.Name = "txt_adding_p";
            // 
            // LB_Wait
            // 
            this.LB_Wait.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.LB_Wait.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LB_Wait, "LB_Wait");
            this.LB_Wait.Name = "LB_Wait";
            this.LB_Wait.ReadOnly = true;
            // 
            // button12
            // 
            this.button12.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button12, "button12");
            this.button12.Name = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // btn_cancel_add
            // 
            resources.ApplyResources(this.btn_cancel_add, "btn_cancel_add");
            this.btn_cancel_add.Name = "btn_cancel_add";
            this.btn_cancel_add.UseVisualStyleBackColor = true;
            this.btn_cancel_add.Click += new System.EventHandler(this.btn_cancel_add_Click);
            // 
            // pg_adding
            // 
            resources.ApplyResources(this.pg_adding, "pg_adding");
            this.pg_adding.Name = "pg_adding";
            // 
            // txt_add_remain
            // 
            this.txt_add_remain.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_add_remain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txt_add_remain, "txt_add_remain");
            this.txt_add_remain.Name = "txt_add_remain";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // btn_cl_list
            // 
            this.btn_cl_list.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_cl_list, "btn_cl_list");
            this.btn_cl_list.Name = "btn_cl_list";
            this.btn_cl_list.UseVisualStyleBackColor = true;
            this.btn_cl_list.Click += new System.EventHandler(this.btn_cl_list_Click_1);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            this.label13.DoubleClick += new System.EventHandler(this.label13_DoubleClick);
            // 
            // btn_browse
            // 
            this.btn_browse.FlatAppearance.BorderSize = 0;
            this.btn_browse.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_browse, "btn_browse");
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.button21_Click_1);
            // 
            // txt_path
            // 
            this.txt_path.BackColor = System.Drawing.SystemColors.InactiveBorder;
            resources.ApplyResources(this.txt_path, "txt_path");
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.DoubleClick += new System.EventHandler(this.textBox3_DoubleClick);
            // 
            // btn_rel_path
            // 
            this.btn_rel_path.FlatAppearance.BorderSize = 0;
            this.btn_rel_path.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_rel_path, "btn_rel_path");
            this.btn_rel_path.Name = "btn_rel_path";
            this.btn_rel_path.UseVisualStyleBackColor = true;
            this.btn_rel_path.Click += new System.EventHandler(this.button7_Click_2);
            // 
            // btn_reset_path
            // 
            this.btn_reset_path.FlatAppearance.BorderSize = 0;
            this.btn_reset_path.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_reset_path, "btn_reset_path");
            this.btn_reset_path.Name = "btn_reset_path";
            this.btn_reset_path.UseVisualStyleBackColor = true;
            this.btn_reset_path.Click += new System.EventHandler(this.btn_reset_path_Click);
            // 
            // btn_save_path
            // 
            resources.ApplyResources(this.btn_save_path, "btn_save_path");
            this.btn_save_path.FlatAppearance.BorderSize = 0;
            this.btn_save_path.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_save_path.Name = "btn_save_path";
            this.btn_save_path.UseVisualStyleBackColor = true;
            this.btn_save_path.Click += new System.EventHandler(this.btn_save_path_Click);
            // 
            // chk_preset
            // 
            resources.ApplyResources(this.chk_preset, "chk_preset");
            this.chk_preset.Checked = true;
            this.chk_preset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_preset.Name = "chk_preset";
            this.chk_preset.UseVisualStyleBackColor = true;
            this.chk_preset.CheckedChanged += new System.EventHandler(this.chk_preset_CheckedChanged_1);
            // 
            // chk_compat
            // 
            resources.ApplyResources(this.chk_compat, "chk_compat");
            this.chk_compat.Name = "chk_compat";
            this.chk_compat.UseVisualStyleBackColor = true;
            this.chk_compat.CheckedChanged += new System.EventHandler(this.chk_compat_CheckedChanged);
            // 
            // chk_vid_cod
            // 
            resources.ApplyResources(this.chk_vid_cod, "chk_vid_cod");
            this.chk_vid_cod.Name = "chk_vid_cod";
            this.chk_vid_cod.UseVisualStyleBackColor = true;
            this.chk_vid_cod.CheckedChanged += new System.EventHandler(this.chk_vid_cod_CheckedChanged);
            // 
            // cb_hw_enc
            // 
            this.cb_hw_enc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cb_hw_enc, "cb_hw_enc");
            this.cb_hw_enc.FormattingEnabled = true;
            this.cb_hw_enc.Items.AddRange(new object[] {
            resources.GetString("cb_hw_enc.Items"),
            resources.GetString("cb_hw_enc.Items1"),
            resources.GetString("cb_hw_enc.Items2")});
            this.cb_hw_enc.Name = "cb_hw_enc";
            this.cb_hw_enc.SelectedIndexChanged += new System.EventHandler(this.cb_hw_enc_SelectedIndexChanged);
            // 
            // btn_logs
            // 
            this.btn_logs.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_logs, "btn_logs");
            this.btn_logs.Name = "btn_logs";
            this.btn_logs.UseVisualStyleBackColor = true;
            this.btn_logs.Click += new System.EventHandler(this.btn_logs_Click);
            // 
            // cb_q
            // 
            this.cb_q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_q.FormattingEnabled = true;
            resources.ApplyResources(this.cb_q, "cb_q");
            this.cb_q.Name = "cb_q";
            this.cb_q.SelectedIndexChanged += new System.EventHandler(this.cb_q_SelectedIndexChanged);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // chk_forceff
            // 
            resources.ApplyResources(this.chk_forceff, "chk_forceff");
            this.chk_forceff.Name = "chk_forceff";
            this.chk_forceff.UseVisualStyleBackColor = true;
            // 
            // btn_add_files
            // 
            resources.ApplyResources(this.btn_add_files, "btn_add_files");
            this.btn_add_files.FlatAppearance.BorderSize = 0;
            this.btn_add_files.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_add_files.ImageList = this.imageList1;
            this.btn_add_files.Name = "btn_add_files";
            this.btn_add_files.UseVisualStyleBackColor = true;
            this.btn_add_files.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_clear_list
            // 
            this.btn_clear_list.FlatAppearance.BorderSize = 0;
            this.btn_clear_list.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_clear_list, "btn_clear_list");
            this.btn_clear_list.ImageList = this.imageList1;
            this.btn_clear_list.Name = "btn_clear_list";
            this.btn_clear_list.UseVisualStyleBackColor = true;
            this.btn_clear_list.Click += new System.EventHandler(this.button5_Click);
            // 
            // chk_subfolders
            // 
            resources.ApplyResources(this.chk_subfolders, "chk_subfolders");
            this.chk_subfolders.FlatAppearance.BorderSize = 0;
            this.chk_subfolders.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.chk_subfolders.Name = "chk_subfolders";
            this.chk_subfolders.UseVisualStyleBackColor = false;
            this.chk_subfolders.CheckedChanged += new System.EventHandler(this.chk_subfolders_CheckedChanged);
            // 
            // btn_add_folders
            // 
            resources.ApplyResources(this.btn_add_folders, "btn_add_folders");
            this.btn_add_folders.FlatAppearance.BorderSize = 0;
            this.btn_add_folders.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_add_folders.ImageList = this.imageList1;
            this.btn_add_folders.Name = "btn_add_folders";
            this.btn_add_folders.UseVisualStyleBackColor = true;
            this.btn_add_folders.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_help
            // 
            this.btn_help.FlatAppearance.BorderSize = 0;
            this.btn_help.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_help, "btn_help");
            this.btn_help.Name = "btn_help";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_exit, "btn_exit");
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_edit_config
            // 
            this.btn_edit_config.FlatAppearance.BorderSize = 0;
            this.btn_edit_config.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_edit_config, "btn_edit_config");
            this.btn_edit_config.Name = "btn_edit_config";
            this.btn_edit_config.UseVisualStyleBackColor = true;
            this.btn_edit_config.Click += new System.EventHandler(this.btn_edit_config_Click);
            // 
            // chk_auto_updates
            // 
            resources.ApplyResources(this.chk_auto_updates, "chk_auto_updates");
            this.chk_auto_updates.Checked = true;
            this.chk_auto_updates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_auto_updates.Name = "chk_auto_updates";
            this.chk_auto_updates.UseVisualStyleBackColor = true;
            this.chk_auto_updates.CheckedChanged += new System.EventHandler(this.chk_auto_updates_CheckedChanged);
            // 
            // check_concat
            // 
            resources.ApplyResources(this.check_concat, "check_concat");
            this.check_concat.Name = "check_concat";
            this.check_concat.UseVisualStyleBackColor = true;
            this.check_concat.CheckedChanged += new System.EventHandler(this.check_concat_CheckedChanged);
            // 
            // btn_concat
            // 
            this.btn_concat.FlatAppearance.BorderSize = 0;
            this.btn_concat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_concat, "btn_concat");
            this.btn_concat.ForeColor = System.Drawing.Color.Black;
            this.btn_concat.Name = "btn_concat";
            this.btn_concat.UseVisualStyleBackColor = true;
            this.btn_concat.Click += new System.EventHandler(this.btn_concat_Click);
            // 
            // btn_concat_2
            // 
            this.btn_concat_2.FlatAppearance.BorderSize = 0;
            this.btn_concat_2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_concat_2, "btn_concat_2");
            this.btn_concat_2.ForeColor = System.Drawing.Color.Black;
            this.btn_concat_2.Name = "btn_concat_2";
            this.btn_concat_2.UseVisualStyleBackColor = true;
            this.btn_concat_2.Click += new System.EventHandler(this.btn_concat_2_Click);
            // 
            // btn_silence
            // 
            this.btn_silence.FlatAppearance.BorderSize = 0;
            this.btn_silence.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_silence, "btn_silence");
            this.btn_silence.Name = "btn_silence";
            this.btn_silence.UseVisualStyleBackColor = true;
            this.btn_silence.Click += new System.EventHandler(this.btn_silence_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.groupBox12, "groupBox12");
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // btn_update
            // 
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_update, "btn_update");
            this.btn_update.Name = "btn_update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // combo_lang
            // 
            this.combo_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_lang.FormattingEnabled = true;
            this.combo_lang.Items.AddRange(new object[] {
            resources.GetString("combo_lang.Items"),
            resources.GetString("combo_lang.Items1")});
            resources.ApplyResources(this.combo_lang, "combo_lang");
            this.combo_lang.Name = "combo_lang";
            this.combo_lang.SelectedIndexChanged += new System.EventHandler(this.combo_lang_SelectedIndexChanged);
            // 
            // lbl_lang
            // 
            resources.ApplyResources(this.lbl_lang, "lbl_lang");
            this.lbl_lang.Name = "lbl_lang";
            // 
            // btn_one_one
            // 
            this.btn_one_one.FlatAppearance.BorderSize = 0;
            this.btn_one_one.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_one_one, "btn_one_one");
            this.btn_one_one.ForeColor = System.Drawing.Color.Black;
            this.btn_one_one.Name = "btn_one_one";
            this.btn_one_one.UseVisualStyleBackColor = true;
            this.btn_one_one.Click += new System.EventHandler(this.btn_one_one_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txt_video_intro
            // 
            this.txt_video_intro.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txt_video_intro, "txt_video_intro");
            this.txt_video_intro.Name = "txt_video_intro";
            this.txt_video_intro.ReadOnly = true;
            this.txt_video_intro.DoubleClick += new System.EventHandler(this.txt_video_intro_DoubleClick);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txt_video_salida
            // 
            this.txt_video_salida.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txt_video_salida, "txt_video_salida");
            this.txt_video_salida.Name = "txt_video_salida";
            this.txt_video_salida.ReadOnly = true;
            this.txt_video_salida.DoubleClick += new System.EventHandler(this.txt_video_salida_DoubleClick);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_clear_intro
            // 
            this.btn_clear_intro.FlatAppearance.BorderSize = 0;
            this.btn_clear_intro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_clear_intro, "btn_clear_intro");
            this.btn_clear_intro.Name = "btn_clear_intro";
            this.btn_clear_intro.UseVisualStyleBackColor = true;
            this.btn_clear_intro.Click += new System.EventHandler(this.btn_clear_intro_Click);
            // 
            // btn_clear_credits
            // 
            this.btn_clear_credits.FlatAppearance.BorderSize = 0;
            this.btn_clear_credits.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_clear_credits, "btn_clear_credits");
            this.btn_clear_credits.Name = "btn_clear_credits";
            this.btn_clear_credits.UseVisualStyleBackColor = true;
            this.btn_clear_credits.Click += new System.EventHandler(this.btn_clear_credits_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col1_2,
            this.col2,
            this.col3,
            this.col4});
            this.listView1.ContextMenuStrip = this.ctm1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // col1
            // 
            resources.ApplyResources(this.col1, "col1");
            // 
            // col1_2
            // 
            resources.ApplyResources(this.col1_2, "col1_2");
            // 
            // col2
            // 
            resources.ApplyResources(this.col2, "col2");
            // 
            // col3
            // 
            resources.ApplyResources(this.col3, "col3");
            // 
            // col4
            // 
            resources.ApplyResources(this.col4, "col4");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.ImageList = this.img_tabc;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txt_pg1_prog
            // 
            this.txt_pg1_prog.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_pg1_prog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pg1_prog.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txt_pg1_prog, "txt_pg1_prog");
            this.txt_pg1_prog.ForeColor = System.Drawing.Color.Black;
            this.txt_pg1_prog.Name = "txt_pg1_prog";
            this.txt_pg1_prog.ReadOnly = true;
            this.txt_pg1_prog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox5_MouseClick);
            // 
            // Pg1
            // 
            resources.ApplyResources(this.Pg1, "Pg1");
            this.Pg1.Name = "Pg1";
            // 
            // txt_remain
            // 
            resources.ApplyResources(this.txt_remain, "txt_remain");
            this.txt_remain.Name = "txt_remain";
            // 
            // lbl_est_size
            // 
            resources.ApplyResources(this.lbl_est_size, "lbl_est_size");
            this.lbl_est_size.Name = "lbl_est_size";
            // 
            // lbl_bitrate
            // 
            resources.ApplyResources(this.lbl_bitrate, "lbl_bitrate");
            this.lbl_bitrate.Name = "lbl_bitrate";
            // 
            // lbl_speed
            // 
            resources.ApplyResources(this.lbl_speed, "lbl_speed");
            this.lbl_speed.Name = "lbl_speed";
            // 
            // lbl_elapsed
            // 
            resources.ApplyResources(this.lbl_elapsed, "lbl_elapsed");
            this.lbl_elapsed.Name = "lbl_elapsed";
            // 
            // btn_abort_all
            // 
            this.btn_abort_all.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_abort_all, "btn_abort_all");
            this.btn_abort_all.Name = "btn_abort_all";
            this.btn_abort_all.UseVisualStyleBackColor = true;
            this.btn_abort_all.Click += new System.EventHandler(this.button20_Click_1);
            // 
            // btn_pause
            // 
            this.btn_pause.FlatAppearance.BorderSize = 0;
            this.btn_pause.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.btn_pause, "btn_pause");
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // pic_resume
            // 
            resources.ApplyResources(this.pic_resume, "pic_resume");
            this.pic_resume.Name = "pic_resume";
            this.pic_resume.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pic_resume);
            this.groupBox10.Controls.Add(this.btn_pause);
            this.groupBox10.Controls.Add(this.btn_abort_all);
            this.groupBox10.Controls.Add(this.lbl_elapsed);
            this.groupBox10.Controls.Add(this.lbl_speed);
            this.groupBox10.Controls.Add(this.lbl_bitrate);
            this.groupBox10.Controls.Add(this.lbl_est_size);
            this.groupBox10.Controls.Add(this.txt_remain);
            this.groupBox10.Controls.Add(this.Pg1);
            this.groupBox10.Controls.Add(this.txt_pg1_prog);
            this.groupBox10.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.chk_forceff);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cb_q);
            this.Controls.Add(this.btn_logs);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btn_one_one);
            this.Controls.Add(this.cb_hw_enc);
            this.Controls.Add(this.chk_vid_cod);
            this.Controls.Add(this.chk_compat);
            this.Controls.Add(this.lbl_lang);
            this.Controls.Add(this.combo_lang);
            this.Controls.Add(this.btn_cl_list);
            this.Controls.Add(this.chk_preset);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_clear_credits);
            this.Controls.Add(this.btn_clear_intro);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.btn_save_path);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_reset_path);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_video_salida);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_video_intro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_rel_path);
            this.Controls.Add(this.btn_silence);
            this.Controls.Add(this.btn_concat_2);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.btn_concat);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.txt_add_remain);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pg_adding);
            this.Controls.Add(this.btn_cancel_add);
            this.Controls.Add(this.check_concat);
            this.Controls.Add(this.chk_auto_updates);
            this.Controls.Add(this.btn_edit_config);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.requeue);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.item_down);
            this.Controls.Add(this.item_up);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.LB_Wait);
            this.Controls.Add(this.txt_adding_p);
            this.Controls.Add(this.btn_add_folders);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.chk_subfolders);
            this.Controls.Add(this.lbl_size);
            this.Controls.Add(this.lbl_dur_list);
            this.Controls.Add(this.lbl_items);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_clear_list);
            this.Controls.Add(this.btn_add_files);
            this.Controls.Add(this.groupBox10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ctm1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.watch_ff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watch_other_instance)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_resume)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip ctm1;
        private System.Windows.Forms.ToolStripMenuItem cti1;
        private System.Windows.Forms.ToolStripMenuItem cti2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem cti3;
        private System.Windows.Forms.ToolStripMenuItem cti4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctdel;
        private System.Windows.Forms.ToolStripMenuItem ctm_add_files;
        private System.Windows.Forms.ToolStripMenuItem ctm_add_folder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer Timer_apaga;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList img_streams;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Timer timer_tasks;
        private System.Windows.Forms.ImageList img_tabc;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.ImageList img_list_4;
        private System.ComponentModel.BackgroundWorker BG_Dur;
        private System.ComponentModel.BackgroundWorker BG_Files;
        private System.ComponentModel.BackgroundWorker BG_P_Dur;
        private System.ComponentModel.BackgroundWorker BG_Validate_URLs;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser_m3u;
        private System.Windows.Forms.ToolStripMenuItem cti6;
        private System.Windows.Forms.Timer timer_est_size;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ImageList img_abort;
        private System.ComponentModel.BackgroundWorker BG_refresh_dur;
        private System.Windows.Forms.Timer Timer_idle;
        private System.Windows.Forms.ToolStripMenuItem cti4_2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.IO.FileSystemWatcher watch_ff;
        private System.Windows.Forms.ToolStripMenuItem ctm1_queue;
        private System.Windows.Forms.ImageList img_undo;
        private System.ComponentModel.BackgroundWorker BG_Vfilter;
        private System.ComponentModel.BackgroundWorker BG_AFilter;
        private System.Windows.Forms.Timer timer_adding;
        private System.ComponentModel.BackgroundWorker BG_Video_Bitrate;
        private System.Windows.Forms.ImageList img_try;
        private System.Windows.Forms.ToolStripMenuItem ct1_total_frames;
        private System.IO.FileSystemWatcher watch_other_instance;
        private System.Windows.Forms.OpenFileDialog openFile_Heads;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem ct_move_up;
        private System.Windows.Forms.ToolStripMenuItem ct_move_down;
        private System.Windows.Forms.CheckBox chk_forceff;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cb_q;
        private System.Windows.Forms.Button btn_logs;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_one_one;
        private System.Windows.Forms.ComboBox cb_hw_enc;
        private System.Windows.Forms.CheckBox chk_vid_cod;
        private System.Windows.Forms.CheckBox chk_compat;
        private System.Windows.Forms.Label lbl_lang;
        private System.Windows.Forms.ComboBox combo_lang;
        private System.Windows.Forms.Button btn_cl_list;
        private System.Windows.Forms.CheckBox chk_preset;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_clear_credits;
        private System.Windows.Forms.Button btn_clear_intro;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btn_save_path;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_reset_path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_video_salida;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_video_intro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_rel_path;
        private System.Windows.Forms.Button btn_silence;
        private System.Windows.Forms.Button btn_concat_2;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_concat;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txt_add_remain;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ProgressBar pg_adding;
        private System.Windows.Forms.Button btn_cancel_add;
        private System.Windows.Forms.CheckBox check_concat;
        private System.Windows.Forms.CheckBox chk_auto_updates;
        private System.Windows.Forms.Button btn_edit_config;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button requeue;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button item_down;
        private System.Windows.Forms.Button item_up;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.TextBox LB_Wait;
        private System.Windows.Forms.TextBox txt_adding_p;
        private System.Windows.Forms.Button btn_add_folders;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.CheckBox chk_subfolders;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.Label lbl_dur_list;
        private System.Windows.Forms.Label lbl_items;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col1_2;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.ColumnHeader col4;
        private System.Windows.Forms.Button btn_clear_list;
        private System.Windows.Forms.Button btn_add_files;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.PictureBox pic_resume;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_abort_all;
        private System.Windows.Forms.Label lbl_elapsed;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.Label lbl_bitrate;
        private System.Windows.Forms.Label lbl_est_size;
        private System.Windows.Forms.Label txt_remain;
        private System.Windows.Forms.ProgressBar Pg1;
        private System.Windows.Forms.TextBox txt_pg1_prog;
        private System.Windows.Forms.Label label11;
    }
}

