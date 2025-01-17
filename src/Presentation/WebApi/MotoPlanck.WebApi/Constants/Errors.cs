﻿using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.WebApi.Constants
{
    /// <summary>
    /// Contains the API errors.
    /// </summary>
    internal static class Errors
    {
        /// <summary>
        /// Gets the un-processable request error.
        /// </summary>
        internal static Error UnProcessableRequest => new(
            "API.UnProcessableRequest",
            "The server could not process the request.");

        /// <summary>
        /// Gets the server error error.
        /// </summary>
        internal static Error ServerError => new(
            "API.ServerError", 
            "The server encountered an unrecoverable error.");

    }
}
