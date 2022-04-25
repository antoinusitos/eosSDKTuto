// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.PlayerDataStorage
{
	/// <summary>
	/// Input data for the <see cref="PlayerDataStorageInterface.DeleteFile" /> function
	/// </summary>
	public class DeleteFileOptions
	{
		/// <summary>
		/// The Product User ID of the local user who authorizes deletion of the file; must be the file's owner
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The name of the file to delete
		/// </summary>
		public string Filename { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct DeleteFileOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_Filename;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public string Filename
		{
			set
			{
				Helper.TryMarshalSet(ref m_Filename, value);
			}
		}

		public void Set(DeleteFileOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = PlayerDataStorageInterface.DeletefileoptionsApiLatest;
				LocalUserId = other.LocalUserId;
				Filename = other.Filename;
			}
		}

		public void Set(object other)
		{
			Set(other as DeleteFileOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_Filename);
		}
	}
}