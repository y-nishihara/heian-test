using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HEIAN_Library.N_システム;
using System.Xml.Serialization;

namespace Mifare処理依頼
{

	public class C_マイフェア管理
	{
		/// <summary>
		/// マイフェアの管理クラスをインスタンス化します
		/// Mifareタグリーダーに対して1対1です
		/// </summary>
		/// <param name="AR_システム名称">システムの照合用の名称を半角英数6文字以内にて指定します、6バイトに切り捨てられます</param>
		public C_マイフェア管理(char[] AR_システム名称)
		{
			for (int i = 0; (i < AR_システム名称.Length)&(i<this.R_システム名称.Length); i++)
			{
				if (BitConverter.GetBytes(AR_システム名称[i]).Length > 1)
				{
					//例外を出します
				}
				this.R_システム名称[i] = AR_システム名称[i];
			}
		}

		/// <summary>
		/// 管理しているマイフェアのデータクラスのインスタンスを格納します
		/// 初期化、もしくはマージにより生成します
		/// 確認のため開発中のみpublicとします
		/// </summary>
		public C_マイフェアデータ R_マイフェアデータ = null;

		/// <summary>
		/// システム名称を半角英数にて格納します
		/// システムの照合に使用します
		/// 6バイトに切り捨てます
		/// </summary>
		char[] R_システム名称 = new char[6] { '\0', '\0', '\0', '\0', '\0', '\0' };

		/// <summary>
		/// 初期化対象のオブジェクトと使用するシステム名称とウェアレベリングデータ用に予約するセクター数を指定して初期化した新しい管理クラスを返します
		/// </summary>
		/// <param name="AR_初期化対象">初期化するクラスオブジェクトを指定します</param>
		/// <param name="AR_システム名称">システム名称を指定します、先頭から6バイトのみ有効です</param>
		/// <param name="AV_ウェアレベリングセクター数">ウェアレベリング用に予約するセクター数です、総セクター数-1が最大値です</param>
		/// <returns>更新された管理クラスを返します、実際に書込みには操作関数に代入して下さい、初期化済みの場合はnullを返します</returns>
		public C_マイフェアデータ F_初期化(int AV_総セクター数, int AV_ウェアレベリングセクター数)
		{
			if (this.R_マイフェアデータ.V_初期化済み == true)
			{
				return null;
			}

			if (AV_ウェアレベリングセクター数 > (AV_総セクター数 - 1))
			{
				//例外を出すようにします
				return null;
			}

			this.R_マイフェアデータ = new C_マイフェアデータ();
			this.R_マイフェアデータ.V_初期化済み = true;

			//仮コードです
			this.R_マイフェアデータ.R_セクター_ウェアレベリング_リスト.Clear();
			for (int i = 0; i < AV_ウェアレベリングセクター数; i++)
			{
				this.R_マイフェアデータ.R_セクター_ウェアレベリング_リスト.Add(new C_マイフェアデータ.C_セクター_ウェアレベリング());
			}
			this.R_マイフェアデータ.R_セクター_システム = new C_マイフェアデータ.C_セクター_システム(this.R_システム名称);

			//初期定義が終了したマイフェアのデータクラスオブジェクトを返します
			return this.R_マイフェアデータ;
		}


