using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HEIAN_Library.N_システム;

namespace Mifare処理依頼
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			//MessageBox.Show(DateTime.Now.AddMilliseconds(int.MaxValue).ToString());
			//C_Nerva8100ホスト.C_コントローラー.C_カートリッジホルダー.C_カートリッジ情報 t = new C_Nerva8100ホスト.C_コントローラー.C_カートリッジホルダー.C_カートリッジ情報();
			//C_Nerva8100ホスト.C_コントローラー.C_カートリッジホルダー.C_カートリッジ作成情報 t2 = new C_Nerva8100ホスト.C_コントローラー.C_カートリッジホルダー.C_カートリッジ作成情報();


			//t.P_カートリッジID = 254;
			//t.P_インク種別 = C_Nerva8100ホスト.C_コントローラー.C_カートリッジホルダー.C_カートリッジ情報.en_インク種別.B02;
			//t.P_インク容量ml = 370;
			//t.P_インクカートリッジ型式名称 = "名称テストNerva1234567";
			//t2.P_インクデータ作成日時 = DateTime.Now;
			//t2.P_未使用インク使用期限 = DateTime.Now.AddYears(3);
			//MessageBox.Show(t.P_カートリッジID.ToString());
			//MessageBox.Show(t.P_インク種別.ToString());
			//MessageBox.Show(t.P_インク容量ml.ToString());
			//MessageBox.Show(t.P_インクカートリッジ型式名称);
			//MessageBox.Show(t2.P_インクデータ作成日時.ToString());
			//MessageBox.Show(t2.P_未使用インク使用期限.ToString());

			InitializeComponent();
			this.groupBox_操作クラス.Enabled = false;
			this.comboBox_管理_データ種別.SelectedIndex = 0;
			this.comboBox_操作_Ch.SelectedIndex = 0;

			this.dataGridView_システム_データ一覧.Rows.Add("カートリッジID", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("インク種別", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("インク容量", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("インクカートリッジ型式", "", "", "", "", "", "", "", "");

			this.dataGridView_システム_データ一覧.Rows.Add("インクデータ作成日時", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("未使用インク使用期限", "", "", "", "", "", "", "", "");

			this.dataGridView_システム_データ一覧.Rows.Add("インク初使用日時", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("インク使用期限", "", "", "", "", "", "", "", "");

			this.dataGridView_システム_データ一覧.Rows.Add("インク最終使用日時", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("インク使用量", "", "", "", "", "", "", "", "");
			this.dataGridView_システム_データ一覧.Rows.Add("印字時間", "", "", "", "", "", "", "", "");

			this.dataGridView_システム_データ一覧.Rows.Add("インク無効日時", "", "", "", "", "", "", "", "");



			foreach (DataGridViewColumn c in dataGridView_システム_データ一覧.Columns)
				c.SortMode = DataGridViewColumnSortMode.NotSortable;

			dataGridView_システム_データ一覧.Columns[0].Frozen = true;

			this.dataGridView_システム_データ一覧[1, 0].Value = "1,0";
			this.dataGridView_システム_データ一覧.Rows[0].Cells[2].Value = 2;

			this.panel_タブ_システムテスト_ベース.Enabled = false;
			this.button_システム_アプリ終了.Enabled = false;
			this.button_システム_印字.Enabled = false;
		}

		C_Nerva8100ホスト R_Nerva8100ホスト = new C_Nerva8100ホスト();
		C_マイフェア管理 R_マイフェア管理 = new C_マイフェア管理("Nerva");

		bool V_接続 = false;
		private void button_接続_Click(object sender, EventArgs e)
		{
			this.panel_ベース.Enabled = false;

			if (this.V_接続 == false)
			{
				this.V_接続 = this.R_Nerva8100ホスト.R_コントローラー.F_接続(this.textBox_IPアドレス.Text);
			}
			else
			{
				this.R_Nerva8100ホスト.R_コントローラー.F_切断();
				this.V_接続 = false;
			}

			if (this.V_接続 == true)
			{
				this.button_接続.Text = "切断";
				this.groupBox_操作クラス.Enabled = true;
				this.panel_タブ_システムテスト_ベース.Enabled = true;
			}
			else
			{
				this.button_接続.Text = "接続";
				this.groupBox_操作クラス.Enabled = false;
				this.panel_タブ_システムテスト_ベース.Enabled = false;
			}

			this.panel_ベース.Enabled = true;
		}

		void M_全データ表示()
		{
			for (int i = 0; i < this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト.Length; i++)
			{
				this.dataGridView_システム_データ一覧.Rows[0].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_カートリッジID;
				this.dataGridView_システム_データ一覧.Rows[1].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_インク種別;
				this.dataGridView_システム_データ一覧.Rows[2].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_インク容量ml;
				this.dataGridView_システム_データ一覧.Rows[3].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_インクカートリッジ型式名称;

				this.dataGridView_システム_データ一覧.Rows[4].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_カートリッジ作成情報.P_インクデータ作成日時;
				this.dataGridView_システム_データ一覧.Rows[5].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_カートリッジ作成情報.P_未使用インク使用期限;

				this.dataGridView_システム_データ一覧.Rows[6].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_インク使用開始情報.P_インク初回使用日時;
				this.dataGridView_システム_データ一覧.Rows[7].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_インク使用開始情報.P_インク使用期限;

				this.dataGridView_システム_データ一覧.Rows[8].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_インク初回使用から最終使用までの間隔.P_インク初回使用から最終使用までの間隔;
				this.dataGridView_システム_データ一覧.Rows[9].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_インク使用量.P_インク使用量pix;
				this.dataGridView_システム_データ一覧.Rows[10].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_パルスウォーミング累計時間.P_パルスウォーミング累計時間;

				this.dataGridView_システム_データ一覧.Rows[11].Cells[i + 1].Value = this.R_Nerva8100ホスト.R_コントローラー.R_カートリッジホルダーリスト[i].R_インク無効日時.P_インク無効日時;
			}
		}

		#region システムテスト

		private void button_システム_初期化_Click(object sender, EventArgs e)
		{
			this.R_Nerva8100ホスト.R_コントローラー.F_インク作成();
			this.M_全データ表示();
		}

		private void button_システム_アプリ起動_Click(object sender, EventArgs e)
		{
			this.button_システム_アプリ起動.Enabled = false;
			this.button_システム_アプリ終了.Enabled = true;
			this.button_システム_印字.Enabled = true;
			this.R_Nerva8100ホスト.R_コントローラー.F_管理ファイル照合();
		}

		private void button_システム_アプリ終了_Click(object sender, EventArgs e)
		{
			this.button_システム_アプリ起動.Enabled = true;
			this.button_システム_アプリ終了.Enabled = false;
			this.button_システム_印字.Enabled = false;
			this.R_Nerva8100ホスト.R_コントローラー.F_終了時操作();
		}

		private void button_システム_印字_Click(object sender, EventArgs e)
		{
			try
			{
				int i = int.Parse(this.textBox_システム_インク使用量.Text);
				int j = int.Parse(this.textBox_システム_印字時間.Text);
				this.R_Nerva8100ホスト.R_コントローラー.F_インク消費(new int[8] { i, i + 1, i + 2, i + 3, i + 4, i + 5, i + 6, i + 7 });
				this.R_Nerva8100ホスト.R_コントローラー.F_パルスウォーミング時間追加(j);
				this.R_Nerva8100ホスト.R_コントローラー.F_インク消費書込み();
				this.M_全データ表示();
			}
			catch (Exception)
			{
			}
		}


		#endregion



		private void button_操作_データ照合_Click(object sender, EventArgs e)
		{
			Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
			C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);
			//↓抽象クラスの為、エラーとなります。
			//※インスタンス化し、代入するのは継承クラスになります
			C_マイフェア管理.C_マイフェアデータ.C_ブロック_ウェアレベリングデータ R_ブロック = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_ウェアレベリングデータ();
			bool b_ret = false;

			//・・・

			b_ret = R_RFID操作.F_データ照合(0, R_ブロック);
			//このメソッド内部ではC_マイフェア管理.C_マイフェアデータ.B_ブロックとして扱われます
			//アドレスと16バイトのデータはその状態でも扱えます
			//また、型を判別するとC_マイフェア管理.C_マイフェアデータ.C_ブロック_ウェアレベリングデータが出てきますので
			//キャストしてC_マイフェア管理.C_マイフェアデータ.C_ブロック_ウェアレベリングデータといて扱うことも出来ます
		}


        #region フォームイベント処理(管理クラス)

        private void button_管理_UID取得_Click(object sender, EventArgs e)
        {
            button_管理_UID取得.Text = R_マイフェア管理.F_UID取得().ToString();
        }

        private void button_管理_システムファイル読込み_Click(object sender, EventArgs e)
        {
            bool b_ret = false;
            C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ V_管理ファイルデータ = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ();

            b_ret = R_マイフェア管理.F_管理ファイル読込み(V_管理ファイルデータ);
            textBox_管理_CheckMD5.Text = V_管理ファイルデータ.V_Check_MD5.ToString();
        }

        private void button_管理_システムファイル保存_Click(object sender, EventArgs e)
        {
            C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ V_ブロック_システムファイルデータ = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ();

            R_マイフェア管理.F_管理ファイル保存();
        }

        private void button_管理_データ読込み_Click(object sender, EventArgs e)
        {
            C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ R_データ = new C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ();
            R_マイフェア管理.F_データ読込み(R_データ);
        }

        private void button_管理_データ書込み_Click(object sender, EventArgs e)
        {
            //ynyn
            //List<C_マイフェア管理.C_マイフェアデータ.C_ブロック_リードオンリーセクタートレーラー> R_ブロックリスト = new List<C_マイフェア管理.C_マイフェアデータ.C_ブロック_リードオンリーセクタートレーラー>();
            //List<C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ> R_データリスト = new List<C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ>();
            //C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ R_データ = new C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ();
            //R_マイフェア管理.F_データ書込み(R_データリスト);
            List<C_マイフェア管理.C_マイフェアデータ.B_ブロック> R_ブロックリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_ブロック>();
            List<C_マイフェア管理.C_マイフェアデータ.B_データ> R_データリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_データ>();
            //R_データリスト.Add();
            R_ブロックリスト = R_マイフェア管理.F_データ書込み(R_データリスト);
        
        }

        private void button_管理_初期化_Click(object sender, EventArgs e)
        {
            int V_総セクター数;
            int V_ウェアレベリングセクター数;

            try
            {
                V_総セクター数 = int.Parse(textBox_管理_総セクター数.Text);
                V_ウェアレベリングセクター数 = int.Parse(textBox_管理_ウェアレベリングセクター数.Text);
                R_マイフェア管理.F_初期化(V_総セクター数, V_ウェアレベリングセクター数);
            }
            catch (System.Exception ex)
            {
                // 失敗したとき
                System.Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }
        }

        private void button_管理_再構築_Click(object sender, EventArgs e)
        {
            //ynyn
            List<byte[]> R_全Mifareタグデータ = new List<byte[]>();
            R_マイフェア管理.F_再構築(R_全Mifareタグデータ);
        }

        #endregion フォームイベント処理(管理クラス)

        #region フォームイベント処理(操作クラス)

        private void button_操作_UID取得_Click(object sender, EventArgs e)
        {
            Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
            C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);

            button_操作_UID取得.Text = R_RFID操作.F_UID取得(0).ToString();
        }

        private void button_操作_システムファイルデータ取得_Click(object sender, EventArgs e)
        {
            Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
            C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);
            C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ R_管理ファイルデータブロック = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ();

            R_管理ファイルデータブロック = R_RFID操作.F_管理ファイルデータ取得(0);
        }

        private void button_操作_システムファイルデータ書込み_Click(object sender, EventArgs e)
        {
            Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
            C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);
            List<C_マイフェア管理.C_マイフェアデータ.B_ブロック> R_書込みブロックリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_ブロック>();
            bool b_ret = false;

            b_ret = R_RFID操作.F_データ書込み(0, R_書込みブロックリスト);
        }

        private void button_操作_データ書込み_Click(object sender, EventArgs e)
        {
            Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
            C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);
            List<C_マイフェア管理.C_マイフェアデータ.B_ブロック> R_書込みブロックリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_ブロック>();
            bool b_ret = false;

            b_ret = R_RFID操作.F_データ書込み(0, R_書込みブロックリスト);
        }

        private void button_操作_初期化_Click(object sender, EventArgs e)
        {
            Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
            C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);
            C_マイフェア管理.C_マイフェアデータ R_データ = new C_マイフェア管理.C_マイフェアデータ();
            Action<float> R_進捗報告動作 = null;
            bool b_ret = false;

            b_ret = R_RFID操作.F_初期化(0, R_データ, R_進捗報告動作);
        }

        private void button_操作_全データ取得_Click(object sender, EventArgs e)
        {
            Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
            C_Nerva8100ホスト.C_コントローラー.C_RFID操作 R_RFID操作 = new C_Nerva8100ホスト.C_コントローラー.C_RFID操作(R_コントローラーライブラリー);
            Action<float> R_進捗報告動作 = null;
            List<byte[]> byte_data = new List<byte[]>();

            byte_data = R_RFID操作.F_全データ取得(0, R_進捗報告動作);
        }

        #endregion フォームイベント処理(操作クラス)


	}
}
