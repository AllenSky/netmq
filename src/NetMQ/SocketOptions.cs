﻿using System;
using JetBrains.Annotations;
using NetMQ.zmq;

namespace NetMQ
{
    public class SocketOptions
    {
        private readonly NetMQSocket m_socket;

        public SocketOptions([NotNull] NetMQSocket socket)
        {
            m_socket = socket;
        }

        public long Affinity
        {
            get { return m_socket.GetSocketOptionLong(ZmqSocketOptions.Affinity); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.Affinity, value); }
        }

        [Obsolete("This property doesn't effect NetMQ anymore")]
        public bool CopyMessages
        {
            get { return false; }
            set { }
        }

        public byte[] Identity
        {
            [CanBeNull] get { return m_socket.GetSocketOptionX<byte[]>(ZmqSocketOptions.Identity); }
            [NotNull] set { m_socket.SetSocketOption(ZmqSocketOptions.Identity, value); }
        }

        public int MulticastRate
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.Rate); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.Rate, value); }
        }

        public TimeSpan MulticastRecoveryInterval
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.ReconnectIvl); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.ReconnectIvl, value); }
        }

        public int SendBuffer
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.SendBuffer); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.SendBuffer, value); }
        }

        [Obsolete("Use ReceiveBuffer instead")]
        public int ReceivevBuffer
        {
            get { return ReceiveBuffer; }
            set { ReceiveBuffer = value; }
        }

        public int ReceiveBuffer
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.ReceiveBuffer); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.ReceiveBuffer, value); }
        }

        /// <summary>
        /// Gets whether the last frame received on the socket had the <em>more</em> flag set or not.
        /// </summary>
        /// <value><c>true</c> if receive more; otherwise, <c>false</c>.</value>
        public bool ReceiveMore
        {
            get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.ReceiveMore); }
//            set { m_socket.SetSocketOption(ZmqSocketOptions.ReceiveMore, value); }
        }

        public TimeSpan Linger
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.Linger); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.Linger, value); }
        }

        public TimeSpan ReconnectInterval
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.ReconnectIvl); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.ReconnectIvl, value); }
        }

        public TimeSpan ReconnectIntervalMax
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.ReconnectIvl); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.ReconnectIvl, value); }
        }

        public int Backlog
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.Backlog); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.Backlog, value); }
        }

        public long MaxMsgSize
        {
            get { return m_socket.GetSocketOptionLong(ZmqSocketOptions.Maxmsgsize); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.Maxmsgsize, value); }
        }

        public int SendHighWatermark
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.SendHighWatermark); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.SendHighWatermark, value); }
        }

        public int ReceiveHighWatermark
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.ReceiveHighWatermark); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.ReceiveHighWatermark, value); }
        }

        public int MulticastHops
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.MulticastHops); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.MulticastHops, value); }
        }

        public TimeSpan ReceiveTimeout
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.ReceiveTimeout); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.ReceiveTimeout, value); }
        }

        public TimeSpan SendTimeout
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.SendTimeout); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.SendTimeout, value); }
        }

        public bool IPv4Only
        {
            get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.IPv4Only); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.IPv4Only, value); }
        }

        [Obsolete("Use LastEndpoint instead")]
        [CanBeNull]
        public string GetLastEndpoint
        {
            get { return LastEndpoint; }
        }

        [CanBeNull]
        public string LastEndpoint
        {
            get { return m_socket.GetSocketOptionX<string>(ZmqSocketOptions.LastEndpoint); }
        }

        public bool RouterMandatory
        {
//            get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.RouterMandatory); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.RouterMandatory, value); }
        }

        public bool TcpKeepalive
        {
            get { return m_socket.GetSocketOption(ZmqSocketOptions.TcpKeepalive) == 1; }
            set { m_socket.SetSocketOption(ZmqSocketOptions.TcpKeepalive, value ? 1 : 0); }
        }

        [Obsolete("This option is not supported and has no effect")]
        public int TcpKeepaliveCnt
        {
//            get { return m_socket.GetSocketOption(ZmqSocketOptions.TcpKeepaliveCnt); }
            set { /* m_socket.SetSocketOption(ZmqSocketOptions.TcpKeepaliveCnt, value); */ }
        }

        public TimeSpan TcpKeepaliveIdle
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.TcpKeepaliveIdle); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.TcpKeepaliveIdle, value); }
        }

        public TimeSpan TcpKeepaliveInterval
        {
            get { return m_socket.GetSocketOptionTimeSpan(ZmqSocketOptions.TcpKeepaliveIntvl); }
            set { m_socket.SetSocketOptionTimeSpan(ZmqSocketOptions.TcpKeepaliveIntvl, value); }
        }

        [CanBeNull]
        public string TcpAcceptFilter
        {
            // TODO the logic here doesn't really suit a setter -- set values are appended to a list, and null clear that list
            // get { return m_socket.GetSocketOptionX<string>(ZmqSocketOptions.TcpAcceptFilter); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.TcpAcceptFilter, value); }
        }

        public bool DelayAttachOnConnect
        {
            get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.DelayAttachOnConnect); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.DelayAttachOnConnect, value); }
        }

        public bool XPubVerbose
        {
//            get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.XpubVerbose); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.XpubVerbose, value); }
        }

        public bool RouterRawSocket
        {
//            get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.RouterRawSocket); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.RouterRawSocket, value); }
        }

        public Endianness Endian
        {
            get { return m_socket.GetSocketOptionX<Endianness>(ZmqSocketOptions.Endian); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.Endian, value); }
        }

        public bool ManualPublisher
        {
            // get { return m_socket.GetSocketOptionX<bool>(ZmqSocketOptions.XPublisherManual); }
            set { m_socket.SetSocketOption(ZmqSocketOptions.XPublisherManual, value); }
        }
    }
}
