using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IArea
{
    public interface IAreaCommand
    {
        void CreateArea(Area area);

        void UpdateArea(Area area);
    }
}
