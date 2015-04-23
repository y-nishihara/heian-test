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
		/// マイフェアの管理クラスを定義しています
		/// このクラスにてマイフェアRFIDタグへのデータ保存、読込みを管理します
		/// Mifareタグリーダーに対して1対1です
		/// </summary>
		/// <param name="AR_システム名称">システムの照合用の名称を6バイト以内にて指定します、6バイト以上は切り捨てられます</param>
		public C_マイフェア管理(string AR_システム名称)
		{
			byte[] LR_value = Encoding.GetEncoding("shift_jis").GetBytes(AR_システム名称);
			int LR_長 = LR_value.Length > 6 ? 6 : LR_value.Length;
			Array.Copy(LR_value, 0, this.R_システム識別, 0, LR_長);
		}

		/// <summary>
		/// 管理しているデータクラスのインスタンスを格納します
		/// 初期化、もしくはマージにより生成します
		/// 確認のため開発中のみpublicとします
		/// </summary>
		public C_マイフェアデータ R_マイフェアデータ = null;

		/// <summary>
		/// システム識別のためのデータを格納します
		/// マイフェア管理クラスのコンストラクターにて文字列を指定します
		/// 6バイト以上は切り捨てます
		/// 文字コードは「shift_jis」です
		/// </summary>
		Byte[] R_システム識別 = new byte[6] { 0, 0, 0, 0, 0, 0 };

		/// 総セクター数とウェアレベリング用に割り当てるセクター数を指定して初期化したマイフェアデータクラスを返します
		/// </summary>
		/// <param name="AV_総セクター数">このマイフェアタグに存在する総セクター数を指定します</param>
		/// <param name="AV_ウェアレベリングセクター数">ウェアレベリング用に予約するセクター数を指定します</param>
		/// <returns>更新されたデータクラスを返します、実際に書込するには操作関数に代入して下さい、初期化済みの場合はnullを返します</returns>
		public C_マイフェアデータ F_初期化(int AV_総セクター数, int AV_ウェアレベリングセクター数)
		{
			if (this.R_マイフェアデータ != null)
			{
				return null;
			}

			if (AV_ウェアレベリングセクター数 > (AV_総セクター数 - 1))
			{
				//例外を出すようにします
				return null;
			}

			this.R_マイフェアデータ = new C_マイフェアデータ();

			//仮コードです
			this.R_マイフェアデータ.R_セクター_ウェアレベリング_リスト.Clear();
			for (int i = 0; i < AV_ウェアレベリングセクター数; i++)
			{
				this.R_マイフェアデータ.R_セクター_ウェアレベリング_リスト.Add(new C_マイフェアデータ.C_セクター_ウェアレベリング());
			}
			this.R_マイフェアデータ.R_セクター_システム = new C_マイフェアデータ.C_セクター_システム(this.R_システム識別);

			//初期定義が終了したマイフェアのデータクラスオブジェクトを返します
			return this.R_マイフェアデータ;
		}

		/// 管理ファイルファイルデータを指定して管理ファイルを復元します
		/// </summary>
		/// <param name="AR_管理ファイルデータ">マイフェアタグから読み取った管理ファイルデータを指定します</param>
		/// <returns>管理ファイルを復元出来たかどうかを返します</returns>
		public bool F_管理ファイル読込み(C_マイフェアデータ.C_ブロック_管理ファイルデータ AR_管理ファイルデータ)
		{
			C_マイフェアデータ LR_マイフェア = null;
			//ライブラリーによりファイル保存します
			using (C_XMLストリーム<C_マイフェアデータ> U_xml = new C_XMLストリーム<C_マイフェアデータ>(C_定数.P_設定保存ディレクトリ + "管理ファイル\\", AR_管理ファイルデータ.V_管理ファイルデータブロック取得時UID.ToString() + ".nci"))
			{
				if (U_xml.F_読込(ref LR_マイフェア, false) == false)
				{
					return false;
				}
				//管理ファイルデータを作成します
				if (System.IO.File.Exists(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名) == true)
				{
					System.IO.FileInfo fi = new System.IO.FileInfo(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名);
					if (AR_管理ファイルデータ.V_管理ファイル更新年 != (short)fi.LastWriteTime.Year) return false;
					if (AR_管理ファイルデータ.V_管理ファイル更新月 != (byte)fi.LastWriteTime.Month) return false;
					if (AR_管理ファイルデータ.V_管理ファイル更新日 != (byte)fi.LastWriteTime.Day) return false;
					if (AR_管理ファイルデータ.V_管理ファイル更新時 != (byte)fi.LastWriteTime.Hour) return false;
					if (AR_管理ファイルデータ.V_管理ファイル更新分 != (byte)fi.LastWriteTime.Minute) return false;
					if (AR_管理ファイルデータ.V_管理ファイル更新秒 != (byte)fi.LastWriteTime.Second) return false;

					using (System.IO.FileStream fs = fi.OpenRead())
					{

						//CheckByte
						int LV_読込みバイト;
						byte LV_チェックバイト = 0 ;
						while ((LV_読込みバイト = fs.ReadByte()) != -1)
						{
							LV_チェックバイト = (byte)((LV_チェックバイト + LV_読込みバイト) % byte.MaxValue);
						}
						if (AR_管理ファイルデータ.V_Check_byte != LV_チェックバイト) return false;

						//CheckMD5
						if (AR_管理ファイルデータ.V_Check_MD5 != C_チェック.F_サムチェック(C_ファイル操作.SF_MD5ハッシュ値の取得(fs))) return false;

						//CheckSHA1
						if (AR_管理ファイルデータ.V_Check_SHA1 != C_チェック.F_サムチェック(C_ファイル操作.SF_SHA1ハッシュ値の取得(fs))) return false;

					}
				}
			}
			return true;
		}

		/// <summary>
		/// 管理クラスを管理ファイルに保存します
		/// ファイル保存場所は設定ディレクトリー下の「管理ファイル」フォルダー内に保存します
		/// ファイル名は「{UID}.nci」です
		/// </summary>
		/// <returns>更新後のされた管理ファイルデータを返します、Mifareタグへ管理ファイル情報を記録するには操作関数に代入して下さい</returns>
		public C_マイフェアデータ.C_ブロック_管理ファイルデータ F_管理ファイル保存()
		{
			C_マイフェアデータ.C_ブロック_管理ファイルデータ LR_ブロック_管理ファイルデータ = new C_マイフェアデータ.C_ブロック_管理ファイルデータ();

			//ライブラリーによりファイル保存します
			using (C_XMLストリーム<C_マイフェアデータ> U_xml = new C_XMLストリーム<C_マイフェアデータ>(C_定数.P_設定保存ディレクトリ + "管理ファイル\\", this.R_マイフェアデータ.R_セクター_システム.V_UID.ToString() + ".nci"))
			{
				U_xml.F_保存(this.R_マイフェアデータ, true);

				//管理ファイルデータを作成します
				if (System.IO.File.Exists(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名) == true)
				{
					System.IO.FileInfo fi = new System.IO.FileInfo(U_xml.P_保存ディレクトリ + U_xml.P_ファイル名);
					LR_ブロック_管理ファイルデータ.V_管理ファイル更新年 = (short)fi.LastWriteTime.Year;
					LR_ブロック_管理ファイルデータ.V_管理ファイル更新月 = (byte)fi.LastWriteTime.Month;
					LR_ブロック_管理ファイルデータ.V_管理ファイル更新日 = (byte)fi.LastWriteTime.Day;
					LR_ブロック_管理ファイルデータ.V_管理ファイル更新時 = (byte)fi.LastWriteTime.Hour;
					LR_ブロック_管理ファイルデータ.V_管理ファイル更新分 = (byte)fi.LastWriteTime.Minute;
					LR_ブロック_管理ファイルデータ.V_管理ファイル更新秒 = (byte)fi.LastWriteTime.Second;

					System.IO.FileStream fs = fi.OpenRead();

					//CheckByte
					int LV_読込みバイト;
					while ((LV_読込みバイト = fs.ReadByte()) != -1)
					{
						LR_ブロック_管理ファイルデータ.V_Check_byte = (byte)((LR_ブロック_管理ファイルデータ.V_Check_byte + LV_読込みバイト) % byte.MaxValue);
					}

					//CheckMD5
					LR_ブロック_管理ファイルデータ.V_Check_MD5 = C_チェック.F_サムチェック(C_ファイル操作.SF_MD5ハッシュ値の取得(fs));

					//CheckSHA1
					LR_ブロック_管理ファイルデータ.V_Check_SHA1 = C_チェック.F_サムチェック(C_ファイル操作.SF_SHA1ハッシュ値の取得(fs));

					fs.Close();
				}
			}
			this.R_マイフェアデータ.R_セクター_システム.R_管理ファイルデータ = LR_ブロック_管理ファイルデータ;
			return LR_ブロック_管理ファイルデータ;
		}

		/// <summary>
		/// Mifareタグに記録されているデータを全読み込みして管理クラスを再構築します
		/// 有効なデータでない場合にはR_マイフェアデータオブジェクトはnullとします
		/// システム識別も確認します
		/// 初期化されていない場合も同様にnullとします
		/// </summary>
		/// <param name="AR_全Mifareタグデータ">マイフェアタグから読み取った全データリストを指定します</param>
		/// <returns>再構築に成功したかどうかを返します</returns>
		public bool F_再構築(List<byte[]> AR_全Mifareタグデータリスト)
		{
			//this.R_マイフェアデータ = null;
			this.R_マイフェアデータ = new C_マイフェアデータ();
			this.R_マイフェアデータ.R_セクター_システム = new C_マイフェアデータ.C_セクター_システム(this.R_システム識別);
			//全てのデータから管理クラスを再構築します
			return true;
		}



		///// <summary>
		///// データを管理クラスに書込みます
		///// 管理クラス内の各ブロッククラスオブジェクトに書き込まれます
		///// Mifareタグに記録されているデータとのズレをなくすため、必ず操作関数に代入して下さい
		///// </summary>
		///// <param name="AR_書込みデータリスト"></param>
		///// <returns></returns>
		/// <summary>
		/// データを管理クラスに書込みます
		/// 管理クラス内の各ブロッククラスオブジェクトに書き込まれます
		/// Mifareタグに記録されているデータとのズレをなくすため、必ず操作関数に代入して下さい
		/// </summary>
		/// <param name="AR_書込みデータリスト">同時に書き込むデータのリストです</param>
		/// <returns>マイフェアタグに書き込むためのブロックデータリストです、操作関数に代入してください</returns>
		public List<C_マイフェアデータ.B_ブロック> F_データ書込み(List<C_マイフェアデータ.B_データ> AR_書込みデータリスト)
		{
			foreach (var fe in AR_書込みデータリスト)
			{
				fe.V_書込み済み = true;
			}
			return new List<C_マイフェアデータ.B_ブロック>();
		}

		/// <summary>
		/// データを管理クラスから更新します
		/// </summary>
		/// <param name="AR_読込みデータ">更新するデータを指定します</param>
		/// <returns>マイフェアタグに記録されているデータの照合用にブロックデータを返します</returns>
		public C_マイフェアデータ.B_ブロック F_データ読込み(C_マイフェアデータ.B_データ AR_読込みデータ)
		{
			return new C_マイフェアデータ.C_ブロック_ウェアレベリングデータ();
		}

		/// <summary>
		/// データを管理クラスから更新します
		/// </summary>
		/// <param name="AR_読込みデータリスト">更新するデータリストを指定します</param>
		public void F_データ読込み(List<C_マイフェアデータ.B_データ> AR_読込みデータリスト)
		{
		}

		/// <summary>
		/// 管理クラスで保持しているUIDを取得します
		/// マイフェアタグの更新を確認するためのポーリング処理に使用します
		/// </summary>
		/// <returns>UIDを返します</returns>
		public uint F_UID取得()
		{
			return this.R_マイフェアデータ.R_セクター_システム.V_UID;
		}

		/// <summary>
		///	マイフェア管理クラスにより管理しているマイフェアのデータクラスです
		///	このデータクラスをシリアル化した管理ファイルから復元可能です
		/// </summary>
		public class C_マイフェアデータ
		{
			#region 内部クラス定義

			/// <summary>
			/// セクタートレーラー内のアクセスビット情報とセクター識別情報を定義します
			/// </summary>
			public class C_セクタートレーラー設定
			{
				public en_アクセスビット状態 R_アクセスビット = en_アクセスビット状態.リードオンリーロック前;

				public en_セクター識別 V_セクター識別 = en_セクター識別.未使用;

				public enum en_セクター識別
				{
					未使用 = 0, セクター_システム, セクター_リードオンリー, セクター_ウェアレベリング
				}

				public enum en_アクセスビット状態
				{
					リードライト = 0, リードオンリーロック前, リードオンリーロック後
				}
			}

			/// <summary>
			/// セクターに対する基本クラスです
			/// </summary>
			public abstract class B_セクター
			{
				public byte V_セクターアドレス;
			}

			/// <summary>
			/// セクターNo0のシステム情報用セクターを定義します
			/// </summary>
			public class C_セクター_システム : B_セクター
			{
				public uint V_UID;
				[XmlIgnore]
				public C_ブロック_管理ファイルデータ R_管理ファイルデータ = new C_ブロック_管理ファイルデータ();
				public C_ブロック_システムカウンターテータ R_システムカウンターデータ = new C_ブロック_システムカウンターテータ();
				public C_ブロック_システムセクタートレーラー R_システムセクタートレーラー = new C_ブロック_システムセクタートレーラー();

				public C_セクター_システム()
				{
				}
				public C_セクター_システム(byte[] AR_システム識別)
				{
					R_システムセクタートレーラー.R_システム識別 = AR_システム識別;
				}
			}

			/// <summary>
			/// リードオンリーデータ用のセクターを定義します
			/// </summary>
			public class C_セクター_リードオンリー : B_セクター
			{
				public C_ブロック_リードオンリーデータ[] R_リードオンリーデータ_リスト = new C_ブロック_リードオンリーデータ[3];
				public C_ブロック_リードオンリーセクタートレーラー R_リードオンリーセクタートレーラー = new C_ブロック_リードオンリーセクタートレーラー();
			}

			/// <summary>
			/// ウェアレベリング用のセクターを定義します
			/// </summary>
			public class C_セクター_ウェアレベリング : B_セクター
			{
				public C_ブロック_ウェアレベリングデータ[] R_ウェアレベリングデータ_リスト = new C_ブロック_ウェアレベリングデータ[3];
				public C_ブロック_ウェアレベリングセクタートレーラー R_ウェアレベリングセクタートレーラー = new C_ブロック_ウェアレベリングセクタートレーラー();
			}

			/// <summary>
			/// ブロックに対する基本クラスです
			/// </summary>
			public abstract class B_ブロック
			{
				public S_ブロックアドレス V_ブロックアドレス = new S_ブロックアドレス();
				public byte[] R_ブロックデータ = new byte[16];
			}

			/// <summary>
			/// 管理ファイルの整合性を確認するためのデータを保有するブロックを定義します
			/// </summary>
			public class C_ブロック_管理ファイルデータ : B_ブロック
			{
				public short V_管理ファイル更新年;
				public byte V_管理ファイル更新月;
				public byte V_管理ファイル更新日;
				public byte V_管理ファイル更新時;
				public byte V_管理ファイル更新分;
				public byte V_管理ファイル更新秒;
				public byte V_Check_MD5;
				public byte V_Check_SHA1;
				public byte V_Check_byte;
				public int V_管理ファイルデータブロック取得時UID;
			}

			/// <summary>
			/// 全体のカウンター情報を保有するブロックを定義します
			/// </summary>
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

			/// <summary>
			/// システムセクターのセクタートレーラーブロックを定義します
			/// </summary>
			public class C_ブロック_システムセクタートレーラー : B_ブロック
			{
				public C_セクタートレーラー設定 R_セクタートレーラー設定 = new C_セクタートレーラー設定();
				public byte[] R_システム識別;
			}

			/// <summary>
			/// リードオンリーデータを保有するブロックを定義します
			/// </summary>
			public class C_ブロック_リードオンリーデータ : B_ブロック
			{
				public C_リードオンリーデータ R_リードオンリーデータ = new C_リードオンリーデータ();
			}

			/// <summary>
			/// リードオンリーセクターのセクタートレーラーブロックを定義します
			/// </summary>
			public class C_ブロック_リードオンリーセクタートレーラー : B_ブロック
			{
				public C_セクタートレーラー設定 R_セクタートレーラー設定 = new C_セクタートレーラー設定();
				public short V_ロック年;
				public byte V_ロック月;
				public byte V_ロック日;
				public byte V_ロック時間;
				public byte[] R_データIDリスト = new byte[3];
			}

			/// <summary>
			/// ウェアレベリングデータのために予約されたブロックを定義します
			/// </summary>
			public class C_ブロック_ウェアレベリングデータ : B_ブロック
			{
				public int V_書き換え回数;
				public byte V_不良回数;
			}

			/// <summary>
			/// ウェアレベリングセクターのセクタートレーラーブロックを定義します
			/// </summary>
			public class C_ブロック_ウェアレベリングセクタートレーラー : B_ブロック
			{
				public byte V_不良ブロック情報;
			}

			/// <summary>
			/// データに対する基底クラスを定義します
			/// </summary>
			public abstract class B_データ
			{
				public byte V_データID;
				public S_ブロックアドレス V_最終書き込みアドレス = new S_ブロックアドレス();
				public bool V_書込み済み = false;
			}

			/// <summary>
			/// 読込み専用データを定義します
			/// 初回に1度のみ書込み出来、その後はロックされて読込みのみに制限されます
			/// データ容量は16バイトです
			/// </summary>
			public class C_リードオンリーデータ : B_データ
			{
				public byte[] R_ROデータ = new byte[16];
			}

			/// <summary>
			/// 読み書き可能なデータを定義します
			/// 書込みエリアは局所破壊防止のためウェアレベリングされます
			/// データ容量は4バイトです
			/// 書き込まれたデータはエラー訂正されます
			/// </summary>
			public class C_ウェアレベリングデータ : B_データ
			{
				public byte[] R_RWデータ = new byte[4];
				public byte V_データカウンター;
			}

			/// <summary>
			/// セクターとブロックのアドレスを定義します
			/// </summary>
			public struct S_ブロックアドレス
			{
				public byte V_セクターアドレス;
				public byte V_ブロックアドレス;
			}

			#endregion

			/// <summary>
			/// 標準アクセスキーを定義します
			/// </summary>
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

			///// <summary>
			///// このMifareタグの初期化が完了しているかどうかを示します
			///// </summary>
			//public bool V_初期化済み;


		}

	}
}
