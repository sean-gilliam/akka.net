//-----------------------------------------------------------------------
// <copyright file="DataTypes.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Akka.Remote.Transport;
using Akka.Util;
using Address = Akka.Actor.Address;

namespace Akka.Remote.TestKit
{
    /// <summary>
    /// TBD
    /// </summary>
    public sealed class RoleName
    {
        readonly string _name;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="name">TBD</param>
        public RoleName(string name)
        {
            _name = name;
        }

        bool Equals(RoleName other)
        {
            return string.Equals(_name, other._name);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RoleName)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(RoleName left, RoleName right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(RoleName left, RoleName right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override string ToString()
        {
            return string.Format("RoleName({0})", _name);
        }
    }

    //TODO: This is messy, better way to do this?
    //Marker interface to avoid using reflection to work out if message
    //is derived from generic type
    /// <summary>
    /// TBD
    /// </summary>
    interface IToClient
    {
        /// <summary>
        /// TBD
        /// </summary>
        object Msg { get; }
    }

    /// <summary>
    /// TBD
    /// </summary>
    /// <typeparam name="T">TBD</typeparam>
    class ToClient<T> : IToClient where T : IClientOp, INetworkOp
    {
        private readonly T _msg;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="msg">TBD</param>
        public ToClient(T msg)
        {
            _msg = msg;
        }

        object IToClient.Msg
        {
            get { return _msg; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public T Msg
        {
            get { return _msg; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="other">TBD</param>
        /// <returns>TBD</returns>
        protected bool Equals(ToClient<T> other)
        {
            return EqualityComparer<T>.Default.Equals(_msg, other._msg);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ToClient<T>)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(_msg);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(ToClient<T> left, ToClient<T> right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(ToClient<T> left, ToClient<T> right)
        {
            return !Equals(left, right);
        }
    }

    //TODO: This is messy, better way to do this?
    //Marker interface to avoid using reflection to work out if message
    //is derived from generic type
    /// <summary>
    /// TBD
    /// </summary>
    interface IToServer
    {
        /// <summary>
        /// TBD
        /// </summary>
        object Msg { get; }
    }

    /// <summary>
    /// TBD
    /// </summary>
    /// <typeparam name="T">TBD</typeparam>
    class ToServer<T> : IToServer where T : IServerOp, INetworkOp
    {
        readonly T _msg;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="msg">TBD</param>
        public ToServer(T msg)
        {
            _msg = msg;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public T Msg
        {
            get { return _msg; }
        }

        object IToServer.Msg
        {
            get { return _msg; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="other">TBD</param>
        /// <returns>TBD</returns>
        protected bool Equals(ToServer<T> other)
        {
            return EqualityComparer<T>.Default.Equals(_msg, other._msg);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ToServer<T>)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(_msg);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(ToServer<T> left, ToServer<T> right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(ToServer<T> left, ToServer<T> right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    interface IClientOp { } // messages sent to from Conductor to Player
    /// <summary>
    /// TBD
    /// </summary>
    interface IServerOp { } // messages sent to from Player to Conductor
    /// <summary>
    /// TBD
    /// </summary>
    interface ICommandOp { } // messages sent from TestConductorExt to Conductor
    /// <summary>
    /// TBD
    /// </summary>
    interface INetworkOp { } // messages sent over the wire
    /// <summary>
    /// TBD
    /// </summary>
    interface IUnconfirmedClientOp : IClientOp { } // unconfirmed messages going to the Player
    /// <summary>
    /// TBD
    /// </summary>
    interface IConfirmedClientOp : IClientOp { }

    /// <summary>
    /// First message of connection sets names straight.
    /// </summary>
    sealed class Hello : INetworkOp
    {
        readonly string _name;
        readonly Address _address;

        private bool Equals(Hello other)
        {
            return string.Equals(_name, other._name) && Equals(_address, other._address);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Hello && Equals((Hello)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ (_address != null ? _address.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(Hello left, Hello right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(Hello left, Hello right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="name">TBD</param>
        /// <param name="address">TBD</param>
        public Hello(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public Address Address
        {
            get { return _address; }
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class EnterBarrier : IServerOp, INetworkOp
    {
        readonly string _name;
        readonly TimeSpan? _timeout;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="name">TBD</param>
        /// <param name="timeout">TBD</param>
        public EnterBarrier(string name, TimeSpan? timeout)
        {
            _name = name;
            _timeout = timeout;
        }

        private bool Equals(EnterBarrier other)
        {
            return string.Equals(_name, other._name) && _timeout.Equals(other._timeout);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is EnterBarrier && Equals((EnterBarrier)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ _timeout.GetHashCode();
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(EnterBarrier left, EnterBarrier right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(EnterBarrier left, EnterBarrier right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public TimeSpan? Timeout
        {
            get { return _timeout; }
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class FailBarrier : IServerOp, INetworkOp
    {
        readonly string _name;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="name">TBD</param>
        public FailBarrier(string name)
        {
            _name = name;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        private bool Equals(FailBarrier other)
        {
            return string.Equals(_name, other._name);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is FailBarrier && Equals((FailBarrier)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(FailBarrier left, FailBarrier right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(FailBarrier left, FailBarrier right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class BarrierResult : IUnconfirmedClientOp, INetworkOp
    {
        readonly string _name;
        readonly bool _success;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="name">TBD</param>
        /// <param name="success">TBD</param>
        public BarrierResult(string name, bool success)
        {
            _name = name;
            _success = success;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public bool Success
        {
            get { return _success; }
        }

        bool Equals(BarrierResult other)
        {
            return string.Equals(_name, other._name) && _success.Equals(other._success);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is BarrierResult && Equals((BarrierResult)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ _success.GetHashCode();
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(BarrierResult left, BarrierResult right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(BarrierResult left, BarrierResult right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class Throttle : ICommandOp
    {
        readonly RoleName _node;
        readonly RoleName _target;
        readonly ThrottleTransportAdapter.Direction _direction;
        readonly float _rateMBit;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="node">TBD</param>
        /// <param name="target">TBD</param>
        /// <param name="direction">TBD</param>
        /// <param name="rateMBit">TBD</param>
        public Throttle(RoleName node, RoleName target, ThrottleTransportAdapter.Direction direction, float rateMBit)
        {
            _node = node;
            _target = target;
            _direction = direction;
            _rateMBit = rateMBit;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Node
        {
            get { return _node; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Target
        {
            get { return _target; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public ThrottleTransportAdapter.Direction Direction
        {
            get { return _direction; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public float RateMBit
        {
            get { return _rateMBit; }
        }

        bool Equals(Throttle other)
        {
            return Equals(_node, other._node) && Equals(_target, other._target) && Equals(_direction, other._direction) && _rateMBit.Equals(other._rateMBit);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Throttle && Equals((Throttle)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_node != null ? _node.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_target != null ? _target.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _direction.GetHashCode();
                hashCode = (hashCode * 397) ^ _rateMBit.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(Throttle left, Throttle right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(Throttle left, Throttle right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class ThrottleMsg : IConfirmedClientOp, INetworkOp
    {
        readonly Address _target;
        readonly ThrottleTransportAdapter.Direction _direction;
        readonly float _rateMBit;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="target">TBD</param>
        /// <param name="direction">TBD</param>
        /// <param name="rateMBit">TBD</param>
        public ThrottleMsg(Address target, ThrottleTransportAdapter.Direction direction, float rateMBit)
        {
            _target = target;
            _direction = direction;
            _rateMBit = rateMBit;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public Address Target
        {
            get { return _target; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public ThrottleTransportAdapter.Direction Direction
        {
            get { return _direction; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public float RateMBit
        {
            get { return _rateMBit; }
        }

        bool Equals(ThrottleMsg other)
        {
            return Equals(_target, other._target) && Equals(_direction, other._direction) && _rateMBit.Equals(other._rateMBit);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ThrottleMsg && Equals((ThrottleMsg)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_target != null ? _target.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _direction.GetHashCode();
                hashCode = (hashCode * 397) ^ _rateMBit.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(ThrottleMsg left, ThrottleMsg right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(ThrottleMsg left, ThrottleMsg right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class Disconnect : ICommandOp
    {
        readonly RoleName _node;
        readonly RoleName _target;
        readonly bool _abort;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="node">TBD</param>
        /// <param name="target">TBD</param>
        /// <param name="abort">TBD</param>
        public Disconnect(RoleName node, RoleName target, bool abort)
        {
            _node = node;
            _target = target;
            _abort = abort;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Node
        {
            get { return _node; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Target
        {
            get { return _target; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public bool Abort
        {
            get { return _abort; }
        }

        bool Equals(Disconnect other)
        {
            return Equals(_node, other._node) && Equals(_target, other._target) && _abort.Equals(other._abort);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Disconnect && Equals((Disconnect)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_node != null ? _node.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_target != null ? _target.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _abort.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(Disconnect left, Disconnect right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(Disconnect left, Disconnect right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class DisconnectMsg : IConfirmedClientOp, INetworkOp
    {
        readonly Address _target;
        readonly bool _abort;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="target">TBD</param>
        /// <param name="abort">TBD</param>
        public DisconnectMsg(Address target, bool abort)
        {
            _target = target;
            _abort = abort;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public Address Target
        {
            get { return _target; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public bool Abort
        {
            get { return _abort; }
        }

        bool Equals(DisconnectMsg other)
        {
            return Equals(_target, other._target) && _abort.Equals(other._abort);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is DisconnectMsg && Equals((DisconnectMsg)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_target != null ? _target.GetHashCode() : 0) * 397) ^ _abort.GetHashCode();
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(DisconnectMsg left, DisconnectMsg right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(DisconnectMsg left, DisconnectMsg right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class Terminate : ICommandOp
    {
        readonly RoleName _node;
        readonly Either<bool, int> _shutdownOrExit;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="node">TBD</param>
        /// <param name="shutdownOrExit">TBD</param>
        public Terminate(RoleName node, Either<bool, int> shutdownOrExit)
        {
            _node = node;
            _shutdownOrExit = shutdownOrExit;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Node
        {
            get { return _node; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public Either<bool, int> ShutdownOrExit
        {
            get { return _shutdownOrExit; }
        }

        bool Equals(Terminate other)
        {
            return Equals(_node, other._node) && Equals(_shutdownOrExit, other._shutdownOrExit);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Terminate && Equals((Terminate)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_node != null ? _node.GetHashCode() : 0) * 397) ^ (_shutdownOrExit != null ? _shutdownOrExit.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(Terminate left, Terminate right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(Terminate left, Terminate right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class TerminateMsg : IConfirmedClientOp, INetworkOp
    {
        readonly Either<bool, int> _shutdownOrExit;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="shutdownOrExit">TBD</param>
        public TerminateMsg(Either<bool, int> shutdownOrExit)
        {
            _shutdownOrExit = shutdownOrExit;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public Either<bool, int> ShutdownOrExit
        {
            get { return _shutdownOrExit; }
        }

        bool Equals(TerminateMsg other)
        {
            return Equals(_shutdownOrExit, other._shutdownOrExit);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is TerminateMsg && Equals((TerminateMsg)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return (_shutdownOrExit != null ? _shutdownOrExit.GetHashCode() : 0);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(TerminateMsg left, TerminateMsg right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(TerminateMsg left, TerminateMsg right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class GetAddress : IServerOp, INetworkOp
    {
        readonly RoleName _node;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="node">TBD</param>
        public GetAddress(RoleName node)
        {
            _node = node;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Node
        {
            get { return _node; }
        }

        bool Equals(GetAddress other)
        {
            return Equals(_node, other._node);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is GetAddress && Equals((GetAddress)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return (_node != null ? _node.GetHashCode() : 0);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(GetAddress left, GetAddress right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(GetAddress left, GetAddress right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class AddressReply : IUnconfirmedClientOp, INetworkOp
    {
        readonly RoleName _node;
        readonly Address _addr;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="node">TBD</param>
        /// <param name="addr">TBD</param>
        public AddressReply(RoleName node, Address addr)
        {
            _node = node;
            _addr = addr;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Node
        {
            get { return _node; }
        }

        /// <summary>
        /// TBD
        /// </summary>
        public Address Addr
        {
            get { return _addr; }
        }

        bool Equals(AddressReply other)
        {
            return Equals(_node, other._node) && Equals(_addr, other._addr);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is AddressReply && Equals((AddressReply)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_node != null ? _node.GetHashCode() : 0) * 397) ^ (_addr != null ? _addr.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(AddressReply left, AddressReply right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(AddressReply left, AddressReply right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    public class Done : IServerOp, IUnconfirmedClientOp, INetworkOp
    {
        private Done() { }
        private static readonly Done _instance = new Done();

        /// <summary>
        /// TBD
        /// </summary>
        public static Done Instance
        {
            get
            {
                return _instance;
            }
        }
    }

    /// <summary>
    /// TBD
    /// </summary>
    sealed class Remove : ICommandOp
    {
        readonly RoleName _node;

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="node">TBD</param>
        public Remove(RoleName node)
        {
            _node = node;
        }

        /// <summary>
        /// TBD
        /// </summary>
        public RoleName Node
        {
            get { return _node; }
        }

        bool Equals(Remove other)
        {
            return Equals(_node, other._node);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="obj">TBD</param>
        /// <returns>TBD</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Remove && Equals((Remove)obj);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <returns>TBD</returns>
        public override int GetHashCode()
        {
            return (_node != null ? _node.GetHashCode() : 0);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator ==(Remove left, Remove right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="left">TBD</param>
        /// <param name="right">TBD</param>
        /// <returns>TBD</returns>
        public static bool operator !=(Remove left, Remove right)
        {
            return !Equals(left, right);
        }
    }
}