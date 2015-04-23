using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace HEIAN_Library.N_機械.N_印字装置.N_Nerva8100
namespace Mifare処理依頼
{
	public partial class C_Nerva8100ホスト
	{
		public partial class C_コントローラー
		{
			/// <summary>
			/// コントローラー内のRFIDに関する操作をまとめたクラスです
			/// </summary>
			public class C_RFID操作
			{
				public C_RFID操作(Nerva8100.Nerva8100Controller AR_コントローラーライブラリー)
				{
					this.R_コントローラーライブラリー = AR_コントローラーライブラリー;
				}

				Nerva8100.Nerva8100Controller R_コントローラーライブラリー;
				byte[] V_key = C_マイフェア管理.C_マイフェアデータ.SR_KeyA;
				
				/// <summary>
				/// マイフェアタグに記録されている管理ファイルに関するデータを取得します
				/// 返すクラス内に取得時のUIDを設定します
				/// </summary>
				/// <param name="A_ch">取得するチャンネルを指定します、0～7</param>
				/// <returns>管理ファイルデータブロックを返します、取得出来ない、または不正なデータの場合はnullを返します</returns>
				public C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ F_管理ファイルデータ取得(int A_ch)
				{
					C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ LR_管理ファイルデータブロック = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_管理ファイルデータ();
					int LV_UID=0;
					LR_管理ファイルデータブロック.V_管理ファイルデータブロック取得時UID = LV_UID;
					return LR_管理ファイルデータブロック;
				}

				/// <summary>
				/// マイフェアタグに記録されている全データを取得します
				/// </summary>
				/// <param name="A_ch">取得するチャンネルを指定します、0～7</param>
				/// <param name="AR_進捗報告動作">進捗を報告するための動作を登録します、floatにて進捗率が渡されます、1で完了です</param>
				/// <returns>1ブロックのデータをbyte[16]とした全ブロックのデータをリストで返します、取得出来ない場合はnullを返します</returns>
				public List<byte[]> F_全データ取得(int A_ch,Action<float> AR_進捗報告動作)
				{
					List<byte[]> LR_データリスト= new List<byte[]>();

					int i = 1;
					for (int fe_セクターNo = 0; fe_セクターNo < 16; fe_セクターNo++)
					{
						for (int fe_ブロックNo = 0; fe_ブロックNo < 4; fe_ブロックNo++)
						{
							//データを取得します
							byte[] LR_データ = new byte[16];
							LR_データリスト.Add(LR_データ);

							if (AR_進捗報告動作 != null)
							{
								int j = i;
								HEIAN_Library.N_システム.C_新スレッド.SF_バックグラウンド処理(() =>
									{
										AR_進捗報告動作((float)j / (4 * 16));
									});
								i++;
							}
						}
					}

					return LR_データリスト;
				}

				/// <summary>
				/// マイフェアタグのUIDを取得します
				/// マイフェアタグの更新を確認するためのポーリング処理に使用します
				/// </summary>
				/// <param name="A_ch">取得するチャンネルを指定します、0～7</param>
				/// <returns>UIDを返します</returns>
				public uint F_UID取得(int A_ch)
				{
					//仮コード
					return (uint)A_ch;
				}

				/// <summary>
				/// マイフェアタグに指定したデータブロックを書込みます
				/// </summary>
				/// <param name="A_ch">書き込むチャンネルを指定します、0～7</param>
				/// <param name="AR_書込みブロックリスト">書き込むブロックのリストを指定します</param>
				/// <returns>書き込みに成功したかどうかの値を返します、1つでも失敗すればfalseです</returns>
				public bool F_データ書込み(int A_ch,List<C_マイフェア管理.C_マイフェアデータ.B_ブロック> AR_書込みブロックリスト)
				{
					return true;
				}

				/// <summary>
				/// マイフェアタグに書き込んであるデータを照合します
				/// </summary>
				/// <param name="A_ch">照合するチャンネルを指定します、0～7</param>
				/// <param name="AR_ブロック">照合するブロックオブジェクトを指定します</param>
				/// <returns>照合の結果を返します</returns>
				public bool F_データ照合(int A_ch,C_マイフェア管理.C_マイフェアデータ.B_ブロック AR_ブロック)
				{
					return true;
				}

				/// <summary>
				/// マイフェアタグのデータを初期化します
				/// </summary>
				/// <param name="A_ch">初期化するチャンネルを指定します</param>
				/// <param name="AR_データ">初期化するデータを指定します</param>
				/// <param name="AR_進捗報告動作">進捗を報告するための動作を登録します、floatにて進捗率が渡されます、1で完了です</param>
				/// <returns>初期化の結果を返します</returns>
				public bool F_初期化(int A_ch,C_マイフェア管理.C_マイフェアデータ AR_データ,Action<float> AR_進捗報告動作)
				{
					return true;
				}
			}
		}
	}
}