		/// <summary>
		/// UIDを指定してシステムファイルを読込み、システムファイルから管理クラスを復元します
		/// システムファイルデータも作成します
		/// </summary>
		/// <param name="AV_UID">復元するMifareタグのUIDを指定します</param>
		/// <returns>システムファイルから復元した管理クラスオブジェクトを返します、管理クラスが復元出来なかった場合はnullを返します</returns>
		public bool F_システムファイル読込み(C_マイフェアデータ.C_ブロック_システムファイルデータ AR_システムファイルデータ)
		{
			C_マイフェアデータ LR_マイフェア = null;
			//ライブラリーによりファイル保存します
			using (C_XMLストリーム<C_マイフェアデータ> U_xml = new C_XMLストリーム<C_マイフェアデータ>(C_定数.P_設定保存ディレクトリ + "システムファイル\\", AR_システムファイルデータ.V_システムファイルデータブロック取得時UID.ToString() + ".tmp"))
			{
				if (U_xml.F_読込(ref LR_マイフェア, false) == false)
				{
					return false;
				}
				//システムファイルデータを作成します
				if (System.IO.File.Exists(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名) == true)
				{
					System.IO.FileInfo fi = new System.IO.FileInfo(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名);
					if (AR_システムファイルデータ.V_システムファイル更新年 != (short)fi.LastWriteTime.Year) return false;
					if (AR_システムファイルデータ.V_システムファイル更新月 != (byte)fi.LastWriteTime.Month) return false;
					if (AR_システムファイルデータ.V_システムファイル更新日 != (byte)fi.LastWriteTime.Day) return false;
					if (AR_システムファイルデータ.V_システムファイル更新時 != (byte)fi.LastWriteTime.Hour) return false;
					if (AR_システムファイルデータ.V_システムファイル更新分 != (byte)fi.LastWriteTime.Minute) return false;
					if (AR_システムファイルデータ.V_システムファイル更新秒 != (byte)fi.LastWriteTime.Second) return false;

					using (System.IO.FileStream fs = fi.OpenRead())
					{

						//CheckByte
						int LV_読込みバイト;
						byte LV_チェックバイト = 0 ;
						while ((LV_読込みバイト = fs.ReadByte()) != -1)
						{
							LV_チェックバイト = (byte)((LV_チェックバイト + LV_読込みバイト) % byte.MaxValue);
						}
						if (AR_システムファイルデータ.V_Check_byte != LV_チェックバイト) return false;

						//CheckMD5
						if (AR_システムファイルデータ.V_Check_MD5 != C_チェック.F_サムチェック(C_ファイル操作.SF_MD5ハッシュ値の取得(fs))) return false;

						//CheckSHA1
						if (AR_システムファイルデータ.V_Check_SHA1 != C_チェック.F_サムチェック(C_ファイル操作.SF_SHA1ハッシュ値の取得(fs))) return false;

					}
				}
			}
			return true;
		}

		/// <summary>
		/// 管理クラスをシステムファイルに保存します
		/// ファイル保存場所は設定ディレクトリー下の「システムファイル」フォルダー内に保存します
		/// ファイル名は「{UID}.tmp」です
		/// </summary>
		/// <returns>更新後のされたシステムファイルデータを返します、Mifareタグへシステムファイル情報を記録するには操作関数に代入して下さい</returns>
		public C_マイフェアデータ.C_ブロック_システムファイルデータ F_システムファイル保存()
		{
			C_マイフェアデータ.C_ブロック_システムファイルデータ LR_ブロック_システムファイルデータ = new C_マイフェアデータ.C_ブロック_システムファイルデータ();

			//ライブラリーによりファイル保存します
			using (C_XMLストリーム<C_マイフェアデータ> U_xml = new C_XMLストリーム<C_マイフェアデータ>(C_定数.P_設定保存ディレクトリ + "システムファイル\\", this.R_マイフェアデータ.R_セクター_システム.V_UID.ToString() + ".tmp"))
			{
				U_xml.F_保存(this.R_マイフェアデータ, true);

				//システムファイルデータを作成します
				if (System.IO.File.Exists(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名) == true)
				{
					System.IO.FileInfo fi = new System.IO.FileInfo(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名);
					LR_ブロック_システムファイルデータ.V_システムファイル更新年 = (short)fi.LastWriteTime.Year;
					LR_ブロック_システムファイルデータ.V_システムファイル更新月 = (byte)fi.LastWriteTime.Month;
					LR_ブロック_システムファイルデータ.V_システムファイル更新日 = (byte)fi.LastWriteTime.Day;
					LR_ブロック_システムファイルデータ.V_システムファイル更新時 = (byte)fi.LastWriteTime.Hour;
					LR_ブロック_システムファイルデータ.V_システムファイル更新分 = (byte)fi.LastWriteTime.Minute;
					LR_ブロック_システムファイルデータ.V_システムファイル更新秒 = (byte)fi.LastWriteTime.Second;

					System.IO.FileStream fs = fi.OpenRead();

					//CheckByte
					int LV_読込みバイト;
					while ((LV_読込みバイト = fs.ReadByte()) != -1)
					{
						LR_ブロック_システムファイルデータ.V_Check_byte = (byte)((LR_ブロック_システムファイルデータ.V_Check_byte + LV_読込みバイト) % byte.MaxValue);
					}

					//CheckMD5
					LR_ブロック_システムファイルデータ.V_Check_MD5 = C_チェック.F_サムチェック(C_ファイル操作.SF_MD5ハッシュ値の取得(fs));

					//CheckSHA1
					LR_ブロック_システムファイルデータ.V_Check_SHA1 = C_チェック.F_サムチェック(C_ファイル操作.SF_SHA1ハッシュ値の取得(fs));

					fs.Close();
				}
			}
			this.R_マイフェアデータ.R_セクター_システム.R_システムファイルデータ = LR_ブロック_システムファイルデータ;
			return LR_ブロック_システムファイルデータ;
		}


