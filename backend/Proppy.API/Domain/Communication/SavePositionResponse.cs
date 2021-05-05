using Proppy.API.Domain.Models;

namespace Proppy.API.Domain.Communication
{
    public class SavePositionResponse: BaseResponse
    {
        public Position Position {get; private set;}

        private SavePositionResponse(bool success, string message, Position position): base(success, message)
        {
            Position = position;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="position">Saved position.</param>
        /// <returns>Response.</returns>
        public SavePositionResponse(Position position): this(true, string.Empty, position)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SavePositionResponse(string message): this(false, message, null)
        { }
    }
}