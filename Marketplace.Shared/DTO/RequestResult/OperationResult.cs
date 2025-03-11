using Marketplace.Shared.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Shared.DTO.AuthResults
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserDTO User { get; set; }
        public static OperationResult Ok() => new OperationResult { Success = true };
        public static OperationResult Ok(string message) => new OperationResult { Success = true, Message = message};
        public static OperationResult Ok(string message, UserDTO user) => new OperationResult { Success = true, Message = message, User = user };
        public static OperationResult Fail(string message) => new OperationResult { Success = false, Message = message };
    }
}
