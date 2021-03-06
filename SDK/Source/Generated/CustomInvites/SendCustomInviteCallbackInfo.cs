// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.CustomInvites
{
	/// <summary>
	/// Output parameters for the <see cref="CustomInvitesInterface.SendCustomInvite" /> Function. These parameters are received through the callback provided to <see cref="CustomInvitesInterface.SendCustomInvite" />
	/// </summary>
	public class SendCustomInviteCallbackInfo : ICallbackInfo, ISettable
	{
		/// <summary>
		/// The <see cref="Result" /> code for the operation. <see cref="Result.Success" /> indicates that the operation succeeded; other codes indicate errors.
		/// </summary>
		public Result ResultCode { get; private set; }

		/// <summary>
		/// Context that was passed into <see cref="CustomInvitesInterface.SendCustomInvite" />
		/// </summary>
		public object ClientData { get; private set; }

		/// <summary>
		/// Local user sending a CustomInvite
		/// </summary>
		public ProductUserId LocalUserId { get; private set; }

		/// <summary>
		/// Users to whom the invites were successfully sent (can be different than original call if an invite for same Payload was previously sent)
		/// </summary>
		public ProductUserId[] TargetUserIds { get; private set; }

		public Result? GetResultCode()
		{
			return ResultCode;
		}

		internal void Set(SendCustomInviteCallbackInfoInternal? other)
		{
			if (other != null)
			{
				ResultCode = other.Value.ResultCode;
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				TargetUserIds = other.Value.TargetUserIds;
			}
		}

		public void Set(object other)
		{
			Set(other as SendCustomInviteCallbackInfoInternal?);
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct SendCustomInviteCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_TargetUserIds;
		private uint m_TargetUserIdsCount;

		public Result ResultCode
		{
			get
			{
				return m_ResultCode;
			}
		}

		public object ClientData
		{
			get
			{
				object value;
				Helper.TryMarshalGet(m_ClientData, out value);
				return value;
			}
		}

		public System.IntPtr ClientDataAddress
		{
			get
			{
				return m_ClientData;
			}
		}

		public ProductUserId LocalUserId
		{
			get
			{
				ProductUserId value;
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
		}

		public ProductUserId[] TargetUserIds
		{
			get
			{
				ProductUserId[] value;
				Helper.TryMarshalGetHandle(m_TargetUserIds, out value, m_TargetUserIdsCount);
				return value;
			}
		}
	}
}