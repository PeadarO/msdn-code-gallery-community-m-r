////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Gadgeteer.Interfaces
{
    using System;
    using Microsoft.SPOT;
    using Gadgeteer.Modules;
    using Microsoft.SPOT.Hardware;

    internal class NativeAnalogInput : Socket.SocketInterfaces.AnalogInput
    {
        private Microsoft.SPOT.Hardware.AnalogInput _port;
        private Cpu.AnalogChannel _channel;
        private Socket _socket;

        public NativeAnalogInput(Socket socket, Socket.Pin pin, Module module, Cpu.AnalogChannel channel)
        {
            if (channel == Cpu.AnalogChannel.ANALOG_NONE)
            {
                Socket.InvalidSocketException.ThrowIfOutOfRange(pin, Socket.Pin.Three, Socket.Pin.Five, "AnalogInput", module);

                // this is a mainboard error that should not happen (we already check for it in SocketInterfaces.RegisterSocket) but just in case...
                throw Socket.InvalidSocketException.FunctionalityException(socket, "AnalogInput");
            }

            _channel = channel;
            _socket = socket;
        }

        public override bool IsActive
        {
            get { return _port != null; }
            set
            {
                if ((_port != null) == value)
                    return;

                if (value)
                {
                    _port = new Microsoft.SPOT.Hardware.AnalogInput(_channel, _socket.AnalogInputScale, _socket.AnalogInputOffset, _socket.AnalogInputPrecisionInBits);
                }
                else
                {
                    _port.Dispose();
                    _port = null;
                }
            }
        }

        public override double ReadVoltage()
        {
            IsActive = true;

            return _port.Read();
        }

        public override void Dispose()
        {
            _port.Dispose();
            _port = null;
        }
    }

    /// <summary>
    /// Represents analog input on a single pin.
    /// </summary>
    public class AnalogInput : IDisposable
    {
        internal readonly Socket.SocketInterfaces.AnalogInput Interface;

        // Note: A constructor summary is auto-generated by the doc builder.
        /// <summary></summary>
        /// <remarks>This automatically checks that the socket supports Type A, and reserves the pin used.
        /// An exception will be thrown if there is a problem with these checks.</remarks>
        /// <param name="socket">The socket.</param>
        /// <param name="pin">The analog input pin to use.</param>
        /// <param name="module">The module using the socket, which can be null if unspecified.</param>
        public AnalogInput(Socket socket, Socket.Pin pin, Module module)
        {
            socket.EnsureTypeIsSupported('A', module);
            socket.ReservePin(pin, module);

            Cpu.AnalogChannel channel = Cpu.AnalogChannel.ANALOG_NONE;
            switch (pin)
            {
                case Socket.Pin.Three:
                    channel = socket.AnalogInput3;
                    break;

                case Socket.Pin.Four:
                    channel = socket.AnalogInput4;
                    break;

                case Socket.Pin.Five:
                    channel = socket.AnalogInput5;
                    break;
            }

            // native implementation is preferred to an indirected one
            if (channel == Cpu.AnalogChannel.ANALOG_NONE && socket.AnalogInputIndirector != null)
                Interface = socket.AnalogInputIndirector(socket, pin, module);

            else
                Interface = new NativeAnalogInput(socket, pin, module, channel);
        }

        /// <summary>
        /// Gets or sets the active state of the analog input.
        /// </summary>
        /// <returns>A Boolean value, true if the analogue input is active, otherwise false.</returns>
        public bool Active
        {
            get { return Interface.IsActive; }
            set { Interface.IsActive = value; }
        }

        /// <summary>
        /// Reads the current analog input value as a voltage between 0 and 3.3V.
        /// </summary>
        /// <returns>The current analog value in volts.</returns>
        public double ReadVoltage()
        {
            return Interface.ReadVoltage();
        }

        /// <summary>
        /// Reads the current analog input value as a proportion from 0.0 to 1.0 of the maximum value (3.3V).
        /// </summary>
        /// <returns>The analog input value from 0.0-1.0</returns>
        public double ReadProportion()
        {
            return Interface.ReadProportion();
        }

        /// <summary>
        /// Returns the <see cref="Socket.SocketInterfaces.AnalogInput" /> for an <see cref="AnalogInput" /> interface.
        /// </summary>
        /// <param name="this">An instance of <see cref="AnalogInput" />.</param>
        /// <returns>The <see cref="Socket.SocketInterfaces.AnalogInput" /> for <paramref name="this"/>.</returns>
        public static explicit operator Socket.SocketInterfaces.AnalogInput(AnalogInput @this)
        {
            return @this.Interface;
        }

        /// <summary>
        /// Releases all resources used by the interface.
        /// </summary>
        public void Dispose()
        {
            Interface.Dispose();
        }
    }
}