namespace Mifare処理依頼
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.button_管理_UID取得 = new System.Windows.Forms.Button();
            this.button_管理_システムファイル読込み = new System.Windows.Forms.Button();
            this.button_管理_システムファイル保存 = new System.Windows.Forms.Button();
            this.button_管理_データ書込み = new System.Windows.Forms.Button();
            this.button_管理_データ読込み = new System.Windows.Forms.Button();
            this.button_管理_再構築 = new System.Windows.Forms.Button();
            this.panel_ベース = new System.Windows.Forms.Panel();
            this.button_接続 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox_IPアドレス = new System.Windows.Forms.TextBox();
            this.groupBox_操作クラス = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBox_操作_Ch = new System.Windows.Forms.ComboBox();
            this.textBox_操作_ウェアレベリングセクター数 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox_操作_総セクター数 = new System.Windows.Forms.TextBox();
            this.label_操作_初期化進捗 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label_操作_全データ取得進捗 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button_操作_初期化 = new System.Windows.Forms.Button();
            this.button_操作_全データ取得 = new System.Windows.Forms.Button();
            this.textBox_操作_データ = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_操作_データブロックNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_操作_データセクターNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_操作_データ書込み = new System.Windows.Forms.Button();
            this.button_操作_データ照合 = new System.Windows.Forms.Button();
            this.textBox_操作_システムファイルデータ = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_操作_CheckSHA1 = new System.Windows.Forms.TextBox();
            this.textBox_操作_CheckMD5 = new System.Windows.Forms.TextBox();
            this.textBox_操作_CheckByte = new System.Windows.Forms.TextBox();
            this.textBox_更新_システムファイル更新日時 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button_操作_システムファイルデータ取得 = new System.Windows.Forms.Button();
            this.button_操作_システムファイルデータ書込み = new System.Windows.Forms.Button();
            this.label_操作_UID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_操作_UID取得 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox_全データ表示エリア = new System.Windows.Forms.RichTextBox();
            this.groupBox_管理クラス = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_管理_ウェアレベリングセクター数 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_管理_総セクター数 = new System.Windows.Forms.TextBox();
            this.textBox_管理_データリスト = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_管理_データ種別 = new System.Windows.Forms.ComboBox();
            this.textBox_管理_システムファイルUID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_管理_CheckSHA1 = new System.Windows.Forms.TextBox();
            this.textBox_管理_CheckMD5 = new System.Windows.Forms.TextBox();
            this.textBox_管理_CheckByte = new System.Windows.Forms.TextBox();
            this.textBox_管理_システムファイル日時 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_管理_UID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_管理_初期化 = new System.Windows.Forms.Button();
            this.panel_ベース.SuspendLayout();
            this.groupBox_操作クラス.SuspendLayout();
            this.groupBox_管理クラス.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_管理_UID取得
            // 
            this.button_管理_UID取得.Location = new System.Drawing.Point(6, 18);
            this.button_管理_UID取得.Name = "button_管理_UID取得";
            this.button_管理_UID取得.Size = new System.Drawing.Size(117, 33);
            this.button_管理_UID取得.TabIndex = 1;
            this.button_管理_UID取得.Text = "管理_UID取得";
            this.button_管理_UID取得.UseVisualStyleBackColor = true;
            this.button_管理_UID取得.Click += new System.EventHandler(this.button_管理_UID取得_Click);
            // 
            // button_管理_システムファイル読込み
            // 
            this.button_管理_システムファイル読込み.Location = new System.Drawing.Point(6, 128);
            this.button_管理_システムファイル読込み.Name = "button_管理_システムファイル読込み";
            this.button_管理_システムファイル読込み.Size = new System.Drawing.Size(161, 33);
            this.button_管理_システムファイル読込み.TabIndex = 12;
            this.button_管理_システムファイル読込み.Text = "管理_システムファイル読込み";
            this.button_管理_システムファイル読込み.UseVisualStyleBackColor = true;
            this.button_管理_システムファイル読込み.Click += new System.EventHandler(this.button_管理_システムファイル読込み_Click);
            // 
            // button_管理_システムファイル保存
            // 
            this.button_管理_システムファイル保存.Location = new System.Drawing.Point(6, 167);
            this.button_管理_システムファイル保存.Name = "button_管理_システムファイル保存";
            this.button_管理_システムファイル保存.Size = new System.Drawing.Size(161, 33);
            this.button_管理_システムファイル保存.TabIndex = 13;
            this.button_管理_システムファイル保存.Text = "管理_システムファイル保存";
            this.button_管理_システムファイル保存.UseVisualStyleBackColor = true;
            this.button_管理_システムファイル保存.Click += new System.EventHandler(this.button_管理_システムファイル保存_Click);
            // 
            // button_管理_データ書込み
            // 
            this.button_管理_データ書込み.Location = new System.Drawing.Point(6, 285);
            this.button_管理_データ書込み.Name = "button_管理_データ書込み";
            this.button_管理_データ書込み.Size = new System.Drawing.Size(117, 32);
            this.button_管理_データ書込み.TabIndex = 14;
            this.button_管理_データ書込み.Text = "管理_データ書込み";
            this.button_管理_データ書込み.UseVisualStyleBackColor = true;
            // 
            // button_管理_データ読込み
            // 
            this.button_管理_データ読込み.Location = new System.Drawing.Point(6, 247);
            this.button_管理_データ読込み.Name = "button_管理_データ読込み";
            this.button_管理_データ読込み.Size = new System.Drawing.Size(117, 32);
            this.button_管理_データ読込み.TabIndex = 15;
            this.button_管理_データ読込み.Text = "管理_データ読込み";
            this.button_管理_データ読込み.UseVisualStyleBackColor = true;
            // 
            // button_管理_再構築
            // 
            this.button_管理_再構築.Location = new System.Drawing.Point(6, 414);
            this.button_管理_再構築.Name = "button_管理_再構築";
            this.button_管理_再構築.Size = new System.Drawing.Size(90, 32);
            this.button_管理_再構築.TabIndex = 16;
            this.button_管理_再構築.Text = "管理_再構築";
            this.button_管理_再構築.UseVisualStyleBackColor = true;
            this.button_管理_再構築.Click += new System.EventHandler(this.button_管理_再構築_Click);
            // 
            // panel_ベース
            // 
            this.panel_ベース.Controls.Add(this.button_接続);
            this.panel_ベース.Controls.Add(this.label28);
            this.panel_ベース.Controls.Add(this.textBox_IPアドレス);
            this.panel_ベース.Controls.Add(this.groupBox_操作クラス);
            this.panel_ベース.Controls.Add(this.label9);
            this.panel_ベース.Controls.Add(this.richTextBox_全データ表示エリア);
            this.panel_ベース.Controls.Add(this.groupBox_管理クラス);
            this.panel_ベース.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ベース.Location = new System.Drawing.Point(0, 0);
            this.panel_ベース.Name = "panel_ベース";
            this.panel_ベース.Size = new System.Drawing.Size(955, 539);
            this.panel_ベース.TabIndex = 17;
            // 
            // button_接続
            // 
            this.button_接続.Location = new System.Drawing.Point(207, 13);
            this.button_接続.Name = "button_接続";
            this.button_接続.Size = new System.Drawing.Size(90, 33);
            this.button_接続.TabIndex = 40;
            this.button_接続.Text = "接続";
            this.button_接続.UseVisualStyleBackColor = true;
            this.button_接続.Click += new System.EventHandler(this.button_接続_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(23, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 12);
            this.label28.TabIndex = 38;
            this.label28.Text = "IPアドレス";
            // 
            // textBox_IPアドレス
            // 
            this.textBox_IPアドレス.Location = new System.Drawing.Point(80, 20);
            this.textBox_IPアドレス.Name = "textBox_IPアドレス";
            this.textBox_IPアドレス.Size = new System.Drawing.Size(106, 19);
            this.textBox_IPアドレス.TabIndex = 37;
            this.textBox_IPアドレス.Text = "192.168.111.254";
            // 
            // groupBox_操作クラス
            // 
            this.groupBox_操作クラス.Controls.Add(this.label29);
            this.groupBox_操作クラス.Controls.Add(this.label22);
            this.groupBox_操作クラス.Controls.Add(this.comboBox_操作_Ch);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_ウェアレベリングセクター数);
            this.groupBox_操作クラス.Controls.Add(this.label27);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_総セクター数);
            this.groupBox_操作クラス.Controls.Add(this.label_操作_初期化進捗);
            this.groupBox_操作クラス.Controls.Add(this.label26);
            this.groupBox_操作クラス.Controls.Add(this.label_操作_全データ取得進捗);
            this.groupBox_操作クラス.Controls.Add(this.label23);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_初期化);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_全データ取得);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_データ);
            this.groupBox_操作クラス.Controls.Add(this.label21);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_データブロックNo);
            this.groupBox_操作クラス.Controls.Add(this.label20);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_データセクターNo);
            this.groupBox_操作クラス.Controls.Add(this.label8);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_データ書込み);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_データ照合);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_システムファイルデータ);
            this.groupBox_操作クラス.Controls.Add(this.label19);
            this.groupBox_操作クラス.Controls.Add(this.label15);
            this.groupBox_操作クラス.Controls.Add(this.label16);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_CheckSHA1);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_CheckMD5);
            this.groupBox_操作クラス.Controls.Add(this.textBox_操作_CheckByte);
            this.groupBox_操作クラス.Controls.Add(this.textBox_更新_システムファイル更新日時);
            this.groupBox_操作クラス.Controls.Add(this.label17);
            this.groupBox_操作クラス.Controls.Add(this.label18);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_システムファイルデータ取得);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_システムファイルデータ書込み);
            this.groupBox_操作クラス.Controls.Add(this.label_操作_UID);
            this.groupBox_操作クラス.Controls.Add(this.label14);
            this.groupBox_操作クラス.Controls.Add(this.button_操作_UID取得);
            this.groupBox_操作クラス.Location = new System.Drawing.Point(314, 71);
            this.groupBox_操作クラス.Name = "groupBox_操作クラス";
            this.groupBox_操作クラス.Size = new System.Drawing.Size(318, 450);
            this.groupBox_操作クラス.TabIndex = 3;
            this.groupBox_操作クラス.TabStop = false;
            this.groupBox_操作クラス.Text = "操作クラス";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(239, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(19, 12);
            this.label29.TabIndex = 42;
            this.label29.Text = "Ch";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(119, 377);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 12);
            this.label22.TabIndex = 73;
            this.label22.Text = "ウェアレベリングセクター数";
            // 
            // comboBox_操作_Ch
            // 
            this.comboBox_操作_Ch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_操作_Ch.FormattingEnabled = true;
            this.comboBox_操作_Ch.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox_操作_Ch.Location = new System.Drawing.Point(264, 18);
            this.comboBox_操作_Ch.Name = "comboBox_操作_Ch";
            this.comboBox_操作_Ch.Size = new System.Drawing.Size(48, 20);
            this.comboBox_操作_Ch.TabIndex = 41;
            // 
            // textBox_操作_ウェアレベリングセクター数
            // 
            this.textBox_操作_ウェアレベリングセクター数.Location = new System.Drawing.Point(247, 374);
            this.textBox_操作_ウェアレベリングセクター数.Name = "textBox_操作_ウェアレベリングセクター数";
            this.textBox_操作_ウェアレベリングセクター数.Size = new System.Drawing.Size(48, 19);
            this.textBox_操作_ウェアレベリングセクター数.TabIndex = 72;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(176, 352);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 71;
            this.label27.Text = "総セクター数";
            // 
            // textBox_操作_総セクター数
            // 
            this.textBox_操作_総セクター数.Location = new System.Drawing.Point(247, 349);
            this.textBox_操作_総セクター数.Name = "textBox_操作_総セクター数";
            this.textBox_操作_総セクター数.Size = new System.Drawing.Size(48, 19);
            this.textBox_操作_総セクター数.TabIndex = 70;
            // 
            // label_操作_初期化進捗
            // 
            this.label_操作_初期化進捗.AutoSize = true;
            this.label_操作_初期化進捗.Location = new System.Drawing.Point(137, 352);
            this.label_操作_初期化進捗.Name = "label_操作_初期化進捗";
            this.label_操作_初期化進捗.Size = new System.Drawing.Size(17, 12);
            this.label_操作_初期化進捗.TabIndex = 69;
            this.label_操作_初期化進捗.Text = "0%";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(102, 352);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 68;
            this.label26.Text = "進捗";
            // 
            // label_操作_全データ取得進捗
            // 
            this.label_操作_全データ取得進捗.AutoSize = true;
            this.label_操作_全データ取得進捗.Location = new System.Drawing.Point(164, 422);
            this.label_操作_全データ取得進捗.Name = "label_操作_全データ取得進捗";
            this.label_操作_全データ取得進捗.Size = new System.Drawing.Size(17, 12);
            this.label_操作_全データ取得進捗.TabIndex = 67;
            this.label_操作_全データ取得進捗.Text = "0%";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(129, 422);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 66;
            this.label23.Text = "進捗";
            // 
            // button_操作_初期化
            // 
            this.button_操作_初期化.Location = new System.Drawing.Point(6, 349);
            this.button_操作_初期化.Name = "button_操作_初期化";
            this.button_操作_初期化.Size = new System.Drawing.Size(90, 33);
            this.button_操作_初期化.TabIndex = 64;
            this.button_操作_初期化.Text = "操作_初期化";
            this.button_操作_初期化.UseVisualStyleBackColor = true;
            this.button_操作_初期化.Click += new System.EventHandler(this.button_操作_初期化_Click);
            // 
            // button_操作_全データ取得
            // 
            this.button_操作_全データ取得.Location = new System.Drawing.Point(6, 412);
            this.button_操作_全データ取得.Name = "button_操作_全データ取得";
            this.button_操作_全データ取得.Size = new System.Drawing.Size(117, 32);
            this.button_操作_全データ取得.TabIndex = 63;
            this.button_操作_全データ取得.Text = "操作_全データ取得";
            this.button_操作_全データ取得.UseVisualStyleBackColor = true;
            this.button_操作_全データ取得.Click += new System.EventHandler(this.button_操作_全データ取得_Click);
            // 
            // textBox_操作_データ
            // 
            this.textBox_操作_データ.Location = new System.Drawing.Point(52, 298);
            this.textBox_操作_データ.Name = "textBox_操作_データ";
            this.textBox_操作_データ.Size = new System.Drawing.Size(246, 19);
            this.textBox_操作_データ.TabIndex = 62;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 301);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 12);
            this.label21.TabIndex = 61;
            this.label21.Text = "データ";
            // 
            // textBox_操作_データブロックNo
            // 
            this.textBox_操作_データブロックNo.Location = new System.Drawing.Point(261, 275);
            this.textBox_操作_データブロックNo.Name = "textBox_操作_データブロックNo";
            this.textBox_操作_データブロックNo.Size = new System.Drawing.Size(36, 19);
            this.textBox_操作_データブロックNo.TabIndex = 60;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(201, 278);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 12);
            this.label20.TabIndex = 59;
            this.label20.Text = "ブロックNo.";
            // 
            // textBox_操作_データセクターNo
            // 
            this.textBox_操作_データセクターNo.Location = new System.Drawing.Point(261, 252);
            this.textBox_操作_データセクターNo.Name = "textBox_操作_データセクターNo";
            this.textBox_操作_データセクターNo.Size = new System.Drawing.Size(36, 19);
            this.textBox_操作_データセクターNo.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "セクターNo.";
            // 
            // button_操作_データ書込み
            // 
            this.button_操作_データ書込み.Location = new System.Drawing.Point(6, 222);
            this.button_操作_データ書込み.Name = "button_操作_データ書込み";
            this.button_操作_データ書込み.Size = new System.Drawing.Size(117, 32);
            this.button_操作_データ書込み.TabIndex = 56;
            this.button_操作_データ書込み.Text = "操作_データ書込み";
            this.button_操作_データ書込み.UseVisualStyleBackColor = true;
            this.button_操作_データ書込み.Click += new System.EventHandler(this.button_操作_データ書込み_Click);
            // 
            // button_操作_データ照合
            // 
            this.button_操作_データ照合.Location = new System.Drawing.Point(6, 260);
            this.button_操作_データ照合.Name = "button_操作_データ照合";
            this.button_操作_データ照合.Size = new System.Drawing.Size(117, 32);
            this.button_操作_データ照合.TabIndex = 55;
            this.button_操作_データ照合.Text = "操作_データ照合";
            this.button_操作_データ照合.UseVisualStyleBackColor = true;
            this.button_操作_データ照合.Click += new System.EventHandler(this.button_操作_データ照合_Click);
            // 
            // textBox_操作_システムファイルデータ
            // 
            this.textBox_操作_システムファイルデータ.Location = new System.Drawing.Point(56, 76);
            this.textBox_操作_システムファイルデータ.Name = "textBox_操作_システムファイルデータ";
            this.textBox_操作_システムファイルデータ.ReadOnly = true;
            this.textBox_操作_システムファイルデータ.Size = new System.Drawing.Size(242, 19);
            this.textBox_操作_システムファイルデータ.TabIndex = 54;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 12);
            this.label19.TabIndex = 53;
            this.label19.Text = "データ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 179);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 12);
            this.label15.TabIndex = 52;
            this.label15.Text = "Check_SHA1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(192, 154);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 12);
            this.label16.TabIndex = 51;
            this.label16.Text = "Check_MD5";
            // 
            // textBox_操作_CheckSHA1
            // 
            this.textBox_操作_CheckSHA1.Location = new System.Drawing.Point(262, 176);
            this.textBox_操作_CheckSHA1.Name = "textBox_操作_CheckSHA1";
            this.textBox_操作_CheckSHA1.Size = new System.Drawing.Size(36, 19);
            this.textBox_操作_CheckSHA1.TabIndex = 50;
            // 
            // textBox_操作_CheckMD5
            // 
            this.textBox_操作_CheckMD5.Location = new System.Drawing.Point(262, 151);
            this.textBox_操作_CheckMD5.Name = "textBox_操作_CheckMD5";
            this.textBox_操作_CheckMD5.Size = new System.Drawing.Size(36, 19);
            this.textBox_操作_CheckMD5.TabIndex = 49;
            // 
            // textBox_操作_CheckByte
            // 
            this.textBox_操作_CheckByte.Location = new System.Drawing.Point(262, 126);
            this.textBox_操作_CheckByte.Name = "textBox_操作_CheckByte";
            this.textBox_操作_CheckByte.Size = new System.Drawing.Size(36, 19);
            this.textBox_操作_CheckByte.TabIndex = 48;
            // 
            // textBox_更新_システムファイル更新日時
            // 
            this.textBox_更新_システムファイル更新日時.Location = new System.Drawing.Point(76, 101);
            this.textBox_更新_システムファイル更新日時.Name = "textBox_更新_システムファイル更新日時";
            this.textBox_更新_システムファイル更新日時.Size = new System.Drawing.Size(222, 19);
            this.textBox_更新_システムファイル更新日時.TabIndex = 47;
            this.textBox_更新_システムファイル更新日時.Text = "2015/10/20 14:10:10";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 12);
            this.label17.TabIndex = 46;
            this.label17.Text = "Check_byte";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 45;
            this.label18.Text = "更新日時";
            // 
            // button_操作_システムファイルデータ取得
            // 
            this.button_操作_システムファイルデータ取得.Location = new System.Drawing.Point(6, 126);
            this.button_操作_システムファイルデータ取得.Name = "button_操作_システムファイルデータ取得";
            this.button_操作_システムファイルデータ取得.Size = new System.Drawing.Size(180, 33);
            this.button_操作_システムファイルデータ取得.TabIndex = 43;
            this.button_操作_システムファイルデータ取得.Text = "操作_システムファイルデータ取得";
            this.button_操作_システムファイルデータ取得.UseVisualStyleBackColor = true;
            this.button_操作_システムファイルデータ取得.Click += new System.EventHandler(this.button_操作_システムファイルデータ取得_Click);
            // 
            // button_操作_システムファイルデータ書込み
            // 
            this.button_操作_システムファイルデータ書込み.Location = new System.Drawing.Point(6, 165);
            this.button_操作_システムファイルデータ書込み.Name = "button_操作_システムファイルデータ書込み";
            this.button_操作_システムファイルデータ書込み.Size = new System.Drawing.Size(180, 33);
            this.button_操作_システムファイルデータ書込み.TabIndex = 44;
            this.button_操作_システムファイルデータ書込み.Text = "操作_システムファイルデータ書込み";
            this.button_操作_システムファイルデータ書込み.UseVisualStyleBackColor = true;
            this.button_操作_システムファイルデータ書込み.Click += new System.EventHandler(this.button_操作_システムファイルデータ書込み_Click);
            // 
            // label_操作_UID
            // 
            this.label_操作_UID.AutoSize = true;
            this.label_操作_UID.Location = new System.Drawing.Point(159, 26);
            this.label_操作_UID.Name = "label_操作_UID";
            this.label_操作_UID.Size = new System.Drawing.Size(41, 12);
            this.label_操作_UID.TabIndex = 42;
            this.label_操作_UID.Text = "000000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(129, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 12);
            this.label14.TabIndex = 41;
            this.label14.Text = "UID";
            // 
            // button_操作_UID取得
            // 
            this.button_操作_UID取得.Location = new System.Drawing.Point(6, 18);
            this.button_操作_UID取得.Name = "button_操作_UID取得";
            this.button_操作_UID取得.Size = new System.Drawing.Size(117, 33);
            this.button_操作_UID取得.TabIndex = 40;
            this.button_操作_UID取得.Text = "操作_UID取得";
            this.button_操作_UID取得.UseVisualStyleBackColor = true;
            this.button_操作_UID取得.Click += new System.EventHandler(this.button_操作_UID取得_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(638, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "全データ表示エリア";
            // 
            // richTextBox_全データ表示エリア
            // 
            this.richTextBox_全データ表示エリア.Location = new System.Drawing.Point(638, 87);
            this.richTextBox_全データ表示エリア.Name = "richTextBox_全データ表示エリア";
            this.richTextBox_全データ表示エリア.Size = new System.Drawing.Size(285, 434);
            this.richTextBox_全データ表示エリア.TabIndex = 1;
            this.richTextBox_全データ表示エリア.Text = "";
            // 
            // groupBox_管理クラス
            // 
            this.groupBox_管理クラス.Controls.Add(this.label12);
            this.groupBox_管理クラス.Controls.Add(this.label11);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_ウェアレベリングセクター数);
            this.groupBox_管理クラス.Controls.Add(this.label10);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_総セクター数);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_データリスト);
            this.groupBox_管理クラス.Controls.Add(this.label4);
            this.groupBox_管理クラス.Controls.Add(this.comboBox_管理_データ種別);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_システムファイルUID);
            this.groupBox_管理クラス.Controls.Add(this.label7);
            this.groupBox_管理クラス.Controls.Add(this.label6);
            this.groupBox_管理クラス.Controls.Add(this.label5);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_CheckSHA1);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_CheckMD5);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_CheckByte);
            this.groupBox_管理クラス.Controls.Add(this.textBox_管理_システムファイル日時);
            this.groupBox_管理クラス.Controls.Add(this.label3);
            this.groupBox_管理クラス.Controls.Add(this.label2);
            this.groupBox_管理クラス.Controls.Add(this.label_管理_UID);
            this.groupBox_管理クラス.Controls.Add(this.label1);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_初期化);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_UID取得);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_システムファイル読込み);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_再構築);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_システムファイル保存);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_データ読込み);
            this.groupBox_管理クラス.Controls.Add(this.button_管理_データ書込み);
            this.groupBox_管理クラス.Location = new System.Drawing.Point(19, 69);
            this.groupBox_管理クラス.Name = "groupBox_管理クラス";
            this.groupBox_管理クラス.Size = new System.Drawing.Size(289, 452);
            this.groupBox_管理クラス.TabIndex = 0;
            this.groupBox_管理クラス.TabStop = false;
            this.groupBox_管理クラス.Text = "管理クラス";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(102, 424);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "全データ表示エリアから再構築します";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 375);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "ウェアレベリングセクター数";
            // 
            // textBox_管理_ウェアレベリングセクター数
            // 
            this.textBox_管理_ウェアレベリングセクター数.Location = new System.Drawing.Point(230, 372);
            this.textBox_管理_ウェアレベリングセクター数.Name = "textBox_管理_ウェアレベリングセクター数";
            this.textBox_管理_ウェアレベリングセクター数.Size = new System.Drawing.Size(48, 19);
            this.textBox_管理_ウェアレベリングセクター数.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "総セクター数";
            // 
            // textBox_管理_総セクター数
            // 
            this.textBox_管理_総セクター数.Location = new System.Drawing.Point(230, 347);
            this.textBox_管理_総セクター数.Name = "textBox_管理_総セクター数";
            this.textBox_管理_総セクター数.Size = new System.Drawing.Size(48, 19);
            this.textBox_管理_総セクター数.TabIndex = 35;
            // 
            // textBox_管理_データリスト
            // 
            this.textBox_管理_データリスト.Location = new System.Drawing.Point(129, 239);
            this.textBox_管理_データリスト.Multiline = true;
            this.textBox_管理_データリスト.Name = "textBox_管理_データリスト";
            this.textBox_管理_データリスト.Size = new System.Drawing.Size(149, 78);
            this.textBox_管理_データリスト.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "データID , データ(int)";
            // 
            // comboBox_管理_データ種別
            // 
            this.comboBox_管理_データ種別.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_管理_データ種別.FormattingEnabled = true;
            this.comboBox_管理_データ種別.Items.AddRange(new object[] {
            "リードオンリーデータ",
            "ウェアレベリングデータ"});
            this.comboBox_管理_データ種別.Location = new System.Drawing.Point(6, 224);
            this.comboBox_管理_データ種別.Name = "comboBox_管理_データ種別";
            this.comboBox_管理_データ種別.Size = new System.Drawing.Size(117, 20);
            this.comboBox_管理_データ種別.TabIndex = 30;
            // 
            // textBox_管理_システムファイルUID
            // 
            this.textBox_管理_システムファイルUID.Location = new System.Drawing.Point(47, 78);
            this.textBox_管理_システムファイルUID.Name = "textBox_管理_システムファイルUID";
            this.textBox_管理_システムファイルUID.Size = new System.Drawing.Size(231, 19);
            this.textBox_管理_システムファイルUID.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "UID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "Check_SHA1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "Check_MD5";
            // 
            // textBox_管理_CheckSHA1
            // 
            this.textBox_管理_CheckSHA1.Location = new System.Drawing.Point(242, 178);
            this.textBox_管理_CheckSHA1.Name = "textBox_管理_CheckSHA1";
            this.textBox_管理_CheckSHA1.Size = new System.Drawing.Size(36, 19);
            this.textBox_管理_CheckSHA1.TabIndex = 25;
            // 
            // textBox_管理_CheckMD5
            // 
            this.textBox_管理_CheckMD5.Location = new System.Drawing.Point(242, 153);
            this.textBox_管理_CheckMD5.Name = "textBox_管理_CheckMD5";
            this.textBox_管理_CheckMD5.Size = new System.Drawing.Size(36, 19);
            this.textBox_管理_CheckMD5.TabIndex = 24;
            // 
            // textBox_管理_CheckByte
            // 
            this.textBox_管理_CheckByte.Location = new System.Drawing.Point(242, 128);
            this.textBox_管理_CheckByte.Name = "textBox_管理_CheckByte";
            this.textBox_管理_CheckByte.Size = new System.Drawing.Size(36, 19);
            this.textBox_管理_CheckByte.TabIndex = 23;
            // 
            // textBox_管理_システムファイル日時
            // 
            this.textBox_管理_システムファイル日時.Location = new System.Drawing.Point(76, 103);
            this.textBox_管理_システムファイル日時.Name = "textBox_管理_システムファイル日時";
            this.textBox_管理_システムファイル日時.Size = new System.Drawing.Size(202, 19);
            this.textBox_管理_システムファイル日時.TabIndex = 22;
            this.textBox_管理_システムファイル日時.Text = "2015/10/20 14:10:10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "Check_byte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "更新日時";
            // 
            // label_管理_UID
            // 
            this.label_管理_UID.AutoSize = true;
            this.label_管理_UID.Location = new System.Drawing.Point(159, 28);
            this.label_管理_UID.Name = "label_管理_UID";
            this.label_管理_UID.Size = new System.Drawing.Size(41, 12);
            this.label_管理_UID.TabIndex = 18;
            this.label_管理_UID.Text = "000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "UID";
            // 
            // button_管理_初期化
            // 
            this.button_管理_初期化.Location = new System.Drawing.Point(6, 351);
            this.button_管理_初期化.Name = "button_管理_初期化";
            this.button_管理_初期化.Size = new System.Drawing.Size(90, 33);
            this.button_管理_初期化.TabIndex = 17;
            this.button_管理_初期化.Text = "管理_初期化";
            this.button_管理_初期化.UseVisualStyleBackColor = true;
            this.button_管理_初期化.Click += new System.EventHandler(this.button_管理_初期化_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(955, 539);
            this.Controls.Add(this.panel_ベース);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_ベース.ResumeLayout(false);
            this.panel_ベース.PerformLayout();
            this.groupBox_操作クラス.ResumeLayout(false);
            this.groupBox_操作クラス.PerformLayout();
            this.groupBox_管理クラス.ResumeLayout(false);
            this.groupBox_管理クラス.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_管理_UID取得;
		private System.Windows.Forms.Button button_管理_システムファイル読込み;
		private System.Windows.Forms.Button button_管理_システムファイル保存;
		private System.Windows.Forms.Button button_管理_データ書込み;
		private System.Windows.Forms.Button button_管理_データ読込み;
		private System.Windows.Forms.Button button_管理_再構築;
		private System.Windows.Forms.Panel panel_ベース;
		private System.Windows.Forms.GroupBox groupBox_管理クラス;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_管理_UID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_管理_初期化;
		private System.Windows.Forms.ComboBox comboBox_管理_データ種別;
		private System.Windows.Forms.TextBox textBox_管理_システムファイルUID;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_管理_CheckSHA1;
		private System.Windows.Forms.TextBox textBox_管理_CheckMD5;
		private System.Windows.Forms.TextBox textBox_管理_CheckByte;
		private System.Windows.Forms.TextBox textBox_管理_システムファイル日時;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox_操作クラス;
		private System.Windows.Forms.TextBox textBox_操作_データセクターNo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button_操作_データ書込み;
		private System.Windows.Forms.Button button_操作_データ照合;
		private System.Windows.Forms.TextBox textBox_操作_システムファイルデータ;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBox_操作_CheckSHA1;
		private System.Windows.Forms.TextBox textBox_操作_CheckMD5;
		private System.Windows.Forms.TextBox textBox_操作_CheckByte;
		private System.Windows.Forms.TextBox textBox_更新_システムファイル更新日時;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button button_操作_システムファイルデータ取得;
		private System.Windows.Forms.Button button_操作_システムファイルデータ書込み;
		private System.Windows.Forms.Label label_操作_UID;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button_操作_UID取得;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.RichTextBox richTextBox_全データ表示エリア;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox_管理_ウェアレベリングセクター数;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox_管理_総セクター数;
		private System.Windows.Forms.TextBox textBox_管理_データリスト;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button_接続;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox textBox_IPアドレス;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox comboBox_操作_Ch;
		private System.Windows.Forms.TextBox textBox_操作_ウェアレベリングセクター数;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox textBox_操作_総セクター数;
		private System.Windows.Forms.Label label_操作_初期化進捗;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label_操作_全データ取得進捗;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button button_操作_初期化;
		private System.Windows.Forms.Button button_操作_全データ取得;
		private System.Windows.Forms.TextBox textBox_操作_データ;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox_操作_データブロックNo;
		private System.Windows.Forms.Label label20;

	}
}

