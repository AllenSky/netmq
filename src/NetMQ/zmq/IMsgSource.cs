namespace NetMQ.zmq
{
    /// <summary>
    /// Classes that implement IMsgSource are able to fetch a message, with the method: PullMsg.
    /// </summary>
    internal interface IMsgSource
    {
        /// <summary>
        /// Fetch a message.
        /// If successful - returns true and writes the message instance to the msg argument.
        /// If not successful - return false and write null to the msg argument.
        /// </summary>
        /// <returns>true if successful - and writes the message to the msg argument</returns>
        bool PullMsg(ref Msg msg);
    }
}
