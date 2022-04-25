// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Presence
{
	/// <summary>
	/// All the known presence information for a specific user. This object must be released by calling <see cref="PresenceInterface.Release" />.
	/// <seealso cref="PresenceInterface.CopyPresence" />
	/// <seealso cref="PresenceInterface.Release" />
	/// </summary>
	public class Info : ISettable
	{
		/// <summary>
		/// The status of the user
		/// </summary>
		public Status Status { get; set; }

		/// <summary>
		/// The Epic Account ID of the user
		/// </summary>
		public EpicAccountId UserId { get; set; }

		/// <summary>
		/// The product ID that the user is logged in from
		/// </summary>
		public string ProductId { get; set; }

		/// <summary>
		/// The version of the product the user is logged in from
		/// </summary>
		public string ProductVersion { get; set; }

		/// <summary>
		/// The platform of that the user is logged in from
		/// </summary>
		public string Platform { get; set; }

		/// <summary>
		/// The rich-text of the user
		/// </summary>
		public string RichText { get; set; }

		/// <summary>
		/// The first data record, or NULL if RecordsCount is not at least 1
		/// </summary>
		public DataRecord[] Records { get; set; }

		/// <summary>
		/// The user-facing name for the product the user is logged in from
		/// </summary>
		public string ProductName { get; set; }

		internal void Set(InfoInternal? other)
		{
			if (other != null)
			{
				Status = other.Value.Status;
				UserId = other.Value.UserId;
				ProductId = other.Value.ProductId;
				ProductVersion = other.Value.ProductVersion;
				Platform = other.Value.Platform;
				RichText = other.Value.RichText;
				Records = other.Value.Records;
				ProductName = other.Value.ProductName;
			}
		}

		public void Set(object other)
		{
			Set(other as InfoInternal?);
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct InfoInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private Status m_Status;
		private System.IntPtr m_UserId;
		private System.IntPtr m_ProductId;
		private System.IntPtr m_ProductVersion;
		private System.IntPtr m_Platform;
		private System.IntPtr m_RichText;
		private int m_RecordsCount;
		private System.IntPtr m_Records;
		private System.IntPtr m_ProductName;

		public Status Status
		{
			get
			{
				return m_Status;
			}

			set
			{
				m_Status = value;
			}
		}

		public EpicAccountId UserId
		{
			get
			{
				EpicAccountId value;
				Helper.TryMarshalGet(m_UserId, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_UserId, value);
			}
		}

		public string ProductId
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_ProductId, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_ProductId, value);
			}
		}

		public string ProductVersion
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_ProductVersion, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_ProductVersion, value);
			}
		}

		public string Platform
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_Platform, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_Platform, value);
			}
		}

		public string RichText
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_RichText, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_RichText, value);
			}
		}

		public DataRecord[] Records
		{
			get
			{
				DataRecord[] value;
				Helper.TryMarshalGet<DataRecordInternal, DataRecord>(m_Records, out value, m_RecordsCount);
				return value;
			}

			set
			{
				Helper.TryMarshalSet<DataRecordInternal, DataRecord>(ref m_Records, value, out m_RecordsCount);
			}
		}

		public string ProductName
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_ProductName, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_ProductName, value);
			}
		}

		public void Set(Info other)
		{
			if (other != null)
			{
				m_ApiVersion = PresenceInterface.InfoApiLatest;
				Status = other.Status;
				UserId = other.UserId;
				ProductId = other.ProductId;
				ProductVersion = other.ProductVersion;
				Platform = other.Platform;
				RichText = other.RichText;
				Records = other.Records;
				ProductName = other.ProductName;
			}
		}

		public void Set(object other)
		{
			Set(other as Info);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_UserId);
			Helper.TryMarshalDispose(ref m_ProductId);
			Helper.TryMarshalDispose(ref m_ProductVersion);
			Helper.TryMarshalDispose(ref m_Platform);
			Helper.TryMarshalDispose(ref m_RichText);
			Helper.TryMarshalDispose(ref m_Records);
			Helper.TryMarshalDispose(ref m_ProductName);
		}
	}
}