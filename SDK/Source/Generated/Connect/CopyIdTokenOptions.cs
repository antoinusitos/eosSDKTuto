// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Connect
{
	/// <summary>
	/// Input parameters for the <see cref="ConnectInterface.CopyIdToken" /> function.
	/// </summary>
	public class CopyIdTokenOptions
	{
		/// <summary>
		/// The local Product User ID whose ID token should be copied.
		/// </summary>
		public ProductUserId LocalUserId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CopyIdTokenOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public void Set(CopyIdTokenOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = ConnectInterface.CopyidtokenApiLatest;
				LocalUserId = other.LocalUserId;
			}
		}

		public void Set(object other)
		{
			Set(other as CopyIdTokenOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LocalUserId);
		}
	}
}