		/// <summary>
		/// Mifareタグに記録されているデータを全読み込みして管理クラスを再構築します
		/// </summary>
		/// <param name="AR_Mifareタグデータ">Mifareタグに記録されている全byte[]データです、通しブロック番号0から順に全ブロックのデータのリスを指定します</param>
		public bool F_再構築(List<byte[]> AR_全Mifareタグデータ)
		{
			//全てのデータから管理クラスを再構築します
			return true;
		}



		/// <summary>
		/// データを管理クラスに書込みます
		/// 管理クラス内の各ブロッククラスオブジェクトに書き込まれます
		/// Mifareタグに記録されているデータとのズレをなくすため、必ず操作関数に代入して下さい
		/// </summary>
		/// <param name="AR_書込みデータリスト"></param>
		/// <returns></returns>
		public List<C_マイフェアデータ.B_ブロック> F_データ書込み(List<C_マイフェアデータ.B_データ> AR_書込みデータリスト)
		{
			return new List<C_マイフェアデータ.B_ブロック>();
		}


		public C_マイフェアデータ.B_ブロック F_データ読込み(ref C_マイフェアデータ.B_データ AR_読込みデータ)
		{
			return new C_マイフェアデータ.C_ブロック_ウェアレベリングデータ();
		}

		public uint F_UID取得()
		{
			return this.R_マイフェアデータ.R_セクター_システム.V_UID;
		}

		/// <summary>
		///	マイフェア管理クラスにより管理しているマイフェアのデータクラスです
		///	このデータクラスをシリアル化したシステムデータから復元可能です
		/// </summary>
		public class C_マイフェアデータ
		{
			#region 内部クラス定義

			public class C_セクタートレーラー設定
			{
				public en_アクセスビット状態 R_アクセスビット = en_アクセスビット状態.初期;
				public en_セクター識別 V_セクター識別 = en_セクター識別.未使用;

				public enum en_セクター識別
				{
					未使用 = 0, セクター_システム, セクター_リードオンリー, セクター_ウェアレベリング
				}

				public enum en_アクセスビット状態
				{
					初期 = 0, ロック前, ロック後
				}
			}

			public abstract class B_セクター
			{
				public byte V_セクターアドレス;
			}

			public class C_セクター_システム : B_セクター
			{
				public uint V_UID;
				[XmlIgnore]
				public C_ブロック_システムファイルデータ R_システムファイルデータ = new C_ブロック_システムファイルデータ();
				public C_ブロック_システムカウンターテータ R_システムカウンターデータ = new C_ブロック_システムカウンターテータ();
				public C_ブロック_システムセクタートレーラー R_システムセクタートレーラー = new C_ブロック_システムセクタートレーラー();

				public C_セクター_システム()
				{
				}
				public C_セクター_システム(char[] AR_システム名称)
				{
					R_システムセクタートレーラー.R_システム名称 = AR_システム名称;
				}
			}

			public class C_セクター_リードオンリー : B_セクター
			{
				public C_ブロック_リードオンリーデータ[] R_リードオンリーデータ_リスト = new C_ブロック_リードオンリーデータ[3];
				public C_ブロック_リードオンリーセクタートレーラー R_リードオンリーセクタートレーラー = new C_ブロック_リードオンリーセクタートレーラー();
			}

			public class C_セクター_ウェアレベリング : B_セクター
			{
				public C_ブロック_ウェアレベリングデータ[] R_ウェアレベリングデータ_リスト = new C_ブロック_ウェアレベリングデータ[3];
				public C_ブロック_ウェアレベリングセクタートレーラー R_ウェアレベリングセクタートレーラー = new C_ブロック_ウェアレベリングセクタートレーラー();
			}

			public class C_セクター_未使用 : B_セクター
			{
			}

			public abstract class B_ブロック
			{
				public S_ブロックアドレス V_ブロックアドレス = new S_ブロックアドレス();
				public byte[] R_ブロックデータ = new byte[16];
			}

			public class C_ブロック_システムファイルデータ : B_ブロック
			{
				public short V_システムファイル更新年;
				public byte V_システムファイル更新月;
				public byte V_システムファイル更新日;
				public byte V_システムファイル更新時;
				public byte V_システムファイル更新分;
				public byte V_システムファイル更新秒;
				public byte V_Check_MD5;
				public byte V_Check_SHA1;
				public byte V_Check_byte;
				public int V_システムファイルデータブロック取得時UID;
			}

