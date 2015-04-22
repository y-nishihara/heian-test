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
		C_マイフェア管理 R_マイフェア管理 = new C_マイフェア管理("Nerva".ToCharArray());

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
			this.R_Nerva8100ホスト.R_コントローラー.F_システムファイル照合();
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



	}
}
