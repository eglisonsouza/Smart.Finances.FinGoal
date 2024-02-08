using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Finances.FinGoal.Core.Exceptions
{
    public class StatusNeedsToBeInProgressException() : Exception("Status needs to be in progress.")
    {
    }
}