			public class C_ブロック_システムカウンターテータ : B_ブロック
			{
				public short V_カウンター更新年;
				public byte V_カウンター更新月;
				public byte V_カウンター更新日;
				public byte V_カウンター更新時;
				public byte V_カウンター更新分;
				public byte V_カウンター更新秒;
				public int V_カウンター;
			}

			public class C_ブロック_システムセクタートレーラー : B_ブロック
			{
				public C_セクタートレーラー設定 R_セクタートレーラー設定 = new C_セクタートレーラー設定();
				public char[] R_システム名称;
			}

			public class C_ブロック_リードオンリーデータ : B_ブロック
			{
				public C_リードオンリーデータ R_リードオンリーデータ = new C_リードオンリーデータ();
			}

			public class C_ブロック_リードオンリーセクタートレーラー : B_ブロック
			{
				public C_セクタートレーラー設定 R_セクタートレーラー設定 = new C_セクタートレーラー設定();
				public short V_ロック年;
				public byte V_ロック月;
				public byte V_ロック日;
				public byte V_ロック時間;
				public byte[] R_データIDリスト = new byte[3];
			}

			public class C_ブロック_ウェアレベリングデータ : B_ブロック
			{
				public int V_書き換え回数;
				public byte V_不良回数;
			}

			public class C_ブロック_ウェアレベリングセクタートレーラー : B_ブロック
			{
				public byte V_不良ブロック情報;
			}

			public abstract class B_データ
			{
				public byte V_データID;
				public S_ブロックアドレス V_最終書き込みアドレス = new S_ブロックアドレス();
			}

			public class C_リードオンリーデータ : B_データ
			{
				public byte[] R_ROデータ = new byte[16];
			}

			public class C_ウェアレベリングデータ : B_データ
			{
				public byte[] R_RWデータ = new byte[4];
				public byte V_データカウンター;
			}

			public class C_システムデータ
			{
				public byte[] R_ROデータ = new byte[6];
			}

			public struct S_ブロックアドレス
			{
				public byte V_セクターアドレス;
				public byte V_ブロックアドレス;
			}

			#endregion

			public static byte[] SR_KeyA = new byte[6] { 0xf1, 0xa0, 0xc0, 0x80, 0x0e, 0x40 };

			/// <summary>
			/// シリアル化のために残しています
			/// 通常はアプリケーションコード内で使用しないで下さい
			/// </summary>
			public C_マイフェアデータ()
			{
			}

			/// <summary>
			/// セクターNo0のセクターデータです
			/// </summary>
			public C_セクター_システム R_セクター_システム;

			/// <summary>
			/// 保有するリードオンリーに割り当て、データを格納済みセクターのリストです
			/// 初期化時に空きとなっているセクターは全てリードオンリーの予約セクターとなります
			/// </summary>
			public List<C_セクター_リードオンリー> R_セクター_リードオンリー_リスト = new List<C_セクター_リードオンリー>();

			/// <summary>
			/// 保有するウェアレベリング用に割り当てたセクターのリストです
			/// 初期化時に最終セクターNoから指定したセクター数を割り当てます
			/// 初期化以外の時にこのリストに追加したり削除されることはありません
			/// ウェアレベリングデータはこれらのセクター内のウェアレベリングブロック全てが対象となります
			/// </summary>
			public List<C_セクター_ウェアレベリング> R_セクター_ウェアレベリング_リスト = new List<C_セクター_ウェアレベリング>();

			/// <summary>
			/// 登録済みのデータのリストです
			/// データにはリードオンリーデータとウェアレベリングデータがあります
			/// </summary>
			public List<B_データ> R_データ_リスト = new List<B_データ>();

			/// <summary>
			/// このMifareタグに存在する総セクター数です
			/// Mifare1kは16セクターです
			/// </summary>
			public int V_総セクター数 = 16;

			/// <summary>
			/// 次のウェアレベリングデータを書き込むアドレスです
			/// 書込み対象ブロックの書込み回数が全体の書込み回数と同じになったら次のブロックへ予約を移動します
			/// 予約アドレスの移動はセクターNoの小さい順でブロックNoの小さいブロックから順に進めます
			/// </summary>
			public S_ブロックアドレス V_書き込み予約アドレス;

			/// <summary>
			/// このMifareタグの初期化が完了しているかどうかを示します
			/// </summary>
			public bool V_初期化済み;


		}

	}
}
