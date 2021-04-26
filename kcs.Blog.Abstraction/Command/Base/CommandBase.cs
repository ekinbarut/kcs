using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.Command
{
    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
    }
}
